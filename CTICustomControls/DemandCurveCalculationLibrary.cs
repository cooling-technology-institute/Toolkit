using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ToolkitLibrary
{
    public class DemandCurveCalculationLibrary
    {
        const int INDEX_TARGETAPPROACH = 18;
        const int INDEX_USERAPPROACH = 19;
        const int INDEX_COEF = 20;
        const int INDEX_LG = 21;
        const int INDEX_KAVL = 22;

        double[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        List<double> ApproachXValues { get; set; }
        double TargetApproach { get; set; }

        public DataTable DemandCurveCalculation(DemandCurveData data)
        {
            TargetApproach = 0;
            ApproachXValues = new List<double>();

            try
            {
                if (data.IsInternationalSystemOfUnits_IS_)
                {
                    data.WetBulbTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature);

                    if (!data.IsElevation)
                    {
                        data.Elevation = UnitConverter.ConvertMetersToFeet(UnitConverter.ConvertKilopascalToElevationInMeters(data.BarometricPressure));
                    }
                }
                else
                {
                    if (!data.IsElevation)
                    {
                        data.Elevation = UnitConverter.ConvertBarometricPressureToElevationInFeet(UnitConverter.CalculatePressureCelcius(data.BarometricPressure));
                    }
                }

                data.DataTable.Clear();

                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "X";
                dataColumn.DataType = Type.GetType("System.Double");
                data.DataTable.Columns.Add(dataColumn);
                for (int i = 1; i <= INDEX_KAVL; i++)
                {
                    dataColumn = new DataColumn();
                    dataColumn.ColumnName = string.Format("Y{0}", i);
                    dataColumn.DataType = Type.GetType("System.Double");
                    data.DataTable.Columns.Add(dataColumn);
                }

                InitializeApproachList(data);
                CalculateApproach(data);
                CalculateApproaches(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Calculation exception: {0}", e.Message));
            }

            return data.DataTable;
        }

        void InitializeApproachList(DemandCurveData data)
        {
            MerkelData merkelData = new MerkelData()
            {
                WetBulbTemperature = data.WetBulbTemperature,
                Range = data.Range,
                Elevation = data.Elevation,
                WaterAirRatio = 0.1
            };

            foreach (double approachValue in InitialApproachXValues)
            {
                merkelData.Approach = approachValue;

                double KaVL = CalculationLibrary.CalculateMerkel(merkelData);

                if ((KaVL > 0.1) && (KaVL < 5.0))
                {
                    ApproachXValues.Add(approachValue);
                }
            }
        }

        void CalculateApproach(DemandCurveData data)
        {
            MerkelData merkelData = new MerkelData()
            {
                WetBulbTemperature = data.WetBulbTemperature,
                Range = data.Range,
                Elevation = data.Elevation,
                WaterAirRatio = data.WaterAirRatio
            };

            if ((data.WaterAirRatio >= 0.1) && (data.WaterAirRatio <= 5.0))
            {
                if (data.CurveC1 != 0.0 && data.CurveC2 != 0.0)
                {
                    data.KaV_L = Math.Round((data.CurveC1 * Math.Pow(data.WaterAirRatio, data.CurveC2)), 5, MidpointRounding.ToEven);
                    data.Approach = GetExactApproach(merkelData);

                    if ((data.KaV_L < .01) || (data.KaV_L > 5.0))
                    {
                        data.KaV_L = 0.0;
                        data.Approach = 0;
                    }

                    if (TargetApproach >= 100)
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
            MerkelData merkelData = new MerkelData()
            {
                WetBulbTemperature = data.WetBulbTemperature,
                Range = data.Range,
                Elevation = data.Elevation,
                WaterAirRatio = data.WaterAirRatio
            };

            double kaVL = 0;
            double maxVal = 5.0;   // for kavl
            double minVal = 0.01;  // for kavl
            double min4Lg = 999.0;
            double dLG = 0.0;
            double sDLG = 0.0;

            for (double waterAirRatio = 0.1; waterAirRatio < 5.0; waterAirRatio += .05)
			{
                DataRow dataRow = data.DataTable.NewRow();

                for (int i = 0; i <= INDEX_USERAPPROACH; i++)
				{
                    if (ApproachXValues[i] > 0.0001)
					{
                        merkelData.WaterAirRatio = data.WaterAirRatio;
                        merkelData.Approach = 0.1;

                        merkelData.Approach = ApproachXValues[i];
                        if (!data.IsInternationalSystemOfUnits_IS_)
                        {
                            merkelData.Approach *= 1.8;
                        }

                        kaVL = CalculationLibrary.CalculateMerkel(merkelData);

                        // ddp
                        if ((kaVL < minVal ) || (kaVL >= maxVal ))
						{
							double dInterp;
							for (dInterp = waterAirRatio; ((kaVL < minVal ) || (kaVL >= maxVal )) && (dInterp > .1); dInterp -= 0.0002)
							{
                                merkelData.WaterAirRatio = dInterp;
                                kaVL = CalculationLibrary.CalculateMerkel(merkelData);
							}
							sDLG = dInterp;
                            ApproachXValues[i] = 0;  //DDP This is the last point
						}
						else
						{
							sDLG = kaVL;
						}

						if ((min4Lg > kaVL) && (kaVL > .1))
                        {
                            min4Lg = kaVL;
                        }

                        dataRow[string.Format("Y{0}", i + 1)] = sDLG;
                    }
                }

                dataRow["X"] = waterAirRatio;
                data.DataTable.Rows.Add(dataRow);
            }
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
            //    m_dblCurveMin = atof(szValue);

            //    GetPrivateProfileString(strSection, "CurveMax", "2.5", szValue, 256, m_strDataName);
            //    m_dblCurveMax = atof(szValue);

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

            //    strTemp.Format("%.04f", m_dblCurveMin);
            //    WritePrivateProfileString(strSection, "CurveMin", strTemp, m_strDataName);

            //    strTemp.Format("%.04f", m_dblCurveMax);
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

        //int FindApproach(long X, long Y)
        //{
        //    int approach = 0;
        //    int curveIndex = 0;
        //    double distance = 5000.0;
        //    double dX = m_DynamicCurveChart.GetSeries(0).XScreenToValue(X);
        //    double dY = m_DynamicCurveChart.GetSeries(0).YScreenToValue(Y);
        //    for (int x = 0; x < m_DynamicCurveChart.GetSeriesCount(); x++)
        //    {
        //        CSeries cs;
        //        CValueList cx;
        //        CValueList cy;

        //        //---------------------------------------------------------------------
        //        // Find only approach lines
        //        //---------------------------------------------------------------------
        //        if (m_DynamicCurveChart.GetSeries(x).GetTitle() == "C" || m_DynamicCurveChart.GetSeries(x).GetTitle() == "L/G")
        //        {
        //            break;
        //        }

        //        cs = m_DynamicCurveChart.GetSeries(x);
        //        cx = cs.GetXValues();
        //        cy = cs.GetYValues();

        //        //---------------------------------------------------------------------
        //        // Find the closest approach line index
        //        //---------------------------------------------------------------------
        //        for (int y = 0; y < cx.GetCount(); y++)
        //        {
        //            double xc = cx.GetValue(y);
        //            double yc = cy.GetValue(y);
        //            double delta = abs(xc - dX) + abs(yc - dY);
        //            if (distance > delta)
        //            {
        //                distance = delta;
        //                curveIndex = x;
        //            }
        //        }
        //    }
        //    approach = curveIndex;
        //    return approach;
        //}

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

        void OnCurveButtonRecalc() 
        {
	       // CWaitCursor curWait;
	       // try
	       // {
		      //  if (UpdateData(true))
		      //  {
			     //   double	dLG;
			     //   double  sDLG;
			     //   double  prevKaVL;
			     //   double  incAmount = 0.0;
			     //   int		iIndex;
			     //   double	dTempRange;
			     //   CString	strTitle;
			     //   double	App[sizeof(m_listApp)/sizeof(double)];
			     //   unsigned long color;

        //#ifdef _NEW_GRAPH_LIMITS
        //            // Try to reconcile graph LG limits with the rest of the program
        //            // (speculative change, DBL, 12/08/2003)
        //            const double dLG_MIN = LG_MIN_IP, dLG_MAX = LG_MAX_IP;
        //#else
        //            const double dLG_MIN = 0.1, dLG_MAX = 5.0;
        //#endif

			     //   //---------------------------------------------------------------------
			     //   // Clean up graph
			     //   //---------------------------------------------------------------------
			     //   m_DynamicCurveChart.RemoveAllSeries();

			     //   //---------------------------------------------------------------------
			     //   // Setup the graph appearance
			     //   //---------------------------------------------------------------------
			     //   m_DynamicCurveChart.GetWalls().SetBackColor(0x0);  // black
			     //   m_DynamicCurveChart.GetPanel().GetGradient().SetStartColor(0x0);
			     //   m_DynamicCurveChart.GetPanel().GetGradient().SetEndColor(0x0);
			     //   m_DynamicCurveChart.GetPanel().GetGradient().SetVisible(true);
			     //   m_DynamicCurveChart.GetAspect().SetView3D(false);
			     //   m_DynamicCurveChart.SetDragMode(dmManual);

			     //   // Standard approach curve pen
			     //   color = 0xFFFF;  // bright yellow

			     //   m_DynamicCurveChart.GetLegend().SetVisible(false);

			     //   m_DynamicCurveChart.GetAxis().GetLeft().SetMinMax(.1, 10);
			     //   m_DynamicCurveChart.GetAxis().GetRight().SetMinMax(.1, 10);
			     //   m_DynamicCurveChart.GetAxis().GetTop().SetMinMax(.1, 10);
        //#ifdef _NEW_GRAPH_LIMITS
			     //   m_DynamicCurveChart.GetAxis().GetBottom().SetMinMax(LG_MIN_IP, LG_MAX_IP);
        //#else
			     //   m_DynamicCurveChart.GetAxis().GetBottom().SetMinMax(.1, 10);
        //#endif

			     //   m_DynamicCurveChart.GetAxis().GetLeft().SetLogarithmic(true);
			     //   m_DynamicCurveChart.GetAxis().GetRight().SetLogarithmic(true);
			     //   m_DynamicCurveChart.GetAxis().GetTop().SetLogarithmic(true);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().SetLogarithmic(true);

			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetMinorTicks().SetColor(  0xCCCCCC );
			     //   m_DynamicCurveChart.GetAxis().GetRight().GetMinorTicks().SetColor( 0xCCCCCC );
			     //   m_DynamicCurveChart.GetAxis().GetTop().GetMinorTicks().SetColor(   0xCCCCCC );
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetMinorTicks().SetColor(0xCCCCCC );

			     //   // grid color
			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetGridPen().SetColor(  0x777777);
			     //   m_DynamicCurveChart.GetAxis().GetRight().GetGridPen().SetColor( 0x777777 );
			     //   m_DynamicCurveChart.GetAxis().GetTop().GetGridPen().SetColor(   0x777777 );
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetGridPen().SetColor(0x777777 );

			     //   // Axis color
			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetAxisPen().SetColor(  0xE4E4E4 );
			     //   m_DynamicCurveChart.GetAxis().GetRight().GetAxisPen().SetColor( 0xE4E4E4 );
			     //   m_DynamicCurveChart.GetAxis().GetTop().GetAxisPen().SetColor(   0xE4E4E4 );
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetAxisPen().SetColor(0xE4E4E4 );

			     //   // grid text
			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetTitle().GetFont().SetColor(0xFFFFFF);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetTitle().GetFont().SetColor(0xFFFFFF);

			     //   // axis labels
			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetLabels().GetFont().SetColor(0xFFFFFF);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetLabels().GetFont().SetColor(0xFFFFFF);

			     //   // set major axis to solid lines - psSolid
			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetGridPen().SetStyle(  psSolid );
			     //   m_DynamicCurveChart.GetAxis().GetRight().GetGridPen().SetStyle( psSolid );
			     //   m_DynamicCurveChart.GetAxis().GetTop().GetGridPen().SetStyle(   psSolid );
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetGridPen().SetStyle(psSolid );

			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetGridPen().SetWidth(  1 );
			     //   m_DynamicCurveChart.GetAxis().GetRight().GetGridPen().SetWidth( 1 );
			     //   m_DynamicCurveChart.GetAxis().GetTop().GetGridPen().SetWidth(   1 );
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetGridPen().SetWidth(1 );

			     //   m_DynamicCurveChart.GetAxis().GetTop().GetLabels().SetAngle(90);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetLabels().SetAngle(90);

			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetLabels().GetFont().SetSize(6);
			     //   m_DynamicCurveChart.GetAxis().GetRight().GetLabels().GetFont().SetSize(6);
			     //   m_DynamicCurveChart.GetAxis().GetTop().GetLabels().GetFont().SetSize(6);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetLabels().GetFont().SetSize(6);

			     //   m_DynamicCurveChart.GetAxis().GetLeft().SetAutomaticMinimum(true);
			     //   m_DynamicCurveChart.GetAxis().GetRight().SetAutomaticMinimum(true);
			     //   m_DynamicCurveChart.GetAxis().GetTop().SetAutomaticMinimum(true);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().SetAutomaticMinimum(true);

			     //   m_DynamicCurveChart.GetAxis().GetLeft().SetAutomaticMaximum(true);
			     //   m_DynamicCurveChart.GetAxis().GetRight().SetAutomaticMaximum(true);
			     //   m_DynamicCurveChart.GetAxis().GetTop().SetAutomaticMaximum(true);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().SetAutomaticMaximum(true);

			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetTitle().SetCaption("KaV/L");
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetTitle().SetCaption("L/G");

			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetTitle().GetFont().SetSize(10);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetTitle().GetFont().SetSize(10);
			     //   m_DynamicCurveChart.GetAxis().GetLeft().GetTitle().GetFont().SetBold(true);
			     //   m_DynamicCurveChart.GetAxis().GetBottom().GetTitle().GetFont().SetBold(true);

			     //   //---------------------------------------------------------------------
			     //   // if metric, convert to english units before calculating
			     //   //---------------------------------------------------------------------
			     //   double WBTC = 0.0;
			     //   double ALTC = 0.0;
			     //   double RANC = 0.0;
			     //   if (TPropPageBase::metricflag)
			     //   {
				    //    WBTC = m_dblCurveWBT;
				    //    ALTC = m_dblAltitude;
				    //    RANC = m_dblCurveRange;
				    //    m_dblCurveWBT = fnCelcToFar(m_dblCurveWBT);
				    //    m_dblAltitude = fnMetersToFeet(m_dblAltitude);
				    //    m_dblCurveRange = m_dblCurveRange * 1.8;
			     //   }
			     //   // pre-scan for min/max value
			     //   double kavl		= 0.0;
			     //   double min4Lg	= 999.0;

			     //   // Init range.
			     //   double  maxVal = 5.0;   // for kavl
			     //   double  minVal = 0.01;  // for kavl


			     //   memset(m_listApp, 0, sizeof(m_listApp));
			     //   m_fnInitApproachList(m_listApp, m_dblCurveWBT, m_dblCurveRange, m_dblAltitude);
			     //   memcpy(App, m_listApp, sizeof(m_listApp));


			     //   //---------------------------------------------------------------------
			     //   // Clear the output values
			     //   //---------------------------------------------------------------------
			     //   m_dblKavl			= 0; // clear value
			     //   m_dblTargetApproach = 0; // clear value
			     //   UpdateData(false);

			     //   //---------------------------------------------------------------------
			     //   // Calculate the Target Approach
			     //   //---------------------------------------------------------------------
			     //   if ((data.WaterAirRatio >= dLG_MIN) && (data.WaterAirRatio <= dLG_MAX))
			     //   {
				    //    if (data.CurveC1 && data.CurveC2)
				    //    {
					   //     m_dblKavl = truncit((data.CurveC1 * pow( data.WaterAirRatio, data.CurveC2 )), 5);
					   //     m_dblTargetApproach = m_fnGetExactApproach(m_dblCurveWBT, m_dblCurveRange, data.WaterAirRatio, m_dblAltitude, m_dblKavl);

					   //     if ((m_dblKavl < .01) || (m_dblKavl > maxVal))
					   //     {
						  //      m_dblKavl = 0.0;
						  //      m_dblTargetApproach = 0;
					   //     }

					   //     if (m_dblTargetApproach >= 100)
					   //     {
						  //      m_dblTargetApproach = 0;
					   //     }

					   //     if (TPropPageBase::metricflag)
					   //     {
						  //      m_dblTargetApproach *= 5.0/9.0;
					   //     }
				    //    }
			     //   }

			     //   //---------------------------------------------------------------------
			     //   // Add the series to the graph
			     //   //---------------------------------------------------------------------
			     //   //---------------------------------------------------------------------
			     //   // Standard Approach Curves
			     //   //---------------------------------------------------------------------
			     //   for (iIndex = 0; iIndex < 18; iIndex++)
			     //   {
				    //    m_DynamicCurveChart.AddSeries(scLine);
				    //    strTitle.Format("%i", (int)App[iIndex]);
				    //    m_DynamicCurveChart.GetSeries(iIndex).SetTitle(strTitle);
			     //   }

			     //   //---------------------------------------------------------------------
			     //   // User and target Approach Curves
			     //   //---------------------------------------------------------------------
			     //   m_DynamicCurveChart.AddSeries(scLine);
			     //   strTitle.Format("%.3f", m_dblTargetApproach);
			     //   m_DynamicCurveChart.GetSeries(INDEX_TARGETAPPROACH).SetTitle(strTitle);
			     //   App[INDEX_TARGETAPPROACH] = m_dblTargetApproach;

			     //   m_DynamicCurveChart.AddSeries(scLine);
			     //   strTitle.Format("%.3f", m_dblUserApproach);
			     //   m_DynamicCurveChart.GetSeries(INDEX_USERAPPROACH).SetTitle(strTitle);
			     //   App[INDEX_USERAPPROACH] = m_dblUserApproach;

			     //   //---------------------------------------------------------------------
			     //   // Characteristic Line
			     //   //---------------------------------------------------------------------
			     //   m_DynamicCurveChart.AddSeries(scLine);
			     //   strTitle = "C";
			     //   m_DynamicCurveChart.GetSeries(INDEX_COEF).SetTitle(strTitle);

			     //   //---------------------------------------------------------------------
			     //   // L/G Line
			     //   //---------------------------------------------------------------------
			     //   m_DynamicCurveChart.AddSeries(scLine);
			     //   strTitle = "L/G";
			     //   m_DynamicCurveChart.GetSeries(INDEX_LG).SetTitle(strTitle);

			     //   //---------------------------------------------------------------------
			     //   // KAVL Line
			     //   //---------------------------------------------------------------------
			     //   m_DynamicCurveChart.AddSeries(scLine);
			     //   strTitle = "KaV/L";
			     //   m_DynamicCurveChart.GetSeries(INDEX_KAVL).SetTitle(strTitle);

			
			     //   //---------------------------------------------------------------------
			     //   // Draw Apprach Lines
			     //   //---------------------------------------------------------------------
			     //   for (dLG = dLG_MIN; dLG < dLG_MAX; dLG += .05)
			     //   {
				    //    incAmount = 0.0;
				    //    for (iIndex = 0; iIndex <= INDEX_USERAPPROACH; iIndex++)
				    //    {
					   //     if (getapp(iIndex) && (App[iIndex] > 0.0001))
					   //     {
						  //      dTempRange = m_dblCurveWBT + (1.8 * (double)iIndex);
            
						  //      if (iIndex > 0) prevKaVL = kavl;
						
						  //      if (TPropPageBase::metricflag)
						  //      {
							 //       kavl = Merkel(m_dblCurveWBT, m_dblCurveRange, 1.8*App[iIndex], dLG, m_dblAltitude);
						  //      }
						  //      else
						  //      {
							 //       kavl = Merkel(m_dblCurveWBT, m_dblCurveRange, App[iIndex], dLG, m_dblAltitude);
						  //      }
            
						  //      // ddp
						  //      if (( kavl < minVal ) || ( kavl >= maxVal ))
						  //      {
							 //       double dInterp;
							 //       for (dInterp = dLG; (( kavl < minVal ) || ( kavl >= maxVal )) && (dInterp > .1); dInterp -= 0.0002)
							 //       {
								//        if (TPropPageBase::metricflag)
								//        {
								//	        kavl = Merkel(m_dblCurveWBT, m_dblCurveRange, 1.8*App[iIndex], dInterp, m_dblAltitude);
								//        }
								//        else
								//        {
								//	        kavl = Merkel(m_dblCurveWBT, m_dblCurveRange, App[iIndex], dInterp, m_dblAltitude);
								//        }
							 //       }
							 //       sDLG = dInterp;
							 //       App[iIndex] = 0;  //DDP This is the last point
						  //      }
						  //      else
						  //      {
							 //       sDLG = dLG;
						  //      }

						  //      if ((min4Lg > kavl) && (kavl > .1))
							 //       min4Lg = kavl;

						  //      if ((kavl <= 10.0) && (kavl >= .1))
						  //      {
							 //       switch (iIndex)
							 //       {
								//        case INDEX_TARGETAPPROACH:
								//        case INDEX_USERAPPROACH:
								//	        m_DynamicCurveChart.GetSeries(iIndex).AddXY(sDLG, kavl, NULL, 0x0099FF);
								//	        break;

								//        default:
								//	        m_DynamicCurveChart.GetSeries(iIndex).AddXY(sDLG, kavl, NULL, color);
								//	        break;
							 //       }
						  //      }
					   //     }
				    //    }
			     //   }

			     //   //---------------------------------------------------------------------
			     //   // Draw Fill Line
			     //   //---------------------------------------------------------------------
			     //   if ((data.CurveC1 != 0) && (data.CurveC2 != 0) && coef)
			     //   {        
				    //    for (dLG = m_dblCurveMin; dLG <= m_dblCurveMax; dLG += .05)
				    //    {
					   //     if ((dLG >= m_dblCurveMin) && (dLG <= m_dblCurveMax))
					   //     {
						  //      double dblK = data.CurveC1 * pow(dLG, data.CurveC2);

						  //      if ((dblK >= min4Lg) && (dblK <= maxVal))
						  //      {
							 //       m_DynamicCurveChart.GetSeries(INDEX_COEF).AddXY(dLG, dblK, NULL, 0x0099FF);	
						  //      }
					   //     }
				    //    }
			     //   }

			     //   //---------------------------------------------------------------------
			     //   // Draw L/G line
			     //   //---------------------------------------------------------------------
			     //   if (data.WaterAirRatio > dLG_MIN && data.WaterAirRatio <= dLG_MAX && Lg)
			     //   {
				    //    m_DynamicCurveChart.GetSeries(INDEX_LG).AddXY(data.WaterAirRatio, min4Lg, NULL, 0x0099FF);
				    //    m_DynamicCurveChart.GetSeries(INDEX_LG).AddXY(data.WaterAirRatio, maxVal, NULL, 0x0099FF);
			     //   }

			     //   //---------------------------------------------------------------------
			     //   // Draw KaV/L line
			     //   //---------------------------------------------------------------------
			     //   if (m_bShowKaVLLine && (m_dblKavl > 0.1) && (m_dblKavl <= maxVal))
			     //   {
				    //    m_DynamicCurveChart.GetSeries(INDEX_KAVL).AddXY(0.1, m_dblKavl, NULL, 0x0099FF);
				    //    m_DynamicCurveChart.GetSeries(INDEX_KAVL).AddXY(5.0, m_dblKavl, NULL, 0x0099FF);
			     //   }

			     //   //---------------------------------------------------------------------
			     //   // Reset to metric if needed and update the output
			     //   //---------------------------------------------------------------------
			     //   if (TPropPageBase::metricflag) // set values back to metric
			     //   {
				    //    m_dblCurveWBT = WBTC;
				    //    m_dblAltitude = ALTC;
				    //    m_dblCurveRange = RANC;
			     //   }

			     //   UpdateData(false);
		      //  }
	       // }
	       // catch(...)
	       // {
		      //  MessageBox("Error in calculation.  Please check your input values.", "Calculation Error", MB_OK | MB_ICONEXCLAMATION);
	       // }
        }

        void OnButtonKavlApproach()
        {
            //if (UpdateData(true))
            //{
            //    m_bShowUserApproach = !m_bShowUserApproach;
            //    if (m_bShowUserApproach)
            //    {
            //        GetDlgItem(IDC_BUTTON_KAVL_APPROACH)->SetWindowText("Approach:");
            //    }
            //    else
            //    {
            //        GetDlgItem(IDC_BUTTON_KAVL_APPROACH)->SetWindowText("Kav/L:");
            //    }
            //    UpdateData(false);
            //}
        }

        void DoDataExchange()
        {
//            cdxCSizingPropPage::DoDataExchange(pDX);
//            //{{AFX_DATA_MAP(TPropPageThree)
//            DDX_Control(pDX, IDC_COMBO_DATA_FILES, m_wndDataFileList);
//            DDX_Control(pDX, IDC_SPIN_MIN, m_SpinMin);
//            DDX_Control(pDX, IDC_SPIN_MAX, m_SpinMax);
//            DDX_Text(pDX, IDC_EDIT_MAX, m_dblCurveMax);
//            DDV_MinMaxDouble(pDX, m_dblCurveMax, 0.1, 20.0);
//            DDX_Text(pDX, IDC_EDIT_MIN, m_dblCurveMin);
//            DDV_MinMaxDouble(pDX, m_dblCurveMin, 0.1, 5.);
//            DDX_Text(pDX, IDC_CURVE_STATIC_ALTITUDE_UNITS, m_strAltitude);
//            DDX_Text(pDX, IDC_CURVE_STATIC_RANGE_UNITS, m_strRange);
//            DDX_Text(pDX, IDC_CURVE_STATIC_WBT_UNITS, m_strWBT);
//            DDX_Control(pDX, IDC_TCHART_GRAPH, m_DynamicCurveChart);
//            //}}AFX_DATA_MAP

//            //---------------------------------------------------------------------
//            // Minmax values
//            //---------------------------------------------------------------------
//            DDX_Text(pDX, IDC_EDIT_CURVE_LG, data.WaterAirRatio);
//# ifdef _NEW_GRAPH_LIMITS
//            DDV_MinMaxDouble(pDX, data.WaterAirRatio, LG_MIN_IP, LG_MAX_IP,
//                LG_MIN_SI, LG_MAX_SI, 2);
//#else
//            DDV_MinMaxDouble(pDX, data.WaterAirRatio, LG_P3_MIN_IP, LG_P3_MAX_IP,
//                LG_P3_MIN_SI, LG_P3_MAX_SI, 2);
//#endif // _NEW_GRAPH_LIMITS
//            DDX_Text(pDX, IDC_CURVE_EDIT_WBT, m_dblCurveWBT);
//            DDV_MinMaxDouble(pDX, m_dblCurveWBT, WBT_MIN_IP, WBT_MAX_IP,
//                WBT_MIN_SI, WBT_MAX_SI, 2);
//            DDX_Text(pDX, IDC_CURVE_EDIT_RANGE, m_dblCurveRange);
//            DDV_MinMaxDouble(pDX, m_dblCurveRange, .1, 160, .2, 88.9, 2);
//            DDX_Text(pDX, IDC_EDIT_CURVE_C1, data.CurveC1);
//            DDV_MinMaxDouble(pDX, data.CurveC1, 0, 10, 0, 10, 2);
//            DDX_Text(pDX, IDC_EDIT_CURVE_C2, data.CurveC2);
//            DDV_MinMaxDouble(pDX, data.CurveC2, -2, 0, -2, 0, 2);

//            //---------------------------------------------------------------------
//            // Get and Validate Altitude or Barometric Pressure.
//            //---------------------------------------------------------------------
//            if (m_bAltitude)
//            {
//                DDX_Text(pDX, IDC_CURVE_EDIT_ALTITUDE, m_dblAltitude);
//                DDV_MinMaxDouble(pDX, m_dblAltitude, ALT_MIN_IP, ALT_MAX_IP,
//                    ALT_MIN_SI, ALT_MAX_SI, 1);
//            }
//            else
//            {
//                double dblPressure;
//                if (TPropPageBase::metricflag)
//                {
//                    dblPressure = Altitude2KPA(m_dblAltitude);
//                }
//                else
//                {
//                    dblPressure = calcPressureF(Altitude2PSI(m_dblAltitude));
//                }
//                dblPressure = truncit(dblPressure, 5);
//                DDX_Text(pDX, IDC_CURVE_EDIT_ALTITUDE, dblPressure);
//                DDV_MinMaxDouble(pDX, dblPressure, BAROMETRIC_PRESSURE_MIN_IP,
//                    BAROMETRIC_PRESSURE_MAX_IP, BAROMETRIC_PRESSURE_MIN_SI,
//                    BAROMETRIC_PRESSURE_MAX_SI, 3);
//                if (TPropPageBase::metricflag)
//                {
//                    m_dblAltitude = KPA2Altitude(dblPressure);
//                }
//                else
//                {
//                    m_dblAltitude = PSI2Altitude(calcPressureC(dblPressure));
//                }
//                m_dblAltitude = truncit(m_dblAltitude, 4);
//            }

//            //---------------------------------------------------------------------
//            // KAVL or Target Approach value
//            //---------------------------------------------------------------------
//            if (pDX && !pDX->m_bSaveAndValidate)
//            {
//                if (!m_bShowUserApproach)
//                {
//                    if (m_dblKavl > 0.001)
//                    {
//                        DDX_Text(pDX, IDC_EDIT_CURVE_KAVL, m_dblKavl);
//                    }
//                    else
//                    {
//                        CString strEmpty;
//                        DDX_Text(pDX, IDC_EDIT_CURVE_KAVL, strEmpty);
//                    }
//                }
//                else
//                {
//                    if (m_dblTargetApproach > 0.001)
//                    {
//                        DDX_Text(pDX, IDC_EDIT_CURVE_KAVL, m_dblTargetApproach);
//                    }
//                    else
//                    {
//                        CString strEmpty;
//                        DDX_Text(pDX, IDC_EDIT_CURVE_KAVL, strEmpty);
//                    }
//                }
//            }

//            GetDlgItem(IDC_BUTTON_ALTITUDE)->SetWindowText(m_strAltitudeLable);
        }

        void OnButtonAltitude()
        {
//            UpdateData(true);

//            m_bAltitude = !m_bAltitude;
//            if (m_bAltitude)
//            {
//                if (TPropPageBase::metricflag)
//                {
//                    m_strAltitude = L_METERS;
//                }
//                else
//                {
//                    m_strAltitude = L_FEET;
//                }
//                m_strAltitudeLable.LoadString(IDS_ALTITUDE);
//# ifdef _DEMO_VERSION    
//                GetDlgItem(IDC_CURVE_EDIT_ALTITUDE)->EnableWindow(false);
//#endif
//            }
//            else
//            {
//                if (TPropPageBase::metricflag)
//                {
//                    m_strAltitude = L_KPA;
//                }
//                else
//                {
//                    m_strAltitude = L_HG;
//                }
//                m_strAltitudeLable.LoadString(IDS_BAROMETRIC_PRESSURE);
//# ifdef _DEMO_VERSION    
//                GetDlgItem(IDC_CURVE_EDIT_ALTITUDE)->EnableWindow(true);
//#endif
//            }

//            UpdateData(false);
        }

        void UpdateUnits()
        {
            //if ((!TPropPageBase::metricflag) && (m_strWBT != L_DEGF))
            //{
            //    // Avoid problems with conversion at limits
            //    if (m_dblCurveWBT == WBT_MAX_SI)
            //        m_dblCurveWBT = WBT_MAX_IP;
            //    else if (m_dblCurveWBT == WBT_MIN_SI)
            //        m_dblCurveWBT = WBT_MIN_IP;
            //    else
            //        m_dblCurveWBT = truncit(fnCelcToFar(m_dblCurveWBT), 2);

            //    m_dblAltitude = truncit(fnMetersToFeet(m_dblAltitude), 2);
            //    m_dblCurveRange = truncit(m_dblCurveRange * 1.8, 2);
            //    m_strWBT = L_DEGF;
            //    m_strRange = L_DEGF;
            //}
            //else if ((TPropPageBase::metricflag) && (m_strWBT != L_DEGC))
            //{
            //    if (m_dblCurveWBT == WBT_MAX_IP)
            //        m_dblCurveWBT = WBT_MAX_SI;
            //    else if (m_dblCurveWBT == WBT_MIN_IP)
            //        m_dblCurveWBT = WBT_MIN_SI;
            //    else
            //        m_dblCurveWBT = truncit(fnFarToCelc(m_dblCurveWBT), 2);
            //    m_dblAltitude = truncit(fnFeetToMeters(m_dblAltitude), 2);
            //    m_dblCurveRange = truncit(m_dblCurveRange / 1.8, 2);
            //    m_strWBT = L_DEGC;
            //    m_strRange = L_DEGK;
            //}

            //if (m_bAltitude)
            //{
            //    if (TPropPageBase::metricflag)
            //    {
            //        m_strAltitude = L_METERS;
            //    }
            //    else
            //    {
            //        m_strAltitude = L_FEET;
            //    }
            //}
            //else
            //{
            //    if (TPropPageBase::metricflag)
            //    {
            //        m_strAltitude = L_KPA;
            //    }
            //    else
            //    {
            //        m_strAltitude = L_HG;
            //    }
            //}
        }

        void ChangeUnits()
        {
            ////---------------------------------------------------------------------
            //// Do not retrieve the data because it will be retrived incorrectly
            ////---------------------------------------------------------------------
            //UpdateUnits();
            //if (IsWindow(m_hWnd))
            //{
            //    UpdateData(false);
            //    OnCurveButtonRecalc();
            //}
        }

        void SetDefaultValues()
        {
//            //---------------------------------------------------------------------
//            // Set Default input values
//            //---------------------------------------------------------------------
//# ifdef _DEMO_VERSION
//            data.CurveC1 = 2.0;
//            data.CurveC2 = (-0.75);
//#else
//            data.CurveC1 = 0;
//            data.CurveC2 = 0;
//#endif
//            data.WaterAirRatio = 1.0;
//            m_dblAltitude = 0;
//            m_dblKavl = 0;
//            m_dblCurveMin = 0.5;
//            m_dblCurveMax = 2.5;
//            m_dblAltitude = 0;
//            if (TPropPageBase::metricflag)
//            {
//                m_dblCurveWBT = 26.667;
//                m_dblCurveRange = 18;
//            }
//            else
//            {
//                m_dblCurveWBT = 80;
//                m_dblCurveRange = 10;
//            }

//            //---------------------------------------------------------------------
//            // Set unit lables
//            //---------------------------------------------------------------------
//            if (TPropPageBase::metricflag)
//            {
//                m_strWBT = L_DEGC;
//                m_strRange = L_DEGK;
//                m_strAltitude = L_METERS;
//            }
//            else
//            {
//                m_strWBT = L_DEGF;
//                m_strRange = L_DEGF;
//                m_strAltitude = L_FEET;
//            }

//            //---------------------------------------------------------------------
//            // Curves are all initially on
//            //---------------------------------------------------------------------
//            coef = true;
//            Lg = true;
//            m_bShowKaVLLine = true;
//            bShowApproach[0] = true;
//            bShowApproach[1] = true;
//            bShowApproach[2] = true;
//            bShowApproach[3] = true;
//            bShowApproach[4] = true;
//            bShowApproach[5] = true;
//            bShowApproach[6] = true;
//            bShowApproach[7] = true;
//            bShowApproach[8] = true;
//            bShowApproach[9] = true;
//            bShowApproach[10] = true;
//            bShowApproach[11] = true;
//            bShowApproach[12] = true;
//            bShowApproach[13] = true;
//            bShowApproach[14] = true;
//            bShowApproach[15] = true;
//            bShowApproach[16] = true;
//            bShowApproach[17] = true;
//            bShowApproach[18] = true;  // Target Approach
//            bShowApproach[19] = true;  // User Approach
//            bShowApproach[20] = false;
//            bShowApproach[21] = false;
//            bShowApproach[22] = false;
//            bShowApproach[23] = false;
//            bShowApproach[24] = false;

//            m_bAltitude = true;
//            m_strAltitudeLable.LoadString(IDS_ALTITUDE);
        }

        void OnDataChanged()
        {
            //m_bDataChanged = true;
            //m_dblKavl = 0; // clear value
            //m_dblTargetApproach = 0; // clear value
            //GetDlgItem(IDC_EDIT_CURVE_KAVL)->SetWindowText("");
            //m_DynamicCurveChart.RemoveAllSeries();
        }

        bool OnInitDialog()
        {
//            cdxCSizingPropPage::OnInitDialog();

//# ifdef _DEMO_VERSION    
//            GetDlgItem(IDC_EDIT_CURVE_C1)->EnableWindow(false);
//            GetDlgItem(IDC_EDIT_CURVE_C2)->EnableWindow(false);
//            if (m_bAltitude)
//                GetDlgItem(IDC_CURVE_EDIT_ALTITUDE)->EnableWindow(false);
//#endif

//            SetHelpID(Demand_Curve_Help);
//            AddSzControl(m_DynamicCurveChart, cdxCSizingDialog::mdResize, cdxCSizingDialog::mdResize);

//            if (m_DynamicCurveChart.GetHeader().GetText().Count() > 0)
//            {
//                m_DynamicCurveChart.GetHeader().GetText().Remove(0);
//            }
//            m_DynamicCurveChart.GetPanel().SetColor(0xFFFFFF);

//            CSpinButtonCtrl* pSpin = (CSpinButtonCtrl*)GetDlgItem(IDC_EDIT_MIN);
//            m_SpinMin.SetBuddy((CWnd*)pSpin);
//            pSpin = (CSpinButtonCtrl*)GetDlgItem(IDC_EDIT_MAX);
//            m_SpinMax.SetBuddy((CWnd*)pSpin);

//            UpdateUnits();
//            UpdateData(false);
//            OnCurveButtonRecalc();
//            m_DynamicCurveChart.GetAxis().GetLeft().SetIncrement(.75);
//            m_DynamicCurveChart.GetAxis().GetBottom().SetIncrement(.5);

//            //
//            // Get list of data Files
//            //
//            CString strPath;

//            GetModuleFileName(NULL, strPath.GetBuffer(MAX_PATH + 1), MAX_PATH);
//            strPath.ReleaseBuffer();
//            strPath = strPath.Left(strPath.ReverseFind('\\') + 1);
//            strPath += "*.bbd";

//            WIN32_FIND_DATA fd;
//            HANDLE handle = FindFirstFile(strPath, &fd);

//            if (handle != INVALID_HANDLE_VALUE)
//            {
//                BOOL bFound(true);
//                while (bFound)
//                {
//                    m_wndDataFileList.AddString(fd.cFileName);
//                    bFound = FindNextFile(handle, &fd);
//                }
//                FindClose(handle);
//            }
//            m_wndDataFileList.InsertString(0, "New Data File");

//            //	UpdateData(false);

            return true;
        }

        void cdxCSizingPropPage()
        {
            //m_bDataChanged = false;
            //m_strDataName = "";

            //m_bAltitude = true;
            //m_strAltitudeLable.LoadString(IDS_ALTITUDE);
            //m_bShowUserApproach = false;
            //m_dblTargetApproach = 0.0;
            //m_dblUserApproach = 0.0;
            ////{{AFX_DATA_INIT(TPropPageThree)
            //m_dblKavl = 0.0;
            //data.WaterAirRatio = 1.0;
            //m_dblCurveMax = 0.0;
            //m_dblCurveMin = 0.0;
            //m_dblAltitude = 0.0;
            //m_strAltitude = _T("");
            //m_strRange = _T("");
            //m_strWBT = _T("");
            ////}}AFX_DATA_INIT
            //SetDefaultValues();
            //memset(m_listApp, 0, sizeof(m_listApp));
            //m_bNotified = false;
        }
    }
}