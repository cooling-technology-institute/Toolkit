// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;

namespace Models
{
    public class DesignData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumAsIntConverter))]
        public TOWER_TYPE TowerType { set; get; }

        public TowerSpecifications TowerSpecifications { set; get; }

        public double Range1 { set; get; }
        public double Range2 { set; get; }
        public double Range3 { set; get; }
        public double Range4 { set; get; }
        public double Range5 { set; get; }

        public List<RangedTemperaturesDesignData> RangedTemperaturesDesignData { set; get; }
        
        public DesignData()
        {
            OwnerName = string.Empty;
            ProjectName = string.Empty;
            Location = string.Empty;
            TowerManufacturer = string.Empty;
            TowerType = TOWER_TYPE.Forced;

            TowerSpecifications = new TowerSpecifications();

            RangedTemperaturesDesignData = new List<RangedTemperaturesDesignData>();
        }
    }
}