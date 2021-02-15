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
        const double WATER_FLOW_RATE_MIN_IP = 0.1;
        const double WATER_FLOW_RATE_MAX_IP = double.MaxValue;
        const double WATER_FLOW_RATE_MIN_SI = 0.1;
        const double WATER_FLOW_RATE_MAX_SI = double.MaxValue;
        const double HOT_WATER_TEMPERATURE_MIN_IP = 32.0;
        const double HOT_WATER_TEMPERATURE_MAX_IP = 212.0;
        const double HOT_WATER_TEMPERATURE_MIN_SI = 0.0;
        const double HOT_WATER_TEMPERATURE_MAX_SI = 100.0;
        const double COLD_WATER_TEMPERATURE_MIN_IP = 32.0;
        const double COLD_WATER_TEMPERATURE_MAX_IP = 212.0;
        const double COLD_WATER_TEMPERATURE_MIN_SI = 0.0;
        const double COLD_WATER_TEMPERATURE_MAX_SI = 100.0;
        const double WetBulbTemperature_MIN_IP = 0.0;
        const double WetBulbTemperature_MAX_IP = 200.0;
        const double WetBulbTemperature_MIN_SI = -18.0;
        const double WetBulbTemperature_MAX_SI = 93.0;
        const double DryBulbTemperature_MIN_IP = 0.0;
        const double DryBulbTemperature_MAX_IP = 200.0;
        const double DryBulbTemperature_MIN_SI = -18.0;
        const double DryBulbTemperature_MAX_SI = 93.0;
        const double FAN_DRIVER_POWER_MIN_IP = 0.0001;
        const double FAN_DRIVER_POWER_MAX_IP = 1000.0;
        const double FAN_DRIVER_POWER_MIN_SI = 0.0001;
        const double FAN_DRIVER_POWER_MAX_SI = 745.7;
        const double BAROMETRIC_PRESSURE_MIN_IP = 5.0;
        const double BAROMETRIC_PRESSURE_MAX_IP = 31.5;
        const double BAROMETRIC_PRESSURE_MIN_SI = 16.932;
        const double BAROMETRIC_PRESSURE_MAX_SI = 103.285;
        const double LiquidGasRatio_MIN_IP = 0.01;
        const double LiquidGasRatio_MAX_IP = 20.0;
        const double LiquidGasRatio_MIN_SI = 0.01;
        const double LiquidGasRatio_MAX_SI = 20.0;

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MinIP = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = false,
            WaterFlowRate = WATER_FLOW_RATE_MIN_IP,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MIN_IP,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MIN_IP,
            WetBulbTemperature = WetBulbTemperature_MIN_IP,
            DryBulbTemperature = DryBulbTemperature_MIN_IP,
            FanDriverPower = FAN_DRIVER_POWER_MIN_IP,
            BarometricPressure = BAROMETRIC_PRESSURE_MIN_IP,
            LiquidToGasRatio = LiquidGasRatio_MIN_IP,
        };

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MaxIP = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = false,
            WaterFlowRate = WATER_FLOW_RATE_MAX_IP,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MAX_IP,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MAX_IP,
            WetBulbTemperature = WetBulbTemperature_MAX_IP,
            DryBulbTemperature = DryBulbTemperature_MAX_IP,
            FanDriverPower = FAN_DRIVER_POWER_MAX_IP,
            BarometricPressure = BAROMETRIC_PRESSURE_MAX_IP,
            LiquidToGasRatio = LiquidGasRatio_MAX_IP,
        };

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MinSI = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = true,
            WaterFlowRate = WATER_FLOW_RATE_MIN_SI,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MIN_SI,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MIN_SI,
            WetBulbTemperature = WetBulbTemperature_MIN_SI,
            DryBulbTemperature = DryBulbTemperature_MIN_SI,
            FanDriverPower = FAN_DRIVER_POWER_MIN_SI,
            BarometricPressure = BAROMETRIC_PRESSURE_MIN_SI,
            LiquidToGasRatio = LiquidGasRatio_MIN_SI,
        };

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MaxSI = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = true,
            WaterFlowRate = WATER_FLOW_RATE_MAX_SI,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MAX_SI,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MAX_SI,
            WetBulbTemperature = WetBulbTemperature_MAX_SI,
            DryBulbTemperature = DryBulbTemperature_MAX_SI,
            FanDriverPower = FAN_DRIVER_POWER_MAX_SI,
            BarometricPressure = BAROMETRIC_PRESSURE_MAX_SI,
            LiquidToGasRatio = LiquidGasRatio_MAX_SI,
        };

        public MechanicalDraftPerformanceCurveInputData MechanicalDraftPerformanceCurveInputData { get; set; }
        public MechanicalDraftPerformanceCurveOutputData MechanicalDraftPerformanceCurveOutputData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            MechanicalDraftPerformanceCurveInputData = new MechanicalDraftPerformanceCurveInputData(IsDemo, IsInternationalSystemOfUnits_SI);
            MechanicalDraftPerformanceCurveOutputData = new MechanicalDraftPerformanceCurveOutputData(IsInternationalSystemOfUnits_SI);
        }

        #region DataValues

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.ToolTip;
            }
        }


        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public string DryBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string FanDriverPowerDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.InputMessage;
            }
        }

        public string FanDriverPowerDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.InputValue;
            }
        }

        public string FanDriverPowerDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.ToolTip;
            }
        }

        public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(MechanicalDraftPerformanceCurveInputData.MechanicalDraftPerformanceCurveDataFile);
            }
        }
        
        #endregion DataValue

        public bool LoadData(string fileName, MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.LoadData(fileName, mechanicalDraftPerformanceCurveFileData, out errorMessage);
        }

        public bool SaveDataFile(out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.SaveDataFile(out errorMessage);
        }

        public bool SaveAsDataFile(string fileName, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.SaveAsDataFile(fileName, out errorMessage);
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

                if (!MechanicalDraftPerformanceCurveInputData.FillAndValidate(mechanicalDraftPerformanceCurveFileData, out errorMessage))
                {

                }


                MechanicalDraftPerformanceCurveCalculationLibrary mechanicalDraftPerformanceCurveCalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

                mechanicalDraftPerformanceCurveCalculationLibrary.MechanicalDraftPerformanceCurveCalculation(mechanicalDraftPerformanceCurveFileData, MechanicalDraftPerformanceCurveOutputData.MechanicalDraftPerformanceCurveOutput);
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Performance Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
            }
            return returnValue;
        }

        public DataTable GetDataTable()
        {
            return MechanicalDraftPerformanceCurveOutputData.NameValueUnitsDataTable.DataTable;
        }

        // Check design or test data, optionally prompting the user with bounds if errors are found.
        bool ValidateData(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, bool isDesignData, StringBuilder errorMessage)
        {
            bool isWaterFlowRateError, isHotWaterTemperatureError, isColdWaterTemperatureError, isWetBulbTemperatureError, isDryBulbTemperatureError, isFanDriverPowerError, isBarometricPressureError, isLiquidGasRatioError;

            MechanicalDraftPerformanceCurveData minimum = new MechanicalDraftPerformanceCurveData();
            MechanicalDraftPerformanceCurveData maximum = new MechanicalDraftPerformanceCurveData();

            if (mechanicalDraftPerformanceCurveData.IsInternationalSystemOfUnits_SI)
            {
                minimum = MechanicalDraftPerformanceCurveData_MinSI;
                maximum = MechanicalDraftPerformanceCurveData_MaxSI;
            }
            else
            {
                minimum = MechanicalDraftPerformanceCurveData_MinIP;
                maximum = MechanicalDraftPerformanceCurveData_MaxIP;
            }

            //MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData(*this, bDesignData);

            // Check each value against min and max bounds
            isWaterFlowRateError = ((mechanicalDraftPerformanceCurveData.WaterFlowRate < minimum.WaterFlowRate) || (mechanicalDraftPerformanceCurveData.WaterFlowRate > maximum.WaterFlowRate));

            isHotWaterTemperatureError = ((mechanicalDraftPerformanceCurveData.HotWaterTemperature < minimum.HotWaterTemperature) 
                                   || (mechanicalDraftPerformanceCurveData.HotWaterTemperature > maximum.HotWaterTemperature) 
                                   || (mechanicalDraftPerformanceCurveData.HotWaterTemperature <= mechanicalDraftPerformanceCurveData.ColdWaterTemperature));

            isColdWaterTemperatureError = ((mechanicalDraftPerformanceCurveData.ColdWaterTemperature < minimum.ColdWaterTemperature) 
                                    || (mechanicalDraftPerformanceCurveData.ColdWaterTemperature > maximum.ColdWaterTemperature));

            isWetBulbTemperatureError = ((mechanicalDraftPerformanceCurveData.WetBulbTemperature < minimum.WetBulbTemperature) 
                                  || (mechanicalDraftPerformanceCurveData.WetBulbTemperature > maximum.WetBulbTemperature));

            isDryBulbTemperatureError = ((mechanicalDraftPerformanceCurveData.DryBulbTemperature < minimum.DryBulbTemperature) 
                                  || (mechanicalDraftPerformanceCurveData.DryBulbTemperature > maximum.DryBulbTemperature) 
                                  || (mechanicalDraftPerformanceCurveData.DryBulbTemperature < mechanicalDraftPerformanceCurveData.WetBulbTemperature));

            isFanDriverPowerError = ((mechanicalDraftPerformanceCurveData.FanDriverPower < minimum.FanDriverPower) 
                              || (mechanicalDraftPerformanceCurveData.FanDriverPower > maximum.FanDriverPower));

            isBarometricPressureError = ((mechanicalDraftPerformanceCurveData.BarometricPressure < minimum.BarometricPressure) 
                                  || (mechanicalDraftPerformanceCurveData.BarometricPressure > maximum.BarometricPressure));

            if (isDesignData)
                isLiquidGasRatioError = ((mechanicalDraftPerformanceCurveData.LiquidToGasRatio < minimum.LiquidToGasRatio) || (mechanicalDraftPerformanceCurveData.LiquidToGasRatio > maximum.LiquidToGasRatio));
            else
                isLiquidGasRatioError = false;

            bool isError = (isWaterFlowRateError || isHotWaterTemperatureError || isColdWaterTemperatureError || isWetBulbTemperatureError || isDryBulbTemperatureError || isFanDriverPowerError ||
                isBarometricPressureError || isLiquidGasRatioError);

            // If requested, display a message box pointing out the errors and displaying
            // the min and max values for each.
            if (isError)
            {
                string type = isDesignData ? "Design" : "Test";
                
                errorMessage.AppendFormat("Your {0} data is out of range for calculating % Capability.\n\n Please check the following {0} values:\n\n", type);
                int i = 1;
                if (isWaterFlowRateError)
                {
                    errorMessage.AppendFormat("{0}. Water Flow Rate:   min = {1},   max = {2}\n", i++, minimum.WaterFlowRate, maximum.WaterFlowRate);
                }
                if (isHotWaterTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Hot Water Temperature:   min = {1},   max = {2}\n", i++, minimum.HotWaterTemperature, maximum.HotWaterTemperature);
                }
                if (isColdWaterTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Cold Water Temperature:   min = {1},   max = {2}\n", i++, minimum.ColdWaterTemperature, maximum.ColdWaterTemperature);
                }
                if (isWetBulbTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Wet Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.WetBulbTemperature, maximum.WetBulbTemperature);
                }
                if (isDryBulbTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Dry Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.DryBulbTemperature, maximum.DryBulbTemperature);
                }
                if (isFanDriverPowerError)
                {
                    errorMessage.AppendFormat("{0}. Fan Driver Power:   min = {1},   max = {2}\n", i++, minimum.FanDriverPower, maximum.FanDriverPower);
                }
                if (isBarometricPressureError)
                {
                    errorMessage.AppendFormat("{0}. Barometric Pressure:   min = {1},   max = {2}\n", i++, minimum.BarometricPressure, maximum.BarometricPressure);
                }
                if (isLiquidGasRatioError)
                {
                    errorMessage.AppendFormat("{0}. Liquid to Gas Ratio:   min = {1},   max = {2}\n", i++, minimum.LiquidToGasRatio, maximum.LiquidToGasRatio);
                }
            }
            return !isError;
        }
    }
}
