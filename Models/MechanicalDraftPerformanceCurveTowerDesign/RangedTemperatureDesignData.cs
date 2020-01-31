// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
    }
}