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
        public string Label { get; set; }
        public string Filter { get; set; }
        public string DefaultExt { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsDesignData { get; set; }
        public virtual void PrintPage(object sender, PrintPageEventArgs e) { }
        public virtual void Calculate() { }
        public virtual bool OpenDataFile(string fileName) { return false; }
        public virtual bool OpenNewDataFile(string fileName) { return false; }
        public virtual bool SaveDataFile() { return false; }
        public virtual bool SaveAsDataFile(string fileName) { return false; }
    }
}
