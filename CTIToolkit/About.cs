// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class About : Form
    {
        ApplicationSettings ApplicationSettings { get; set; }
        public About(ApplicationSettings applicationSettings)
        {
            ApplicationSettings = applicationSettings;

            InitializeComponent();

            this.Text = string.Format("About {0}", AssemblyInformation.Title);
            this.copyright.Text = string.Format("{0} {1}. All rights reserved.", AssemblyInformation.Copyright, AssemblyInformation.Company);
            this.versionNumber.Text = AssemblyInformation.AssemblyVersion;

            SerialNumberInput.Text = ApplicationSettings.SerialNumber;
            this.serialNumber.Text = ApplicationSettings.SerialNumber;
            UpdateFormForSerialNumber();
        }

        private void SetSerialNumber_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SerialNumberInput.Text))
            {
                MessageBox.Show("You must enter a serial number.");
            }
            else
            {
                if (ApplicationSettings.TestSerialNumber(SerialNumberInput.Text))
                {
                    ApplicationSettings.SerialNumber = SerialNumberInput.Text;
                }
                else
                {
                    MessageBox.Show("You must enter an invalid serial number.");
                }
            }
            UpdateFormForSerialNumber();
        }

        private void ActivateSoftware_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.serialNumber.Text))
            {
                string email = "test@cti.org";
                string firstMacAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(firstMacAddress))
                {
                    // You need to post the data as key value pairs:
                    string postData = string.Format("serialnumber={0}&id={1}&email={2}", this.serialNumber.Text, firstMacAddress, email);
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    // Post the data to the right place.
                    Uri target = new Uri("http://192.168.3.230/setcmd.cgx");
                    WebRequest request = WebRequest.Create(target);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;

                    using (var dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }

                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        //Do what you need to do with the response.
                    }
                }
            }
        }

        private void UpdateFormForSerialNumber()
        {
            if (ApplicationSettings.TestSerialNumber(this.serialNumber.Text))
            {
                ApplicationSettings.SerialNumber = this.serialNumber.Text;
                this.demoWarning.Visible = false;
                this.SerialNumberInput.Visible = false;
                this.setSerialNumberButton.Visible = false;
                this.setSerialNumberInputLabel.Visible = false;
            }
            else
            {
                this.demoWarning.Visible = true;
                this.SerialNumberInput.Visible = true;
                this.setSerialNumberButton.Visible = true;
                this.setSerialNumberInputLabel.Visible = true;
            }
        }

        private void CtiLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(ctiLinkLabel.Text);
            Process.Start(processStartInfo);
        }
    }
}
