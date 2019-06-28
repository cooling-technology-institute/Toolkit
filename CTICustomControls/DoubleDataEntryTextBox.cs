using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTICustomControls
{
    public partial class DoubleDataEntryTextBox : UserControl
    {
        private double Default = 0.0;
        private double Minimum = 0.0;
        private double Maximum = 0.0;
        private double Current = 0.0;
        private bool IsValid = false;
        private string InputMessage = string.Empty;
        private string InputValue = string.Empty;
        private string Format = string.Empty;
        private string ToolTipFormat = string.Empty;
        private string ToolTip = string.Empty;
        private bool IsDemo = true;

        public DoubleDataEntryTextBox()
        {
            InitializeComponent();
        }

        private void DataEntryTextBox_Load(object sender, EventArgs e)
        {
        }
    }
}
