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

        public MechanicalDraftPerformanceCurveOutputDataViewModel MechanicalDraftPerformanceCurveOutputDataViewModel { get; set; }

        private MechanicalDraftPerformanceCurveFileData fileData { get; set; }

        public string DataFileName { get; set; }
        
        MechanicalDraftPerformanceCurveFileData MechanicalDraftPerformanceCurveFileData;

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            DesignData = new TowerDesignData(IsDemo, IsInternationalSystemOfUnits_SI);
            TestPoints = new List<TowerTestPoint>();

            MechanicalDraftPerformanceCurveOutputDataViewModel = new MechanicalDraftPerformanceCurveOutputDataViewModel(IsInternationalSystemOfUnits_SI);

            BuildFilename();

            fileData = new MechanicalDraftPerformanceCurveFileData(isInternationalSystemOfUnits_IS_);
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

        public bool OpenDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;

            try
            {
                MechanicalDraftPerformanceCurveFileData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveFileData>(File.ReadAllText(DataFileName));
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to read file: {0}. Exception: {1}", Path.GetFileName(DataFileName), e.ToString());
                return false;
            }

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if (IsInternationalSystemOfUnits_SI != MechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI)
                {
                    IsInternationalSystemOfUnits_SI = MechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI;
                }

                if (!LoadData(out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    returnValue = false;
                    errorMessage = string.Empty;
                }

            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
            }

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        public bool OpenNewDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;
            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if (!LoadData(out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    returnValue = false;
                    errorMessage = string.Empty;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to create new file.");
            }

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        #region DataValues

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return DesignData.WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return DesignData.WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return DesignData.WaterFlowRateDataValue.ToolTip;
            }
        }


        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return DesignData.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return DesignData.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return DesignData.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return DesignData.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return DesignData.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return DesignData.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return DesignData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return DesignData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return DesignData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return DesignData.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return DesignData.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public string DryBulbTemperatureDataValueTooltip
        {
            get
            {
                return DesignData.DryBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string FanDriverPowerDataValueInputMessage
        {
            get
            {
                return DesignData.FanDriverPowerDataValue.InputMessage;
            }
        }

        public string FanDriverPowerDataValueInputValue
        {
            get
            {
                return DesignData.FanDriverPowerDataValue.InputValue;
            }
        }

        public string FanDriverPowerDataValueTooltip
        {
            get
            {
                return DesignData.FanDriverPowerDataValue.ToolTip;
            }
        }

        public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return DesignData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return DesignData.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return DesignData.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return DesignData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return DesignData.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return DesignData.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return DesignData.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(DataFileName);
            }
        }
        
        #endregion DataValue

        public bool LoadData(out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if(MechanicalDraftPerformanceCurveFileData != null)
            {
                if (!DesignData.LoadData(MechanicalDraftPerformanceCurveFileData.DesignData, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                foreach (TowerTestData testData in MechanicalDraftPerformanceCurveFileData.TestData)
                {
                    TowerTestPoint towerTestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI);
                    if (!towerTestPoint.LoadData(IsInternationalSystemOfUnits_SI, testData, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(string.Format("Test {0}: {1}", towerTestPoint.TestName, errorMessage));
                        errorMessage = string.Empty;
                    }
                    TestPoints.Add(towerTestPoint);
                }
            }
            return returnValue;
        }

        public bool FillAndValidate(int testIndex, MechanicalDraftPerformanceCurveFileData fileData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (!DesignData.FillAndValidate(fileData.DesignData, out errorMessage))
            {
                returnValue = false;
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
            }

            fileData.TestData.Clear();

            foreach (TowerTestPoint towerTestPoint in TestPoints)
            {
                TowerTestData towerTestData = new TowerTestData(IsInternationalSystemOfUnits_SI);
                if (!towerTestPoint.FillAndValidate(towerTestData, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(string.Format("Test {0}: {1}", towerTestPoint.TestName, errorMessage));
                    errorMessage = string.Empty;
                }
                fileData.TestData.Add(towerTestData);
            }

            //if (!TestPoints.FillAndValidate(mechanicalDraftPerformanceCurveFileData.TestData[testIndex], out errorMessage))
            //{
            //    returnValue = false;
            //    stringBuilder.AppendLine(errorMessage);
            //    errorMessage = string.Empty;
            //}

            return returnValue;
        }

        public bool CalculatePerformanceCurve(int testIndex, MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            try
            {
                //MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

                //// validate test data
                //if (!mechanicalDraftPerformanceCurveTowerDesignViewModel.FillAndValidate(mechanicalDraftPerformanceCurveFileData.DesignData, out errorMessage))
                //{

                //}

                //if (!DesignData.FillAndValidate(mechanicalDraftPerformanceCurveFileData, out errorMessage))
                //{

                //}


                MechanicalDraftPerformanceCurveCalculationLibrary mechanicalDraftPerformanceCurveCalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

                mechanicalDraftPerformanceCurveCalculationLibrary.MechanicalDraftPerformanceCurveCalculation(testIndex, mechanicalDraftPerformanceCurveFileData, MechanicalDraftPerformanceCurveOutputDataViewModel.MechanicalDraftPerformanceCurveOutput);
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Performance Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
            }
            return returnValue;
        }

        public DataTable GetDataTable()
        {
            return MechanicalDraftPerformanceCurveOutputDataViewModel.NameValueUnitsDataTable.DataTable;
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

        public bool AddTestPoint(string testName, out string errorMessage)
        {
            bool returnValue = true;

            try
            {
                TowerTestPoint towerTestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI);
                towerTestPoint.TestName = testName;
                TestPoints.Add(towerTestPoint);
                errorMessage = string.Empty;
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

    }
}
