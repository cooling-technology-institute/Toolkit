// Copyright Cooling Technology Institute 2019-2020

using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class DemandCurveData
    {
        public const string DataType = "DemandCurveData";
        public const string Version = "1.0";

        public bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public DataTable DataTable { get; set; }

        public double CurveC1 { set; get; }
        public double CurveC2 { set; get; }
        public double LiquidToGasRatio { set; get; } //L/G
        public double Elevation { set; get; }
        public double BarometricPressure { set; get; }
        public double KaV_L { set; get; }
        public double CurveMinimum { set; get; }
        public double CurveMaximum { set; get; }
        public double WetBulbTemperature { set; get; }
        public double Range { set; get; }
        public double Approach { set; get; }

        public bool IsElevation { get; set; } // attitude
        public bool IsCoef { get; set; } // coef
        public bool IsWaterAirRatio { get; set; } // lg

        public List<SeriesData> SeriesData { get; set; }

        public double TargetApproach { get; set; }
        public double UserApproach { get; set; }


        public DemandCurveData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
            IsElevation = true;

//#ifdef _DEMO_VERSION
//            CurveC1 = 2.0;
//            CurveC2 = (-0.75);
//#else
            CurveC1 = 0;
            CurveC2 = 0;
//#endif
            LiquidToGasRatio = 1.0;
            BarometricPressure = 0.0;
            Elevation = 0;
            KaV_L = 0;
            CurveMinimum = 0.5;
            CurveMaximum = 2.5;
            if (IsInternationalSystemOfUnits_SI_)
            {
                WetBulbTemperature = 26.667;
                Range = 18;
            }
            else
            {
                WetBulbTemperature = 80;
                Range = 10;
            }

            DataTable = new DataTable();
        }
    }
}