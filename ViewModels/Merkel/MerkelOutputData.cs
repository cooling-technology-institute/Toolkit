// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace ViewModels
{
    public class MerkelOutputData
    {
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }

        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        Units Units { get; set; }

        public MerkelOutputData(bool isInternationalSystemOfUnits_SI)
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

        public void FillTable(MerkelCalculationData data)
        {
            NameValueUnitsDataTable.DataTable.Clear();

            NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F5"), string.Empty);
        }
    }
}