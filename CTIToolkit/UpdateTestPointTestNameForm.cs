using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class UpdateTestPointTestNameForm : Form
    {
        public string TestName;

        public UpdateTestPointTestNameForm(bool isDemo, bool isInternationalSystemOfUnits_IS_, string value)
        {
            InitializeComponent();
            TestName = value;
            TestNameTextBox.Text = TestName;
        }

        private void TestNameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TestNameTextBox, "");
        }

        private void TestNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TestNameTextBox.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TestNameTextBox.Select(0, TestNameTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TestNameTextBox, "Test Point Name must be set to a value.");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
