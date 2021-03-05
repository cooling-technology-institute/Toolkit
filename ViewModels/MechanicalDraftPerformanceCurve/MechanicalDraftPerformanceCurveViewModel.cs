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
        public TowerTestPoint TestPoint { get; set; }
        public MechanicalDraftPerformanceCurveOutputDataViewModel MechanicalDraftPerformanceCurveOutputDataViewModel { get; set; }
        public List<string> TestNames { get; set; }

        public string DataFileName { get; set; }
        
        MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData;

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            DesignData = new TowerDesignData(IsDemo, IsInternationalSystemOfUnits_SI);
            TestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI);
            TestNames = new List<string>();

            MechanicalDraftPerformanceCurveOutputDataViewModel = new MechanicalDraftPerformanceCurveOutputDataViewModel(IsInternationalSystemOfUnits_SI);
        }

        public bool OpenDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            try
            {
                mechanicalDraftPerformanceCurveFileData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveFileData>(File.ReadAllText(fileName));
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to read file: {0}. Exception: {1}", Path.GetFileName(fileName), e.ToString());
                return false;
            }

            if (mechanicalDraftPerformanceCurveFileData != null)
            {
                if (IsInternationalSystemOfUnits_SI != mechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI)
                {
                    IsInternationalSystemOfUnits_SI = mechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI;
                }

                if (!LoadData(-1, mechanicalDraftPerformanceCurveFileData, out errorMessage))
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

        public bool LoadData(int testIndex, MechanicalDraftPerformanceCurveFileData fileData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            TestNames.Clear();
            foreach (Models.TowerTestData test in fileData.TestData)
            {
                TestNames.Add(test.TestName);
            }

            if(!DesignData.LoadData(fileData.DesignData, out errorMessage))
            {
                returnValue = false;
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
            }

            if (!TestPoint.LoadData(testIndex, fileData.TestData, out errorMessage))
            {
                returnValue = false;
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
            }

            return returnValue;
        }

        public bool FillAndValidate(int testIndex, MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (!DesignData.FillAndValidate(mechanicalDraftPerformanceCurveFileData.DesignData, out errorMessage))
            {
                returnValue = false;
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
            }

            if (!TestPoint.FillAndValidate(mechanicalDraftPerformanceCurveFileData.TestData[testIndex], out errorMessage))
            {
                returnValue = false;
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
            }

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
    }
}
