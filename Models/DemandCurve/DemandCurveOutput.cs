// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class DemandCurveOutput
    {
        public DataTable DataTable { get; set; }
        public List<SeriesData> SeriesData { get; set; }

        public DemandCurveOutput()
        {
            DataTable = new DataTable();
        }
    }
}
