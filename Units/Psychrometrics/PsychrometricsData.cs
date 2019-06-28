using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public enum PsychrometricsCalculationType
    {
        Psychrometrics_WBT_DBT,
        Psychrometrics_DBT_RH,
        Psychrometrics_Enthalpy
    }

    public class PsychrometricsData
    {
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }

        public PsychrometricsCalculationType CalculationType { get; set; }
 
        public double Elevation { set; get; }
        public double TemperatureWetBulb { set; get; } // TWB
        public double TemperatureDryBulb { set; get; } // TDB

        public double BarometricPressure { set; get; }
        public double HumidityRatio { set; get; }
        public double RelativeHumidity { set; get; }
        public double Enthalpy { set; get; }
        public double SpecificVolume { set; get; }
        public double Density { set; get; }
        public double DewPoint { set; get; }
        public double DegreeOfSaturation { get; set; }

        public string UnitsTemperature { set; get; }
        public string UnitsEnthalpy { set; get; }
        public string UnitsDensity { set; get; }
        public string UnitsVolume { set; get; }
        public string UnitsHumidity { set; get; }
        public string Temperature { set; get; }

        public Units Units { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }
        public bool IsElevation { get; set; }

        //public PsychrometricsData(bool isInternationalSystemOfUnits_IS_, bool isElevation, bool isDemo = false)
        public PsychrometricsData(bool isInternationalSystemOfUnits_IS_)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            BarometricPressure = 0.0;
            HumidityRatio = 0.0;
            RelativeHumidity = 0.0;
            Enthalpy = 0.0;
            SpecificVolume = 0.0;
            Density = 0.0;
            DewPoint = 0.0;
            IsDemo = false;
            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
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