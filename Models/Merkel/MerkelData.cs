// Copyright Cooling Technology Institute 2019-2020

namespace Models
{
    public class MerkelData
    {
        public const string DataType = "MerkelData";
        public const string Version = "1.0";

        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public double Elevation { set; get; }
        public double BarometricPressure { set; get; }

        public double HotWaterTemperature { set; get; }
        public double ColdWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; } 
        public double LiquidToGasRatio { set; get; }
        public double Approach { set; get; }
        public double Range { set; get; }
        public double KaV_L { set; get; }

        public MerkelData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            HotWaterTemperature = 0.0;
            ColdWaterTemperature = 0.0;
            LiquidToGasRatio = 0.0;
            BarometricPressure = 0.0;
            WetBulbTemperature = 0.0;
            Range = 0.0;
            KaV_L = 0.0;
        }
    }
}