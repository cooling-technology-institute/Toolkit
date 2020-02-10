// Copyright Cooling Technology Institute 2019-2020

using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewModels
{
    public class TowerDesignCurveDataInputData
    {
        public RangedTemperaturesDesignData RangedTemperaturesDesignData { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { set; get; }

        public WetBulbTemperatureDataValue WetBulbTemperature1 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperature2 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperature3 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperature4 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperature5 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperature6 { set; get; }

        public ColdWaterTemperatureDataValue Range1ColdWaterTemperature1 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperature2 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperature3 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperature4 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperature5 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperature6 { set; get; }

        public ColdWaterTemperatureDataValue Range2ColdWaterTemperature1 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperature2 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperature3 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperature4 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperature5 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperature6 { set; get; }


        public ColdWaterTemperatureDataValue Range3ColdWaterTemperature1 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperature2 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperature3 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperature4 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperature5 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperature6 { set; get; }

        public ColdWaterTemperatureDataValue Range4ColdWaterTemperature1 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperature2 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperature3 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperature4 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperature5 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperature6 { set; get; }

        public ColdWaterTemperatureDataValue Range5ColdWaterTemperature1 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperature2 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperature3 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperature4 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperature5 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperature6 { set; get; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public TowerDesignCurveDataInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperature1 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperature2 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperature3 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperature4 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperature5 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperature6 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range1ColdWaterTemperature1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperature2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperature3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperature4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperature5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperature6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range2ColdWaterTemperature1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperature2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperature3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperature4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperature5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperature6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range3ColdWaterTemperature1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperature2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperature3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperature4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperature5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperature6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range4ColdWaterTemperature1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperature2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperature3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperature4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperature5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperature6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range5ColdWaterTemperature1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperature2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperature3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperature4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperature5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperature6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }
    }
}
