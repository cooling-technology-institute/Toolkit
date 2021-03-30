// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;

namespace Models
{
    public class ColdWaterTemperatures
    {
        public List<double> Temperatures { get; set; }
    }

    public class WetBulbTemperatures
    {
        public List<double> Temperatures { get; set; }
        public List<ColdWaterTemperatures> ColdTemperatures { get; set; }
    }

    public class MechanicalDraftPerformanceCurveCalculationData
    {
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerSpecifications TowerTestData { set; get; }
        public TowerSpecifications TowerDesignData { set; get; }
        public DesignData DesignData { get; set; }
        public List<double> Ranges { get; set; }
        public List<WetBulbTemperatures> WetBulbTemperatures { get; set; }


        public MechanicalDraftPerformanceCurveCalculationData()
        {
            TowerTestData = new TowerSpecifications();
            TowerDesignData = new TowerSpecifications();
            DesignData = new DesignData();
            Ranges = new List<double>();
        }
    }
}