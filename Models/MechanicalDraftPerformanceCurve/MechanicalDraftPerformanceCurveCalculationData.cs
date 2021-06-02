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
        public List<double> InterpolateRanges { get; set; }
        public MechanicalDraftPerformanceCurveOutput TestOutput { get; set; }
        public MechanicalDraftPerformanceCurveOutput DesignOutput { get; set; }
        public CrossPlot1 CrossPlot1 { get; set; }

        public MechanicalDraftPerformanceCurveCalculationData()
        {
            TowerTestData = new TowerSpecifications();
            TowerDesignData = new TowerSpecifications();
            Ranges = new List<double>();
            WaterFlowRates = new List<WaterFlowRate>();
            InterpolateRanges = new List<double>();
            Y = new List<double>();
            TestOutput = new MechanicalDraftPerformanceCurveOutput();
            DesignOutput = new MechanicalDraftPerformanceCurveOutput();
            CrossPlot1 = new CrossPlot1();
        }

        public double FindMinimumWetBulbTempurature(WaterFlowRate waterFlowRate)
        {
            if (waterFlowRate != null
                && waterFlowRate.WetBulbTemperatures != null && waterFlowRate.WetBulbTemperatures.Count > 0)
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
            return 0;
        }

        public double FindMaximumWetBulbTempurature(WaterFlowRate waterFlowRate)
        {
            if (waterFlowRate != null
                && waterFlowRate.WetBulbTemperatures != null && waterFlowRate.WetBulbTemperatures.Count > 0)
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
            return 0;
        }

        public double FindMinimumColdWaterTempurature(WaterFlowRate waterFlowRate)
        {
            if (waterFlowRate != null
                && waterFlowRate.WetBulbTemperatures != null && waterFlowRate.WetBulbTemperatures.Count > 0
                && waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures != null && waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures.Count > 0)
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
            return 0;
        }

        public double FindMaximumColdWaterTempurature(WaterFlowRate waterFlowRate)
        {
            if (waterFlowRate != null 
                && waterFlowRate.WetBulbTemperatures != null && waterFlowRate.WetBulbTemperatures.Count > 0
                && waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures != null && waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures.Count > 0)
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
            return 0;
        }

        public double FindMinimumRange()
        {
            if (Ranges != null && Ranges.Count > 0)
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
            return 0;
        }

        public double FindMaximumRange()
        {
            if (Ranges != null && Ranges.Count > 0)
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
            return 0;
        }

        public double FindMinimumWaterFlowRate()
        {
            if(WaterFlowRates != null && WaterFlowRates.Count > 0)
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
           return 0;
        }

        public double FindMaximumWaterFlowRate()
        {
            if (WaterFlowRates != null && WaterFlowRates.Count > 0)
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
            return 0;
        }

        public List<double> GetWaterFlowRates()
        {
            List<double> values = new List<double>();
            if (WaterFlowRates != null && WaterFlowRates.Count > 0)
            {
                foreach (WaterFlowRate waterFlowRate in WaterFlowRates)
                {
                    values.Add(waterFlowRate.FlowRate);
                }
            }
            return values;
        }
    }
}