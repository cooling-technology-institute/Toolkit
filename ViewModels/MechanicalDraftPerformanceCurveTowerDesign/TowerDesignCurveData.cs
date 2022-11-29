// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Text;

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
        public string ErrorMessage { get; set; }

        public TowerDesignCurveData(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            ErrorMessage = string.Empty;

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue1 = new WetBulbTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue1.IsZeroValid = true;
            WetBulbTemperatureDataValue1.InitializeValue(0.0);
            WetBulbTemperatureDataValue2 = new WetBulbTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue2.IsZeroValid = true;
            WetBulbTemperatureDataValue2.InitializeValue(0.0);
            WetBulbTemperatureDataValue3 = new WetBulbTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue3.IsZeroValid = true;
            WetBulbTemperatureDataValue3.InitializeValue(0.0);
            WetBulbTemperatureDataValue4 = new WetBulbTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue4.IsZeroValid = true;
            WetBulbTemperatureDataValue4.InitializeValue(0.0);
            WetBulbTemperatureDataValue5 = new WetBulbTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue5.IsZeroValid = true;
            WetBulbTemperatureDataValue5.InitializeValue(0.0);
            WetBulbTemperatureDataValue6 = new WetBulbTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue6.IsZeroValid = true;
            WetBulbTemperatureDataValue6.InitializeValue(0.0);

            Range1ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue1.IsZeroValid = true;
            Range1ColdWaterTemperatureDataValue1.InitializeValue(0.0);
            Range1ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue2.IsZeroValid = true;
            Range1ColdWaterTemperatureDataValue2.InitializeValue(0.0);
            Range1ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue3.IsZeroValid = true;
            Range1ColdWaterTemperatureDataValue3.InitializeValue(0.0);
            Range1ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue4.IsZeroValid = true;
            Range1ColdWaterTemperatureDataValue4.InitializeValue(0.0);
            Range1ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue5.IsZeroValid = true;
            Range1ColdWaterTemperatureDataValue5.InitializeValue(0.0);
            Range1ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue6.IsZeroValid = true;
            Range1ColdWaterTemperatureDataValue6.InitializeValue(0.0);

            Range2ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue1.IsZeroValid = true;
            Range2ColdWaterTemperatureDataValue1.InitializeValue(0.0);
            Range2ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue2.IsZeroValid = true;
            Range2ColdWaterTemperatureDataValue2.InitializeValue(0.0);
            Range2ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue3.IsZeroValid = true;
            Range2ColdWaterTemperatureDataValue3.InitializeValue(0.0);
            Range2ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue4.IsZeroValid = true;
            Range2ColdWaterTemperatureDataValue4.InitializeValue(0.0);
            Range2ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue5.IsZeroValid = true;
            Range2ColdWaterTemperatureDataValue5.InitializeValue(0.0);
            Range2ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue6.IsZeroValid = true;
            Range2ColdWaterTemperatureDataValue6.InitializeValue(0.0);

            Range3ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue1.IsZeroValid = true;
            Range3ColdWaterTemperatureDataValue1.InitializeValue(0.0);
            Range3ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue2.IsZeroValid = true;
            Range3ColdWaterTemperatureDataValue2.InitializeValue(0.0);
            Range3ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue3.IsZeroValid = true;
            Range3ColdWaterTemperatureDataValue3.InitializeValue(0.0);
            Range3ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue4.IsZeroValid = true;
            Range3ColdWaterTemperatureDataValue4.InitializeValue(0.0);
            Range3ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue5.IsZeroValid = true;
            Range3ColdWaterTemperatureDataValue5.InitializeValue(0.0);
            Range3ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue6.IsZeroValid = true;
            Range3ColdWaterTemperatureDataValue6.InitializeValue(0.0);

            Range4ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue1.IsZeroValid = true;
            Range4ColdWaterTemperatureDataValue1.InitializeValue(0.0);
            Range4ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue2.IsZeroValid = true;
            Range4ColdWaterTemperatureDataValue2.InitializeValue(0.0);
            Range4ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue3.IsZeroValid = true;
            Range4ColdWaterTemperatureDataValue3.InitializeValue(0.0);
            Range4ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue4.IsZeroValid = true;
            Range4ColdWaterTemperatureDataValue4.InitializeValue(0.0);
            Range4ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue5.IsZeroValid = true;
            Range4ColdWaterTemperatureDataValue5.InitializeValue(0.0);
            Range4ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue6.IsZeroValid = true;
            Range4ColdWaterTemperatureDataValue6.InitializeValue(0.0);

            Range5ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue1.IsZeroValid = true;
            Range5ColdWaterTemperatureDataValue1.InitializeValue(0.0);
            Range5ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue2.IsZeroValid = true;
            Range5ColdWaterTemperatureDataValue2.InitializeValue(0.0);
            Range5ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue3.IsZeroValid = true;
            Range5ColdWaterTemperatureDataValue3.InitializeValue(0.0);
            Range5ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue4.IsZeroValid = true;
            Range5ColdWaterTemperatureDataValue4.InitializeValue(0.0);
            Range5ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue5.IsZeroValid = true;
            Range5ColdWaterTemperatureDataValue5.InitializeValue(0.0);
            Range5ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, isInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue6.IsZeroValid = true;
            Range5ColdWaterTemperatureDataValue6.InitializeValue(0.0);
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                isChanged = true;
                IsInternationalSystemOfUnits_SI = isIS;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range1ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range1ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range1ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range1ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range1ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range1ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5ColdWaterTemperatureDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5ColdWaterTemperatureDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5ColdWaterTemperatureDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5ColdWaterTemperatureDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5ColdWaterTemperatureDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5ColdWaterTemperatureDataValue6.ConvertValue(IsInternationalSystemOfUnits_SI);
            }
            return isChanged;
        }

        public bool LoadDataValue(DataValue dataValue, double value, StringBuilder stringBuilder)
        {
            bool returnValue = true;
            if(!dataValue.UpdateCurrentValue(value))
            {
                returnValue = false;
                stringBuilder.AppendLine(string.Format("{0}. Current Value: {1}", dataValue.ErrorMessage, value));
            }
            return returnValue;
        }

        public bool LoadData(RangedTemperaturesDesignData rangedTemperaturesDesignData)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            returnValue = LoadDataValue(WaterFlowRateDataValue, rangedTemperaturesDesignData.WaterFlowRate, stringBuilder)
            & LoadDataValue(WetBulbTemperatureDataValue1, rangedTemperaturesDesignData.WetBulbTemperatures.Temperature1, stringBuilder)
            & LoadDataValue(WetBulbTemperatureDataValue2, rangedTemperaturesDesignData.WetBulbTemperatures.Temperature2, stringBuilder)
            & LoadDataValue(WetBulbTemperatureDataValue3, rangedTemperaturesDesignData.WetBulbTemperatures.Temperature3, stringBuilder)
            & LoadDataValue(WetBulbTemperatureDataValue4, rangedTemperaturesDesignData.WetBulbTemperatures.Temperature4, stringBuilder)
            & LoadDataValue(WetBulbTemperatureDataValue5, rangedTemperaturesDesignData.WetBulbTemperatures.Temperature5, stringBuilder)
            & LoadDataValue(WetBulbTemperatureDataValue6, rangedTemperaturesDesignData.WetBulbTemperatures.Temperature6, stringBuilder)
            & LoadDataValue(Range1ColdWaterTemperatureDataValue1, rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature1, stringBuilder)
            & LoadDataValue(Range1ColdWaterTemperatureDataValue2, rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature2, stringBuilder)
            & LoadDataValue(Range1ColdWaterTemperatureDataValue3, rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature3, stringBuilder)
            & LoadDataValue(Range1ColdWaterTemperatureDataValue4, rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature4, stringBuilder)
            & LoadDataValue(Range1ColdWaterTemperatureDataValue5, rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature5, stringBuilder)
            & LoadDataValue(Range1ColdWaterTemperatureDataValue6, rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature6, stringBuilder)
            & LoadDataValue(Range2ColdWaterTemperatureDataValue1, rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature1, stringBuilder)
            & LoadDataValue(Range2ColdWaterTemperatureDataValue2, rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature2, stringBuilder)
            & LoadDataValue(Range2ColdWaterTemperatureDataValue3, rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature3, stringBuilder)
            & LoadDataValue(Range2ColdWaterTemperatureDataValue4, rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature4, stringBuilder)
            & LoadDataValue(Range2ColdWaterTemperatureDataValue5, rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature5, stringBuilder)
            & LoadDataValue(Range2ColdWaterTemperatureDataValue6, rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature6, stringBuilder)
            & LoadDataValue(Range3ColdWaterTemperatureDataValue1, rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature1, stringBuilder)
            & LoadDataValue(Range3ColdWaterTemperatureDataValue2, rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature2, stringBuilder)
            & LoadDataValue(Range3ColdWaterTemperatureDataValue3, rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature3, stringBuilder)
            & LoadDataValue(Range3ColdWaterTemperatureDataValue4, rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature4, stringBuilder)
            & LoadDataValue(Range3ColdWaterTemperatureDataValue5, rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature5, stringBuilder)
            & LoadDataValue(Range3ColdWaterTemperatureDataValue6, rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature6, stringBuilder)
            & LoadDataValue(Range4ColdWaterTemperatureDataValue1, rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature1, stringBuilder)
            & LoadDataValue(Range4ColdWaterTemperatureDataValue2, rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature2, stringBuilder)
            & LoadDataValue(Range4ColdWaterTemperatureDataValue3, rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature3, stringBuilder)
            & LoadDataValue(Range4ColdWaterTemperatureDataValue4, rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature4, stringBuilder)
            & LoadDataValue(Range4ColdWaterTemperatureDataValue5, rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature5, stringBuilder)
            & LoadDataValue(Range4ColdWaterTemperatureDataValue6, rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature6, stringBuilder)
            & LoadDataValue(Range5ColdWaterTemperatureDataValue1, rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature1, stringBuilder)
            & LoadDataValue(Range5ColdWaterTemperatureDataValue2, rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature2, stringBuilder)
            & LoadDataValue(Range5ColdWaterTemperatureDataValue3, rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature3, stringBuilder)
            & LoadDataValue(Range5ColdWaterTemperatureDataValue4, rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature4, stringBuilder)
            & LoadDataValue(Range5ColdWaterTemperatureDataValue5, rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature5, stringBuilder)
            & LoadDataValue(Range5ColdWaterTemperatureDataValue6, rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature6, stringBuilder);

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool FillFileData(ref RangedTemperaturesDesignData rangedTemperaturesDesignData)
        {
            ErrorMessage = string.Empty;
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
                ErrorMessage = string.Format("Tower Design Curve Data fill failed. Exception: {0} ", e.ToString());
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

        public double FindMinimumColdWaterTempurature()
        {
            double minimum = 0.0;

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        if (WetBulbTemperatureDataValue1.Current != 0.0)
                        {
                            if (Range1ColdWaterTemperatureDataValue1.Current < minimum)
                            {
                                minimum = Range1ColdWaterTemperatureDataValue1.Current;
                            }
                            if (Range1ColdWaterTemperatureDataValue2.Current < minimum)
                            {
                                minimum = Range1ColdWaterTemperatureDataValue2.Current;
                            }
                            if (Range1ColdWaterTemperatureDataValue3.Current < minimum)
                            {
                                minimum = Range1ColdWaterTemperatureDataValue3.Current;
                            }
                            if (Range1ColdWaterTemperatureDataValue4.Current < minimum)
                            {
                                minimum = Range1ColdWaterTemperatureDataValue4.Current;
                            }
                            if (Range1ColdWaterTemperatureDataValue5.Current < minimum)
                            {
                                minimum = Range1ColdWaterTemperatureDataValue5.Current;
                            }
                            if (Range1ColdWaterTemperatureDataValue6.Current < minimum)
                            {
                                minimum = Range1ColdWaterTemperatureDataValue6.Current;
                            }
                        }
                        break;
                    case 1:
                        if ((WetBulbTemperatureDataValue2.Current != 0.0) && (WetBulbTemperatureDataValue2.Current < minimum))
                        {
                            minimum = WetBulbTemperatureDataValue2.Current;
                        }
                        break;
                    case 2:
                        if ((WetBulbTemperatureDataValue3.Current != 0.0) && (WetBulbTemperatureDataValue3.Current < minimum))
                        {
                            minimum = WetBulbTemperatureDataValue3.Current;
                        }
                        break;
                    case 3:
                        if ((WetBulbTemperatureDataValue4.Current != 0.0) && (WetBulbTemperatureDataValue4.Current < minimum))
                        {
                            minimum = WetBulbTemperatureDataValue4.Current;
                        }
                        break;
                    case 4:
                        if ((WetBulbTemperatureDataValue5.Current != 0.0) && (WetBulbTemperatureDataValue5.Current < minimum))
                        {
                            minimum = WetBulbTemperatureDataValue5.Current;
                        }
                        break;
                    case 5:
                        if ((WetBulbTemperatureDataValue6.Current != 0.0) && (WetBulbTemperatureDataValue6.Current < minimum))
                        {
                            minimum = WetBulbTemperatureDataValue6.Current;
                        }
                        break;
                    default:
                        break;
                }
            }
            return minimum;
        }

        public double FindMaximumColdWaterTempurature()
        {
            double maximum = 0.0;

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        if ((WetBulbTemperatureDataValue1.Current != 0.0) && (WetBulbTemperatureDataValue1.Current > maximum))
                        {
                            maximum = WetBulbTemperatureDataValue1.Current;
                        }
                        break;
                    case 1:
                        if ((WetBulbTemperatureDataValue2.Current != 0.0) && (WetBulbTemperatureDataValue2.Current > maximum))
                        {
                            maximum = WetBulbTemperatureDataValue2.Current;
                        }
                        break;
                    case 2:
                        if ((WetBulbTemperatureDataValue3.Current != 0.0) && (WetBulbTemperatureDataValue3.Current > maximum))
                        {
                            maximum = WetBulbTemperatureDataValue3.Current;
                        }
                        break;
                    case 3:
                        if ((WetBulbTemperatureDataValue4.Current != 0.0) && (WetBulbTemperatureDataValue4.Current > maximum))
                        {
                            maximum = WetBulbTemperatureDataValue4.Current;
                        }
                        break;
                    case 4:
                        if ((WetBulbTemperatureDataValue5.Current != 0.0) && (WetBulbTemperatureDataValue5.Current > maximum))
                        {
                            maximum = WetBulbTemperatureDataValue5.Current;
                        }
                        break;
                    case 5:
                        if ((WetBulbTemperatureDataValue6.Current != 0.0) && (WetBulbTemperatureDataValue6.Current > maximum))
                        {
                            maximum = WetBulbTemperatureDataValue6.Current;
                        }
                        break;
                    default:
                        break;
                }
            }
            return maximum;
        }
    }
}
