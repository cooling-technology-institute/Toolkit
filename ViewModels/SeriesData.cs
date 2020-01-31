using System.Collections.Generic;

namespace ViewModels
{
    public class SeriesData
    {
        public string Name { get; set; }
        public double Approach { get; set; }
        public List<Point> Points { get; set; }

        public SeriesData(string name, double approach)
        {
            Name = name;
            Approach = approach;
            Points = new List<Point>();
        }
    }
}
