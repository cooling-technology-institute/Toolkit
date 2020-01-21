using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class WetBulbTemperatureDesignData
    {
        public double WaterFlowRate { set; get; }

        public double WetBulbTemperatures[5] { set; get; }
	
        public WetBulbTemperatureDesignData()
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
			
			for(int i = 0; i < WetBulbTemperatures.Length; i++)
			{
				WetBulbTemperatures = 0.0;
			}
            WaterFlowRate = 0.0;
        }
    }
}