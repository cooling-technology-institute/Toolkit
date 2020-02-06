// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveData
    {
        public bool IsInternationalSystemOfUnits_SI_ { get; set; }
        public const string DataType = "MechanicalDraftPerformanceCurveData";
        public const string Version = "1.0";

        public MechanicalDraftPerformanceCurveTestData MechanicalDraftPerformanceCurveTestData { get; set; }
        public MechanicalDraftPerformanceCurveDesignData MechanicalDraftPerformanceCurveDesignData { get; set; }

        public MechanicalDraftPerformanceCurveData(bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;

            MechanicalDraftPerformanceCurveTestData = new MechanicalDraftPerformanceCurveTestData();
            MechanicalDraftPerformanceCurveDesignData = new MechanicalDraftPerformanceCurveDesignData();
        }
    }
}