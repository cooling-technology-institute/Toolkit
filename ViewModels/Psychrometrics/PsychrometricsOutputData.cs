// Copyright Cooling Technology Institute 2019-2020

using Models;

namespace ViewModels
{
    public class PsychrometricsOutputData
    {
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        Units Units { get; set; }

        public PsychrometricsOutputData(bool isInternationalSystemOfUnits_IS_)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            if(isInternationalSystemOfUnits_IS_)
            {
                Units = new UnitsIS();
            }
            else
            {
                Units = new UnitsIP();
            }
        }

        public void ClearTable()
        {
            NameValueUnitsDataTable.DataTable.Clear();
        }

        public void FillDataTable(PsychrometricsData data)
        {
            ClearTable();

            //data.BarometricPressure = truncit(data.BarometricPressure, 5);
            NameValueUnitsDataTable.AddRow("Barometric Pressure", data.BarometricPressure.ToString("F4"), Units.BarometricPressure);
            NameValueUnitsDataTable.AddRow("Elevation above MSL", data.Elevation.ToString(), ConstantUnits.Foot);
            NameValueUnitsDataTable.AddRow("Dry Bulb Temperature", data.DryBulbTemperature.ToString("F2"), Units.Temperature);
            NameValueUnitsDataTable.AddRow("Wet Bulb Temperature", data.WetBulbTemperature.ToString("F2"), Units.Temperature);
            NameValueUnitsDataTable.AddRow("Enthalpy", data.Enthalpy.ToString("F4"), Units.Enthalpy);
            NameValueUnitsDataTable.AddRow("Dew Point", data.DewPoint.ToString("F2"), Units.Temperature);
            NameValueUnitsDataTable.AddRow("Relative Humidity", (data.RelativeHumidity * 100.00).ToString("F2"), ConstantUnits.Percentage);
            NameValueUnitsDataTable.AddRow("Density", data.Density.ToString("F5"), Units.Density);
            NameValueUnitsDataTable.AddRow("Specific Volume", data.SpecificVolume.ToString("F4"), Units.SpecificVolume);
            NameValueUnitsDataTable.AddRow("Humidity Ratio", data.HumidityRatio.ToString("F5"), Units.HumidityRatio);
        }
    }
}
