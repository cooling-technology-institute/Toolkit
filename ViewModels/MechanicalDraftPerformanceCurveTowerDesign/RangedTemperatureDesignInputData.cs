// Copyright Cooling Technology Institute 2019-2020

using Models;
using System;

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
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public RangedTemperatureDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue1 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue2 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue3 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue4 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue5 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue6 = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range1ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range1ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range2ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range2ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range3ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range3ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range4ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range4ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            Range5ColdWaterTemperatureDataValue1 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue2 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue3 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue4 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue5 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            Range5ColdWaterTemperatureDataValue6 = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
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

        public bool FillAndValidate(ref RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                rangedTemperaturesDesignData.WaterFlowRate = WaterFlowRateDataValue.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature1 = WetBulbTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature2 = WetBulbTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature3 = WetBulbTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature4 = WetBulbTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature5 = WetBulbTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.WetBulbTemperatures.Temperature6 = WetBulbTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature1 = Range1ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature2 = Range1ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature3 = Range1ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature4 = Range1ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature5 = Range1ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature6 = Range1ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature1 = Range2ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature2 = Range2ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature3 = Range2ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature4 = Range2ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature5 = Range2ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature6 = Range2ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature1 = Range3ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature2 = Range3ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature3 = Range3ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature4 = Range3ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature5 = Range3ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature6 = Range3ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature1 = Range4ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature2 = Range4ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature3 = Range4ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature4 = Range4ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature5 = Range4ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature6 = Range4ColdWaterTemperatureDataValue6.Current;

                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature1 = Range5ColdWaterTemperatureDataValue1.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature2 = Range5ColdWaterTemperatureDataValue2.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature3 = Range5ColdWaterTemperatureDataValue3.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature4 = Range5ColdWaterTemperatureDataValue4.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature5 = Range5ColdWaterTemperatureDataValue5.Current;
                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature6 = Range5ColdWaterTemperatureDataValue6.Current;
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Ranged Temperature design data fill failed. Exception: {0} ", e.ToString());
            }
            return returnValue;
        }

        public int CountWetBulbTemperatures()
        {
            bool zeroDetected = false;

            int count = 0;

            for (int i = 0; i < 6 && !zeroDetected; i++)
            {
                switch (i)
                {
                    case 0:
                        if (WetBulbTemperatureDataValue1.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 1:
                        if (WetBulbTemperatureDataValue2.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 2:
                        if (WetBulbTemperatureDataValue3.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 3:
                        if (WetBulbTemperatureDataValue4.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 4:
                        if (WetBulbTemperatureDataValue5.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    case 5:
                        if (WetBulbTemperatureDataValue6.Current == 0.0)
                        {
                            zeroDetected = true;
                        }
                        break;
                    default:
                        break;
                }
                if (!zeroDetected)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
