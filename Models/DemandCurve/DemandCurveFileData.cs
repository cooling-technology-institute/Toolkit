// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class DemandCurveFileData : FileDataType
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public double WetBulbTemperature { set; get; }
        public double Range { set; get; }
        public double Elevation { set; get; }
        public double BarometricPressure { set; get; }
        public double CurveC1 { set; get; }
        public double CurveC2 { set; get; }
        public double CurveMinimum { set; get; }
        public double CurveMaximum { set; get; }
        public double LiquidToGasRatio { set; get; } //L/G

        public bool IsElevation { get; set; } // attitude

        public DemandCurveFileData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            DataType = "DemandCurveData";
            Version = "1.0";
        }
    }
}
