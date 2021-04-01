// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveViewModel
    {
        public TowerDesignData DesignData { get; set; }
        public List<TowerTestPoint> TestPoints { get; set; }

        public MechanicalDraftPerformanceCurveOutputDataViewModel OutputDataViewModel { get; set; }

        public string DataFileName { get; set; }
        
        public MechanicalDraftPerformanceCurveFileData MechanicalDraftPerformanceCurveFileData;

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public string ErrorMessage { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            ErrorMessage = string.Empty;

            DesignData = new TowerDesignData(IsDemo, IsInternationalSystemOfUnits_SI);
            TestPoints = new List<TowerTestPoint>();

            OutputDataViewModel = new MechanicalDraftPerformanceCurveOutputDataViewModel(IsInternationalSystemOfUnits_SI);

            BuildFilename();

            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);
        }

        public bool SwitchUnits(bool isIS)
        {
            bool isChange = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                ConvertValues(isIS);
            }
            return isChange;
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChange = false;

            isChange |= DesignData.ConvertValues(isIS);
            foreach (TowerTestPoint towerTestPoint in TestPoints)
            {
                isChange |= towerTestPoint.ConvertValues(isIS);
            }
            return isChange;
        }

        public void BuildFilename()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
            int i = 1;

            do
            {
                DataFileName = Path.Combine(path, string.Format("MechanicalDraftPerformanceCurve{0}.mdpc", i++));
                if(File.Exists(DataFileName))
                {
                    DataFileName = string.Empty;
                }

            } while (string.IsNullOrEmpty(DataFileName));
        }

        public bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;
            ErrorMessage = string.Empty;

            try
            {
                MechanicalDraftPerformanceCurveFileData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveFileData>(File.ReadAllText(DataFileName));
            }
            catch (Exception e)
            {
                stringBuilder.AppendFormat("Failure to read file: {0}. Exception: {1}\n", Path.GetFileName(DataFileName), e.ToString());
                returnValue = false;
            }

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if(MechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    //ToolkitMain,UpdateU
                    SwitchUnits(MechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI);
                }

                if (!LoadData())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }

            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool OpenNewDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            DataFileName = fileName;
            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if (!LoadData())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to create new file.");
                returnValue = false;
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        #region DataValues

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(DataFileName);
            }
        }
        
        #endregion DataValue

        public bool LoadData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if(MechanicalDraftPerformanceCurveFileData != null)
            {
                if (!DesignData.LoadData(MechanicalDraftPerformanceCurveFileData.DesignData))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(DesignData.ErrorMessage);
                }
                
                TestPoints.Clear();
                foreach (TowerTestData testData in MechanicalDraftPerformanceCurveFileData.TestData)
                {
                    TowerTestPoint towerTestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI);
                    if (!towerTestPoint.LoadData(IsInternationalSystemOfUnits_SI, testData))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(string.Format("Test {0}: {1}", towerTestPoint.TestName, towerTestPoint.ErrorMessage));
                    }
                    TestPoints.Add(towerTestPoint);
                }
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            return returnValue;
        }

        public bool FillFileData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (!DesignData.FillFileData(MechanicalDraftPerformanceCurveFileData.DesignData))
            {
                returnValue = false;
                stringBuilder.AppendLine(DesignData.ErrorMessage);
            }

            MechanicalDraftPerformanceCurveFileData.TestData.Clear();

            foreach (TowerTestPoint towerTestPoint in TestPoints)
            {
                TowerTestData towerTestData = new TowerTestData(IsInternationalSystemOfUnits_SI);
                if (!towerTestPoint.FillFileData(towerTestData))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(string.Format("Test {0}: {1}", towerTestPoint.TestName, towerTestPoint.ErrorMessage));
                }
                MechanicalDraftPerformanceCurveFileData.TestData.Add(towerTestData);
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool FillCalculationData(int testIndex, MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            calculationData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            if (!DesignData.FillCalculationData(calculationData))
            {
                returnValue = false;
                stringBuilder.AppendLine(DesignData.ErrorMessage);
            }

            MechanicalDraftPerformanceCurveFileData.TestData.Clear();

            if (!TestPoints[testIndex].FillCalculationData(calculationData))
            {
                returnValue = false;
                stringBuilder.AppendLine(string.Format("Test {0}: {1}", TestPoints[testIndex].TestName, TestPoints[testIndex].ErrorMessage));
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool CalculatePerformanceCurve(int testIndex)
        {
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            string errorMessage = string.Empty;

            try
            {
                if (DesignData.ValidateRanges(3, out errorMessage))
                {
                    if (DesignData.ValidateWaterFlowRates(3, out errorMessage))
                    {
                        if (DesignData.ValidateRangedTemperatures(3, out errorMessage))
                        {
                            MechanicalDraftPerformanceCurveCalculationData calculationData = new MechanicalDraftPerformanceCurveCalculationData();
                            if (FillCalculationData(testIndex, calculationData))
                            {
                                MechanicalDraftPerformanceCurveCalculationLibrary calculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

                                calculationLibrary.MechanicalDraftPerformanceCurveCalculation(calculationData, OutputDataViewModel.MechanicalDraftPerformanceCurveOutput, true);

                                OutputDataViewModel.FillTable();
                            }
                            else
                            {
                                returnValue = false;
                                stringBuilder.AppendLine(ErrorMessage);
                            }
                        }
                        else
                        {
                            stringBuilder.AppendLine(errorMessage);
                            errorMessage = string.Empty;
                            returnValue = false;
                        }
                    }
                    else
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                }
                else
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }
            }
            catch (Exception exception)
            {
                stringBuilder.AppendFormat("Error in Performance Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            return returnValue;
        }

        public DataTable GetDataTable()
        {
            return OutputDataViewModel.NameValueUnitsDataTable.DataTable;
        }

        // Check design or test data, optionally prompting the user with bounds if errors are found.
        bool ValidateData(Models.TowerSpecifications mechanicalDraftPerformanceCurveData, bool isDesignData, StringBuilder errorMessage)
        {
            //bool isError = (isWaterFlowRateError || isHotWaterTemperatureError || isColdWaterTemperatureError || isWetBulbTemperatureError || isDryBulbTemperatureError || isFanDriverPowerError ||
            //    isBarometricPressureError || isLiquidGasRatioError);

            //// If requested, display a message box pointing out the errors and displaying
            //// the min and max values for each.
            //if (isError)
            //{
            //    string type = isDesignData ? "Design" : "Test";

            //    errorMessage.AppendFormat("Your {0} data is out of range for calculating % Capability.\n\n Please check the following {0} values:\n\n", type);
            //    int i = 1;
            //    if (isWaterFlowRateError)
            //    {
            //        errorMessage.AppendFormat("{0}. Water Flow Rate:   min = {1},   max = {2}\n", i++, minimum.WaterFlowRate, maximum.WaterFlowRate);
            //    }
            //    if (isHotWaterTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Hot Water Temperature:   min = {1},   max = {2}\n", i++, minimum.HotWaterTemperature, maximum.HotWaterTemperature);
            //    }
            //    if (isColdWaterTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Cold Water Temperature:   min = {1},   max = {2}\n", i++, minimum.ColdWaterTemperature, maximum.ColdWaterTemperature);
            //    }
            //    if (isWetBulbTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Wet Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.WetBulbTemperature, maximum.WetBulbTemperature);
            //    }
            //    if (isDryBulbTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Dry Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.DryBulbTemperature, maximum.DryBulbTemperature);
            //    }
            //    if (isFanDriverPowerError)
            //    {
            //        errorMessage.AppendFormat("{0}. Fan Driver Power:   min = {1},   max = {2}\n", i++, minimum.FanDriverPower, maximum.FanDriverPower);
            //    }
            //    if (isBarometricPressureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Barometric Pressure:   min = {1},   max = {2}\n", i++, minimum.BarometricPressure, maximum.BarometricPressure);
            //    }
            //    if (isLiquidGasRatioError)
            //    {
            //        errorMessage.AppendFormat("{0}. Liquid to Gas Ratio:   min = {1},   max = {2}\n", i++, minimum.LiquidToGasRatio, maximum.LiquidToGasRatio);
            //    }
            //}
            return true;// !isError;
        }

        public bool AddTestPoint(string testName)
        {
            bool returnValue = true;
            ErrorMessage = string.Empty;

            try
            {
                TowerTestPoint towerTestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI);
                towerTestPoint.TestName = testName;
                TestPoints.Add(towerTestPoint);
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

    }
}
