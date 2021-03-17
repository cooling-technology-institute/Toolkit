using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public abstract class CalculatePrintUserControl : UserControl
    {
        public abstract void Print();
        public abstract void Calculate();
    }
}
