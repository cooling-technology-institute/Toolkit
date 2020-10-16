// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveData
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public double WaterFlowRate { set; get; }
        public double ColdWaterTemperature { set; get; }
        public double HotWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; }
        public double DryBulbTemperature { set; get; }
        public double FanDriverPower { set; get; }
        public double BarometricPressure { set; get; }
        public double LiquidToGasRatio { set; get; }

        public MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = false;
            WaterFlowRate = 0.0;
            HotWaterTemperature = 0.0;
            ColdWaterTemperature = 0.0;
            WetBulbTemperature = 0.0;
            DryBulbTemperature = 0.0;
            FanDriverPower = 0.0;
            BarometricPressure = 0.0;
            LiquidToGasRatio = 0.0;
        }
    }
}