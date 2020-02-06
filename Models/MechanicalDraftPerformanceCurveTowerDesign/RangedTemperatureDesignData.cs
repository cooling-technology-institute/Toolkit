// Copyright Cooling Technology Institute 2019-2020

namespace Models
{
    public class RangedTemperaturesDesignData
    {
        public double WaterFlowRate { set; get; }

        public TemperatureDesignData WetBulbTemperatures { set; get; }

        public TemperatureDesignData ColdWaterTemperaturesRange1 { set; get; }
        public TemperatureDesignData ColdWaterTemperaturesRange2 { set; get; }
        public TemperatureDesignData ColdWaterTemperaturesRange3 { set; get; }
        public TemperatureDesignData ColdWaterTemperaturesRange4 { set; get; }
        public TemperatureDesignData ColdWaterTemperaturesRange5 { set; get; }
        public TemperatureDesignData ColdWaterTemperaturesRange6 { set; get; }

        public RangedTemperaturesDesignData()
        {
            WetBulbTemperatures = new TemperatureDesignData();
            ColdWaterTemperaturesRange1 = new TemperatureDesignData();
            ColdWaterTemperaturesRange2 = new TemperatureDesignData();
            ColdWaterTemperaturesRange3 = new TemperatureDesignData();
            ColdWaterTemperaturesRange4 = new TemperatureDesignData();
            ColdWaterTemperaturesRange5 = new TemperatureDesignData();
            ColdWaterTemperaturesRange6 = new TemperatureDesignData();
        }

        public bool ValidateWetBulbTemperature(int count, out string errorMessage)
        {
            return WetBulbTemperatures.ValidateTemperatures(count, 6, "Wet Bulb Temperatures", out errorMessage);
        }

        public bool ValidateColdWaterTemperaturesRange1(int count, out string errorMessage)
        {
            return ColdWaterTemperaturesRange1.ValidateTemperatures(count, WetBulbTemperatures.LastValidTemperature, "Cold Water Temperatures for Range 1", out errorMessage);
        }

        public bool ValidateColdWaterTemperaturesRange2(int count, out string errorMessage)
        {
            return ColdWaterTemperaturesRange2.ValidateTemperatures(count, WetBulbTemperatures.LastValidTemperature, "Cold Water Temperatures for Range 2", out errorMessage);
        }

        public bool ValidateColdWaterTemperaturesRange3(int count, out string errorMessage)
        {
            return ColdWaterTemperaturesRange3.ValidateTemperatures(count, WetBulbTemperatures.LastValidTemperature, "Cold Water Temperatures for Range 3", out errorMessage);
        }

        public bool ValidateColdWaterTemperaturesRange4(int count, out string errorMessage)
        {
            return ColdWaterTemperaturesRange4.ValidateTemperatures(count, WetBulbTemperatures.LastValidTemperature, "Cold Water Temperatures for Range 4", out errorMessage);
        }

        public bool ValidateColdWaterTemperaturesRange5(int count, out string errorMessage)
        {
            return ColdWaterTemperaturesRange5.ValidateTemperatures(count, WetBulbTemperatures.LastValidTemperature, "Cold Water Temperatures for Range 5", out errorMessage);
        }
    }
}