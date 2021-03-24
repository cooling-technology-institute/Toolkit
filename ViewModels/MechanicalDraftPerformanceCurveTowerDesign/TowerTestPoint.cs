// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Text;

namespace ViewModels
{
    public class TowerTestPoint
    {
        public string TestName { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        private TowerTestData TowerTestData { get; set; }

        public TowerTestPoint(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            
            TestName = string.Empty;
            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            string errorMessage;
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue.IsZeroValid = true;
            LiquidToGasRatioDataValue.UpdateCurrentValue(0.0, out errorMessage);
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                isChanged = true;
            }

            return isChanged;
        }

        public bool LoadData(bool isInternationalSystemOfUnits_SI, TowerTestData testData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            }

            try
            {
                if (testData != null)
                {
                    TestName = testData.TestName;
                    string label = string.Format("Test Data {0} : ", TestName);

                    if (!WaterFlowRateDataValue.UpdateCurrentValue(testData.TowerSpecifications.WaterFlowRate, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!HotWaterTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.HotWaterTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.ColdWaterTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!WetBulbTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.WetBulbTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!DryBulbTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.DryBulbTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!FanDriverPowerDataValue.UpdateCurrentValue(testData.TowerSpecifications.FanDriverPower, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!BarometricPressureDataValue.UpdateCurrentValue(testData.TowerSpecifications.BarometricPressure, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    // the l/g is an output for a test point so should not be saved to file
                    //if (!LiquidToGasRatioDataValue.UpdateCurrentValue(testData.TowerSpecifications.LiquidToGasRatio, out errorMessage))
                    //{
                    //    returnValue = false;
                    //    stringBuilder.AppendLine(label + errorMessage);
                    //    errorMessage = string.Empty;
                    //}

                    errorMessage = stringBuilder.ToString();
                }
            }
            catch(Exception exception)
            {
                errorMessage = string.Format("Failure to update page with data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }

        public bool FillAndValidate(TowerTestData towerTestData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                towerTestData.TestName = TestName;
                towerTestData.TowerSpecifications.WaterFlowRate = WaterFlowRateDataValue.Current;
                towerTestData.TowerSpecifications.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.FanDriverPower = FanDriverPowerDataValue.Current;
                towerTestData.TowerSpecifications.BarometricPressure = BarometricPressureDataValue.Current;
                towerTestData.TowerSpecifications.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failure to fill and validate Test Data '{0}'. Exception {1}.", TestName, exception.ToString());
            }
            return returnValue;
        }

        //#region DataValues

        //public string WaterFlowRateDataValueInputMessage
        //{
        //    get
        //    {
        //        return WaterFlowRateDataValue.InputMessage;
        //    }
        //}

        //public string WaterFlowRateDataValueInputValue
        //{
        //    get
        //    {
        //        return WaterFlowRateDataValue.InputValue;
        //    }
        //}

        //public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string WaterFlowRateDataValueTooltip
        //{
        //    get
        //    {
        //        return WaterFlowRateDataValue.ToolTip;
        //    }
        //}


        //public string HotWaterTemperatureDataValueInputMessage
        //{
        //    get
        //    {
        //        return HotWaterTemperatureDataValue.InputMessage;
        //    }
        //}

        //public string HotWaterTemperatureDataValueInputValue
        //{
        //    get
        //    {
        //        return HotWaterTemperatureDataValue.InputValue;
        //    }
        //}

        //public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string HotWaterTemperatureDataValueTooltip
        //{
        //    get
        //    {
        //        return HotWaterTemperatureDataValue.ToolTip;
        //    }
        //}

        //public string ColdWaterTemperatureDataValueInputMessage
        //{
        //    get
        //    {
        //        return ColdWaterTemperatureDataValue.InputMessage;
        //    }
        //}

        //public string ColdWaterTemperatureDataValueInputValue
        //{
        //    get
        //    {
        //        return ColdWaterTemperatureDataValue.InputValue;
        //    }
        //}

        //public string ColdWaterTemperatureDataValueTooltip
        //{
        //    get
        //    {
        //        return ColdWaterTemperatureDataValue.ToolTip;
        //    }
        //}

        //public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string WetBulbTemperatureDataValueInputMessage
        //{
        //    get
        //    {
        //        return WetBulbTemperatureDataValue.InputMessage;
        //    }
        //}

        //public string WetBulbTemperatureDataValueInputValue
        //{
        //    get
        //    {
        //        return WetBulbTemperatureDataValue.InputValue;
        //    }
        //}

        //public string WetBulbTemperatureDataValueTooltip
        //{
        //    get
        //    {
        //        return WetBulbTemperatureDataValue.ToolTip;
        //    }
        //}

        //public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string DryBulbTemperatureDataValueInputMessage
        //{
        //    get
        //    {
        //        return DryBulbTemperatureDataValue.InputMessage;
        //    }
        //}

        //public string DryBulbTemperatureDataValueInputValue
        //{
        //    get
        //    {
        //        return DryBulbTemperatureDataValue.InputValue;
        //    }
        //}

        //public string DryBulbTemperatureDataValueTooltip
        //{
        //    get
        //    {
        //        return DryBulbTemperatureDataValue.ToolTip;
        //    }
        //}

        //public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string FanDriverPowerDataValueInputMessage
        //{
        //    get
        //    {
        //        return FanDriverPowerDataValue.InputMessage;
        //    }
        //}

        //public string FanDriverPowerDataValueInputValue
        //{
        //    get
        //    {
        //        return FanDriverPowerDataValue.InputValue;
        //    }
        //}

        //public string FanDriverPowerDataValueTooltip
        //{
        //    get
        //    {
        //        return FanDriverPowerDataValue.ToolTip;
        //    }
        //}

        //public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string BarometricPressureDataValueInputMessage
        //{
        //    get
        //    {
        //        return BarometricPressureDataValue.InputMessage;
        //    }
        //}

        //public string BarometricPressureDataValueInputValue
        //{
        //    get
        //    {
        //        return BarometricPressureDataValue.InputValue;
        //    }
        //}

        //public string BarometricPressureDataValueTooltip
        //{
        //    get
        //    {
        //        return BarometricPressureDataValue.ToolTip;
        //    }
        //}

        //public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        //}

        //public string LiquidToGasRatioDataValueInputMessage
        //{
        //    get
        //    {
        //        return LiquidToGasRatioDataValue.InputMessage;
        //    }
        //}

        //public string LiquidToGasRatioDataValueInputValue
        //{
        //    get
        //    {
        //        return LiquidToGasRatioDataValue.InputValue;
        //    }
        //}

        //public string LiquidToGasRatioDataValueTooltip
        //{
        //    get
        //    {
        //        return LiquidToGasRatioDataValue.ToolTip;
        //    }
        //}

        //public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        //{
        //    return LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        //}

        //#endregion DataValues
    }
}