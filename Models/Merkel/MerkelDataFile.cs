// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class MerkelDataFile : FileDataType
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }

        public double Elevation { set; get; }
        public double BarometricPressure { set; get; }

        public double HotWaterTemperature { set; get; }
        public double ColdWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; } 
        public double LiquidToGasRatio { set; get; }

        public MerkelDataFile(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            DataType = "Merkel";
            Version = "1.0";
            
            IsElevation = false;
            Elevation = 0.0;
            BarometricPressure = 0.0;
            HotWaterTemperature = 0.0;
            ColdWaterTemperature = 0.0;
            WetBulbTemperature = 0.0;
            LiquidToGasRatio = 0.0;
        }
    }
}