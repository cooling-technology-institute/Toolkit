// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveOutput
    {
        public double AdjustedFlow { set; get; }
        public double PredictedFlow { set; get; }
        public double TowerCapability { set; get; }
        public double ColdWaterTemperatureDeviation { set; get; } 

        public MechanicalDraftPerformanceCurveOutput()
        {
            AdjustedFlow = 0.0;
            PredictedFlow = 0.0;
            TowerCapability = 0.0;
            ColdWaterTemperatureDeviation = 0.0;
        }
    }
}