using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class CalculatePrintUserControl : UserControl
    {
        public virtual void PrintPage(object sender, PrintPageEventArgs e) { }
        public virtual void Calculate() { }
    }
}
