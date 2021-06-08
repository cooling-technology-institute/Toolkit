// Copyright Cooling Technology Institute 2019-2021

using System;

namespace Models
{
    public class Point : ICloneable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
            Initialize();
        }

        public Point(double x, double y)
        {
            Initialize();
            X = x;
            Y = y;
        }

        public void Initialize()
        {
            X = 0.0;
            Y = 0.0;
        }
        public object Clone()
        {
            return (Point)MemberwiseClone();
        }
    }
}