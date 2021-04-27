using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class PrintControl
    {
        public UserControl UserControl { get; set; }
        public string Label { get; set; }
        public bool IsDesignData { get; set; }
        public Bitmap Bitmap { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PrintControl()
        {
            UserControl = null;
            Label = string.Empty;
            IsDesignData = false;
            Bitmap = null;
            X = Y = 0;
        }
    }
}
