using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateSerialNumber
{
    public partial class GenerateSerialNumberForm : Form
    {
        public GenerateSerialNumberForm()
        {
            InitializeComponent();
        }

        private void GenerateSerialNumberForm_Load(object sender, EventArgs e)
        {
        }

        private void generateSerialNumber_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                string serialNumber = GenerateSrialNumber();
                if (!string.IsNullOrEmpty(serialNumber))
                {
                    int insertQueryCount = toolkit_4TableAdapter.InsertQuery(serialNumber, emailTextBox.Text, first_NameTextBox.Text, last_NameTextBox.Text, companyTextBox.Text, DateTime.Now);
                    if(insertQueryCount == 1)
                    {
                        generatedSerialNumber.Text = serialNumber;
                    }
                }
            }
        }

        // 012345678901234567890
        // aa99-a999-a9aa
        public string GenerateSrialNumber()
        {
            string serialNumber = string.Empty;
            char ch;
            Random random = new Random();
            bool goodNumber = false;

            while (!goodNumber)
            {
                // check the serial number 
                for (int x = 0; x < 14; x++)
                {
                    switch (x)
                    {
                        // alphabetic
                        case 0:
                        case 1:
                        case 5:
                        case 10:
                        case 12:
                        case 13:
                            ch = (char)((random.Next() % 26) + 65);
                            break;
                        case 2:
                        case 3:
                        case 6:
                        case 7:
                        case 8:
                        case 11:
                            ch = (char)((random.Next() % 10) + 48);
                            break;
                        case 4:
                        case 9:
                            ch = '-';
                            break;
                        default:
                            ch = ' ';
                            break;
                    }
                    serialNumber += ch;
                }

                // can't be the beta number
                if (serialNumber.ToUpper() != "BB00-B000-B0BB")
                {
                    int serialNumberCount = (int)toolkit_4TableAdapter.DoesSerialNumberExist(serialNumber);
                    if(serialNumberCount == 0)
                    {
                        goodNumber = true;
                    }
                }
            }
            return serialNumber;
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                emailTextBox.Select(0, emailTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(emailTextBox, "Email cannot be empty");
            }
        }

        private void emailTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(emailTextBox, "");
        }

        private void first_NameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(first_NameTextBox, "");
        }

        private void first_NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(first_NameTextBox.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                first_NameTextBox.Select(0, first_NameTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(first_NameTextBox, "First name cannot be empty");
            }
        }

        private void last_NameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(last_NameTextBox, "");
        }

        private void last_NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(last_NameTextBox.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                last_NameTextBox.Select(0, last_NameTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(last_NameTextBox, "Last name cannot be empty");
            }
        }

        private void companyTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(companyTextBox, "");
        }

        private void companyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(companyTextBox.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                companyTextBox.Select(0, last_NameTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(companyTextBox, "Company cannot be empty");
            }
        }
    }
}
