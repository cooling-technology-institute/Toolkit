// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;

namespace ViewModels
{
    public class TowerDesignCurveData
    {
        public WaterFlowRateDataValue WaterFlowRateDataValue { set; get; }

        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue1 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue2 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue3 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue4 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue5 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue6 { set; get; }


        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue6 { set; get; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerDesignCurveData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue1 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue2 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue3 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue4 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue5 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue6 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range1ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range2ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range3ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range4ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range5ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
        }

        #region DataValueAccess

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return WaterFlowRateDataValue.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue1InputMessage
        {
            get
            {
                return WetBulbTemperatureDataValue1.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue1InputValue
        {
            get
            {
                return WetBulbTemperatureDataValue1.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return WetBulbTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue1Tooltip
        {
            get
            {
                return WetBulbTemperatureDataValue1.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue2InputMessage
        {
            get
            {
                return WetBulbTemperatureDataValue2.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue2InputValue
        {
            get
            {
                return WetBulbTemperatureDataValue2.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return WetBulbTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue2Tooltip
        {
            get
            {
                return WetBulbTemperatureDataValue2.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue3InputMessage
        {
            get
            {
                return WetBulbTemperatureDataValue3.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue3InputValue
        {
            get
            {
                return WetBulbTemperatureDataValue3.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return WetBulbTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue3Tooltip
        {
            get
            {
                return WetBulbTemperatureDataValue3.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue4InputMessage
        {
            get
            {
                return WetBulbTemperatureDataValue4.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue4InputValue
        {
            get
            {
                return WetBulbTemperatureDataValue4.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return WetBulbTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue4Tooltip
        {
            get
            {
                return WetBulbTemperatureDataValue4.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue5InputMessage
        {
            get
            {
                return WetBulbTemperatureDataValue5.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue5InputValue
        {
            get
            {
                return WetBulbTemperatureDataValue5.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return WetBulbTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue5Tooltip
        {
            get
            {
                return WetBulbTemperatureDataValue5.ToolTip;
            }
        }

        public string WetBulbTemperatureDataValue6InputMessage
        {
            get
            {
                return WetBulbTemperatureDataValue6.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValue6InputValue
        {
            get
            {
                return WetBulbTemperatureDataValue6.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return WetBulbTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValue6Tooltip
        {
            get
            {
                return WetBulbTemperatureDataValue6.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return Range1ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return Range1ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return Range1ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return Range1ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return Range1ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range1ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range1ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range1ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return Range1ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range1ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return Range1ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return Range2ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return Range2ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue2.ToolTip;
            }
        }
        public string Range2ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return Range2ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return Range2ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range2ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return Range2ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue5.ToolTip;
            }
        }


        public string Range2ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range2ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range2ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return Range2ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range2ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return Range2ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return Range3ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return Range3ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return Range3ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return Range3ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return Range3ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range3ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range3ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range3ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return Range3ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range3ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return Range3ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return Range4ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return Range4ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return Range4ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return Range4ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return Range4ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range4ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range4ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range4ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return Range4ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range4ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return Range4ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue1InputMessage
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue1.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue1InputValue
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue1.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue1UpdateValue(string value, out string errorMessage)
        {
            return Range5ColdWaterTemperatureDataValue1.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue1Tooltip
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue1.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue2InputMessage
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue2.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue2InputValue
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue2.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue2UpdateValue(string value, out string errorMessage)
        {
            return Range5ColdWaterTemperatureDataValue2.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue2Tooltip
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue2.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue3InputMessage
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue3.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue3InputValue
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue3.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue3UpdateValue(string value, out string errorMessage)
        {
            return Range5ColdWaterTemperatureDataValue3.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue3Tooltip
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue3.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue4InputMessage
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue4.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue4InputValue
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue4.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue4UpdateValue(string value, out string errorMessage)
        {
            return Range5ColdWaterTemperatureDataValue4.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue4Tooltip
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue4.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue5InputMessage
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue5.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue5InputValue
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue5.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue5UpdateValue(string value, out string errorMessage)
        {
            return Range5ColdWaterTemperatureDataValue5.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue5Tooltip
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue5.ToolTip;
            }
        }

        public string Range5ColdWaterTemperatureDataValue6InputMessage
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue6.InputMessage;
            }
        }

        public string Range5ColdWaterTemperatureDataValue6InputValue
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue6.InputValue;
            }
        }

        public bool Range5ColdWaterTemperatureDataValue6UpdateValue(string value, out string errorMessage)
        {
            return Range5ColdWaterTemperatureDataValue6.UpdateValue(value, out errorMessage);
        }

        public string Range5ColdWaterTemperatureDataValue6Tooltip
        {
            get
            {
                return Range5ColdWaterTemperatureDataValue6.ToolTip;
            }
        }

        #endregion DataValueAccess

        public bool LoadData(bool isInternationalSystemOfUnits_IS, RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_IS)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                WetBulbTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                WetBulbTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                WetBulbTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                WetBulbTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                WetBulbTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range1ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range1ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range1ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range1ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range1ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range1ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range2ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range2ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range2ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range2ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range2ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range2ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range3ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range3ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range3ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range3ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range3ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range3ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range4ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range4ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range4ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range4ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range4ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range4ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range5ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range5ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range5ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range5ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range5ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                Range5ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI, false);
            }

            WaterFlowRateDataValue.UpdateCurrentValue(rangedTemperaturesDesignData.WaterFlowRate, out errorMessage);

            WetBulbTemperatureDataValue1.UpdateCurrentValue(rangedTemperaturesDesignData.WetBulbTemperatures.Temperature1, out errorMessage);
            WetBulbTemperatureDataValue2.UpdateCurrentValue(rangedTemperaturesDesignData.WetBulbTemperatures.Temperature2, out errorMessage);
            WetBulbTemperatureDataValue3.UpdateCurrentValue(rangedTemperaturesDesignData.WetBulbTemperatures.Temperature3, out errorMessage);
            WetBulbTemperatureDataValue4.UpdateCurrentValue(rangedTemperaturesDesignData.WetBulbTemperatures.Temperature4, out errorMessage);
            WetBulbTemperatureDataValue5.UpdateCurrentValue(rangedTemperaturesDesignData.WetBulbTemperatures.Temperature5, out errorMessage);
            WetBulbTemperatureDataValue6.UpdateCurrentValue(rangedTemperaturesDesignData.WetBulbTemperatures.Temperature6, out errorMessage);

            Range1ColdWaterTemperatureDataValue1.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature1, out errorMessage);
            Range1ColdWaterTemperatureDataValue2.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature2, out errorMessage);
            Range1ColdWaterTemperatureDataValue3.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature3, out errorMessage);
            Range1ColdWaterTemperatureDataValue4.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature4, out errorMessage);
            Range1ColdWaterTemperatureDataValue5.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature5, out errorMessage);
            Range1ColdWaterTemperatureDataValue6.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature6, out errorMessage);

            Range2ColdWaterTemperatureDataValue1.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature1, out errorMessage);
            Range2ColdWaterTemperatureDataValue2.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature2, out errorMessage);
            Range2ColdWaterTemperatureDataValue3.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature3, out errorMessage);
            Range2ColdWaterTemperatureDataValue4.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature4, out errorMessage);
            Range2ColdWaterTemperatureDataValue5.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature5, out errorMessage);
            Range2ColdWaterTemperatureDataValue6.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature6, out errorMessage);

            Range3ColdWaterTemperatureDataValue1.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature1, out errorMessage);
            Range3ColdWaterTemperatureDataValue2.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature2, out errorMessage);
            Range3ColdWaterTemperatureDataValue3.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature3, out errorMessage);
            Range3ColdWaterTemperatureDataValue4.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature4, out errorMessage);
            Range3ColdWaterTemperatureDataValue5.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature5, out errorMessage);
            Range3ColdWaterTemperatureDataValue6.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature6, out errorMessage);

            Range4ColdWaterTemperatureDataValue1.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature1, out errorMessage);
            Range4ColdWaterTemperatureDataValue2.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature2, out errorMessage);
            Range4ColdWaterTemperatureDataValue3.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature3, out errorMessage);
            Range4ColdWaterTemperatureDataValue4.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature4, out errorMessage);
            Range4ColdWaterTemperatureDataValue5.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature5, out errorMessage);
            Range4ColdWaterTemperatureDataValue6.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature6, out errorMessage);

            Range5ColdWaterTemperatureDataValue1.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature1, out errorMessage);
            Range5ColdWaterTemperatureDataValue2.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature2, out errorMessage);
            Range5ColdWaterTemperatureDataValue3.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature3, out errorMessage);
            Range5ColdWaterTemperatureDataValue4.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature4, out errorMessage);
            Range5ColdWaterTemperatureDataValue5.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature5, out errorMessage);
            Range5ColdWaterTemperatureDataValue6.UpdateCurrentValue(rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature6, out errorMessage);

            return true;
        }

        public bool FillAndValidate(ref RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                rangedTemperaturesDesignData.WaterFlowRate = WaterFlowRateDataValue.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature1 = WetBulbTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature2 = WetBulbTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature3 = WetBulbTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature4 = WetBulbTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature5 = WetBulbTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature6 = WetBulbTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature1 = Range1ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature2 = Range1ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature3 = Range1ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature4 = Range1ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature5 = Range1ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature6 = Range1ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature1 = Range2ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature2 = Range2ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature3 = Range2ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature4 = Range2ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature5 = Range2ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature6 = Range2ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature1 = Range3ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature2 = Range3ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature3 = Range3ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature4 = Range3ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature5 = Range3ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature6 = Range3ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature1 = Range4ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature2 = Range4ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature3 = Range4ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature4 = Range4ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature5 = Range4ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature6 = Range4ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature1 = Range5ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature2 = Range5ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature3 = Range5ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature4 = Range5ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature5 = Range5ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature6 = Range5ColdWaterTemperatureDataValue6.Current;
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Tower Design Curve Data fill failed. Exception: {0} ", e.ToString());
            }
            return returnValue;
        }

        public int CountWetBulbTemperatures()
        {
            bool zeroDetected = false;

            int count = 0;

            for (int i = 0; i < 6 && !zeroDetected; i++)
            {
                switch (i)
                {
                    case 0:
                        if (WetBulbTemperatureDataValue1.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 1:
                        if (WetBulbTemperatureDataValue2.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 2:
                        if (WetBulbTemperatureDataValue3.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 3:
                        if (WetBulbTemperatureDataValue4.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 4:
                        if (WetBulbTemperatureDataValue5.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 5:
                        if (WetBulbTemperatureDataValue6.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    default:
                        break;
                }
                if (!zeroDetected)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
