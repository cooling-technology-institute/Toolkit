using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            this.Text = string.Format("About {0}", AssemblyInformation.Title);
            this.copyright.Text = string.Format("{0} {1}. All rights reserved.", AssemblyInformation.Copyright, AssemblyInformation.Company);
            this.versionNumber.Text = AssemblyInformation.AssemblyVersion;

            setSerialNumber();
        }

        private void demoSetSerialNumber_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(setSerialNumberInput.Text))
            {
                MessageBox.Show("You must enter a serial number.");
            }
            else
            {
                if(AssemblyInformation.TestSerialNumber(setSerialNumberInput.Text))
                {
                    AssemblyInformation.SerialNumber = setSerialNumberInput.Text;
                }
                else
                {
                    MessageBox.Show("You must enter an invalid serial number.");
                }
            }
            setSerialNumber();
        }

        private void setSerialNumber()
        {
            this.serialNumber.Text = AssemblyInformation.SerialNumber;

            if (this.serialNumber.Text == AssemblyInformation.Demo)
            {
                this.demoWarning.Visible = true;
                this.setSerialNumberInput.Visible = true;
                this.setSerialNumberButton.Visible = true;
                this.setSerialNumberInputLabel.Visible = true;
            }
            else
            {
                this.demoWarning.Visible = false;
                this.setSerialNumberInput.Visible = false;
                this.setSerialNumberButton.Visible = false;
                this.setSerialNumberInputLabel.Visible = false;
            }
        }

        private void ctiLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(ctiLinkLabel.Text);
            Process.Start(processStartInfo);
        }
    }
}
