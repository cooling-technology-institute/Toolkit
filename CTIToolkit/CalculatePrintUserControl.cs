using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class CalculatePrintUserControl : UserControl
    {
        public const int MARGIN = 10;
        public PrintControl PrintControl { get; set; }
        public string Filter { get; set; }
        public string DefaultExt { get; set; }
        public string Title { get; set; }
        public string DefaultFileName { get; set; }
        public string ErrorMessage { get; set; }
        public virtual void PrintPage(object sender, PrintPageEventArgs e) { }
        public virtual void Calculate() { }
        public virtual bool OpenDataFile(string fileName) { return false; }
        public virtual bool OpenNewDataFile(string fileName) { return false; }
        public virtual bool SaveDataFile() { return false; }
        public virtual bool SaveAsDataFile(string fileName) { return false; }
        
        public CalculatePrintUserControl()
        {
            PrintControl = new PrintControl();
        }
        
        public string BuildDefaultFileName()
        {
            string dataFileName = string.Empty;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
            int i = 1;

            do
            {
                dataFileName = Path.Combine(path, string.Format("{0}{1}.{2}", DefaultFileName, i++, DefaultExt));
                if (File.Exists(dataFileName))
                {
                    dataFileName = string.Empty;
                }

            } while (string.IsNullOrEmpty(dataFileName));
            
            return dataFileName;
        }
    }
}
