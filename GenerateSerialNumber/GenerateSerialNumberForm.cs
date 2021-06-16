// Copyright Cooling Technology Institute 2019-2021
using System;
using System.Windows.Forms;

namespace GenerateSerialNumber
{
    public partial class GenerateSerialNumberForm : Form
    {
        public GenerateSerialNumberForm()
        {
            InitializeComponent();
            serialNumber.Text = GenerateSrialNumber();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            serialNumber.Text = GenerateSrialNumber();
        }

        // 012345678901234567890
        // aa99-a999-a9aa
        public string GenerateSrialNumber()
        {
            string serialNumber = string.Empty;
            char ch;
            Random random = new Random();

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
                        ch = (char) ((random.Next() % 26) + 65);
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
            return serialNumber;
        }

    }
}
