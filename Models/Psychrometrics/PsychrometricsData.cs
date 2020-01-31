// Copyright Cooling Technology Institute 2019-2020

namespace Models
{
    public class PsychrometricsData
    {
        public PsychrometricsCalculationType CalculationType { set; get; }
        public bool IsElevation { set; get; }
        public bool IsInternationalSystemOfUnits_IS_ { set; get; }
        public double Elevation { set; get; }
        public double WetBulbTemperature { set; get; } // TWB
        public double DryBulbTemperature { set; get; } // TDB
        public double BarometricPressure { set; get; }
        public double HumidityRatio { set; get; }
        public double RelativeHumidity { set; get; }
        public double Enthalpy { set; get; }
        public double SpecificVolume { set; get; }
        public double Density { set; get; }
        public double DewPoint { set; get; }
        public double DegreeOfSaturation { get; set; }

        public PsychrometricsData()
        {
            CalculationType = PsychrometricsCalculationType.Psychrometrics_WetBulbTemperature_DryBulbTemperature;
            IsElevation = false;
            IsInternationalSystemOfUnits_IS_ = false;
            Elevation = 0.0;
            WetBulbTemperature = 0.0;
            DryBulbTemperature = 0.0;
            BarometricPressure = 0.0;
            HumidityRatio = 0.0;
            RelativeHumidity = 0.0;
            Enthalpy = 0.0;
            SpecificVolume = 0.0;
            Density = 0.0;
            DewPoint = 0.0;
            DegreeOfSaturation = 0.0;
        }
    }
}