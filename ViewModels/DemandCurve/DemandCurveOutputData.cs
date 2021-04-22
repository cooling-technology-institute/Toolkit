// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;

namespace ViewModels
{
    public class DemandCurveOutputData
    {
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }

        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }

        Units Units { get; set; }

        public DemandCurveOutputData(bool isInternationalSystemOfUnits_IS_)
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

        public void FillTable(DemandCurveData data)
        {
        }
    }
}