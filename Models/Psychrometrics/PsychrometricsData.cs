// Copyright Cooling Technology Institute 2019-2021

using System;

namespace Models
{
    public class PsychrometricsData : ICloneable
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public double Elevation { set; get; } 
        public double WetBulbTemperature { set; get; } // TWB
        public double DryBulbTemperature { set; get; } // TDB
        public double BarometricPressure { set; get; }
        public double HumidityRatio { set; get; }
        public double RelativeHumidity { set; get; }
        public double Enthalpy { set; get; }
        public double RootEnthalpy { set; get; }
        public double SpecificVolume { set; get; }
        public double Density { set; get; }
        public double DewPoint { set; get; }
        public double DegreeOfSaturation { get; set; }
        public double SaturationVaporPressureWetBulb { get; set; }
        public double SaturationVaporPressureDryBulb { get; set; }
        public double FsWetBulb { get; set; }
        public double FsDryBulb { get; set; }
        public double WsWetBulb { get; set; }
        public double WsDryBulb { get; set; }

        public PsychrometricsData()
        {
            IsInternationalSystemOfUnits_SI = false;
            Clear();
        }

        public PsychrometricsData(TowerSpecifications data)
        {
            IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
            Clear();
            WetBulbTemperature = data.WetBulbTemperature;
            DryBulbTemperature = data.DryBulbTemperature;
            BarometricPressure = data.BarometricPressure;
        }

        public virtual void Clear()
        {
            Elevation = 0.0;
            WetBulbTemperature = 0.0;
            DryBulbTemperature = 0.0;
            BarometricPressure = 0.0;
            HumidityRatio = 0.0;
            RelativeHumidity = 0.0;
            Enthalpy = 0.0;
            RootEnthalpy = 0.0;
            SpecificVolume = 0.0;
            Density = 0.0;
            DewPoint = 0.0;
            DegreeOfSaturation = 0.0;
            SaturationVaporPressureWetBulb = 0.0;
            SaturationVaporPressureDryBulb = 0.0;
            FsWetBulb = 0.0;
            FsDryBulb = 0.0;
            WsWetBulb = 0.0;
            WsDryBulb = 0.0;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}