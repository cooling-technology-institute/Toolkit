using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class MerkelData
    {
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }

        public double Elevation { set; get; }
        public double BarometricPressure { set; get; }

        public double HotWaterTemperature { set; get; }
        public double ColdWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; } // TWB
        public double WaterAirRatio { set; get; }
        public double Approach { set; get; }
        public double Range { set; get; }
        public double KaV_L { set; get; }

        public string UnitsTemperature { set; get; }
        public string UnitsEnthalpy { set; get; }

        public Units Units { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }
        public bool IsElevation { get; set; }

        //public MerkelData(bool isInternationalSystemOfUnits_IS_, bool isElevation, bool isDemo = false)
        public MerkelData()
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            HotWaterTemperature = 0.0;
            ColdWaterTemperature = 0.0;
            WaterAirRatio = 0.0;
            BarometricPressure = 0.0;

            IsDemo = false;
            IsInternationalSystemOfUnits_IS_ = false;
            IsElevation = true;
            SetUnits();
        }

        private void SetUnits()
        {
            if (IsInternationalSystemOfUnits_IS_)
            {
                Units = new UnitsSI();
            }
            else
            {
                Units = new UnitsIP();
            }
        }

        public void SetInternationalSystemOfUnits_IS_(bool value)
        {
            IsInternationalSystemOfUnits_IS_ = value;
            SetUnits();
        }

        public void SetElevation(bool value)
        {
            IsElevation = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
            SetUnits();
        }
    }
}