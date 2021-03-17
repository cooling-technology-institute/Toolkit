// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class TowerSpecifications
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

        public TowerSpecifications()
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

        public TowerSpecifications(TowerSpecifications mechanicalDraftPerformanceCurveData)
        {
            IsInternationalSystemOfUnits_SI = mechanicalDraftPerformanceCurveData.IsInternationalSystemOfUnits_SI;
            WaterFlowRate = mechanicalDraftPerformanceCurveData.WaterFlowRate;
            HotWaterTemperature = mechanicalDraftPerformanceCurveData.HotWaterTemperature;
            ColdWaterTemperature = mechanicalDraftPerformanceCurveData.ColdWaterTemperature;
            WetBulbTemperature = mechanicalDraftPerformanceCurveData.WetBulbTemperature;
            DryBulbTemperature = mechanicalDraftPerformanceCurveData.DryBulbTemperature;
            FanDriverPower = mechanicalDraftPerformanceCurveData.FanDriverPower;
            BarometricPressure = mechanicalDraftPerformanceCurveData.BarometricPressure;
            LiquidToGasRatio = mechanicalDraftPerformanceCurveData.LiquidToGasRatio;
        }
    }
}