// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Collections.Generic;

namespace Models
{
    public class CrossPlot1
    {
        public List<Point> Points { get; set; }
        public double ColdWaterTemperatureMinimum { get; set; }
        public double ColdWaterTemperatureMaximum { get; set; }

        public CrossPlot1()
        {
            Points = new List<Point>();
            ColdWaterTemperatureMinimum = 0.0;
            ColdWaterTemperatureMaximum = 0.0;
        }
    }

    public class RangePoints
    {
        public List<Point> Points { get; set; }

        public RangePoints()
        {
            Points = new List<Point>();
        }
    }

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
        public List<WetBulbTemperature> WetBulbTemperatures { get; set; }
        public List<RangePoints> RangePoints { get; set; }
        public List<double> Yfit { get; set; }

        public WaterFlowRate()
        {
            FlowRate = 0.0;
            WetBulbTemperatures = new List<WetBulbTemperature>();
            RangePoints = new List<RangePoints>();
            Yfit = new List<double>();
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
        public CrossPlot1 CrossPlot1 { get; set; }

        public MechanicalDraftPerformanceCurveCalculationData()
        {
            TowerTestData = new TowerSpecifications();
            TowerDesignData = new TowerSpecifications();
            Ranges = new List<double>();
            WaterFlowRates = new List<WaterFlowRate>();
            WetBulbTemperatureRange = new List<double>();
            Y = new List<double>();
            CrossPlot1 = new CrossPlot1();
        }

        public double FindMinimumWetBulbTempurature(WaterFlowRate waterFlowRate)
        {
            double value = waterFlowRate.WetBulbTemperatures[0].Temperature;
            foreach(WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
            {
                if(wetBulbTemperature.Temperature < value)
                {
                    value = wetBulbTemperature.Temperature;
                }
            }
            return Math.Round(value, MidpointRounding.ToEven);
        }

        public double FindMaximumWetBulbTempurature(WaterFlowRate waterFlowRate)
        {
            double value = waterFlowRate.WetBulbTemperatures[0].Temperature;
            foreach (WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
            {
                if (wetBulbTemperature.Temperature > value)
                {
                    value = wetBulbTemperature.Temperature;
                }
            }
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public double FindMinimumColdWaterTempurature(WaterFlowRate waterFlowRate)
        {
            double value = waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures[0];
            foreach (WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
            {
                foreach (double coldWaterTemperature in wetBulbTemperature.ColdWaterTemperatures)
                {
                    if (coldWaterTemperature < value)
                    {
                        value = coldWaterTemperature;
                    }
                }
            }
            return Math.Round(value, MidpointRounding.ToEven);
        }

        public double FindMaximumColdWaterTempurature(WaterFlowRate waterFlowRate)
        {
            double value = waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures[0];
            foreach (WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
            {
                foreach (double coldWaterTemperature in wetBulbTemperature.ColdWaterTemperatures)
                {
                    if (coldWaterTemperature > value)
                    {
                        value = coldWaterTemperature;
                    }
                }
            }
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public double FindMinimumRange()
        {
            double value = Ranges[0];
            foreach (double range in Ranges)
            {
                if (range < value)
                {
                    value = range;
                }
            }
            return Math.Round(value, MidpointRounding.ToEven);
        }

        public double FindMaximumRange()
        {
            double value = Ranges[0];
            foreach (double range in Ranges)
            {
                if (range > value)
                {
                    value = range;
                }
            }
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public double FindMinimumWaterFlowRate()
        {
            double value = WaterFlowRates[0].FlowRate;
            foreach (WaterFlowRate waterFlowRate in WaterFlowRates)
            {
                if (waterFlowRate.FlowRate < value)
                {
                    value = waterFlowRate.FlowRate;
                }
            }
            return Math.Round(value, MidpointRounding.ToEven);
        }

        public double FindMaximumWaterFlowRate()
        {
            double value = WaterFlowRates[0].FlowRate;
            foreach (WaterFlowRate waterFlowRate in WaterFlowRates)
            {
                if (waterFlowRate.FlowRate > value)
                {
                    value = waterFlowRate.FlowRate;
                }
            }
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public List<double> GetWaterFlowRates()
        {
            List<double> values = new List<double>();
            foreach (WaterFlowRate waterFlowRate in WaterFlowRates)
            {
                values.Add(waterFlowRate.FlowRate);
            }
            return values;
        }
    }
}