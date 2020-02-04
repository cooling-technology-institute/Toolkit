// Copyright Cooling Technology Institute 2019-2020

using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignViewModel
    {
        public MechanicalDraftPerformanceCurveTowerDesignInputData MechanicalDraftPerformanceCurveTowerDesignInputData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WaterFlowRateDataValue.ToolTip;
            }
        }


        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public string DryBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.DryBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string FanDriverPowerDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.FanDriverPowerDataValue.InputMessage;
            }
        }

        public string FanDriverPowerDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.FanDriverPowerDataValue.InputValue;
            }
        }

        public string FanDriverPowerDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.FanDriverPowerDataValue.ToolTip;
            }
        }

        public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue1InputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue1.InputMessage;
            }
        }

        public string RangeDataValue1InputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue1.InputValue;
            }
        }

        public string RangeDataValue1Tooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue1.ToolTip;
            }
        }

        public bool RangeDataValue1UpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue1.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue2InputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue2.InputMessage;
            }
        }

        public string RangeDataValue2InputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue2.InputValue;
            }
        }

        public string RangeDataValue2Tooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue2.ToolTip;
            }
        }

        public bool RangeDataValue2UpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue2.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue3InputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue3.InputMessage;
            }
        }

        public string RangeDataValue3InputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue3.InputValue;
            }
        }

        public string RangeDataValue3Tooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue3.ToolTip;
            }
        }

        public bool RangeDataValue3UpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue3.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue4InputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string RangeDataValue4InputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue4.InputValue;
            }
        }

        public string RangeDataValue4Tooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue4.ToolTip;
            }
        }

        public bool RangeDataValue4UpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue4.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue5InputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue5.InputMessage;
            }
        }

        public string RangeDataValue5InputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue5.InputValue;
            }
        }

        public string RangeDataValue5Tooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue5.ToolTip;
            }
        }

        public bool RangeDataValue5UpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.RangeDataValue5.UpdateValue(value, out errorMessage);
        }

        public string OwnerNameInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.OwnerName;
            }
        }

        public string ProjectNameInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.ProjectName;
            }
        }

        public string LocationInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.Location;
            }
        }

        public string TowerManufacturerInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.TowerManufacturer;
            }
        }

        public TOWER_TYPE TowerTypeInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.TowerType;
            }
        }

        public List<TabPage> TowerDesignDataCurveDataTabPages
        {
            get
            {
                return new List<TabPage>();
            }
        }

        public MechanicalDraftPerformanceCurveTowerDesignViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            MechanicalDraftPerformanceCurveTowerDesignInputData = new MechanicalDraftPerformanceCurveTowerDesignInputData(IsDemo, IsInternationalSystemOfUnits_IS);
        }
    }
}
