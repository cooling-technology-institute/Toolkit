// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveViewModel
    {
        public MechanicalDraftPerformanceCurveInputDataViewModel MechanicalDraftPerformanceCurveInputDataViewModel { get; set; }
        public MechanicalDraftPerformanceCurveOutputDataViewModel MechanicalDraftPerformanceCurveOutputDataViewModel { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            MechanicalDraftPerformanceCurveInputDataViewModel = new MechanicalDraftPerformanceCurveInputDataViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            MechanicalDraftPerformanceCurveOutputDataViewModel = new MechanicalDraftPerformanceCurveOutputDataViewModel(IsInternationalSystemOfUnits_SI);
        }

        #region DataValues

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.WaterFlowRateDataValue.ToolTip;
            }
        }


        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public string DryBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.DryBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string FanDriverPowerDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.FanDriverPowerDataValue.InputMessage;
            }
        }

        public string FanDriverPowerDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.FanDriverPowerDataValue.InputValue;
            }
        }

        public string FanDriverPowerDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.FanDriverPowerDataValue.ToolTip;
            }
        }

        public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputDataViewModel.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(MechanicalDraftPerformanceCurveInputDataViewModel.MechanicalDraftPerformanceCurveDataFile);
            }
        }
        
        #endregion DataValue

        public bool LoadData(string fileName, MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.LoadData(fileName, mechanicalDraftPerformanceCurveFileData, out errorMessage);
        }

        public bool SaveDataFile(out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.SaveDataFile(out errorMessage);
        }

        public bool SaveAsDataFile(string fileName, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputDataViewModel.SaveAsDataFile(fileName, out errorMessage);
        }

        public bool FillAndValidate(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            return returnValue;
        }

        public bool CalculatePerformanceCurve(MechanicalDraftPerformanceCurveTowerDesignViewModel mechanicalDraftPerformanceCurveTowerDesignViewModel, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            try
            {
                MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

                // validate test data
                if (!mechanicalDraftPerformanceCurveTowerDesignViewModel.FillAndValidate(mechanicalDraftPerformanceCurveFileData.DesignData, out errorMessage))
                {

                }

                if (!MechanicalDraftPerformanceCurveInputDataViewModel.FillAndValidate(mechanicalDraftPerformanceCurveFileData, out errorMessage))
                {

                }


                MechanicalDraftPerformanceCurveCalculationLibrary mechanicalDraftPerformanceCurveCalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

                mechanicalDraftPerformanceCurveCalculationLibrary.MechanicalDraftPerformanceCurveCalculation(mechanicalDraftPerformanceCurveFileData, MechanicalDraftPerformanceCurveOutputDataViewModel.MechanicalDraftPerformanceCurveOutput);
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
        bool ValidateData(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, bool isDesignData, StringBuilder errorMessage)
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
