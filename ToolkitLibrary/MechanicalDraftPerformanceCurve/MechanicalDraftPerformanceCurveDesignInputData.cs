using System.Collections.Generic;

namespace ToolkitLibrary
{
    //Hot Water Temperature HWT
    //Cold Water Temperature CWT
    //Wet Bulb Temperature WBT
    //Water Flow Rate L
    //Air Flow Rate G
    public class MechanicalDraftPerformanceCurveDesignInputData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public string TowerType { set; get; }

        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { set; get; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { set; get; } 
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { set; get; }
        public FanDrivePowerDataValue FanDrivePowerDataValue { set; get; }
        public BarometricPressureDataValue BarometricPressureDataValue { set; get; }
        public LiquidToGasRatioRateDataValue LiquidToGasRatioRateDataValue { set; get; }
        public WaterFlowRateDataValue WaterFlowRateDataValue { set; get; }

        public RangeDataValue RangeDataValue1 { get; set; }
        public RangeDataValue RangeDataValue2 { get; set; }
        public RangeDataValue RangeDataValue3 { get; set; }
        public RangeDataValue RangeDataValue4 { get; set; }
        public RangeDataValue RangeDataValue5 { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public MechanicalDraftPerformanceCurveDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            RangeDataValue1 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue2 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue3 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue4 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue5 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioRateDataValue = new LiquidToGasRatioRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }
    }
}