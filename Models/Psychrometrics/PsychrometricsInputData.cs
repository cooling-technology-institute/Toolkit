// Copyright Cooling Technology Institute 2019-2020

namespace Models
{
    public class PsychrometricsInputData
    {
        public const string DataType = "PsychrometricsInputData";
        public const string Version = "1.0";

        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public PsychrometricsCalculationType CalculationType { set; get; }
        public bool IsElevation { set; get; }
        public double Elevation { set; get; }

        PsychrometricsData PsychrometricsData { get; set; }

        public PsychrometricsInputData()
        {
            CalculationType = PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature;
            IsElevation = false;
            IsInternationalSystemOfUnits_SI = false;
            Elevation = 0.0;
            PsychrometricsData = new PsychrometricsData();
        }
    }
}