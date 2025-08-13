// Copyright Cooling Technology Institute 2019-2021

using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        public List<DataTable> DataTables { get; set; }
        public int DataTableIndex { get; set; }

        public PrintControl()
        {
            UserControl = null;
            Label = string.Empty;
            IsDesignData = false;
            Bitmap = null;
            X = new List<int>();
            DataTables = new List<DataTable>();
            DataTableIndex = 0;
            PageIndex = 0;
        }

        public void CaptureScreen(PrintPageEventArgs e, float x, float y, Size s)
        {
            Bitmap = new Bitmap(s.Width, s.Height, e.Graphics);
            Graphics memoryGraphics = Graphics.FromImage(Bitmap);
            memoryGraphics.CopyFromScreen(UserControl.Location.X, UserControl.Location.Y, 0, 0, s);
        }
    }
}
