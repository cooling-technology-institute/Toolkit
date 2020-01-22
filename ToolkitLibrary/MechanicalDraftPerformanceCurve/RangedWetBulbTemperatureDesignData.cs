using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class RangedWetBulbTemperatureDesignData
    {
        public double WaterFlowRate { set; get; }

        public WetBulbTemperatureDesignData WetBulbTemperatures { set; get; }

        public RangeWetBulbTemperaturesDesignData[] RangeWetBulbTemperatures { set; get; }

        public RangedWetBulbTemperatureDesignData()
        {
            RangeWetBulbTemperatures = new RangeWetBulbTemperaturesDesignData[5];
        }
    }
}