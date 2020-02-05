// Copyright Cooling Technology Institute 2019-2020DataValue

using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewModels
{
    public class RangedTemperatureDesignInputData
    {
        public RangedTemperaturesDesignData RangedTemperaturesDesignData { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { set; get; }

        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue1 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue2 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue3 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue4 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue5 { set; get; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range1ColdWaterTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range2ColdWaterTemperatureDataValue6 { set; get; }


        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range3ColdWaterTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range4ColdWaterTemperatureDataValue6 { set; get; }

        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue1 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue2 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue3 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue4 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue5 { set; get; }
        public ColdWaterTemperatureDataValue Range5ColdWaterTemperatureDataValue6 { set; get; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public RangedTemperatureDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue1 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue2 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue3 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue4 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue5 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue6 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range1ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range1ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range2ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range2ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range3ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range3ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range4ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range4ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            Range5ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            Range5ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
        }

        public bool LoadData(RangedTemperaturesDesignData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            RangedTemperaturesDesignData = data;

            WaterFlowRateDataValue.UpdateCurrentValue(RangedTemperaturesDesignData.WaterFlowRate, out errorMessage);

            WetBulbTemperatureDataValue1.UpdateCurrentValue(RangedTemperaturesDesignData.WetBulbTemperatures.Temperature1, out errorMessage);
            WetBulbTemperatureDataValue2.UpdateCurrentValue(RangedTemperaturesDesignData.WetBulbTemperatures.Temperature2, out errorMessage);
            WetBulbTemperatureDataValue3.UpdateCurrentValue(RangedTemperaturesDesignData.WetBulbTemperatures.Temperature3, out errorMessage);
            WetBulbTemperatureDataValue4.UpdateCurrentValue(RangedTemperaturesDesignData.WetBulbTemperatures.Temperature4, out errorMessage);
            WetBulbTemperatureDataValue5.UpdateCurrentValue(RangedTemperaturesDesignData.WetBulbTemperatures.Temperature5, out errorMessage);
            WetBulbTemperatureDataValue6.UpdateCurrentValue(RangedTemperaturesDesignData.WetBulbTemperatures.Temperature6, out errorMessage);

            Range1ColdWaterTemperatureDataValue1.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature1, out errorMessage);
            Range1ColdWaterTemperatureDataValue2.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature2, out errorMessage);
            Range1ColdWaterTemperatureDataValue3.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature3, out errorMessage);
            Range1ColdWaterTemperatureDataValue4.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature4, out errorMessage);
            Range1ColdWaterTemperatureDataValue5.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature5, out errorMessage);
            Range1ColdWaterTemperatureDataValue6.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature6, out errorMessage);

            Range2ColdWaterTemperatureDataValue1.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature1, out errorMessage);
            Range2ColdWaterTemperatureDataValue2.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature2, out errorMessage);
            Range2ColdWaterTemperatureDataValue3.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature3, out errorMessage);
            Range2ColdWaterTemperatureDataValue4.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature4, out errorMessage);
            Range2ColdWaterTemperatureDataValue5.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature5, out errorMessage);
            Range2ColdWaterTemperatureDataValue6.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature6, out errorMessage);

            Range3ColdWaterTemperatureDataValue1.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature1, out errorMessage);
            Range3ColdWaterTemperatureDataValue2.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature2, out errorMessage);
            Range3ColdWaterTemperatureDataValue3.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature3, out errorMessage);
            Range3ColdWaterTemperatureDataValue4.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature4, out errorMessage);
            Range3ColdWaterTemperatureDataValue5.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature5, out errorMessage);
            Range3ColdWaterTemperatureDataValue6.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature6, out errorMessage);

            Range4ColdWaterTemperatureDataValue1.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature1, out errorMessage);
            Range4ColdWaterTemperatureDataValue2.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature2, out errorMessage);
            Range4ColdWaterTemperatureDataValue3.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature3, out errorMessage);
            Range4ColdWaterTemperatureDataValue4.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature4, out errorMessage);
            Range4ColdWaterTemperatureDataValue5.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature5, out errorMessage);
            Range4ColdWaterTemperatureDataValue6.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature6, out errorMessage);

            Range5ColdWaterTemperatureDataValue1.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature1, out errorMessage);
            Range5ColdWaterTemperatureDataValue2.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature2, out errorMessage);
            Range5ColdWaterTemperatureDataValue3.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature3, out errorMessage);
            Range5ColdWaterTemperatureDataValue4.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature4, out errorMessage);
            Range5ColdWaterTemperatureDataValue5.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature5, out errorMessage);
            Range5ColdWaterTemperatureDataValue6.UpdateCurrentValue(RangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature6, out errorMessage);

            return true;
        }

    }
}
