// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class PrintControl
    {
        public UserControl UserControl { get; set; }
        public string Label { get; set; }
        public bool IsDesignData { get; set; }
        public Bitmap Bitmap { get; set; }
        public List<int> X { get; set; }
        public int PageIndex { get; set; }

        public PrintControl()
        {
            UserControl = null;
            Label = string.Empty;
            IsDesignData = false;
            Bitmap = null;
            X = new List<int>();
            PageIndex = 0;
        }
    }
}
