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
        private const double liquidToGasRatio_MIN = 0.1;
        private const double liquidToGasRatio_MAX = 5.0;

        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26 };
        //        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        public List<bool> ApproachInRange { get; private set; }
        public List<bool> ApproachOutOfRange { get; private set; }
        private double CalculatedLiquidToGasRatio { get; set; }
        private double CalculatedLiquidToGasRatio_MIN { get; set; }
        private MerkelCalculationData MerkelCalculationData { get; set; }

        public DemandCurveCalculationLibrary(bool isInternationalSystemOfUnits_IS)
        {
            MerkelCalculationData = new MerkelCalculationData(isInternationalSystemOfUnits_IS);
        }

        public bool Calculate(DemandCurveCalculationData data)
        {
            ErrorMessage = string.Empty;

            data.DemandCurveData.TargetApproach = 0;

            //ApproachXValues = new List<double>();
            ApproachInRange = new List<bool>();
            ApproachOutOfRange = new List<bool>();
            CalculatedLiquidToGasRatio_MIN = 999.0;

            data.DataTable.Clear();

            InitializeApproachList(data);

            for (int i = 0; i < InitialApproachXValues.Length; i++)
            {
                if (ApproachInRange[i])
                {
                    DataColumn dataColumn = new DataColumn();
                    dataColumn.ColumnName = string.Format("L/G-Approach-{0}", InitialApproachXValues[i]);
                    dataColumn.DataType = Type.GetType("System.Double");
                    data.DataTable.Columns.Add(dataColumn);
                    dataColumn = new DataColumn();
                    dataColumn.ColumnName = string.Format("kaVL-Approach-{0}", InitialApproachXValues[i]);
                    dataColumn.DataType = Type.GetType("System.Double");
                    data.DataTable.Columns.Add(dataColumn);
                }
            }

            CalculateApproach(data);
            CalculateApproaches(data);
            GenerateCharacterticsLine(data);
            GenerateLGLine(data);
            GenerateKaVLLine(data);
            GenerateUserApproach(data);

            File.WriteAllText("demand.txt", stringBuilder.ToString());

            return true;
        }

        void InitializeApproachList(DemandCurveCalculationData data)
        {
            MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(data);

            foreach (double approachValue in InitialApproachXValues)
            {
                MerkelCalculationData.Approach = approachValue;

                if (CalculateMerkel(MerkelCalculationData))
                {
                    bool approachInRange = (MerkelCalculationData.KaV_L > 0.1) && (MerkelCalculationData.KaV_L < 5.0);
                    ApproachInRange.Add(approachInRange);
                    ApproachOutOfRange.Add(!approachInRange);
                }
            }
        }

        private void MerkelConvertValues(DemandCurveCalculationData data)
        {
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
            MerkelCalculationData.IsElevation = data.DemandCurveData.IsElevation;
            MerkelCalculationData.WetBulbTemperature = data.DemandCurveData.WetBulbTemperature;
            MerkelCalculationData.Elevation = data.DemandCurveData.Elevation;
            MerkelCalculationData.WetBulbTemperature = data.DemandCurveData.WetBulbTemperature;
            MerkelCalculationData.BarometricPressure = data.DemandCurveData.BarometricPressure;
            ConvertMerkelValues(MerkelCalculationData);

            MerkelCalculationData.Range = data.DemandCurveData.Range;
            if (data.IsInternationalSystemOfUnits_SI)
            {
                MerkelCalculationData.Range *= 1.8;
            }
            MerkelCalculationData.LiquidToGasRatio = 0.1;
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = false;
        }

        void CalculateApproach(DemandCurveCalculationData data)
        {
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
            MerkelConvertValues(data);
            MerkelCalculationData.LiquidToGasRatio = data.DemandCurveData.LiquidToGasRatio;

            if ((data.DemandCurveData.LiquidToGasRatio >= 0.1) && (data.DemandCurveData.LiquidToGasRatio <= 5.0))
            {
                if (data.DemandCurveData.CurveC1 != 0.0 && data.DemandCurveData.CurveC2 != 0.0)
                {
                    data.DemandCurveData.KaV_L = Math.Round((data.DemandCurveData.CurveC1 * Math.Pow(data.DemandCurveData.LiquidToGasRatio, data.DemandCurveData.CurveC2)), 5, MidpointRounding.ToEven);
                    MerkelCalculationData.KaV_L = data.DemandCurveData.KaV_L;
                    data.DemandCurveData.TargetApproach = GetExactApproach(MerkelCalculationData);

                    if ((data.DemandCurveData.KaV_L < .01) || (data.DemandCurveData.KaV_L > 5.0))
                    {
                        data.DemandCurveData.KaV_L = 0.0;
                        data.DemandCurveData.TargetApproach = 0;
                    }

                    if (data.DemandCurveData.TargetApproach >= 100)
                    {
                        data.DemandCurveData.TargetApproach = 0;
                    }

                    if (data.IsInternationalSystemOfUnits_SI)
                    {
                        data.DemandCurveData.TargetApproach *= 5.0 / 9.0;
                    }
                }
            }
        }

        void CalculateApproaches(DemandCurveCalculationData data)
        {
            stringBuilder = new StringBuilder();

            MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(data);

            for (double liquidToGasRatio = liquidToGasRatio_MIN; liquidToGasRatio < liquidToGasRatio_MAX; liquidToGasRatio += .05)
            {
                stringBuilder.AppendFormat("\ndLG {0} \n\n", liquidToGasRatio.ToString("F6"));

                for (int i = 0; i < InitialApproachXValues.Length; i++)
                {
                    ApproachOutOfRange[i] = GenerateApproach(ApproachInRange[i], ApproachOutOfRange[i], data, liquidToGasRatio, InitialApproachXValues[i], false);
                    stringBuilder.AppendFormat("\niIndex {0}  getapp(iIndex) {1} App[iIndex] {2} ", i, 1, ApproachOutOfRange[i] ? "0" : InitialApproachXValues[i].ToString("F0"));
                }
                stringBuilder.AppendLine("\niIndex 18  getapp(iIndex) 1 App[iIndex] 0 \n");
                stringBuilder.AppendLine("iIndex 19  getapp(iIndex) 1 App[iIndex] 0 ");
            }
        }

        void GenerateUserApproach(DemandCurveCalculationData data)
        {
            if (data.DemandCurveData.UserApproach != 0)
            {
                data.IsUserApproach = true;
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "User-X";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "User-Y";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);

                MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
                MerkelConvertValues(data);

                for (double liquidToGasRatio = liquidToGasRatio_MIN; liquidToGasRatio < liquidToGasRatio_MAX; liquidToGasRatio += .05)
                {
                    GenerateApproach(true, false, data, liquidToGasRatio, data.DemandCurveData.UserApproach, true);
                }
            }
        }


        void GenerateCharacterticsLine(DemandCurveCalculationData data)
        {
            //---------------------------------------------------------------------
            // Draw Fill Line
            //---------------------------------------------------------------------
            if ((data.DemandCurveData.CurveC1 != 0) && (data.DemandCurveData.CurveC2 != 0))
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = string.Format("Charactertics-X");
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);

                dataColumn = new DataColumn();
                dataColumn.ColumnName = "Charactertics-Y";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);

                for (double lg = data.DemandCurveData.CurveMinimum; lg <= data.DemandCurveData.CurveMaximum; lg += .05)
                {
                    if ((lg >= data.DemandCurveData.CurveMinimum) && (lg <= data.DemandCurveData.CurveMaximum))
                    {
                        double k = data.DemandCurveData.CurveC1 * Math.Pow(lg, data.DemandCurveData.CurveC2);

                        if ((k >= CalculatedLiquidToGasRatio_MIN) && (k <= liquidToGasRatio_MAX))
                        {
                            DataRow dataRow = data.DataTable.NewRow();
                            dataRow["Charactertics-X"] = lg;
                            dataRow["Charactertics-Y"] = k;
                            data.DataTable.Rows.Add(dataRow);
                            data.IsCoef = true;
                            stringBuilder.AppendFormat("\nkaVL-Charactertics {0} L/G-Charactertics {1} \n", lg.ToString("F6"), k.ToString("F6"));
                            //m_wndGraph.GetSeries(INDEX_Charactertics).AddXY(waterAirRatio, dblK, NULL, 00099FF);
                        }
                    }
                }
            }
        }

        void GenerateLGLine(DemandCurveCalculationData data)
        {
            //---------------------------------------------------------------------
            // Draw L/G line
            //---------------------------------------------------------------------
            if ((data.DemandCurveData.LiquidToGasRatio > liquidToGasRatio_MIN) && (data.DemandCurveData.LiquidToGasRatio <= liquidToGasRatio_MAX))
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "L/G-X";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "L/G-Y";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);

                DataRow dataRow = data.DataTable.NewRow();
                 dataRow["L/G-X"] = data.DemandCurveData.LiquidToGasRatio;
                dataRow["L/G-Y"] = CalculatedLiquidToGasRatio_MIN;
                stringBuilder.AppendFormat("\nL/G-X {0} L/G-Y {1} \n", data.DemandCurveData.LiquidToGasRatio.ToString("F6"), CalculatedLiquidToGasRatio_MIN.ToString("F6"));
                data.DataTable.Rows.Add(dataRow);

                dataRow = data.DataTable.NewRow();
                dataRow["L/G-X"] = data.DemandCurveData.LiquidToGasRatio;
                dataRow["L/G-Y"] = liquidToGasRatio_MAX;
                stringBuilder.AppendFormat("\nL/G-X {0} L/G-Y {1} \n", data.DemandCurveData.LiquidToGasRatio.ToString("F6"), liquidToGasRatio_MAX.ToString("F6"));
                data.DataTable.Rows.Add(dataRow);
                data.IsLiquidToGasRatio = true;
            }
        }

        void GenerateKaVLLine(DemandCurveCalculationData data)
        {
            //---------------------------------------------------------------------
            // Draw KaV/L line
            //---------------------------------------------------------------------
            if ((data.DemandCurveData.KaV_L > 0.1) && (data.DemandCurveData.KaV_L <= liquidToGasRatio_MAX))
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "Line-X";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "Line-Y";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);

                DataRow dataRow = data.DataTable.NewRow();
                dataRow["Line-X"] = liquidToGasRatio_MIN;
                dataRow["Line-Y"] = data.DemandCurveData.KaV_L;
                stringBuilder.AppendFormat("\nkaVL-Line {0} L/G-Line {1} \n", liquidToGasRatio_MIN.ToString("F6"), data.DemandCurveData.KaV_L.ToString("F6"));
                data.DataTable.Rows.Add(dataRow);
 
                dataRow = data.DataTable.NewRow();
                dataRow["Line-X"] = liquidToGasRatio_MAX;
                dataRow["Line-Y"] = data.DemandCurveData.KaV_L;
                stringBuilder.AppendFormat("\nkaVL-Line {0} L/G-Line {1} \n", liquidToGasRatio_MAX.ToString("F6"), data.DemandCurveData.KaV_L.ToString("F6"));
                data.DataTable.Rows.Add(dataRow);
                data.IsKaV_L = true;

                //data.DataTable.Rows[0][string.Format("kaVL-{0}", INDEX_KAVL)] = liquidToGasRatio_MAX;
                //data.DataTable.Rows[0][columnName] = waterAirRatio_MAX;
                //data.DataTable.Rows[1][columnName] = liquidToGasRatio_MAX;
            }
        }

        private bool GenerateApproach(bool inRange, bool outOfRange, DemandCurveCalculationData data, double liquidToGasRatio, double approachValue, bool isUserApproach)
        {
            const double kavl_MIN = 0.01;
            const double kavl_MAX = 5.0;

            if (inRange && !outOfRange)
            {
                string approachXValue = ((int)approachValue).ToString();

                MerkelCalculationData.LiquidToGasRatio = liquidToGasRatio;
                MerkelCalculationData.Approach = approachValue;

                if (data.IsInternationalSystemOfUnits_SI)
                {
                    MerkelCalculationData.Approach *= 1.8;
                }

                if (liquidToGasRatio > 1.3 && liquidToGasRatio < 1.4)
                {
                    stringBuilder.AppendLine();
                }

                if (CalculateMerkel(MerkelCalculationData))
                {
                    stringBuilder.AppendFormat("\n m_dblCurveWBT {0}, m_dblCurveRange {1}, App[iIndex] {2}, dLG {3}, m_dblAltitude {4} ", MerkelCalculationData.WetBulbTemperature.ToString("F6"), MerkelCalculationData.Range.ToString("F6"), MerkelCalculationData.Approach.ToString("F6"), MerkelCalculationData.LiquidToGasRatio.ToString("F6"), MerkelCalculationData.Elevation.ToString("F6"));
                    stringBuilder.AppendFormat("\n kavl {0} minVal {1} maxVal {2} dLG {3} App[iIndex] {4}", MerkelCalculationData.KaV_L.ToString("F6"), kavl_MIN.ToString("F6"), kavl_MAX.ToString("F6"), liquidToGasRatio.ToString("F6"), approachValue.ToString("F6"));

                    // ddp
                    if ((MerkelCalculationData.KaV_L < kavl_MIN) || (MerkelCalculationData.KaV_L >= kavl_MAX))
                    {
                        double dInterp;
                        for (dInterp = liquidToGasRatio; ((MerkelCalculationData.KaV_L < kavl_MIN) || (MerkelCalculationData.KaV_L >= kavl_MAX)) && (dInterp > .1); dInterp -= 0.0002)
                        {
                            stringBuilder.AppendFormat("\n dInterp {0} kavl {1}", dInterp.ToString("F6"), MerkelCalculationData.KaV_L.ToString("F6"));
                            MerkelCalculationData.Approach = approachValue;
                            if (data.IsInternationalSystemOfUnits_SI)
                            {
                                MerkelCalculationData.Approach *= 1.8;
                            }
                            MerkelCalculationData.LiquidToGasRatio = dInterp;
                            if (!CalculateMerkel(MerkelCalculationData))
                            {
                                break;
                            }
                        }
                        CalculatedLiquidToGasRatio = dInterp;
                        outOfRange = true;  //DDP This is the last point
                    }
                    else
                    {
                        CalculatedLiquidToGasRatio = liquidToGasRatio;
                    }

                    stringBuilder.AppendFormat("\n kavl {0} dLG {1} App[iIndex] {2}", MerkelCalculationData.KaV_L.ToString("F6"), liquidToGasRatio.ToString("F6"), outOfRange ? "0.000000" : approachValue.ToString("F6"));

                    if ((CalculatedLiquidToGasRatio_MIN > MerkelCalculationData.KaV_L) && (MerkelCalculationData.KaV_L > .1))
                    {
                        CalculatedLiquidToGasRatio_MIN = MerkelCalculationData.KaV_L;
                    }
                    stringBuilder.AppendFormat("\n sDLG {0} ", CalculatedLiquidToGasRatio.ToString("F6"));
                    stringBuilder.AppendFormat("min4Lg {0} ", CalculatedLiquidToGasRatio_MIN.ToString("F6"));

                    if ((MerkelCalculationData.KaV_L <= 10.0) && (MerkelCalculationData.KaV_L >= .1))
                    {
                        stringBuilder.AppendFormat("\n m_wndGraph {0} KaV_L {1}", CalculatedLiquidToGasRatio.ToString("F6"), MerkelCalculationData.KaV_L.ToString("F6"));
                        DataRow dataRow = data.DataTable.NewRow();
                        string x = (isUserApproach) ? "User-X" : string.Format("L/G-Approach-{0}", approachXValue);
                        string y = (isUserApproach) ? "User-Y" : string.Format("kaVL-Approach-{0}", approachXValue);
                        dataRow[x] = CalculatedLiquidToGasRatio;
                        dataRow[y] = MerkelCalculationData.KaV_L;
                        data.DataTable.Rows.Add(dataRow);
                    }
                    else
                    {
                        stringBuilder.AppendFormat("no m_wndGraph");
                    }
                }
            }
            stringBuilder.AppendLine();
            return outOfRange;
        }

        double GetExactApproach(MerkelCalculationData MerkelCalculationData)
        {
            double approach;
            double delta = 1.0;

            double givenKaV_L = MerkelCalculationData.KaV_L;

            //---------------------------------------------------------------------
            // Find approach within .001
            //---------------------------------------------------------------------
            for (approach = 0.0; approach < 100.0; approach += delta)
            {
                MerkelCalculationData.Approach = approach;

                CalculateMerkel(MerkelCalculationData);
                if (delta > 0.9)
                {
                    if (MerkelCalculationData.KaV_L < givenKaV_L)
                    {
                        delta = -0.001;
                    }
                    //else
                    //{
                    //    break; // calculation error?
                    //}
                }
                else
                {
                    if (MerkelCalculationData.KaV_L >= givenKaV_L)
                    {
                        approach = Math.Round(approach, 3, MidpointRounding.ToEven);
                        break;
                    }
                }
            }
            return approach;
        }
    }
}