// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveData
    {
        const double WATER_FLOW_RATE_MIN_IP = 0.1;
        const double WATER_FLOW_RATE_MAX_IP = double.MaxValue;
        const double WATER_FLOW_RATE_MIN_SI = 0.1;
        const double WATER_FLOW_RATE_MAX_SI = double.MaxValue;
        const double HOT_WATER_TEMPERATURE_MIN_IP = 32.0;
        const double HOT_WATER_TEMPERATURE_MAX_IP = 212.0;
        const double HOT_WATER_TEMPERATURE_MIN_SI = 0.0;
        const double HOT_WATER_TEMPERATURE_MAX_SI = 100.0;
        const double COLD_WATER_TEMPERATURE_MIN_IP = 32.0;
        const double COLD_WATER_TEMPERATURE_MAX_IP = 212.0;
        const double COLD_WATER_TEMPERATURE_MIN_SI = 0.0;
        const double COLD_WATER_TEMPERATURE_MAX_SI = 100.0;
        const double WetBulbTemperature_MIN_IP = 0.0;
        const double WetBulbTemperature_MAX_IP = 200.0;
        const double WetBulbTemperature_MIN_SI = -18.0;
        const double WetBulbTemperature_MAX_SI = 93.0;
        const double DryBulbTemperature_MIN_IP = 0.0;
        const double DryBulbTemperature_MAX_IP = 200.0;
        const double DryBulbTemperature_MIN_SI = -18.0;
        const double DryBulbTemperature_MAX_SI = 93.0;
        const double FAN_DRIVER_POWER_MIN_IP = 0.0001;
        const double FAN_DRIVER_POWER_MAX_IP = 1000.0;
        const double FAN_DRIVER_POWER_MIN_SI = 0.0001;
        const double FAN_DRIVER_POWER_MAX_SI = 745.7;
        const double BAROMETRIC_PRESSURE_MIN_IP = 5.0;
        const double BAROMETRIC_PRESSURE_MAX_IP = 31.5;
        const double BAROMETRIC_PRESSURE_MIN_SI = 16.932;
        const double BAROMETRIC_PRESSURE_MAX_SI = 103.285;
        const double LiquidGasRatio_MIN_IP = 0.01;
        const double LiquidGasRatio_MAX_IP = 20.0;
        const double LiquidGasRatio_MIN_SI = 0.01;
        const double LiquidGasRatio_MAX_SI = 20.0;

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

        public MechanicalDraftPerformanceCurveData(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData)
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