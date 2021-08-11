// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace ViewModels
{
    public class PsychrometricsOutputData
    {
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        Units Units { get; set; }

        public PsychrometricsOutputData(bool isInternationalSystemOfUnits_SI)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            SwitchUnits(isInternationalSystemOfUnits_SI);
        }

        public void SwitchUnits(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
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
            NameValueUnitsDataTable.AddRow("Elevation above MSL", data.Elevation.ToString("F2"), ConstantUnits.Foot);
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
