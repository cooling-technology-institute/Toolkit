// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveFileData
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public const string DataType = "MechanicalDraftPerformanceCurveData";
        public const string Version = "1.0";

        public List<TowerTestData> TestData { get; set; }
        public DesignData DesignData { get; set; }

        public MechanicalDraftPerformanceCurveFileData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            TestData = new List<TowerTestData>();
            DesignData = new DesignData();
        }
    }
}