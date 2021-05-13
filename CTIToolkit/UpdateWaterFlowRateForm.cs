using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class UpdateWaterFlowRateForm : Form
    {
        public WaterFlowRateDataValue WaterFlowRateDataValue;

        public UpdateWaterFlowRateForm(bool isDemo, bool isInternationalSystemOfUnits_IS_, double value)
        {
            InitializeComponent();
            WaterFlowRateDataValue = new WaterFlowRateDataValue(isDemo, isInternationalSystemOfUnits_IS_);
            WaterFlowRateDataValue.UpdateCurrentValue(value);
            WaterFlowRate.Text = WaterFlowRateDataValue.InputValue;
        }

        private void WaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WaterFlowRate, "");
        }

        private void WaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            if (!WaterFlowRateDataValue.UpdateValue(WaterFlowRate.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WaterFlowRate.Select(0, WaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WaterFlowRate, WaterFlowRateDataValue.ErrorMessage);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
