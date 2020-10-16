// Copyright Cooling Technology Institute 2019-2020

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

        public MechanicalDraftPerformanceCurveData TestData { get; set; }
        public MechanicalDraftPerformanceCurveDesignData DesignData { get; set; }

        public MechanicalDraftPerformanceCurveFileData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            TestData = new MechanicalDraftPerformanceCurveData();
            DesignData = new MechanicalDraftPerformanceCurveDesignData();
        }
    }
}