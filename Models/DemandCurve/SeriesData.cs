// Copyright Cooling Technology Institute 2019-2020

using System.Collections.Generic;
using System.Drawing;

namespace Models
{
    public class SeriesData
    {
        public string Name { get; set; }
        public double Approach { get; set; }
        public List<Point> Points { get; set; }
        public Color Color { get; set; }
        public bool isChecked { get; set; }

        public SeriesData(string name, double approach)
        {
            Name = name;
            Approach = approach;
            Points = new List<Point>();
        }
    }
}
