using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class PsychrometricsInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }
        public bool IsElevation { get; set; }

        public EnthalpyDataValue EnthalpyDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public RelativeHumitityDataValue RelativeHumitityDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }

        public PsychrometricsInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
            IsElevation = true;
            CalculationType = PsychrometricsCalculationType.Psychrometrics_WBT_DBT;
            EnthalpyDataValue = new EnthalpyDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            RelativeHumitityDataValue = new RelativeHumitityDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
        }

        public bool ConvertValues(bool isInternationalSystemOfUnits_IS_)
        {
            if(IsInternationalSystemOfUnits_IS_ != isInternationalSystemOfUnits_IS_)
            {
                IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
                EnthalpyDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
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