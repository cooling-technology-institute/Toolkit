﻿// Copyright Cooling Technology Institute 2019-2020

using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveDesignData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumAsIntConverter))]
        public TOWER_TYPE TowerType { set; get; }

        public double WaterFlowRate { set; get; }
        public double ColdWaterTemperature { set; get; }
        public double HotWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; } 
        public double DryBulbTemperature { set; get; }
        public double FanDriverPower { set; get; }
        public double BarometricPressure { set; get; }
        public double LiquidToGasRatio { set; get; }

        public double Range1 { set; get; }
        public double Range2 { set; get; }
        public double Range3 { set; get; }
        public double Range4 { set; get; }
        public double Range5 { set; get; }
        public int RangeCount { set; get; }
        public int LastValidRange { set; get; }
        public bool RangeLessThan { set; get; }

        public List<RangedTemperaturesDesignData> RangedTemperaturesDesignData { set; get; }
	
        public MechanicalDraftPerformanceCurveDesignData()
        {
            OwnerName = string.Empty;
            ProjectName = string.Empty;
            Location = string.Empty;
            TowerManufacturer = string.Empty;
            TowerType = TOWER_TYPE.Forced;

            WaterFlowRate = 0.0;
            HotWaterTemperature = 0.0;
            ColdWaterTemperature = 0.0;
            WetBulbTemperature = 0.0;
            DryBulbTemperature = 0.0;
            FanDriverPower = 0.0;
            BarometricPressure = 0.0;
            LiquidToGasRatio = 0.0;

            RangeCount = 0;
            LastValidRange = 0;
            RangeLessThan = false;

            RangedTemperaturesDesignData = new List<RangedTemperaturesDesignData>();
        }

        public bool ValidateRanges(int count, out string errorMessage)
        {
            errorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            bool zeroDetected = false;

            RangeCount = 0;
            LastValidRange = 0;
            RangeLessThan = false;

            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        returnValue &= CheckRange(i, Range1, 0.0, ref zeroDetected, stringBuilder);
                        break;
                    case 1:
                        returnValue &= CheckRange(i, Range2, Range1, ref zeroDetected, stringBuilder);
                        break;
                    case 2:
                        returnValue &= CheckRange(i, Range3, Range2, ref zeroDetected, stringBuilder);
                        break;
                    case 3:
                        returnValue &= CheckRange(i, Range4, Range3, ref zeroDetected, stringBuilder);
                        break;
                    case 4:
                        returnValue &= CheckRange(i, Range5, Range4, ref zeroDetected, stringBuilder);
                        break;
                    default:
                        returnValue = false;
                        break;
                }
            }

            if (RangeCount < count)
            {
                stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} ranges in the Tower Design Data to calculate Tower Capability.", count));
                returnValue = false;
            }
            
            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        bool CheckRange(int rangeNumber, double range, double previousRange, ref bool zeroDetected, StringBuilder stringBuilder)
        {
            bool returnValue = true;

            if (range == 0.0)
            {
                returnValue = false;
                zeroDetected = true;
            }
            else
            {
                if(rangeNumber == 1)
                {
                    if (previousRange < range)
                    {
                        RangeLessThan = true;
                    }
                }
                else if(rangeNumber > 0)
                {
                    if (previousRange == range)
                    {
                        stringBuilder.AppendLine(string.Format("Range {0} is equal to Range {1}.", rangeNumber, rangeNumber + 1));
                        returnValue = false;
                    }
                    else if (RangeLessThan && (previousRange > range))
                    {
                        stringBuilder.AppendLine(string.Format("Range {0} is greater than Range {1}.", rangeNumber, rangeNumber + 1));
                        returnValue = false;
                    }
                    else if (!RangeLessThan && (previousRange < range))
                    {
                        stringBuilder.AppendLine(string.Format("Range {0} is less than Range {1}.", rangeNumber, rangeNumber + 1));
                        returnValue = false;
                    }
                }

                if (returnValue)
                {
                    LastValidRange = rangeNumber + 1;

                    if (!zeroDetected)
                    {
                        RangeCount++;
                    }
                }
            }
            return returnValue;
        }
    }
}