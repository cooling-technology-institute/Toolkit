// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class PsychrometricsDataFile : FileDataType
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PsychrometricsCalculationType CalculationType { get; set; }
        public bool IsElevation { get; set; }

        public double Enthalpy { get; set; }
        public double Elevation { get; set; }
        public double BarometricPressure { get; set; }
        public double RelativeHumidity { get; set; }
        public double WetBulbTemperature { get; set; }
        public double DryBulbTemperature { get; set; }

        public PsychrometricsDataFile(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            DataType = "Psychrometrics";
            Version = "1.0";
        }
    }
}
