// Copyright Cooling Technology Institute 2019-2020

using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewModels
{
    public class TowerDesignCurveDataViewModel
    {
        public RangedTemperaturesDesignData RangedTemperaturesDesignData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public string WetBulbTemperature1DataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.WetBulbTemperature1DataValue.InputMessage;
            }
        }

        public string WetBulbTemperature1DataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.WetBulbTemperature1DataValue.InputValue;
            }
        }

        public bool WetBulbTemperature1DataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.WetBulbTemperature1DataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperature1DataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.WetBulbTemperature1DataValue.ToolTip;
            }
        }


        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public string DryBulbTemperatureDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.DryBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string FanDriverPowerDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.FanDriverPowerDataValue.InputMessage;
            }
        }

        public string FanDriverPowerDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.FanDriverPowerDataValue.InputValue;
            }
        }

        public string FanDriverPowerDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.FanDriverPowerDataValue.ToolTip;
            }
        }

        public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return RangedTemperaturesDesignData.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue1InputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue1.InputMessage;
            }
        }

        public string RangeDataValue1InputValue
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue1.InputValue;
            }
        }

        public string RangeDataValue1Tooltip
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue1.ToolTip;
            }
        }

        public bool RangeDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.RangeDataValue1.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue2InputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue2.InputMessage;
            }
        }

        public string RangeDataValue2InputValue
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue2.InputValue;
            }
        }

        public string RangeDataValue2Tooltip
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue2.ToolTip;
            }
        }

        public bool RangeDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.RangeDataValue2.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue3InputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue3.InputMessage;
            }
        }

        public string RangeDataValue3InputValue
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue3.InputValue;
            }
        }

        public string RangeDataValue3Tooltip
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue3.ToolTip;
            }
        }

        public bool RangeDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.RangeDataValue3.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue4InputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string RangeDataValue4InputValue
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue4.InputValue;
            }
        }

        public string RangeDataValue4Tooltip
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue4.ToolTip;
            }
        }

        public bool RangeDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.RangeDataValue4.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValue5InputMessage
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue5.InputMessage;
            }
        }

        public string RangeDataValue5InputValue
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue5.InputValue;
            }
        }

        public string RangeDataValue5Tooltip
        {
            get
            {
                return RangedTemperaturesDesignData.RangeDataValue5.ToolTip;
            }
        }

        public bool RangeDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperaturesDesignData.RangeDataValue5.UpdateValue(value, out errorMessage);
        }

        public string OwnerNameInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.OwnerName;
            }
        }

        public string ProjectNameInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.ProjectName;
            }
        }

        public string LocationInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.Location;
            }
        }

        public string TowerManufacturerInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.TowerManufacturer;
            }
        }

        public TOWER_TYPE TowerTypeInputValue
        {
            get
            {
                return RangedTemperaturesDesignData.TowerType;
            }
        }

        public List<TabPage> TowerDesignDataCurveDataTabPages
        {
            get
            {

            }
        }

        public TowerDesignCurveDataViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            RangedTemperaturesDesignData = new RangedTemperaturesDesignData(IsDemo, IsInternationalSystemOfUnits_IS);
        }

    }
}
