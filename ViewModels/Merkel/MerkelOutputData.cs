// Copyright Cooling Technology Institute 2019-2021

using Models;

namespace ViewModels
{
    public class MerkelOutputData
    {
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }

        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        Units Units { get; set; }

        public MerkelOutputData(bool isInternationalSystemOfUnits_IS_)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            if (isInternationalSystemOfUnits_IS_)
            {
                Units = new UnitsIS();
            }
            else
            {
                Units = new UnitsIP();
            }
        }

        public void FillTable(MerkelData data)
        {
            NameValueUnitsDataTable.DataTable.Clear();

            NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F5"), string.Empty);
        }
    }
}