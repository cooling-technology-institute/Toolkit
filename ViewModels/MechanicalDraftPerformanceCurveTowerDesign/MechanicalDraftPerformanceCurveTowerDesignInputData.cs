// Copyright Cooling Technology Institute 2019-2020

using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignInputData
    {
        const int MIN_FLOW_COUNT = 3;
        const int MIN_RANGE_COUNT = 3;
        const int MIN_WET_BULB_TEMPERTURE_COUNT = 3;	// Dean's notes say 5 ....

        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public TOWER_TYPE TowerType { set; get; }
        public int RangeCount { set; get; }

        public RangeDataValue RangeDataValue1 { get; set; }
        public RangeDataValue RangeDataValue2 { get; set; }
        public RangeDataValue RangeDataValue3 { get; set; }
        public RangeDataValue RangeDataValue4 { get; set; }
        public RangeDataValue RangeDataValue5 { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }

        public WaterFlowRateDataValue AddWaterFlowRateDataValue { get; set; }

        public string MechanicalDraftPerformanceCurvePerformanceDesignDataFile { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveDesignData MechanicalDraftPerformanceCurveDesignData { get; set; }

        public MechanicalDraftPerformanceCurveTowerDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            MechanicalDraftPerformanceCurveDesignData = new MechanicalDraftPerformanceCurveDesignData();
    
            OwnerName = string.Empty;
            ProjectName = string.Empty;
            Location = string.Empty;
            TowerManufacturer = string.Empty;
            TowerType = TOWER_TYPE.Forced;

            RangeDataValue1 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue1.InitializeValue(0.0);
            RangeDataValue2 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue2.InitializeValue(0.0);
            RangeDataValue3 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue3.InitializeValue(0.0);
            RangeDataValue4 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue4.InitializeValue(0.0);
            RangeDataValue5 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue5.InitializeValue(0.0);

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

        public bool LoadData(MechanicalDraftPerformanceCurveFileData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();
            string label = "Design Data: ";
            try
            {
                MechanicalDraftPerformanceCurveDesignData = data.DesignData;

                OwnerName = MechanicalDraftPerformanceCurveDesignData.OwnerName;
                ProjectName = MechanicalDraftPerformanceCurveDesignData.ProjectName;
                Location = MechanicalDraftPerformanceCurveDesignData.Location;
                TowerManufacturer = MechanicalDraftPerformanceCurveDesignData.TowerManufacturer;
                TowerType = MechanicalDraftPerformanceCurveDesignData.TowerType;

                if (IsInternationalSystemOfUnits_SI != data.IsInternationalSystemOfUnits_SI)
                {
                    IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
                    WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    RangeDataValue1.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    RangeDataValue2.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    RangeDataValue3.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    RangeDataValue4.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    RangeDataValue5.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                }

                if (!WaterFlowRateDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.HotWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.ColdWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.WetBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.DryBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!FanDriverPowerDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.FanDriverPower, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.BarometricPressure, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(data.DesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue1.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range1, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue2.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range2, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue3.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range3, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue4.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range4, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue5.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range5, out errorMessage))
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
                        if (RangeDataValue1.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 1:
                        if (RangeDataValue2.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 2:
                        if (RangeDataValue3.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 3:
                        if (RangeDataValue4.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 4:
                        if (RangeDataValue5.Current == 0.0)
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

        public bool FillAndValidate(MechanicalDraftPerformanceCurveDesignData mechanicalDraftPerformanceCurveDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                mechanicalDraftPerformanceCurveDesignData.OwnerName = OwnerName;
                mechanicalDraftPerformanceCurveDesignData.ProjectName = ProjectName;
                mechanicalDraftPerformanceCurveDesignData.Location = Location;
                mechanicalDraftPerformanceCurveDesignData.TowerManufacturer = TowerManufacturer;
                mechanicalDraftPerformanceCurveDesignData.TowerType = TowerType;
                mechanicalDraftPerformanceCurveDesignData.OwnerName = OwnerName;

                mechanicalDraftPerformanceCurveDesignData.Range1 = RangeDataValue1.Current;
                mechanicalDraftPerformanceCurveDesignData.Range2 = RangeDataValue2.Current;
                mechanicalDraftPerformanceCurveDesignData.Range3 = RangeDataValue3.Current;
                mechanicalDraftPerformanceCurveDesignData.Range4 = RangeDataValue4.Current;
                mechanicalDraftPerformanceCurveDesignData.Range5 = RangeDataValue5.Current;

                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.WaterFlowRate = WaterFlowRateDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.FanDriverPower = FanDriverPowerDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.BarometricPressure = BarometricPressureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.MechanicalDraftPerformanceCurveData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Test Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}
