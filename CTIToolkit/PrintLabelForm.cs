using System;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class PrintLabelForm : Form
    {
        public string GetLabel()
        {
            return DocumentLabelTextBox.Text;
        }

        public bool IsDesignData()
        {
            return DesignRadioButton.Checked;
        }

        public PrintLabelForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
