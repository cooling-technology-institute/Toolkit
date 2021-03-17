// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace ViewModels
{
    public class PsychrometricsInputData
    {
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI_ { get; set; }
        public bool IsElevation { get; set; }

        public EnthalpyDataValue EnthalpyDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public RelativeHumidityDataValue RelativeHumidityDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }

        public PsychrometricsInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
            IsElevation = true;
            CalculationType = PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature;
            EnthalpyDataValue = new EnthalpyDataValue(IsDemo, IsInternationalSystemOfUnits_SI_);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_SI_);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI_);
            RelativeHumidityDataValue = new RelativeHumidityDataValue(IsDemo, IsInternationalSystemOfUnits_SI_);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI_);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI_);
        }

        public bool FillAndValidate(PsychrometricsData data, bool isElevation, out string errorMessage)
        {
            errorMessage = string.Empty;

            data.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI_;
            data.BarometricPressure = BarometricPressureDataValue.Current;
            data.Elevation = ElevationDataValue.Current;
            data.RootEnthalpy = EnthalpyDataValue.Current;
            data.RelativeHumidity = RelativeHumidityDataValue.Current;
            data.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
            data.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
            
            return true;
        }

        public bool ConvertValues(bool isInternationalSystemOfUnits_IS_)
        {
            if(IsInternationalSystemOfUnits_SI_ != isInternationalSystemOfUnits_IS_)
            {
                IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
                EnthalpyDataValue.ConvertValue(IsInternationalSystemOfUnits_SI_);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_SI_);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI_);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI_);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI_);
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