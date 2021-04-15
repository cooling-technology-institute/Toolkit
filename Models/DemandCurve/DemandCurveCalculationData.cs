// Copyright Cooling Technology Institute 2019-2021

using System.Data;

namespace Models
{
    public class DemandCurveCalculationData
    {
        public DemandCurveData DemandCurveData { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }
        public bool ShowUserApproach { get; set; }
        public DataTable DataTable { get; set; }

        public DemandCurveCalculationData(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;

            DemandCurveData = new DemandCurveData();

            DataTable = new DataTable();
        }
    }
}
