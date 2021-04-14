// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class DemandCurveCalculationData
    {
        public DemandCurveData DemandCurveData { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public DemandCurveCalculationData(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
        }
    }
}
