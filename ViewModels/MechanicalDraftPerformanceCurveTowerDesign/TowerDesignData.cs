// Copyright Cooling Technology Institute 2019-2022

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public enum Order
    {
        Ascending,
        Descending
    };

    public class TowerDesignData
    {
        const int MINIMUM_WATER_FLOW_RATES_COUNT = 3;
        const int MINIMUM_RANGE_COUNT = 3;
        const int MINIMUM_WET_BULB_TEMPERTURE_COUNT = 3;	// Dean's notes say 5 ....

        public string OwnerNameValue { set; get; }
        public string ProjectNameValue { set; get; }
        public string LocationValue { set; get; }
        public string TowerManufacturerValue { set; get; }
        public TOWER_TYPE TowerTypeValue { set; get; }

        public RangeDataValue Range1Value { get; set; }
        public RangeDataValue Range2Value { get; set; }
        public RangeDataValue Range3Value { get; set; }
        public RangeDataValue Range4Value { get; set; }
        public RangeDataValue Range5Value { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }

        public WaterFlowRateDataValue AddWaterFlowRateDataValue { get; set; }

        public List<TowerDesignCurveData> TowerDesignCurveData { set; get; }

        public Order RangeOrder { get; set; }
        public Order WaterFlowRateOrder { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }
        public string ErrorMessage { get; set; }

        public TowerDesignData(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            ErrorMessage = string.Empty;

            OwnerNameValue = string.Empty;
            ProjectNameValue = string.Empty;
            LocationValue = string.Empty;
            TowerManufacturerValue = string.Empty;
            TowerTypeValue = TOWER_TYPE.Induced;

            Range1Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1Value.IsZeroValid = true;
            Range1Value.InitializeValue(0.0);
            Range2Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2Value.IsZeroValid = true;
            Range2Value.InitializeValue(0.0);
            Range3Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3Value.IsZeroValid = true;
            Range3Value.InitializeValue(0.0);
            Range4Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4Value.IsZeroValid = true;
            Range4Value.InitializeValue(0.0);
            Range5Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5Value.IsZeroValid = true;
            Range5Value.InitializeValue(0.0);

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            AddWaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            TowerDesignCurveData = new List<TowerDesignCurveData>();

            RangeOrder = Order.Ascending;
            WaterFlowRateOrder = Order.Ascending;
        }

        public void UpdateDemo(bool isDemo)
        {
            if (IsDemo != isDemo)
            {
                IsDemo = isDemo;

                Range1Value.SetDemo(isDemo);
                Range2Value.SetDemo(isDemo);
                Range3Value.SetDemo(isDemo);
                Range4Value.SetDemo(isDemo);
                Range5Value.SetDemo(isDemo);

                WaterFlowRateDataValue.SetDemo(isDemo);
                HotWaterTemperatureDataValue.SetDemo(isDemo);
                ColdWaterTemperatureDataValue.SetDemo(isDemo);
                WetBulbTemperatureDataValue.SetDemo(isDemo);
                DryBulbTemperatureDataValue.SetDemo(isDemo);
                FanDriverPowerDataValue.SetDemo(isDemo);
                BarometricPressureDataValue.SetDemo(isDemo);
                LiquidToGasRatioDataValue.SetDemo(isDemo);

                AddWaterFlowRateDataValue.SetDemo(isDemo);
            }
        }

        public bool ConvertValues(bool isIS)
        {
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
                Range1Value.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range2Value.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range3Value.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range4Value.ConvertValue(IsInternationalSystemOfUnits_SI);
                Range5Value.ConvertValue(IsInternationalSystemOfUnits_SI);

                foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignCurveData)
                {
                    towerDesignCurveData.ConvertValues(IsInternationalSystemOfUnits_SI);
                }
            }
            return false;
        }

        public bool LoadDataValue(DataValue dataValue, double value, StringBuilder stringBuilder)
        {
            bool returnValue = true;
            if (!dataValue.UpdateCurrentValue(value))
            {
                returnValue = false;
                stringBuilder.AppendLine(string.Format("{0}. Current Value: {1}", dataValue.ErrorMessage, value));
            }
            return returnValue;
        }

        public bool LoadData(DesignData data)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Design Data: ");

            try
            {
                OwnerNameValue = data.OwnerName;
                ProjectNameValue = data.ProjectName;
                LocationValue = data.Location;
                TowerManufacturerValue = data.TowerManufacturer;
                TowerTypeValue = data.TowerType;

                returnValue = LoadDataValue(WaterFlowRateDataValue, data.TowerSpecifications.WaterFlowRate, stringBuilder)
                & LoadDataValue(HotWaterTemperatureDataValue, data.TowerSpecifications.HotWaterTemperature, stringBuilder)
                & LoadDataValue(ColdWaterTemperatureDataValue, data.TowerSpecifications.ColdWaterTemperature, stringBuilder)
                & LoadDataValue(WetBulbTemperatureDataValue, data.TowerSpecifications.WetBulbTemperature, stringBuilder)
                & LoadDataValue(DryBulbTemperatureDataValue, data.TowerSpecifications.DryBulbTemperature, stringBuilder)
                & LoadDataValue(FanDriverPowerDataValue, data.TowerSpecifications.FanDriverPower, stringBuilder)
                & LoadDataValue(BarometricPressureDataValue, data.TowerSpecifications.BarometricPressure, stringBuilder)
                & LoadDataValue(LiquidToGasRatioDataValue, data.TowerSpecifications.LiquidToGasRatio, stringBuilder)
                & LoadDataValue(Range1Value, data.Range1, stringBuilder)
                & LoadDataValue(Range2Value, data.Range2, stringBuilder)
                & LoadDataValue(Range3Value, data.Range3, stringBuilder)
                & LoadDataValue(Range4Value, data.Range4, stringBuilder)
                & LoadDataValue(Range5Value, data.Range5, stringBuilder);

                TowerDesignCurveData.Clear();
                foreach (RangedTemperaturesDesignData rangedTemperaturesDesignData in data.RangedTemperaturesDesignData)
                {
                    TowerDesignCurveData towerDesignCurveData = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI);
                    if (!towerDesignCurveData.LoadData(rangedTemperaturesDesignData))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(string.Format("Flow Rate {0}:", rangedTemperaturesDesignData.WaterFlowRate));
                        stringBuilder.AppendLine(towerDesignCurveData.ErrorMessage);
                    }
                    TowerDesignCurveData.Add(towerDesignCurveData);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Failure to Mechanical Draft Performance Curve Design Data. Exception: {0}", e.ToString());
                returnValue = false;
            }
            
            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool IsAscendingOrder(List<double> values)
        {
            bool inOrder = true;

            double testValue = 0.0;

            foreach(double value in values)
            {
                if (value != 0.0)
                {
                    if (value <= testValue)
                    {
                        inOrder = false;
                    }
                    else
                    {
                        testValue = value;
                    }
                }
            }
            return inOrder;
        }

        public bool IsDescendingOrder(List<double> values)
        {
            bool inOrder = true;

            double testValue = 0.0;

            foreach (double value in values)
            {
                if (value >= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = value;
                }
            }
            return inOrder;
        }

        public bool FillFileData(DesignData data)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                data.OwnerName = OwnerNameValue;
                data.ProjectName = ProjectNameValue;
                data.Location = LocationValue;
                data.TowerManufacturer = TowerManufacturerValue;
                data.TowerType = TowerTypeValue;
                data.OwnerName = OwnerNameValue;

                data.Range1 = Range1Value.Current;
                data.Range2 = Range2Value.Current;
                data.Range3 = Range3Value.Current;
                data.Range4 = Range4Value.Current;
                data.Range5 = Range5Value.Current;

                data.TowerSpecifications.WaterFlowRate = WaterFlowRateDataValue.Current;
                data.TowerSpecifications.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                data.TowerSpecifications.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                data.TowerSpecifications.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                data.TowerSpecifications.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                data.TowerSpecifications.FanDriverPower = FanDriverPowerDataValue.Current;
                data.TowerSpecifications.BarometricPressure = BarometricPressureDataValue.Current;
                data.TowerSpecifications.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;

                data.RangedTemperaturesDesignData = new System.Collections.Generic.List<RangedTemperaturesDesignData>();

                foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignCurveData)
                {
                    RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();
                    if(!towerDesignCurveData.FillFileData(ref rangedTemperaturesDesignData))
                    {
                        ErrorMessage += towerDesignCurveData.ErrorMessage;
                    }
                    data.RangedTemperaturesDesignData.Add(rangedTemperaturesDesignData);
                }
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Design Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }

        private bool BuildTemperatureList(List<bool> isValidRange, string flowRateMessage,
                                           WetBulbTemperature wetBulbTemperature,
                                           WetBulbTemperatureDataValue wetbulbTemperature,
                                           ColdWaterTemperatureDataValue rangeColdWaterTemperature1,
                                           ColdWaterTemperatureDataValue rangeColdWaterTemperature2,
                                           ColdWaterTemperatureDataValue rangeColdWaterTemperature3,
                                           ColdWaterTemperatureDataValue rangeColdWaterTemperature4,
                                           ColdWaterTemperatureDataValue rangeColdWaterTemperature5,
                                           StringBuilder stringBuilder
                                           )
        {
            bool returnValue = true;

            if (!WetBulbTemperatureDataValue.IsValid)
            {
                if(returnValue)
                {
                    stringBuilder.AppendLine(flowRateMessage);
                }
                stringBuilder.AppendLine(wetbulbTemperature.ErrorMessage);
                returnValue = false;
            }
            wetBulbTemperature.Temperature = wetbulbTemperature.Current;

            flowRateMessage += string.Format(" Wet Bulb Temperature: {0}", wetBulbTemperature.Temperature);

            if (isValidRange[0])
            {
                if (!rangeColdWaterTemperature1.IsValid)
                {
                    if (returnValue)
                    {
                        stringBuilder.AppendLine(flowRateMessage);
                    }
                    stringBuilder.AppendLine(rangeColdWaterTemperature1.ErrorMessage);
                    returnValue = false;
                }
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature1.Current);
            }
            if (isValidRange[1])
            {
                if (!rangeColdWaterTemperature2.IsValid)
                {
                    if (returnValue)
                    {
                        stringBuilder.AppendLine(flowRateMessage);
                    }
                    stringBuilder.AppendLine(rangeColdWaterTemperature2.ErrorMessage);
                    returnValue = false;
                }
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature2.Current);
            }
            if (isValidRange[2])
            {
                if (!rangeColdWaterTemperature3.IsValid)
                {
                    if (returnValue)
                    {
                        stringBuilder.AppendLine(flowRateMessage);
                    }
                    stringBuilder.AppendLine(rangeColdWaterTemperature3.ErrorMessage);
                    returnValue = false;
                }
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature3.Current);
            }
            if (isValidRange[3])
            {
                if (!rangeColdWaterTemperature4.IsValid)
                {
                    if (returnValue)
                    {
                        stringBuilder.AppendLine(flowRateMessage);
                    }
                    stringBuilder.AppendLine(rangeColdWaterTemperature4.ErrorMessage);
                    returnValue = false;
                }
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature4.Current);
            }
            if (isValidRange[4])
            {
                if (!rangeColdWaterTemperature5.IsValid)
                {
                    if (returnValue)
                    {
                        stringBuilder.AppendLine(flowRateMessage);
                    }
                    stringBuilder.AppendLine(rangeColdWaterTemperature5.ErrorMessage);
                    returnValue = false;
                }
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature5.Current);
            }
            return returnValue;
        }

        public bool FillCalculationData(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;
            List<bool> isValidRange = new List<bool> { false, false, false, false, false };
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                calculationData.TowerType = TowerTypeValue;
                calculationData.TowerDesignData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

                if (!WaterFlowRateDataValue.IsValid)
                {
                    stringBuilder.AppendLine(WaterFlowRateDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.WaterFlowRate = WaterFlowRateDataValue.Current;

                if (!HotWaterTemperatureDataValue.IsValid)
                {
                    stringBuilder.AppendLine(HotWaterTemperatureDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;

                if (!ColdWaterTemperatureDataValue.IsValid)
                {
                    stringBuilder.AppendLine(ColdWaterTemperatureDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;

                if (!WetBulbTemperatureDataValue.IsValid)
                {
                    stringBuilder.AppendLine(WetBulbTemperatureDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;

                if (!DryBulbTemperatureDataValue.IsValid)
                {
                    stringBuilder.AppendLine(DryBulbTemperatureDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;

                if (!FanDriverPowerDataValue.IsValid)
                {
                    stringBuilder.AppendLine(FanDriverPowerDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.FanDriverPower = FanDriverPowerDataValue.Current;

                if (!BarometricPressureDataValue.IsValid)
                {
                    stringBuilder.AppendLine(BarometricPressureDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.BarometricPressure = BarometricPressureDataValue.Current;

                if (!LiquidToGasRatioDataValue.IsValid)
                {
                    stringBuilder.AppendLine(LiquidToGasRatioDataValue.ErrorMessage);
                    returnValue = false;
                }
                calculationData.TowerDesignData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;

                if (Range1Value.Current != 0.0)
                {
                    if (!Range1Value.IsValid)
                    {
                        stringBuilder.AppendLine(Range1Value.ErrorMessage);
                        returnValue = false;
                    }
                    isValidRange[0] = true;
                    calculationData.Ranges.Add(Range1Value.Current);
                }
                if (Range2Value.Current != 0.0)
                {
                    if (!Range2Value.IsValid)
                    {
                        stringBuilder.AppendLine(Range2Value.ErrorMessage);
                        returnValue = false;
                    }
                    isValidRange[1] = true;
                    calculationData.Ranges.Add(Range2Value.Current);
                }
                if (Range3Value.Current != 0.0)
                {
                    if (!Range3Value.IsValid)
                    {
                        stringBuilder.AppendLine(Range3Value.ErrorMessage);
                        returnValue = false;
                    }
                    isValidRange[2] = true;
                    calculationData.Ranges.Add(Range3Value.Current);
                }
                if (Range4Value.Current != 0.0)
                {
                    if (!Range4Value.IsValid)
                    {
                        stringBuilder.AppendLine(Range4Value.ErrorMessage);
                        returnValue = false;
                    }
                    isValidRange[3] = true;
                    calculationData.Ranges.Add(Range4Value.Current);
                }
                if (Range5Value.Current != 0.0)
                {
                    if (!Range5Value.IsValid)
                    {
                        stringBuilder.AppendLine(Range5Value.ErrorMessage);
                    }
                    isValidRange[4] = true;
                    calculationData.Ranges.Add(Range5Value.Current);
                }

                string flowRateMessage = string.Empty;
                foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignCurveData)
                {
                    WaterFlowRate flowRate = new WaterFlowRate();
                    flowRate.FlowRate = towerDesignCurveData.WaterFlowRateDataValue.Current;
                    
                    flowRateMessage = string.Format("For Flow Rate: {0}", flowRate.FlowRate);

                    if(towerDesignCurveData.WetBulbTemperatureDataValue1.Current != 0.0)
                    {
                        WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                        if(!BuildTemperatureList(isValidRange, flowRateMessage, 
                                                    wetBulbTemperature,
                                                    towerDesignCurveData.WetBulbTemperatureDataValue1,
                                                    towerDesignCurveData.Range1ColdWaterTemperatureDataValue1,
                                                    towerDesignCurveData.Range2ColdWaterTemperatureDataValue1,
                                                    towerDesignCurveData.Range3ColdWaterTemperatureDataValue1,
                                                    towerDesignCurveData.Range4ColdWaterTemperatureDataValue1,
                                                    towerDesignCurveData.Range5ColdWaterTemperatureDataValue1,
                                                    stringBuilder))
                        {
                            returnValue = false;
                        }
                        flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                    }
                    if (towerDesignCurveData.WetBulbTemperatureDataValue2.Current != 0.0)
                    {
                        WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                        if (!BuildTemperatureList(isValidRange, flowRateMessage,
                                                    wetBulbTemperature,
                                                    towerDesignCurveData.WetBulbTemperatureDataValue2,
                                                    towerDesignCurveData.Range1ColdWaterTemperatureDataValue2,
                                                    towerDesignCurveData.Range2ColdWaterTemperatureDataValue2,
                                                    towerDesignCurveData.Range3ColdWaterTemperatureDataValue2,
                                                    towerDesignCurveData.Range4ColdWaterTemperatureDataValue2,
                                                    towerDesignCurveData.Range5ColdWaterTemperatureDataValue2,
                                                    stringBuilder))
                        {
                            returnValue = false;
                        }
                        flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                    }
                    if (towerDesignCurveData.WetBulbTemperatureDataValue3.Current != 0.0)
                    {
                        WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                        if (!BuildTemperatureList(isValidRange, flowRateMessage,
                                                    wetBulbTemperature,
                                                    towerDesignCurveData.WetBulbTemperatureDataValue3,
                                                    towerDesignCurveData.Range1ColdWaterTemperatureDataValue3,
                                                    towerDesignCurveData.Range2ColdWaterTemperatureDataValue3,
                                                    towerDesignCurveData.Range3ColdWaterTemperatureDataValue3,
                                                    towerDesignCurveData.Range4ColdWaterTemperatureDataValue3,
                                                    towerDesignCurveData.Range5ColdWaterTemperatureDataValue3,
                                                    stringBuilder))
                        {
                            returnValue = false;
                        }
                        flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                    }
                    if (towerDesignCurveData.WetBulbTemperatureDataValue4.Current != 0.0)
                    {
                        WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                        if (!BuildTemperatureList(isValidRange, flowRateMessage,
                                                    wetBulbTemperature,
                                                    towerDesignCurveData.WetBulbTemperatureDataValue4,
                                                    towerDesignCurveData.Range1ColdWaterTemperatureDataValue4,
                                                    towerDesignCurveData.Range2ColdWaterTemperatureDataValue4,
                                                    towerDesignCurveData.Range3ColdWaterTemperatureDataValue4,
                                                    towerDesignCurveData.Range4ColdWaterTemperatureDataValue4,
                                                    towerDesignCurveData.Range5ColdWaterTemperatureDataValue4,
                                                    stringBuilder))
                        {
                            returnValue = false;
                        }
                        flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                    }
                    if (towerDesignCurveData.WetBulbTemperatureDataValue5.Current != 0.0)
                    {
                        WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                        if (!BuildTemperatureList(isValidRange, flowRateMessage,
                                                    wetBulbTemperature,
                                                    towerDesignCurveData.WetBulbTemperatureDataValue5,
                                                    towerDesignCurveData.Range1ColdWaterTemperatureDataValue5,
                                                    towerDesignCurveData.Range2ColdWaterTemperatureDataValue5,
                                                    towerDesignCurveData.Range3ColdWaterTemperatureDataValue5,
                                                    towerDesignCurveData.Range4ColdWaterTemperatureDataValue5,
                                                    towerDesignCurveData.Range5ColdWaterTemperatureDataValue5,
                                                    stringBuilder))
                        {
                            returnValue = false;
                        }
                        flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                    }
                    if (towerDesignCurveData.WetBulbTemperatureDataValue6.Current != 0.0)
                    {
                        WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                        if (!BuildTemperatureList(isValidRange, flowRateMessage,
                                                    wetBulbTemperature,
                                                    towerDesignCurveData.WetBulbTemperatureDataValue6,
                                                    towerDesignCurveData.Range1ColdWaterTemperatureDataValue6,
                                                    towerDesignCurveData.Range2ColdWaterTemperatureDataValue6,
                                                    towerDesignCurveData.Range3ColdWaterTemperatureDataValue6,
                                                    towerDesignCurveData.Range4ColdWaterTemperatureDataValue6,
                                                    towerDesignCurveData.Range5ColdWaterTemperatureDataValue6,
                                                    stringBuilder))
                        {
                            returnValue = false;
                        }
                        flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                    }
                    calculationData.WaterFlowRates.Add(flowRate);
                }
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Design Data. Exception {0}.", exception.ToString());
            }

            if (stringBuilder.Length > 0)
            {
                ErrorMessage += "\n" + stringBuilder.ToString();
                returnValue = false;
            }

            return returnValue;
        }

        public bool ValidateRanges(int count, MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (calculationData.Ranges.Count < count)
            {
                stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} ranges in the Tower Design Data to calculate Tower Capability.", count));
                returnValue = false;
            }

            // are ranges in order
            if (!(IsAscendingOrder(calculationData.Ranges) || IsDescendingOrder(calculationData.Ranges)))
            {
                stringBuilder.AppendLine("The ranges must be in acsending or descending order to calculate Tower Capability.");
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool ValidateWaterFlowRates(int count, MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            // verify number of water flow rate
            if (calculationData.WaterFlowRates.Count < count)
            {
                stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} water flow rates.", count));
                returnValue = false;
            }
            else
            {
                List<double> waterFlowRates = new List<double>();
                foreach (WaterFlowRate waterFlowRate in calculationData.WaterFlowRates)
                {
                    waterFlowRates.Add(waterFlowRate.FlowRate);
                }

                // verify ascending order of water flow rate
                if (!IsAscendingOrder(waterFlowRates))
                {
                    stringBuilder.AppendLine(string.Format("The water flow rates must be in acsending to calculate Tower Capability.", count));
                    returnValue = false;
                }
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool ValidateWetBulbTemperatures(int count, MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            // verify number of wet bulb temperature for each water flow rates
            foreach (WaterFlowRate waterFlowRate in calculationData.WaterFlowRates)
            {
                List<double> wetBulbTemperatures = new List<double>();
                foreach (WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
                {
                    wetBulbTemperatures.Add(wetBulbTemperature.Temperature);
                }

                //int wetBulbTemperatures = CountWetBulbTemperatures(towerDesignCurveData);
                if (wetBulbTemperatures.Count < count)
                {
                    stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} Wet Bulb Temperatures for flow rate {1}.", count, waterFlowRate.FlowRate));
                    returnValue = false;
                }
                // are wet bulb temperature in order - Wet bulb temperature design data must be entered in ascending order only
                else if (IsAscendingOrder(wetBulbTemperatures))
                {
                    //// check the cold water temperature count and order
                    //double minimum = towerDesignCurveData.FindMinimumColdWaterTempurature();
                    //double maximum = towerDesignCurveData.FindMaximumColdWaterTempurature();
                    ////if (minimum == )
                }
                else
                {
                    stringBuilder.AppendLine(string.Format("The Wet Bulb Temperatures must be in ascending order, check Water Flow Rate: {0}.", waterFlowRate.FlowRate));
                    returnValue = false;
                }
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool IsValid()
        {
            bool isValid = false;
            try
            {
                MechanicalDraftPerformanceCurveCalculationData calculationData = new MechanicalDraftPerformanceCurveCalculationData();
                
                if(FillCalculationData(calculationData))
                {
                    if (ValidateRanges(MINIMUM_RANGE_COUNT, calculationData))
                    {
                        if (ValidateWaterFlowRates(MINIMUM_WATER_FLOW_RATES_COUNT, calculationData))
                        {
                            if (ValidateWetBulbTemperatures(MINIMUM_WET_BULB_TEMPERTURE_COUNT, calculationData))
                            {
                                isValid = true;
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                ErrorMessage = string.Format("There has been some problem validating the design data. Exception: {0}", e.Message);
            }
            return isValid;
        }
    }
}
