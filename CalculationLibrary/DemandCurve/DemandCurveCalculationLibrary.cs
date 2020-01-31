// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using Models;

namespace CalculationLibrary
{
    public class DemandCurveCalculationLibrary
    {
        const int INDEX_TARGETAPPROACH = 18;
        const int INDEX_USERAPPROACH = 19;
        const int INDEX_COEF = 20;
        const int INDEX_LG = 21;
        const int INDEX_KAVL = 22;

        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26 };
//        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        public List<bool> ApproachInRange { get; private set; }
        public List<bool> ApproachOutOfRange { get; private set; }

        public bool DemandCurveCalculation(bool isElevation, bool showUserApproach, DemandCurveData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            data.TargetApproach = 0;
            data.UserApproach = 0;

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

            if ((data.CurveC1 != 0) && (data.CurveC2 != 0))
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

        void InitializeApproachList(DemandCurveData data)
        {
            MerkelData merkelData = new MerkelData()
            {
                WetBulbTemperature = data.WetBulbTemperature,
                Range = data.Range,
                Elevation = data.Elevation,
                LiquidToGasRatio = 0.1
            };

            foreach (double approachValue in InitialApproachXValues)
            {
                merkelData.Approach = approachValue;

                double KaVL = CalculationLibrary.CalculateMerkel(merkelData);
                bool approachInRange = (KaVL > 0.1) && (KaVL < 5.0);
                ApproachInRange.Add(approachInRange);
                ApproachOutOfRange.Add(!approachInRange);
            }
        }

        void CalculateApproach(DemandCurveData data)
        {
            MerkelData merkelData = new MerkelData()
            {
                WetBulbTemperature = data.WetBulbTemperature,
                Range = data.Range,
                Elevation = data.Elevation,
                LiquidToGasRatio = data.LiquidToGasRatio
            };

            if ((data.LiquidToGasRatio >= 0.1) && (data.LiquidToGasRatio <= 5.0))
            {
                if (data.CurveC1 != 0.0 && data.CurveC2 != 0.0)
                {
                    data.KaV_L = Math.Round((data.CurveC1 * Math.Pow(data.LiquidToGasRatio, data.CurveC2)), 5, MidpointRounding.ToEven);
                    data.Approach = GetExactApproach(merkelData);

                    if ((data.KaV_L < .01) || (data.KaV_L > 5.0))
                    {
                        data.KaV_L = 0.0;
                        data.Approach = 0;
                    }

                    if (data.TargetApproach >= 100)
                    {
                        data.Approach = 0;
                    }

                    if (!data.IsInternationalSystemOfUnits_IS_)
                    {
                        data.Approach *= 5.0 / 9.0;
                    }
                }
            }
        }

        void CalculateApproaches(DemandCurveData data)
        {
            //StreamWriter fs = new StreamWriter("new.txt");

            MerkelData merkelData = new MerkelData()
            {
                WetBulbTemperature = 80, // data.WetBulbTemperature,
                Range = data.Range,
                Elevation = data.Elevation,
                LiquidToGasRatio = data.LiquidToGasRatio
            };

            double kaVL = 0;
            double calculatedWaterAirRatio = 0.0;
            const double waterAirRatio_MIN = 0.01, waterAirRatio_MAX = 5.0;
            double calculatedWaterAirRatio_MIN = 999.0;

            //ApproachXValues[INDEX_TARGETAPPROACH] = TargetApproach;
            //ApproachXValues[INDEX_USERAPPROACH] = UserApproach;

            for (double waterAirRatio = waterAirRatio_MIN; waterAirRatio < waterAirRatio_MAX; waterAirRatio += .05)
            {
                //fs.WriteLine("\ndLG {0} \n", waterAirRatio.ToString("F6"));
                DataRow dataRow = data.DataTable.NewRow();

                for(int i = 0; i < InitialApproachXValues.Length; i++)
                {
                    //fs.WriteLine("\niIndex {0}  getapp(iIndex) {1} App[iIndex] {2} ", i, 1, (int)ApproachXValues[i]);
                    string approachXValue = ((int)InitialApproachXValues[i]).ToString();

                    if (ApproachInRange[i] && !ApproachOutOfRange[i])
                    {
                        merkelData.LiquidToGasRatio = waterAirRatio;
                        merkelData.Approach = InitialApproachXValues[i];
                        if (data.IsInternationalSystemOfUnits_IS_)
                        {
                            merkelData.Approach *= 1.8;
                        }

                        if (waterAirRatio > 1.3 && waterAirRatio < 1.4)
                        {
                            //fs.WriteLine();
                        }

                        //fs.WriteLine(" m_dblCurveWBT {0}, m_dblCurveRange {1}, App[iIndex] {2}, dLG {3}, m_dblAltitude {4} ", merkelData.WetBulbTemperature.ToString("F6"), merkelData.Range.ToString("F6"), merkelData.Approach.ToString("F6"), merkelData.WaterAirRatio.ToString("F6"), merkelData.Elevation.ToString("F6"));

                        kaVL = CalculationLibrary.CalculateMerkel(merkelData);

                        //fs.WriteLine(" m_dblCurveWBT {0}, m_dblCurveRange {1}, App[iIndex] {2}, dLG {3}, m_dblAltitude {4} ", merkelData.WetBulbTemperature.ToString("F6"), merkelData.Range.ToString("F6"), merkelData.Approach.ToString("F6"), merkelData.WaterAirRatio.ToString("F6"), merkelData.Elevation.ToString("F6"));
                        //fs.WriteLine("kavl {0} minVal {1} maxVal {2} dLG {3} App[iIndex] {4} ", kaVL.ToString("F6"), waterAirRatio_MIN.ToString("F6"), waterAirRatio_MAX.ToString("F6"), waterAirRatio.ToString("F6"), ApproachXValues[i].ToString("F6"));

                        // ddp
                        if ((kaVL < waterAirRatio_MIN) || (kaVL >= waterAirRatio_MAX))
                        {
                            double dInterp;
                            for (dInterp = waterAirRatio; ((kaVL < waterAirRatio_MIN) || (kaVL >= waterAirRatio_MAX)) && (dInterp > .1); dInterp -= 0.0002)
                            {
                                merkelData.Approach = InitialApproachXValues[i];
                                if (data.IsInternationalSystemOfUnits_IS_)
                                {
                                    merkelData.Approach *= 1.8;
                                }
                                merkelData.LiquidToGasRatio = dInterp;
                                kaVL = CalculationLibrary.CalculateMerkel(merkelData);
                            }
                            calculatedWaterAirRatio = dInterp;
                            ApproachOutOfRange[i] = true;  //DDP This is the last point
                        }
                        else
                        {
                            calculatedWaterAirRatio = waterAirRatio;
                        }

                        //fs.WriteLine("kavl {0} dLG {1} App[iIndex] {2} ", kaVL.ToString("F6"), waterAirRatio.ToString("F6"), ApproachXValues[i].ToString("F6"));

                        if ((calculatedWaterAirRatio_MIN > kaVL) && (kaVL > .1))
                        {
                            calculatedWaterAirRatio_MIN = kaVL;
                        }
                        //fs.Write("sDLG {0} ", calculatedWaterAirRatio.ToString("F6"));
                        //fs.Write("min4Lg {0} \n", min4Lg.ToString("F6"));

                        if ((kaVL <= 10.0) && (kaVL >= .1))
                        {
                            //fs.WriteLine("index {2} m_wndGraph {0} {1}", calculatedWaterAirRatio.ToString("F6"), kaVL.ToString("F6"), i);
                            dataRow[string.Format("L/G-{0}", approachXValue)] = calculatedWaterAirRatio;
                            dataRow[string.Format("kaVL-{0}", approachXValue)] = kaVL;
                        }
                    }
                }
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

            //            if ((dblK >= calculatedWaterAirRatio_MIN) && (dblK <= waterAirRatio_MAX))
            //            {
            //                dataRow["kaVL-COEF"] = kaVL;
            //                dataRow["L/G-COEF"] = calculatedWaterAirRatio;
            //                //m_wndGraph.GetSeries(INDEX_COEF).AddXY(waterAirRatio, dblK, NULL, 00099FF);
            //            }
            //        }
            //        data.DataTable.Rows.Add(dataRow);
            //    }
            //}

            //////---------------------------------------------------------------------
            ////// Draw L/G line
            //////---------------------------------------------------------------------
            //if (data.WaterAirRatio > waterAirRatio_MIN && data.WaterAirRatio <= waterAirRatio_MAX)// && Lg)
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
            //    dataRow["L/G-Y"] = data.WaterAirRatio;
            //    dataRow["L/G-X"] = calculatedWaterAirRatio_MIN;
            //    data.DataTable.Rows.Add(dataRow);

            //    dataRow = data.DataTable.NewRow();
            //    dataRow["L/G-Y"] = data.WaterAirRatio;
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
                  data.DataTable.Rows[0][string.Format("kaVL-{0}", INDEX_KAVL)] = waterAirRatio_MAX;
            //    data.DataTable.Rows[0][columnName] = waterAirRatio_MAX;
            //    data.DataTable.Rows[1][columnName] = waterAirRatio_MAX;
            //}

            //fs.Flush();
            //fs.Close();
        }

        void SaveDataFiles()
        {
            //UpdateData();

            //if (m_bDataChanged && (m_strDataName.GetLength()))
            //{
            //    if (MessageBox("Do you want to save the changes to the current data?", "Demand Curve Data", MB_YESNO) == IDYES)
            //    {
            //        OnButtonSave();
            //    }
            //}

            //if (m_wndDataFileList.GetCurSel() == 0)
            //{
            //    TNewDemandCurveDataDlg dlgNewData;

            //    if (dlgNewData.DoModal() == IDOK)
            //    {
            //        if (m_wndDataFileList.SelectString(0, dlgNewData.m_strNewFileName) == CB_ERR)
            //        {
            //            CString strPath;
            //            CString strNewFileName;

            //            GetModuleFileName(NULL, strPath.GetBuffer(MAX_PATH + 1), MAX_PATH);
            //            strPath.ReleaseBuffer();
            //            strPath = strPath.Left(strPath.ReverseFind('\\') + 1);

            //            m_strDataName = strPath + dlgNewData.m_strNewFileName;

            //            m_wndDataFileList.AddString(dlgNewData.m_strNewFileName);
            //            m_wndDataFileList.SelectString(0, dlgNewData.m_strNewFileName);
            //            OnButtonSave();
            //        }
            //    }
            //    else
            //    {
            //        m_strDataName == "";
            //    }
            //}

            //if ((m_wndDataFileList.GetCurSel() != LB_ERR) && (m_wndDataFileList.GetCurSel() != 0))
            //{
            //    CString strSection;
            //    char szValue[256];


            //    m_wndDataFileList.GetLBText(m_wndDataFileList.GetCurSel(), m_strDataName);

            //    CString strPath;
            //    CString strNewFileName;

            //    GetModuleFileName(NULL, strPath.GetBuffer(MAX_PATH + 1), MAX_PATH);
            //    strPath.ReleaseBuffer();
            //    strPath = strPath.Left(strPath.ReverseFind('\\') + 1);

            //    m_strDataName = strPath + m_strDataName;

            //    //---------------------------------------------------------------------
            //    // Set Default input values
            //    //---------------------------------------------------------------------
            //    strSection = "Demand Curve Data";
            //    GetPrivateProfileString(strSection, "CurveC1", "0.0", szValue, 256, m_strDataName);
            //    data.CurveC1 = atof(szValue);

            //    GetPrivateProfileString(strSection, "CurveC2", "0.0", szValue, 256, m_strDataName);
            //    data.CurveC2 = atof(szValue);

            //    GetPrivateProfileString(strSection, "Altitude", "0.0", szValue, 256, m_strDataName);
            //    m_dblAltitude = atof(szValue);

            //    GetPrivateProfileString(strSection, "Kavl", "0.0", szValue, 256, m_strDataName);
            //    m_dblKavl = atof(szValue);

            //    GetPrivateProfileString(strSection, "Lg", "0.0", szValue, 256, m_strDataName);
            //    data.WaterAirRatio = atof(szValue);

            //    GetPrivateProfileString(strSection, "CurveMin", "0.5", szValue, 256, m_strDataName);
            //    data.CurveMinimum = atof(szValue);

            //    GetPrivateProfileString(strSection, "CurveMax", "2.5", szValue, 256, m_strDataName);
            //    data.CurveMaximum = atof(szValue);

            //    GetPrivateProfileString(strSection, "CurveWBT", "80.0", szValue, 256, m_strDataName);
            //    m_dblCurveWBT = atof(szValue);

            //    GetPrivateProfileString(strSection, "CurveRange", "10.0", szValue, 256, m_strDataName);
            //    m_dblCurveRange = atof(szValue);

            //    //---------------------------------------------------------------------
            //    // Set unit lables
            //    //---------------------------------------------------------------------
            //    GetPrivateProfileString(strSection, "WBTUnits", L_DEGF, szValue, 256, m_strDataName);
            //    m_strWBT = szValue;

            //    GetPrivateProfileString(strSection, "RangeUnits", L_DEGF, szValue, 256, m_strDataName);
            //    m_strRange = szValue;

            //    GetPrivateProfileString(strSection, "AltUnits", L_FEET, szValue, 256, m_strDataName);
            //    m_strAltitude = szValue;

            //    //---------------------------------------------------------------------
            //    // Curves are all initially on
            //    //---------------------------------------------------------------------
            //    coef = true;
            //    Lg = true;
            //    m_bShowKaVLLine = true;
            //    bShowApproach[0] = true;
            //    bShowApproach[1] = true;
            //    bShowApproach[2] = true;
            //    bShowApproach[3] = true;
            //    bShowApproach[4] = true;
            //    bShowApproach[5] = true;
            //    bShowApproach[6] = true;
            //    bShowApproach[7] = true;
            //    bShowApproach[8] = true;
            //    bShowApproach[9] = true;
            //    bShowApproach[10] = true;
            //    bShowApproach[11] = true;
            //    bShowApproach[12] = true;
            //    bShowApproach[13] = true;
            //    bShowApproach[14] = true;
            //    bShowApproach[15] = true;
            //    bShowApproach[16] = true;
            //    bShowApproach[17] = true;
            //    bShowApproach[18] = true;  // Target Approach
            //    bShowApproach[19] = true;  // User Approach
            //    bShowApproach[20] = false;
            //    bShowApproach[21] = false;
            //    bShowApproach[22] = false;
            //    bShowApproach[23] = false;
            //    bShowApproach[24] = false;

            //    m_bAltitude = true;
            //    m_strAltitudeLable.LoadString(IDS_ALTITUDE);

            //    UpdateUnits();
            //}

            //UpdateData(false);
        }

        void OnButtonSave()
        {
            //CString strSection;
            //CString strTemp;

            //UpdateData();

            //if (m_strDataName.GetLength())
            //{
            //    //---------------------------------------------------------------------
            //    // Set Default input values
            //    //---------------------------------------------------------------------
            //    strSection = "Demand Curve Data";

            //    strTemp.Format("%.04f", data.CurveC1);
            //    WritePrivateProfileString(strSection, "CurveC1", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", data.CurveC2);
            //    WritePrivateProfileString(strSection, "CurveC2", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", m_dblAltitude);
            //    WritePrivateProfileString(strSection, "Altitude", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", m_dblKavl);
            //    WritePrivateProfileString(strSection, "Kavl", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", data.WaterAirRatio);
            //    WritePrivateProfileString(strSection, "Lg", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", data.CurveMinimum);
            //    WritePrivateProfileString(strSection, "CurveMin", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", data.CurveMaximum);
            //    WritePrivateProfileString(strSection, "CurveMax", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", m_dblCurveWBT);
            //    WritePrivateProfileString(strSection, "CurveWBT", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", m_dblCurveRange);
            //    WritePrivateProfileString(strSection, "CurveRange", strTemp, m_strDataName);

            //    //---------------------------------------------------------------------
            //    // Set unit lables
            //    //---------------------------------------------------------------------
            //    WritePrivateProfileString(strSection, "WBTUnits", m_strWBT, m_strDataName);
            //    WritePrivateProfileString(strSection, "RangeUnits", m_strRange, m_strDataName);
            //    WritePrivateProfileString(strSection, "AltUnits", m_strAltitude, m_strDataName);

            //    m_bDataChanged = false;
            //}
        }

        void OnMultiEdit()
        {
            //TMultiEdit dlgCurveStatus;
            //dlgCurveStatus.m_fnInitData(m_listApp, bShowApproach, coef, Lg, m_bShowKaVLLine, bShowApproach[INDEX_TARGETAPPROACH], bShowApproach[INDEX_USERAPPROACH], m_dblUserApproach);
            //if (dlgCurveStatus.DoModal() == IDOK)
            //{
            //    dlgCurveStatus.m_fnGetData(bShowApproach, coef, Lg, m_bShowKaVLLine, bShowApproach[INDEX_TARGETAPPROACH], bShowApproach[INDEX_USERAPPROACH], m_dblUserApproach);
            //    OnCurveButtonRecalc();
            //}
        }

        void OnOnMouseUpTchartGraph(long Button, long X, long Y)
        {
            //if (Button == 2)
            //{
            //    UpdateData(true);

            //    double dX = m_DynamicCurveChart.GetSeries(0).XScreenToValue(X);
            //    double dY = m_DynamicCurveChart.GetSeries(0).YScreenToValue(Y);

            //    double WBTC;
            //    double ALTC;
            //    double RANC;

            //    WBTC = m_dblCurveWBT;
            //    ALTC = m_dblAltitude;
            //    RANC = m_dblCurveRange;
            //    if (TPropPageBase::metricflag)
            //    {
            //        WBTC = fnCelcToFar(m_dblCurveWBT);
            //        ALTC = fnMetersToFeet(m_dblAltitude);
            //        RANC = m_dblCurveRange * 1.8;
            //    }

            //    double dblApproach = m_fnGetExactApproach(WBTC, RANC, dX, ALTC, dY);

            //    if (TPropPageBase::metricflag)
            //    {
            //        dblApproach *= 5.0 / 9.0;
            //    }

            //    CString strPos;
            //    strPos.Format("Approach\t= %.3f\n\nL/G\t= %.3f\nKaV/L\t= %.5f", dblApproach, dX, dY);
            //    MessageBox(strPos, "Mouse Clicked at", MB_OK | MB_ICONINFORMATION);
            //}
        }

        void OnOnDblClickTchartGraph()
        {
            //const MSG* msg = GetCurrentMessage();
            //POINT pt = msg->pt;
            //m_DynamicCurveChart.ScreenToClient(&pt);
            //int approach = findApproach(pt.x, pt.y);
            //setapp(approach, false);
            //OnCurveButtonRecalc();
        }

        double GetExactApproach(MerkelData merkelData)
        {
            double approach;
            double delta = 1.0;

            //---------------------------------------------------------------------
            // Find approach within .001
            //---------------------------------------------------------------------
            for (approach = 0.0; approach < 100.0; approach += delta)
            {
                merkelData.Approach = approach;
                double kavl = CalculationLibrary.CalculateMerkel(merkelData);

                if (delta > 0.9)
                {
                    if (kavl < merkelData.KaV_L)
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
                    if (kavl >= merkelData.KaV_L)
                    {
                        approach = Math.Round(approach, 3, MidpointRounding.ToEven);
                        break;
                    }
                }
            }
            return approach;
        }

        void OnFilePrintPreview()
        {
            //TPrint tp;
            //if (tp.DoModal() == IDOK)
            //{
            //    wndPrintFrame.ShowWindow(SW_NORMAL);
            //    wndPrintView.ShowWindow(SW_NORMAL);
            //    wndPrintFrame.m_bPrintPreview = TRUE;
            //    wndPrintView.m_fnPrintPreview(tp.m_csDescription, m_dblCurveRange, m_dblCurveWBT, m_dblAltitude, data.CurveC1, data.CurveC2, m_dblKavl, data.WaterAirRatio, INDEX_TARGETAPPROACH, INDEX_USERAPPROACH, &m_DynamicCurveChart);
            //}
        }

        void OnFilePrint()
        {
            //TPrint tp;
            //if (tp.DoModal() == IDOK)
            //{
            //    wndPrintView.m_fnPrint(tp.m_csDescription, m_dblCurveRange, m_dblCurveWBT, m_dblAltitude, data.CurveC1, data.CurveC2, m_dblKavl, data.WaterAirRatio, INDEX_TARGETAPPROACH, INDEX_USERAPPROACH, &m_DynamicCurveChart);
            //}
        }
    }
}