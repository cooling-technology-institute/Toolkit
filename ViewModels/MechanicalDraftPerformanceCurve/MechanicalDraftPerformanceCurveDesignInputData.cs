// Copyright Cooling Technology Institute 2019-2020

using System.Collections.Generic;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveDesignInputData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public string TowerType { set; get; }

        public WaterAirFlowRateDataValue WaterAirFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioRateDataValue { get; set; }

        public List<MechanicalDraftPerformanceCurveTowerDesignInputData> MechanicalDraftPerformanceCurveTowerDesignInputData { get; set; }

        public string MechanicalDraftPerformanceCurvePerformanceDesignDataFile { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public MechanicalDraftPerformanceCurveDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            WaterAirFlowRateDataValue = new WaterAirFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioRateDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }

        public bool ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_IS != isInternationalSystemOfUnits_IS_)
            {
                IsInternationalSystemOfUnits_IS = isInternationalSystemOfUnits_IS_;
                WaterAirFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                LiquidToGasRatioRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                isChanged = true;
            }

            return isChanged;
        }

        public bool LoadFile(string filename, out string errorMessage)
        {
            errorMessage = string.Empty;

            // if file extension is json
            // else load old file format and save a json file

            return true;
        }
    }
}