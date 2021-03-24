// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class MechanicalDraftPerformanceCurveOutput
    {
        public double AdjustedFlow { set; get; }
        public double PredictedFlow { set; get; }
        public double TowerCapability { set; get; }
        public double ColdWaterTemperatureDeviation { set; get; }
        public double Density { set; get; }
        public double SpecificVolume { set; get; }
        public double WetBulbTemperature { set; get; }
        public double LiquidToGasRatio { set; get; }
        
        public MechanicalDraftPerformanceCurveOutput()
        {
            AdjustedFlow = 0.0;
            PredictedFlow = 0.0;
            TowerCapability = 0.0;
            ColdWaterTemperatureDeviation = 0.0;
            Density = 0.0;
            SpecificVolume = 0.0;
            WetBulbTemperature = 0.0;
            LiquidToGasRatio = 0.0;
        }
    }
}