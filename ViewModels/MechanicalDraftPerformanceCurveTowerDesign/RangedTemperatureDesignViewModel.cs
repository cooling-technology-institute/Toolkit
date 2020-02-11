// Copyright Cooling Technology Institute 2019-2020

using Models;

namespace ViewModels
{
    public class RangedTemperatureDesignViewModel
    {
        public RangedTemperatureDesignInputData RangedTemperatureDesignInputData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public RangedTemperatureDesignViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            RangedTemperatureDesignInputData = new RangedTemperatureDesignInputData(IsDemo, IsInternationalSystemOfUnits_SI);
        }

        #region DataValueAccess

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WaterFlowRateDataValue.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue1InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue1.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue1InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue1.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue1Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue1.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue2InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue2.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue2InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue2.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue2Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue2.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue3InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue3.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue3InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue3.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue3Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue3.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue4InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue4.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue4InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue4.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue4Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue4.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue5InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue5.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue5InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue5.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue5Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue5.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue6InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue6.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue6InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue6.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue6Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.WetBulbTemperatureDataValue6.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range1ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue2.ToolTip;
            }
        }
        public string Range2ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue5.ToolTip;
            }
        }


        public string Range2ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range2ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range3ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range4ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return RangedTemperatureDesignInputData.Range5ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        #endregion DataValueAccess

        public bool LoadData(bool isInternationalSystemOfUnits_IS, RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;
            return RangedTemperatureDesignInputData.LoadData(isInternationalSystemOfUnits_IS, rangedTemperaturesDesignData, out errorMessage);
        }

        public bool FillAndValidate(ref RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;

            bool returnValue = RangedTemperatureDesignInputData.FillAndValidate(ref rangedTemperaturesDesignData, out errorMessage);

            return returnValue;
        }

        public int CountWetBulbTemperatures()
        {
            return RangedTemperatureDesignInputData.CountWetBulbTemperatures();
        }

    }
}
