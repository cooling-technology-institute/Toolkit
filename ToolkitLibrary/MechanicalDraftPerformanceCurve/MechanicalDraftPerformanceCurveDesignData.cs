﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class MechanicalDraftPerformanceCurveDesignData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public TOWER_TYPE TowerType { set; get; }

        public double WaterFlowRate { set; get; }
        public double ColdWaterTemperature { set; get; }
        public double HotWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; } 
        public double DryBulbTemperature { set; get; }
        public double FanDrivePower { set; get; }
        public double BarometricPressure { set; get; }
        public double LiquidToGasRatio { set; get; }

        public List<double> Range { set; get; }

        public List<WetBulbTemperatureDesignData> WetBulbTemperatureDesignData { set; get; }
	
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
            FanDrivePower = 0.0;
            BarometricPressure = 0.0;
            LiquidToGasRatio = 0.0;
        }
    }
}