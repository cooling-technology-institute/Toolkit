// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class TowerDesignData
    {
        const int MIN_FLOW_COUNT = 3;
        const int MIN_RANGE_COUNT = 3;
        const int MIN_WET_BULB_TEMPERTURE_COUNT = 3;	// Dean's notes say 5 ....

        public string OwnerNameValue { set; get; }
        public string ProjectNameValue { set; get; }
        public string LocationValue { set; get; }
        public string TowerManufacturerValue { set; get; }
        public TOWER_TYPE TowerTypeValue { set; get; }
        public int RangeCount { set; get; }

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

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerDesignData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            OwnerNameValue = string.Empty;
            ProjectNameValue = string.Empty;
            LocationValue = string.Empty;
            TowerManufacturerValue = string.Empty;
            TowerTypeValue = TOWER_TYPE.Forced;

            Range1Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1Value.InitializeValue(0.0);
            Range2Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2Value.InitializeValue(0.0);
            Range3Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3Value.InitializeValue(0.0);
            Range4Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4Value.InitializeValue(0.0);
            Range5Value = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
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
        }

        public bool LoadData(DesignData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();
            string label = "Design Data: ";
            try
            {
                OwnerNameValue = data.OwnerName;
                ProjectNameValue = data.ProjectName;
                LocationValue = data.Location;
                TowerManufacturerValue = data.TowerManufacturer;
                TowerTypeValue = data.TowerType;

                if (IsInternationalSystemOfUnits_SI != data.TowerSpecifications.IsInternationalSystemOfUnits_SI)
                {
                    IsInternationalSystemOfUnits_SI = data.TowerSpecifications.IsInternationalSystemOfUnits_SI;
                    WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    Range1Value.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    Range2Value.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    Range3Value.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    Range4Value.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    Range5Value.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                }

                if (!WaterFlowRateDataValue.UpdateCurrentValue(data.TowerSpecifications.WaterFlowRate, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.HotWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.ColdWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.WetBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(data.TowerSpecifications.DryBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!FanDriverPowerDataValue.UpdateCurrentValue(data.TowerSpecifications.FanDriverPower, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(data.TowerSpecifications.BarometricPressure, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(data.TowerSpecifications.LiquidToGasRatio, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!Range1Value.UpdateCurrentValue(data.Range1, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!Range2Value.UpdateCurrentValue(data.Range2, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!Range3Value.UpdateCurrentValue(data.Range3, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!Range4Value.UpdateCurrentValue(data.Range4, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!Range5Value.UpdateCurrentValue(data.Range5, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                CountRanges();
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to Mechanical Draft Performance Curve Design Data. Exception: {0}", e.ToString());
                returnValue = false;
            }
            return returnValue;
        }

        public int CountRanges()
        {
            bool zeroDetected = false;

            RangeCount = 0;

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
                    RangeCount++;
                }
            }
            return RangeCount;
        }

        public bool FillAndValidate(DesignData data, out string errorMessage)
        {
            errorMessage = string.Empty;
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
                    towerDesignCurveData.FillAndValidate(ref rangedTemperaturesDesignData, out errorMessage);
                    data.RangedTemperaturesDesignData.Add(rangedTemperaturesDesignData);
                }
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Design Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}
