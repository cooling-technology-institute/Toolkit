// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CalculationLibrary
{
    public class DemandCurveCalculationLibrary : CalculationLibrary
    {
        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26 };
//        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        public List<bool> ApproachInRange { get; private set; }
        public List<bool> ApproachOutOfRange { get; private set; }

        public bool DemandCurveCalculation(DemandCurveCalculationData data)
        {
            ErrorMessage = string.Empty;

            data.DemandCurveData.TargetApproach = 0;
            data.DemandCurveData.UserApproach = 0;

            //ApproachXValues = new List<double>();
            ApproachInRange = new List<bool>();
            ApproachOutOfRange = new List<bool>();

            data.DataTable.Clear();

            InitializeApproachList(data);

            for (int i = 0; i < InitialApproachXValues.Length; i++)
            {
                if(ApproachInRange[i])
                {
                    DataColumn dataColumn = new DataColumn();
                    dataColumn.ColumnName = string.Format("L/G-{0}", InitialApproachXValues[i]);
                    dataColumn.DataType = Type.GetType("System.Double");
                    data.DataTable.Columns.Add(dataColumn);
                    dataColumn = new DataColumn();
                    dataColumn.ColumnName = string.Format("kaVL-{0}", InitialApproachXValues[i]);
                    dataColumn.DataType = Type.GetType("System.Double");
                    data.DataTable.Columns.Add(dataColumn);
                }
            }

            if ((data.DemandCurveData.CurveC1 != 0) && (data.DemandCurveData.CurveC2 != 0))
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = string.Format("L/G-COEF");
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "kaVL-COEF";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);
            }

            CalculateApproach(data);
            CalculateApproaches(data);

            return true;
        }

        void InitializeApproachList(DemandCurveCalculationData data)
        {
            MerkelCalculationData merkelCalculationData = new MerkelCalculationData(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(merkelCalculationData, data);

            foreach (double approachValue in InitialApproachXValues)
            {
                merkelCalculationData.Approach = approachValue;

                if(CalculateMerkel(merkelCalculationData))
                {
                    bool approachInRange = (merkelCalculationData.KaV_L > 0.1) && (merkelCalculationData.KaV_L < 5.0);
                    ApproachInRange.Add(approachInRange);
                    ApproachOutOfRange.Add(!approachInRange);
                }
            }
        }

        private void MerkelConvertValues(MerkelCalculationData merkelCalculationData, DemandCurveCalculationData data)
        {
            merkelCalculationData.IsElevation = data.DemandCurveData.IsElevation;
            merkelCalculationData.WetBulbTemperature = data.DemandCurveData.WetBulbTemperature;
            merkelCalculationData.Elevation = data.DemandCurveData.Elevation;
            merkelCalculationData.WetBulbTemperature = data.DemandCurveData.WetBulbTemperature;
            merkelCalculationData.BarometricPressure = data.DemandCurveData.BarometricPressure;
            ConvertMerkelValues(merkelCalculationData);

            merkelCalculationData.Range = data.DemandCurveData.Range;
            if (data.IsInternationalSystemOfUnits_SI)
            {
                merkelCalculationData.Range *= 1.8;
            }
            merkelCalculationData.LiquidToGasRatio = 0.1;
            merkelCalculationData.IsInternationalSystemOfUnits_SI = false;
        }

        void CalculateApproach(DemandCurveCalculationData data)
        {
            MerkelCalculationData merkelCalculationData = new MerkelCalculationData(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(merkelCalculationData, data);

            if ((data.DemandCurveData.LiquidToGasRatio >= 0.1) && (data.DemandCurveData.LiquidToGasRatio <= 5.0))
            {
                if (data.DemandCurveData.CurveC1 != 0.0 && data.DemandCurveData.CurveC2 != 0.0)
                {
                    data.DemandCurveData.KaV_L = Math.Round((data.DemandCurveData.CurveC1 * Math.Pow(data.DemandCurveData.LiquidToGasRatio, data.DemandCurveData.CurveC2)), 5, MidpointRounding.ToEven);
                    data.DemandCurveData.Approach = GetExactApproach(merkelCalculationData);

                    if ((data.DemandCurveData.KaV_L < .01) || (data.DemandCurveData.KaV_L > 5.0))
                    {
                        data.DemandCurveData.KaV_L = 0.0;
                        data.DemandCurveData.Approach = 0;
                    }

                    if (data.DemandCurveData.TargetApproach >= 100)
                    {
                        data.DemandCurveData.Approach = 0;
                    }

                    if (!data.IsInternationalSystemOfUnits_SI)
                    {
                        data.DemandCurveData.Approach *= 5.0 / 9.0;
                    }
                }
            }
        }

        void CalculateApproaches(DemandCurveCalculationData data)
        {
            const double liquidToGasRatio_MIN = 0.1;
            const double liquidToGasRatio_MAX = 5.0;
            const double kavl_MIN = 0.01;
            const double kavl_MAX = 5.0;
            double calculatedLiquidToGasRatio = 0.0;
            double calculatedLiquidToGasRatio_MIN = 999.0;

            stringBuilder = new StringBuilder();

            MerkelCalculationData merkelCalculationData = new MerkelCalculationData(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(merkelCalculationData, data);

            for (double liquidToGasRatio = liquidToGasRatio_MIN; liquidToGasRatio < liquidToGasRatio_MAX; liquidToGasRatio += .05)
            {
                stringBuilder.AppendFormat("\ndLG {0} \n\n", liquidToGasRatio.ToString("F6"));
                DataRow dataRow = data.DataTable.NewRow();

                for(int i = 0; i < InitialApproachXValues.Length; i++)
                {
                    stringBuilder.AppendFormat("\niIndex {0}  getapp(iIndex) {1} App[iIndex] {2} ", i, 1, ApproachOutOfRange[i] ? "0" : InitialApproachXValues[i].ToString("F0"));
                    string approachXValue = ((int)InitialApproachXValues[i]).ToString();

                    if (ApproachInRange[i] && !ApproachOutOfRange[i])
                    {
                        merkelCalculationData.LiquidToGasRatio = liquidToGasRatio;
                        merkelCalculationData.Approach = InitialApproachXValues[i];

                        if (data.IsInternationalSystemOfUnits_SI)
                        {
                            merkelCalculationData.Approach *= 1.8;
                        }

                        if (liquidToGasRatio > 1.3 && liquidToGasRatio < 1.4)
                        {
                            stringBuilder.AppendLine();
                        }

                        if (CalculateMerkel(merkelCalculationData))
                        {
                            stringBuilder.AppendFormat("\n m_dblCurveWBT {0}, m_dblCurveRange {1}, App[iIndex] {2}, dLG {3}, m_dblAltitude {4} ", merkelCalculationData.WetBulbTemperature.ToString("F6"), merkelCalculationData.Range.ToString("F6"), merkelCalculationData.Approach.ToString("F6"), merkelCalculationData.LiquidToGasRatio.ToString("F6"), merkelCalculationData.Elevation.ToString("F6"));
                            stringBuilder.AppendFormat("\n kavl {0} minVal {1} maxVal {2} dLG {3} App[iIndex] {4}", merkelCalculationData.KaV_L.ToString("F6"), kavl_MIN.ToString("F6"), kavl_MAX.ToString("F6"), liquidToGasRatio.ToString("F6"), InitialApproachXValues[i].ToString("F6"));

                            // ddp
                            if ((merkelCalculationData.KaV_L < kavl_MIN) || (merkelCalculationData.KaV_L >= kavl_MAX))
                            {
                                double dInterp;
                                for (dInterp = liquidToGasRatio; ((merkelCalculationData.KaV_L < kavl_MIN) || (merkelCalculationData.KaV_L >= kavl_MAX)) && (dInterp > .1); dInterp -= 0.0002)
                                {
                                    stringBuilder.AppendFormat("\n dInterp {0} kavl {1}", dInterp.ToString("F6"), merkelCalculationData.KaV_L.ToString("F6"));
                                    merkelCalculationData.Approach = InitialApproachXValues[i];
                                    if (data.IsInternationalSystemOfUnits_SI)
                                    {
                                        merkelCalculationData.Approach *= 1.8;
                                    }
                                    merkelCalculationData.LiquidToGasRatio = dInterp;
                                    if(!CalculateMerkel(merkelCalculationData))
                                    {
                                        break;
                                    }
                                }
                                calculatedLiquidToGasRatio = dInterp;
                                ApproachOutOfRange[i] = true;  //DDP This is the last point
                            }
                            else
                            {
                                calculatedLiquidToGasRatio = liquidToGasRatio;
                            }

                            stringBuilder.AppendFormat("\n kavl {0} dLG {1} App[iIndex] {2}", merkelCalculationData.KaV_L.ToString("F6"), liquidToGasRatio.ToString("F6"), ApproachOutOfRange[i] ? "0.000000" : InitialApproachXValues[i].ToString("F6"));

                            if ((calculatedLiquidToGasRatio_MIN > merkelCalculationData.KaV_L) && (merkelCalculationData.KaV_L > .1))
                            {
                                calculatedLiquidToGasRatio_MIN = merkelCalculationData.KaV_L;
                            }
                            stringBuilder.AppendFormat("\n sDLG {0} ", calculatedLiquidToGasRatio.ToString("F6"));
                            stringBuilder.AppendFormat("min4Lg {0} ", calculatedLiquidToGasRatio_MIN.ToString("F6"));

                            if ((merkelCalculationData.KaV_L <= 10.0) && (merkelCalculationData.KaV_L >= .1))
                            {
                                stringBuilder.AppendFormat("\n index {2} m_wndGraph {0} {1}", calculatedLiquidToGasRatio.ToString("F6"), merkelCalculationData.KaV_L.ToString("F6"), i);
                                dataRow[string.Format("L/G-{0}", approachXValue)] = calculatedLiquidToGasRatio;
                                dataRow[string.Format("kaVL-{0}", approachXValue)] = merkelCalculationData.KaV_L;
                            }
                            else
                            {
                                stringBuilder.AppendFormat("no m_wndGraph");
                            }
                        }
                    }
                    stringBuilder.AppendLine();
                }
                stringBuilder.AppendLine("\niIndex 18  getapp(iIndex) 1 App[iIndex] 0 \n");
                stringBuilder.AppendLine("iIndex 19  getapp(iIndex) 1 App[iIndex] 0 ");
                data.DataTable.Rows.Add(dataRow);
            }

            ////---------------------------------------------------------------------
            //// Draw Fill Line
            ////---------------------------------------------------------------------
            //if ((data.CurveC1 != 0) && (data.CurveC2 != 0))//&& coef)
            //{
            //    for (double waterAirRatio = data.CurveMinimum; waterAirRatio <= data.CurveMaximum; waterAirRatio += .05)
            //    {
            //        DataRow dataRow = data.DataTable.NewRow();
            //        if ((waterAirRatio >= data.CurveMinimum) && (waterAirRatio <= data.CurveMaximum))
            //        {
            //            double dblK = data.CurveC1 * Math.Pow(waterAirRatio, data.CurveC2);

            //            if ((dblK >= calculatedLiquidToGasRatio_MIN) && (dblK <= waterAirRatio_MAX))
            //            {
            //                dataRow["kaVL-COEF"] = kaVL;
            //                dataRow["L/G-COEF"] = calculatedLiquidToGasRatio;
            //                //m_wndGraph.GetSeries(INDEX_COEF).AddXY(waterAirRatio, dblK, NULL, 00099FF);
            //            }
            //        }
            //        data.DataTable.Rows.Add(dataRow);
            //    }
            //}

            //////---------------------------------------------------------------------
            ////// Draw L/G line
            //////---------------------------------------------------------------------
            //if (data.LiquidToGasRatio > waterAirRatio_MIN && data.LiquidToGasRatio <= waterAirRatio_MAX)// && Lg)
            //{
            //    DataColumn dataColumn = new DataColumn();
            //    dataColumn.ColumnName = "L/G-X";
            //    dataColumn.DataType = Type.GetType("System.Double");
            //    data.DataTable.Columns.Add(dataColumn);
            //    dataColumn = new DataColumn();
            //    dataColumn.ColumnName = "L/G-Y";
            //    dataColumn.DataType = Type.GetType("System.Double");
            //    data.DataTable.Columns.Add(dataColumn);

            //    DataRow dataRow = data.DataTable.NewRow();
            //    dataRow["L/G-Y"] = data.LiquidToGasRatio;
            //    dataRow["L/G-X"] = calculatedLiquidToGasRatio_MIN;
            //    data.DataTable.Rows.Add(dataRow);

            //    dataRow = data.DataTable.NewRow();
            //    dataRow["L/G-Y"] = data.LiquidToGasRatio;
            //    dataRow["L/G-X"] = waterAirRatio_MAX;
            //    data.DataTable.Rows.Add(dataRow);
            //}

            //////---------------------------------------------------------------------
            ////// Draw KaV/L line
            //////---------------------------------------------------------------------
            //if ((data.KaV_L > 0.1) && (data.KaV_L <= waterAirRatio_MAX)) // && m_bShowKaVLLine)
            //{
            //    DataRow dataRow = data.DataTable.NewRow();
            //    dataRow[string.Format("kaVL-{0}", INDEX_KAVL)] = waterAirRatio_MIN;
            //    dataRow[string.Format("L/G-{0}", INDEX_KAVL)] = data.KaV_L;
            //    data.DataTable.Rows.Add(dataRow);
            //    dataRow = data.DataTable.NewRow();
            //    dataRow[string.Format("kaVL-{0}", INDEX_KAVL)] = waterAirRatio_MAX;
            //    dataRow[string.Format("L/G-{0}", INDEX_KAVL)] = data.KaV_L;
            //    data.DataTable.Rows.Add(dataRow);
            //      data.DataTable.Rows[0][string.Format("kaVL-{0}", INDEX_KAVL)] = liquidToGasRatio_MAX;
            //    data.DataTable.Rows[0][columnName] = waterAirRatio_MAX;
            //    data.DataTable.Rows[1][columnName] = waterAirRatio_MAX;
            //}

            File.WriteAllText("demand.txt", stringBuilder.ToString());
        }

        double GetExactApproach(MerkelCalculationData merkelCalculationData)
        {
            double approach;
            double delta = 1.0;

            double givenKaV_L = merkelCalculationData.KaV_L;

            //---------------------------------------------------------------------
            // Find approach within .001
            //---------------------------------------------------------------------
            for (approach = 0.0; approach < 100.0; approach += delta)
            {
                merkelCalculationData.Approach = approach;

                if(CalculateMerkel(merkelCalculationData))
                {
                    if (delta > 0.9)
                    {
                        if (merkelCalculationData.KaV_L < givenKaV_L)
                        {
                            delta = -0.001;
                        }
                        else
                        {
                            break; // calculation error?
                        }
                    }
                    else
                    {
                        if (merkelCalculationData.KaV_L >= givenKaV_L)
                        {
                            approach = Math.Round(approach, 3, MidpointRounding.ToEven);
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return approach;
        }
    }
}