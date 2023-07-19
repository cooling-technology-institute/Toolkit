// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class DemandCurveData
    {
        public double CurveC1 { set; get; }
        public double CurveC2 { set; get; }
        public double LiquidToGasRatio { set; get; } //L/G
        public double Elevation { set; get; }
        public double BarometricPressure { set; get; }
        public double CurveMinimum { set; get; }
        public double CurveMaximum { set; get; }
        public double WetBulbTemperature { set; get; }
        public double Range { set; get; }

        public bool IsElevation { get; set; } // attitude
        public bool IsApproach { get; set; } // coef
        public bool IsWaterAirRatio { get; set; } // lg

        public double KaV_L { set; get; }
        public double TargetApproach { set; get; }
        public double UserApproach { get; set; }
        public double Pressure { set; get; }

        public DemandCurveData()
        {
            Initialize();
        }

        public void Initialize()
        {
            CurveC1 = 0.0;
            CurveC2 = 0.0;
            LiquidToGasRatio = 0.0;
            BarometricPressure = 0.0;
            Elevation = 0;
            CurveMinimum = 0;
            CurveMaximum = 0;
            WetBulbTemperature = 0.0;
            Range = 0.0;
            Pressure = 0.0;

            IsElevation = true;
            IsWaterAirRatio = false;
            IsApproach = true;

            KaV_L = 0;
            TargetApproach = 0.0;
            UserApproach = 0.0;
        }
    }
}