// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;
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
        public List<Approach> Approaches { get; set; }
        public bool IsCoef { get; set; }
        public bool IsLiquidToGasRatio { get; set; }
        public bool IsKaV_L { get; set; }
        public bool IsUserApproach { get; set; }
        
        public DemandCurveCalculationData(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            DemandCurveData = new DemandCurveData();
            Approaches = new List<Approach>();
            DataTable = new DataTable();
            Initialize();
        }

        public void Initialize()
        {
            IsCoef = false;
            IsLiquidToGasRatio = false;
            IsKaV_L = false;
            IsUserApproach = false;
            DemandCurveData.Initialize();
            Approaches.Clear();
            DataTable.Rows.Clear();
            DataTable.Columns.Clear();
            DataTable.Clear();
        }

        public void ConvertValues(bool isIS)
        {
            IsInternationalSystemOfUnits_SI = isIS;
            Initialize();
        }
    }
}
