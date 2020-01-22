using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class WetBulbTemperatureDesignData
    {
        public double[] WetBulbTemperatures { set; get; }

        public WetBulbTemperatureDesignData()
        {
            WetBulbTemperatures = new double[5];
			
			for(int i = 0; i < WetBulbTemperatures.Length; i++)
			{
				WetBulbTemperatures[i] = 0.0;
			}
        }
    }
}