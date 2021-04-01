// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;

namespace Models
{
    public class WetBulbTemperature
    {
        public double Temperature { get; set; }
        public List<double> ColdWaterTemperatures { get; set; }
        public WetBulbTemperature()
        {
            Temperature = 0.0;
            ColdWaterTemperatures = new List<double>();
        }
    }

    public class WaterFlowRate
    {
        public double FlowRate { get; set; }
        public List<double> Yfit { get; set; }
        public List<WetBulbTemperature> WetBulbTemperatures { get; set; }
        public WaterFlowRate()
        {
            FlowRate = 0.0;
            Yfit = new List<double>();
            WetBulbTemperatures = new List<WetBulbTemperature>();
        }
    }

    public class MechanicalDraftPerformanceCurveCalculationData
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerSpecifications TowerTestData { set; get; }
        public TowerSpecifications TowerDesignData { set; get; }
        public List<double> Ranges { get; set; }
        public List<WaterFlowRate> WaterFlowRates { get; set; }
        public TOWER_TYPE TowerType { get; set; }
        public List<double> Y { get; set; }
        public List<double> WetBulbTemperatureRange { get; set; }

        public MechanicalDraftPerformanceCurveCalculationData()
        {
            TowerTestData = new TowerSpecifications();
            TowerDesignData = new TowerSpecifications();
            Ranges = new List<double>();
            WaterFlowRates = new List<WaterFlowRate>();
            WetBulbTemperatureRange = new List<double>();
            Y = new List<double>();
        }
    }
}