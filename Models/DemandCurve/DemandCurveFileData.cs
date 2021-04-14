// Copyright Cooling Technology Institute 2019-2021

namespace Models
{
    public class DemandCurveFileData
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public const string DataType = "DemandCurveData";
        public const string Version = "1.0";

        public DemandCurveData DemandCurveData { get; set; }

        public DemandCurveFileData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            DemandCurveData = new DemandCurveData();
        }
    }
}
