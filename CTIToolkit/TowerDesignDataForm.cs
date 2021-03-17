using System;
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

        private void TowerDesignDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isChanged = false;

            if (e.CloseReason == CloseReason.None)
            {
                foreach (Control control in Controls)
                {
                    if (control is TowerDesignDataUserControl)
                    {
                        isChanged |= ((TowerDesignDataUserControl)control).HasDataChanged;
                    }
                }

                if (isChanged)
                {
                    // Are you sure?
                    var result = MessageBox.Show("Are you sure you want to discard your changes?", "Cancel Updates",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                    // If the yes button was pressed ...
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        foreach (Control control in Controls)
                        {
                            if (control is TowerDesignDataUserControl)
                            {
                                ((TowerDesignDataUserControl)control).ClearIsChanged();
                            }
                        }
                    }
                }

            }
        }
    }
}
