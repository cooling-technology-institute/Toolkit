using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class TowerDesignDataForm : Form
    {
        public TowerDesignDataForm()
        {
            InitializeComponent();
        }

        protected void closeformCallback(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        public void AddControlEvents()
        {
            foreach(Control control in Controls)
            {
                if(control is TowerDesignDataUserControl)
                {
                    ((TowerDesignDataUserControl)control).CloseFormEvent += new FormClosingEventHandler(closeformCallback);
                }
            }
        }

        private void TowerDesignDataOkButton_Click(object sender, EventArgs e)
        {

        }

        private void TowerDesignDataCancelButton_Click(object sender, EventArgs e)
        {

        }

        private void AddFlowRateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
