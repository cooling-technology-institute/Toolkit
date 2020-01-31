// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class TemperatureDesignData
    {
        public double Temperature1 { set; get; }
        public double Temperature2 { set; get; }
        public double Temperature3 { set; get; }
        public double Temperature4 { set; get; }
        public double Temperature5 { set; get; }
        public double Temperature6 { set; get; }

        public TemperatureDesignData()
        {
            Temperature1 = 0.0;
            Temperature2 = 0.0;
            Temperature3 = 0.0;
            Temperature4 = 0.0;
            Temperature5 = 0.0;
            Temperature6 = 0.0;
        }
    }
}