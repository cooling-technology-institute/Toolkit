using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    //Hot Water Temperature HWT
    //Cold Water Temperature CWT
    //Wet Bulb Temperature WBT
    //Water Flow Rate L
    //Air Flow Rate G
    public class MerkelInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }
        public bool IsElevation { get; set; }

        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBlubTemperatureDataValue WetBlubTemperatureDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public WaterAirFlowRateDataValue WaterAirFlowRateDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }

        public MerkelInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS_ = IsInternationalSystemOfUnits_IS_;
            IsElevation = true;
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            WetBlubTemperatureDataValue = new WetBlubTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            WaterAirFlowRateDataValue = new WaterAirFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
        }

        public bool ConvertValues(bool isInternationalSystemOfUnits_IS_)
        {
            if(IsInternationalSystemOfUnits_IS_ != isInternationalSystemOfUnits_IS_)
            {
                IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                WaterAirFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                WetBlubTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                return true;
            }
            return false;
        }

        public void SetElevation(bool value)
        {
            IsElevation = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }
    }
}