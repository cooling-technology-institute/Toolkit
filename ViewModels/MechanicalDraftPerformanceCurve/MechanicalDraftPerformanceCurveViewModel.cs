// Copyright Cooling Technology Institute 2019-2020

using Models;
using System.Collections.Generic;
using System.IO;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveViewModel
    {
        public MechanicalDraftPerformanceCurveInputData MechanicalDraftPerformanceCurveInputData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

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

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            MechanicalDraftPerformanceCurveInputData = new MechanicalDraftPerformanceCurveInputData(IsDemo, IsInternationalSystemOfUnits_IS);
        }

        public MechanicalDraftPerformanceCurveData GetData()
        {
            return MechanicalDraftPerformanceCurveInputData.Data;
        }

        public void OpenDataFile(string fileName)
        {
            MechanicalDraftPerformanceCurveInputData.OpenDataFile(fileName);
        }

        public void SaveDataFile()
        {
            MechanicalDraftPerformanceCurveInputData.SaveDataFile();
        }

        public void SaveAsDataFile(string fileName)
        {
            MechanicalDraftPerformanceCurveInputData.SaveAsDataFile(fileName);
        }

    }
}
