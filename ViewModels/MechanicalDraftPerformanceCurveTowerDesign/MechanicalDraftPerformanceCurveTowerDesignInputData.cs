// Copyright Cooling Technology Institute 2019-2020

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignInputData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public string TowerType { set; get; }

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

        public string MechanicalDraftPerformanceCurvePerformanceDesignDataFile { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public MechanicalDraftPerformanceCurveTowerDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            RangeDataValue1 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue2 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue3 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue4 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue5 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
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
