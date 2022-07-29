// Copyright Cooling Technology Institute 2019-2021

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

                if (!WaterFlowRateDataValue.UpdateCurrentValue(data.TowerSpecifications.WaterFlowRate))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(WaterFlowRateDataValue.ErrorMessage);
                }

                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.HotWaterTemperature))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(HotWaterTemperatureDataValue.ErrorMessage);
                }

                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.ColdWaterTemperature))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(ColdWaterTemperatureDataValue.ErrorMessage);
                }

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.WetBulbTemperature))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(WetBulbTemperatureDataValue.ErrorMessage);
                }

                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.DryBulbTemperature))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(DryBulbTemperatureDataValue.ErrorMessage);
                }

                if (!FanDriverPowerDataValue.UpdateCurrentValue(data.TowerSpecifications.FanDriverPower))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(FanDriverPowerDataValue.ErrorMessage);
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(data.TowerSpecifications.BarometricPressure))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(BarometricPressureDataValue.ErrorMessage);
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(data.TowerSpecifications.LiquidToGasRatio))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(LiquidToGasRatioDataValue.ErrorMessage);
                }

                if (!Range1Value.UpdateCurrentValue(data.Range1))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(Range1Value.ErrorMessage);
                }

                if (!Range2Value.UpdateCurrentValue(data.Range2))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(Range2Value.ErrorMessage);
                }

                if (!Range3Value.UpdateCurrentValue(data.Range3))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(Range3Value.ErrorMessage);
                }

                if (!Range4Value.UpdateCurrentValue(data.Range4))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(Range4Value.ErrorMessage);
                }

                if (!Range5Value.UpdateCurrentValue(data.Range5))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(Range5Value.ErrorMessage);
                }

                TowerDesignCurveData.Clear();
                foreach (RangedTemperaturesDesignData rangedTemperaturesDesignData in data.RangedTemperaturesDesignData)
                {
                    TowerDesignCurveData towerDesignCurveData = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI);
                    if (!towerDesignCurveData.LoadData(rangedTemperaturesDesignData))
                    {
                        returnValue = false;
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

        public bool CheckRangeOrder()
        {
            return ValidRangeAscendingOrder() || ValidRangeDescendingOrder();
        }

        public bool ValidRangeAscendingOrder()
        {
            bool inOrder = true;

            double testValue = 0.0;

            if(Range1Value.Current > testValue)
            {
                testValue = Range1Value.Current;
            }
            if(Range2Value.Current != 0.0)
            {
                if(Range2Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range2Value.Current;
                }
            }
            if (Range3Value.Current != 0.0)
            {
                if (Range3Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range3Value.Current;
                }
            }
            if (Range4Value.Current != 0.0)
            {
                if (Range4Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range4Value.Current;
                }
            }
            if (Range5Value.Current != 0.0)
            {
                if (Range5Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range5Value.Current;
                }
            }
            if(inOrder)
            {
                RangeOrder = Order.Ascending;
            }
            return inOrder;
        }

        public bool ValidRangeDescendingOrder()
        {
            bool inOrder = true;
    
            double testValue = 0.0;

            if (Range1Value.Current != testValue)
            {
                testValue = Range1Value.Current;
            }
            if (Range2Value.Current != 0.0)
            {
                if (Range2Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range2Value.Current;
                }
            }
            if (Range3Value.Current != 0.0)
            {
                if (Range3Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range3Value.Current;
                }
            }
            if (Range4Value.Current != 0.0)
            {
                if (Range4Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range4Value.Current;
                }
            }
            if (Range5Value.Current != 0.0)
            {
                if (Range5Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range5Value.Current;
                }
            }
            if (inOrder)
            {
                RangeOrder = Order.Descending;
            }
            return inOrder;
        }

        public int CountRanges()
        {
            bool zeroDetected = false;

            int rangeCount = 0;

            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        if (Range1Value.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 1:
                        if (Range2Value.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 2:
                        if (Range3Value.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 3:
                        if (Range4Value.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 4:
                        if (Range5Value.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    default:
                        break;
                }
                if (!zeroDetected)
                {
                    rangeCount++;
                }
            }
            return rangeCount;
        }

        public int CountWetBulbTemperatures(TowerDesignCurveData towerDesignCurveData)
        {
            int count = 0;
            bool zeroDetected = false;

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        if (towerDesignCurveData.WetBulbTemperatureDataValue1.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 1:
                        if (towerDesignCurveData.WetBulbTemperatureDataValue2.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 2:
                        if (towerDesignCurveData.WetBulbTemperatureDataValue3.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 3:
                        if (towerDesignCurveData.WetBulbTemperatureDataValue4.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 4:
                        if (towerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 5:
                        if (towerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0)
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

        public bool CheckWaterFlowRateOrder()
        {
            return ValidWaterFlowRateAscendingOrder();
        }

        public bool ValidWaterFlowRateAscendingOrder()
        {
            bool inOrder = true;

            double testValue = 0.0;
            foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignCurveData)
            {
                if (towerDesignCurveData.WaterFlowRateDataValue.Current != 0.0)
                {
                    if (towerDesignCurveData.WaterFlowRateDataValue.Current > testValue)
                    {
                        testValue = towerDesignCurveData.WaterFlowRateDataValue.Current;
                    }
                    else
                    {
                        inOrder = false;
                    }
                }
            }
            return inOrder;
        }

        public bool ValidWaterFlowRateDescendingOrder(TowerDesignCurveData towerDesignCurveData)
        {
            bool inOrder = true;

            double testValue = 0.0;

            if (Range1Value.Current != testValue)
            {
                testValue = Range1Value.Current;
            }
            if (Range2Value.Current != 0.0)
            {
                if (Range2Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range2Value.Current;
                }
            }
            if (Range3Value.Current != 0.0)
            {
                if (Range3Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range3Value.Current;
                }
            }
            if (Range4Value.Current != 0.0)
            {
                if (Range4Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range4Value.Current;
                }
            }
            if (Range5Value.Current != 0.0)
            {
                if (Range5Value.Current <= testValue)
                {
                    inOrder = false;
                }
                else
                {
                    testValue = Range5Value.Current;
                }
            }
            if (inOrder)
            {
                RangeOrder = Order.Descending;
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

        private void BuildTemperatureList(List<bool> isValidRange, WetBulbTemperature wetBulbTemperature,
                                           double wetbulbTemperature,
                                           double rangeColdWaterTemperature1,
                                           double rangeColdWaterTemperature2,
                                           double rangeColdWaterTemperature3,
                                           double rangeColdWaterTemperature4,
                                           double rangeColdWaterTemperature5
                                           )
        {
            wetBulbTemperature.Temperature = wetbulbTemperature;
            if (isValidRange[0])
            {
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature1);
            }
            if (isValidRange[1])
            {
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature2);
            }
            if (isValidRange[2])
            {
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature3);
            }
            if (isValidRange[3])
            {
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature4);
            }
            if (isValidRange[4])
            {
                wetBulbTemperature.ColdWaterTemperatures.Add(rangeColdWaterTemperature5);
            }
        }

        public bool FillCalculationData(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;
            List<bool> isValidRange = new List<bool> { false, false, false, false, false };

            try
            {
                calculationData.TowerType = TowerTypeValue;
                calculationData.TowerDesignData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

                calculationData.TowerDesignData.WaterFlowRate = WaterFlowRateDataValue.Current;
                calculationData.TowerDesignData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                calculationData.TowerDesignData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                calculationData.TowerDesignData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                calculationData.TowerDesignData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                calculationData.TowerDesignData.FanDriverPower = FanDriverPowerDataValue.Current;
                calculationData.TowerDesignData.BarometricPressure = BarometricPressureDataValue.Current;
                calculationData.TowerDesignData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;

                if (Range1Value.Current != 0.0)
                {
                    isValidRange[0] = true;
                    calculationData.Ranges.Add(Range1Value.Current);
                }
                if (Range2Value.Current != 0.0)
                {
                    isValidRange[1] = true;
                    calculationData.Ranges.Add(Range2Value.Current);
                }
                if (Range3Value.Current != 0.0)
                {
                    isValidRange[2] = true;
                    calculationData.Ranges.Add(Range3Value.Current);
                }
                if (Range4Value.Current != 0.0)
                {
                    isValidRange[3] = true;
                    calculationData.Ranges.Add(Range4Value.Current);
                }
                if (Range5Value.Current != 0.0)
                {
                    isValidRange[4] = true;
                    calculationData.Ranges.Add(Range5Value.Current);
                }

                foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignCurveData)
                {
                    WaterFlowRate flowRate = new WaterFlowRate();
                    flowRate.FlowRate = towerDesignCurveData.WaterFlowRateDataValue.Current;

                    if (towerDesignCurveData.WetBulbTemperatureDataValue1.Current != 0.0)
                    {
                        if(towerDesignCurveData.WetBulbTemperatureDataValue1.Current != 0.0)
                        {
                            WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                            BuildTemperatureList(isValidRange, wetBulbTemperature,
                                                       towerDesignCurveData.WetBulbTemperatureDataValue1.Current,
                                                       towerDesignCurveData.Range1ColdWaterTemperatureDataValue1.Current,
                                                       towerDesignCurveData.Range2ColdWaterTemperatureDataValue1.Current,
                                                       towerDesignCurveData.Range3ColdWaterTemperatureDataValue1.Current,
                                                       towerDesignCurveData.Range4ColdWaterTemperatureDataValue1.Current,
                                                       towerDesignCurveData.Range5ColdWaterTemperatureDataValue1.Current
                                                       );
                            flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                        }
                        if (towerDesignCurveData.WetBulbTemperatureDataValue2.Current != 0.0)
                        {
                            WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                            BuildTemperatureList(isValidRange, wetBulbTemperature,
                                                       towerDesignCurveData.WetBulbTemperatureDataValue2.Current,
                                                       towerDesignCurveData.Range1ColdWaterTemperatureDataValue2.Current,
                                                       towerDesignCurveData.Range2ColdWaterTemperatureDataValue2.Current,
                                                       towerDesignCurveData.Range3ColdWaterTemperatureDataValue2.Current,
                                                       towerDesignCurveData.Range4ColdWaterTemperatureDataValue2.Current,
                                                       towerDesignCurveData.Range5ColdWaterTemperatureDataValue2.Current
                                                       );
                            flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                        }
                        if (towerDesignCurveData.WetBulbTemperatureDataValue3.Current != 0.0)
                        {
                            WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                            BuildTemperatureList(isValidRange, wetBulbTemperature,
                                                       towerDesignCurveData.WetBulbTemperatureDataValue3.Current,
                                                       towerDesignCurveData.Range1ColdWaterTemperatureDataValue3.Current,
                                                       towerDesignCurveData.Range2ColdWaterTemperatureDataValue3.Current,
                                                       towerDesignCurveData.Range3ColdWaterTemperatureDataValue3.Current,
                                                       towerDesignCurveData.Range4ColdWaterTemperatureDataValue3.Current,
                                                       towerDesignCurveData.Range5ColdWaterTemperatureDataValue3.Current
                                                       );
                            flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                        }
                        if (towerDesignCurveData.WetBulbTemperatureDataValue4.Current != 0.0)
                        {
                            WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                            BuildTemperatureList(isValidRange, wetBulbTemperature,
                                                       towerDesignCurveData.WetBulbTemperatureDataValue4.Current,
                                                       towerDesignCurveData.Range1ColdWaterTemperatureDataValue4.Current,
                                                       towerDesignCurveData.Range2ColdWaterTemperatureDataValue4.Current,
                                                       towerDesignCurveData.Range3ColdWaterTemperatureDataValue4.Current,
                                                       towerDesignCurveData.Range4ColdWaterTemperatureDataValue4.Current,
                                                       towerDesignCurveData.Range5ColdWaterTemperatureDataValue4.Current
                                                       );
                            flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                        }
                        if (towerDesignCurveData.WetBulbTemperatureDataValue5.Current != 0.0)
                        {
                            WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                            BuildTemperatureList(isValidRange, wetBulbTemperature,
                                                       towerDesignCurveData.WetBulbTemperatureDataValue5.Current,
                                                       towerDesignCurveData.Range1ColdWaterTemperatureDataValue5.Current,
                                                       towerDesignCurveData.Range2ColdWaterTemperatureDataValue5.Current,
                                                       towerDesignCurveData.Range3ColdWaterTemperatureDataValue5.Current,
                                                       towerDesignCurveData.Range4ColdWaterTemperatureDataValue5.Current,
                                                       towerDesignCurveData.Range5ColdWaterTemperatureDataValue5.Current
                                                       );
                            flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                        }
                        if (towerDesignCurveData.WetBulbTemperatureDataValue6.Current != 0.0)
                        {
                            WetBulbTemperature wetBulbTemperature = new WetBulbTemperature();
                            BuildTemperatureList(isValidRange, wetBulbTemperature,
                                                       towerDesignCurveData.WetBulbTemperatureDataValue6.Current,
                                                       towerDesignCurveData.Range1ColdWaterTemperatureDataValue6.Current,
                                                       towerDesignCurveData.Range2ColdWaterTemperatureDataValue6.Current,
                                                       towerDesignCurveData.Range3ColdWaterTemperatureDataValue6.Current,
                                                       towerDesignCurveData.Range4ColdWaterTemperatureDataValue6.Current,
                                                       towerDesignCurveData.Range5ColdWaterTemperatureDataValue6.Current
                                                       );
                            flowRate.WetBulbTemperatures.Add(wetBulbTemperature);
                        }
                    }
                    calculationData.WaterFlowRates.Add(flowRate);

                }
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Design Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }

        public bool ValidateRanges(int count)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            
            int rangeCount = CountRanges();
            
            if (rangeCount < count)
            {
                stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} ranges in the Tower Design Data to calculate Tower Capability.", count));
                returnValue = false;
            }

            if(!CheckRangeOrder())
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

        public bool ValidateRangedTemperatures(int count)
        {
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            // verify number of wet bulb temperature for each water flow rates
            foreach(TowerDesignCurveData towerDesignCurveData in TowerDesignCurveData)
            {
                int wetBulbTemperatures = CountWetBulbTemperatures(towerDesignCurveData);
                if (wetBulbTemperatures < count)
                {
                    stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} Wet Bulb Temperatures for flow rate {1}.", count, towerDesignCurveData.WaterFlowRateDataValue.Current));
                    returnValue = false;
                }
                else  // verify ascending order of Wet Bulb Temperatures
                {
                    double minimum = towerDesignCurveData.FindMinimumColdWaterTempurature();
                    double maximum = towerDesignCurveData.FindMaximumColdWaterTempurature();
                    if(minimum == )
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
                if (ValidateRanges(MINIMUM_RANGE_COUNT))
                {
                    if (ValidateWaterFlowRates(MINIMUM_WATER_FLOW_RATES_COUNT))
                    {
                        if (ValidateRangedTemperatures(MINIMUM_WET_BULB_TEMPERTURE_COUNT))
                        {
                            isValid = true;
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

        public bool ValidateWaterFlowRates(int count)
        {
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            // verify number of water flow rate
            if (TowerDesignCurveData.Count < count)
            {
                stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} water flow rates.", count));
                returnValue = false;
            }

            // verify ascending / decending order of water flow rate
            if(!CheckWaterFlowRateOrder())
            {
                stringBuilder.AppendLine(string.Format("The water flow rates must be in acsending to calculate Tower Capability.", count));
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }
    }
}
