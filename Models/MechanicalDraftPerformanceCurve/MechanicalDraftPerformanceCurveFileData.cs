// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveFileData : FileDataType
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public List<TowerTestData> TestData { get; set; }
        public DesignData DesignData { get; set; }

        public MechanicalDraftPerformanceCurveFileData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            DataType = "MechanicalDraftPerformanceCurveData";
            Version = "1.0";

            TestData = new List<TowerTestData>();
            DesignData = new DesignData();
        }
    }
}