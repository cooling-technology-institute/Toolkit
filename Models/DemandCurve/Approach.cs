// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Models
{
    public class Approach
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public List<Point> Points { get; set; }
        public bool InRange { get; set; }
        public bool OutOfRange { get; set; }
        public bool IsApproach { get; set; }


        public Approach(double approach)
        {
            Initialize();
            Value = approach;
            Name = ((int) approach).ToString();
            IsApproach = true;
        }

        public Approach(string name)
        {
            Initialize();
            InRange = true;
            OutOfRange = false;
            Name = name;
        }

        public void Initialize()
        {
            Value = 0;
            Name = string.Empty;
            InRange = false;
            OutOfRange = true;
            IsApproach = false;
            Points = new List<Point>();
        }
    }
}
