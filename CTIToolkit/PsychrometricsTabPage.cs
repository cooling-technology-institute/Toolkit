// Copyright Cooling Technology Institute 2019-2021

using CTIToolkit.PrintableForms;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class PsychrometricsTabPage: CalculatePrintUserControl
    {
        PsychrometricsViewModel PsychrometricsViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public PsychrometricsTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            IsDemo = applicationSettings.IsDemo;

            Filter = "Psychrometrics files (*.psy)|*.psy|All files (*.*)|*.*";
            DefaultExt = "psy";
            Title = "Psychrometrics";
            DefaultFileName = "Psychrometrics";

            PsychrometricsViewModel = new PsychrometricsViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            PsychrometricsViewModel.DataFileName = BuildDefaultFileName();
            
            SetDisplayedValues();

            Calculate();
        }

        private void SetupBarometericPressure(bool value)
        {
            BarometericPressureLabel.Enabled = value;
            BarometericPressureLabel.Visible = value;
            BarometericPressure_Value.Enabled = value;
            BarometericPressure_Value.Visible = value;
            BarometericPressureUnits.Enabled = value;
            BarometericPressureUnits.Visible = value;
        }

        private void SetupElevation(bool value)
        {
            ElevationLabel.Enabled = value;
            ElevationLabel.Visible = value;
            Elevation_Value.Enabled = value;
            Elevation_Value.Visible = value;
            ElevationUnits.Enabled = value;
            ElevationUnits.Visible = value;
        }

        private void SetupRelativeHumidity(bool value)
        {
            RelativeHumidityLabel.Enabled = value;
            RelativeHumidityLabel.Visible = value;
            RelativeHumidity_Value.Enabled = value;
            RelativeHumidity_Value.Visible = value;
            RelativeHumidityUnits.Enabled = value;
            RelativeHumidityUnits.Visible = value;
        }

        private void SetupEnthalpy(bool value)
        {
            EnthalpyLabel.Enabled = value;
            EnthalpyLabel.Visible = value;
            EnthalpyValue.Enabled = value;
            EnthalpyValue.Visible = value;
            EnthalpyUnits.Enabled = value;
            EnthalpyUnits.Visible = value;
        }

        private void SetupWetBulbTemperature(bool value)
        {
            WetBulbTemperatureLabel.Enabled = value;
            WetBulbTemperatureLabel.Visible = value;
            WetBulbTemperature_Value.Enabled = value;
            WetBulbTemperature_Value.Visible = value;
            WetBulbTemperatureUnits.Enabled = value;
            WetBulbTemperatureUnits.Visible = value;
        }

        private void SetRadioButtons()
        {
            if(PsychrometricsViewModel.IsElevation())
            {
                ElevationRadio.Checked = true;
                BarometricPressureRadio.Checked = false;
            }
            else
            {
                ElevationRadio.Checked = false;
                BarometricPressureRadio.Checked = true;
            }
            if (PsychrometricsViewModel.CalculationType() == Models.PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity)
            {
                Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked = false;
                Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked = true;
                Psychrometrics_Enthalpy.Checked = false;
            }
            else if (PsychrometricsViewModel.CalculationType() == Models.PsychrometricsCalculationType.Enthalpy)
            {
                Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked = false;
                Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked = false;
                Psychrometrics_Enthalpy.Checked = true;
            }
            else
            {
                Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked = true;
                Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked = false;
                Psychrometrics_Enthalpy.Checked = false;
            }
        }

        private bool SetDisplayedValues()
        {
            try
            {
                SwitchUnitsSelection();

                if (BarometricPressureRadio.Checked)
                {
                    SetupBarometericPressure(true);
                    SetupElevation(false);
                }
                else
                {
                    SetupBarometericPressure(false);
                    SetupElevation(true);
                }

                if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
                {
                    SetupRelativeHumidity(true);
                    SetupWetBulbTemperature(false);
                    SetupEnthalpy(false);
                }
                else if(Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked)
                {
                    SetupRelativeHumidity(false);
                    SetupWetBulbTemperature(true);
                    SetupEnthalpy(false);
                }
                else //Psychrometrics_Enthalpy
                {
                    SetupRelativeHumidity(false);
                    SetupWetBulbTemperature(false);
                    SetupEnthalpy(true);
                }

                WetBulbTemperatureLabel.Text = PsychrometricsViewModel.WetBulbTemperatureDataValueInputMessage + ":";
                WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                WetBulbTemperature_Value.Text = PsychrometricsViewModel.WetBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(WetBulbTemperature_Value, PsychrometricsViewModel.WetBulbTemperatureDataValueToolTip);

                DryBulbTemperatureLabel.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputMessage + ":";
                DryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                DryBulbTemperature_Value.Text = PsychrometricsViewModel.DryBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(DryBulbTemperature_Value, PsychrometricsViewModel.DryBulbTemperatureDataValueToolTip);

                RelativeHumidityLabel.Text = PsychrometricsViewModel.RelativeHumidityDataValueInputMessage + ":";
                RelativeHumidityLabel.TextAlign = ContentAlignment.MiddleRight;
                RelativeHumidity_Value.Text = PsychrometricsViewModel.RelativeHumidityDataValueInputValue;
                toolTip1.SetToolTip(RelativeHumidity_Value, PsychrometricsViewModel.RelativeHumidityDataValueToolTip);

                EnthalpyLabel.Text = PsychrometricsViewModel.EnthalpyDataValueInputMessage + ":";
                EnthalpyLabel.TextAlign = ContentAlignment.MiddleRight;
                EnthalpyValue.Text = PsychrometricsViewModel.EnthalpyDataValueInputValue;
                toolTip1.SetToolTip(EnthalpyValue, PsychrometricsViewModel.EnthalpyDataValueToolTip);

                ElevationLabel.Text = PsychrometricsViewModel.ElevationDataValueInputMessage + ":";
                ElevationLabel.TextAlign = ContentAlignment.MiddleRight;
                Elevation_Value.Text = PsychrometricsViewModel.ElevationDataValueInputValue;
                toolTip1.SetToolTip(Elevation_Value, PsychrometricsViewModel.ElevationDataValueToolTip);

                BarometericPressureLabel.Text = PsychrometricsViewModel.BarometricPressureDataValueInputMessage + ":";
                BarometericPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                BarometericPressure_Value.Text = PsychrometricsViewModel.BarometricPressureDataValueInputValue;
                toolTip1.SetToolTip(BarometericPressure_Value, PsychrometricsViewModel.BarometricPressureDataValueToolTip);

                DataFilename.Text = PsychrometricsViewModel.DataFilenameInputValue;
            }
            catch
            {
                //errorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            PsychrometricsViewModel.SwitchUnits(IsInternationalSystemOfUnits_SI);
            SetDisplayedValues();
            Calculate();
        }

        private void SwitchUnitsSelection()
        {
            RelativeHumidityUnits.Text = ConstantUnits.Percentage;

            if (IsInternationalSystemOfUnits_SI)
            {
                WetBulbTemperatureUnits.Text = ConstantUnits.TemperatureCelsius;
                DryBulbTemperatureUnits.Text = ConstantUnits.TemperatureCelsius;
                EnthalpyUnits.Text = ConstantUnits.BtuPerPound;
                ElevationUnits.Text = ConstantUnits.Meter;
                BarometericPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
            }
            else
            {
                WetBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                DryBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                EnthalpyUnits.Text = ConstantUnits.BtuPerPound;
                ElevationUnits.Text = ConstantUnits.Foot;
                DryBulbTemperatureUnits.Text = ConstantUnits.TemperatureFahrenheit;
                BarometericPressureUnits.Text = ConstantUnits.BarometricPressureInchOfMercury;
            }
        }

        public override void Calculate()
        {
            string errorMessage = string.Empty;
            ClearDataSource();
            try
            {
                if (PsychrometricsViewModel.CalculatePsychrometrics(out errorMessage))
                {
                    if (PsychrometricsViewModel.GetDataTable() != null)
                    {
                        // Set a DataGrid control's DataSource to the DataView.
                        CalculatedValuesGridView.DataSource = new DataView(PsychrometricsViewModel.GetDataTable());
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error in calculation. Please check your input values. Exception Message: {0}", exception.Message), "Calculation Error");
            }
        }

        public override bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (PsychrometricsViewModel.OpenDataFile(fileName))
            {
                if (PsychrometricsViewModel.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    if(this.Parent.Parent.Parent is ToolkitMain)
                    {
                        ToolkitMain main = this.Parent.Parent.Parent as ToolkitMain;
                        main.UpdateUnits(PsychrometricsViewModel.IsInternationalSystemOfUnits_SI ? UnitsSelection.International_System_Of_Units_SI : UnitsSelection.United_States_Customary_Units_IP);
                    }
                }
                
                SetRadioButtons();

                if (!SetDisplayedValues())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }

                Calculate();
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data.");
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public override bool OpenNewDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (PsychrometricsViewModel.OpenNewDataFile(fileName))
            {
                if (!PsychrometricsViewModel.LoadData())
                {
                    stringBuilder.AppendLine(PsychrometricsViewModel.ErrorMessage);
                    returnValue = false;
                }

                if (!SetDisplayedValues())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                }

                Calculate();
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public override bool SaveDataFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            if (!PsychrometricsViewModel.SaveDataFile())
            {
                stringBuilder.AppendLine(PsychrometricsViewModel.ErrorMessage);
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public override bool SaveAsDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            PsychrometricsViewModel.DataFileName = fileName;
            DataFilename.Text = PsychrometricsViewModel.DataFilenameInputValue;

            if (!PsychrometricsViewModel.SaveAsDataFile(fileName))
            {
                stringBuilder.AppendLine(PsychrometricsViewModel.ErrorMessage);
                returnValue = false;
            }

            ErrorMessage = stringBuilder.ToString();

            return returnValue;
        }


        public override void PrintPage(object sender, PrintPageEventArgs e)
        {
            NameValueUnitsDataTable nameValueUnitsDataTable = new NameValueUnitsDataTable();
        
            if (PsychrometricsViewModel.GetDataTable() != null)
            {
                string calculationProperty = string.Empty;

                if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
                {
                    calculationProperty = Psychrometrics_DryBulbTemperature_RelativeHumidity.Text;
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.DryBulbTemperatureDataValueInputMessage, DryBulbTemperature_Value.Text, DryBulbTemperatureUnits.Text);
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.RelativeHumidityDataValueInputMessage, RelativeHumidity_Value.Text, RelativeHumidityUnits.Text);
                }
                else if (Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked)
                {
                    calculationProperty = Psychrometrics_WetBulbTemperature_DryBulbTemperature.Text;
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.DryBulbTemperatureDataValueInputMessage, DryBulbTemperature_Value.Text, DryBulbTemperatureUnits.Text);
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.WetBulbTemperatureDataValueInputMessage, WetBulbTemperature_Value.Text, WetBulbTemperatureUnits.Text);
                }
                else //Psychrometrics_Enthalpy
                {
                    calculationProperty = Psychrometrics_Enthalpy.Text;
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.ElevationDataValueInputMessage, EnthalpyValue.Text, EnthalpyUnits.Text);
                }

                if (BarometricPressureRadio.Checked)
                {
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.BarometricPressureDataValueInputMessage, BarometericPressure_Value.Text, BarometericPressureUnits.Text);
                }
                else
                {
                    nameValueUnitsDataTable.AddRow(PsychrometricsViewModel.ElevationDataValueInputMessage, Elevation_Value.Text, ElevationUnits.Text);
                }

                PsychrometricPrinterOutput printerOutput = new PsychrometricPrinterOutput(e.PageBounds.Height - 80, calculationProperty, this.PrintControl.Label, nameValueUnitsDataTable, PsychrometricsViewModel);
                printerOutput.CreateControl();
                var bm = new Bitmap(printerOutput.Width, printerOutput.Height);
                printerOutput.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
                e.Graphics.DrawImage(bm, 40, 40);

                e.Graphics.DrawString("CTI Toolkit 4.0 Beta Version",
                                      new Font("Times New Roman", 16),
                                      new SolidBrush(Color.Red),
                                      40, e.PageSettings.Bounds.Height - 60);
                Font font = new Font("Times New Roman", 8);
                SizeF size = e.Graphics.MeasureString(PsychrometricsViewModel.DataFilenameInputValue, font);
                e.Graphics.DrawString(PsychrometricsViewModel.DataFilenameInputValue,
                                      font,
                                      new SolidBrush(Color.Black),
                                      e.PageSettings.Bounds.Width - size.Width - 40, e.PageSettings.Bounds.Height - 60);
            }
            else
            {
                MessageBox.Show("You must run the calculation before printing.");
            }
        }

        private void PyschmetricsElevationRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ElevationRadio.Checked)
            {
                ClearDataSource();
                PsychrometricsViewModel.UpdateIsElevationValue(true);
                SetupBarometericPressure(false);
                SetupElevation(true);
                Calculate();
            }
        }

        private void PsychrometricsPressureRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (BarometricPressureRadio.Checked)
            {
                ClearDataSource();
                PsychrometricsViewModel.UpdateIsElevationValue(false);
                SetupBarometericPressure(true);
                SetupElevation(false);
                Calculate();
            }
        }

        private void Psychrometrics_WetBulbTemperature_DryBulbTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_WetBulbTemperature_DryBulbTemperature.Checked)
            {
                ClearDataSource();
                SetupRelativeHumidity(false);
                SetupWetBulbTemperature(true);
                SetupEnthalpy(false);
                PsychrometricsViewModel.UpdateCalculationType(Models.PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature);
                Calculate();
            }
        }

        private void Psychrometrics_DryBulbTemperature_RelativeHumidity_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_DryBulbTemperature_RelativeHumidity.Checked)
            {
                ClearDataSource();
                SetupRelativeHumidity(true);
                SetupWetBulbTemperature(false);
                SetupEnthalpy(false);
                PsychrometricsViewModel.UpdateCalculationType(Models.PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity);
                Calculate();
            }
        }

        private void Psychrometrics_Enthalpy_CheckedChanged(object sender, EventArgs e)
        {
            if (Psychrometrics_Enthalpy.Checked)
            {
                ClearDataSource();
                SetupRelativeHumidity(false);
                SetupWetBulbTemperature(false);
                SetupEnthalpy(true);
                PsychrometricsViewModel.UpdateCalculationType(Models.PsychrometricsCalculationType.Enthalpy);
                Calculate();
            }
        }

        private void ClearDataSource()
        {
            if (CalculatedValuesGridView.DataSource != null)
            {
                CalculatedValuesGridView.DataSource = null;
            }
        }

        public void PsychrometricsCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Elevation_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Elevation_Value, "");
        }

        private void Elevation_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (PsychrometricsViewModel.ElevationDataValueInputValue != Elevation_Value.Text);

            if (!PsychrometricsViewModel.ElevationDataValueUpdateValue(Elevation_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Elevation_Value.Select(0, Elevation_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Elevation_Value, PsychrometricsViewModel.ElevationDataValueErrorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void BarometericPressure_Value_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(BarometericPressure_Value, "");
        }

        private void BarometericPressure_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (PsychrometricsViewModel.BarometricPressureDataValueInputValue != BarometericPressure_Value.Text);

            if (!PsychrometricsViewModel.BarometricPressureDataValueUpdateValue(BarometericPressure_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                BarometericPressure_Value.Select(0, BarometericPressure_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(BarometericPressure_Value, PsychrometricsViewModel.BarometricPressureDataValueErrorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void DryBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(DryBulbTemperature_Value, "");

        }

        private void DryBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (PsychrometricsViewModel.DryBulbTemperatureDataValueInputValue != DryBulbTemperature_Value.Text);

            if (!PsychrometricsViewModel.DryBulbTemperatureDataValueUpdateValue(DryBulbTemperature_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature_Value.Select(0, DryBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature_Value, PsychrometricsViewModel.DryBulbTemperatureDataValueErrorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void WetBulbTemperature_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(WetBulbTemperature_Value, "");
        }

        private void WetBulbTemperature_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (PsychrometricsViewModel.WetBulbTemperatureDataValueInputValue != WetBulbTemperature_Value.Text);

            if (!PsychrometricsViewModel.WetBulbTemperatureDataValueUpdateValue(WetBulbTemperature_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature_Value.Select(0, WetBulbTemperature_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature_Value, PsychrometricsViewModel.WetBulbTemperatureDataValueErrorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void RelativeHumidity_Value_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(RelativeHumidity_Value, "");
        }

        private void RelativeHumidity_Value_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (PsychrometricsViewModel.RelativeHumidityDataValueInputValue != RelativeHumidity_Value.Text);

            if (!PsychrometricsViewModel.RelativeHumidityDataValueUpdateValue(RelativeHumidity_Value.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                RelativeHumidity_Value.Select(0, RelativeHumidity_Value.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(RelativeHumidity_Value, PsychrometricsViewModel.RelativeHumidityDataValueErrorMessage);
            }
            else if (recalculate)
            {
                Calculate();
            }
        }

        private void EnthalpyValue_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(EnthalpyValue, "");
        }

        private void EnthalpyValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool recalculate = (PsychrometricsViewModel.EnthalpyDataValueInputValue != EnthalpyValue.Text);

            if (!PsychrometricsViewModel.EnthalpyDataValueUpdateValue(EnthalpyValue.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                EnthalpyValue.Select(0, EnthalpyValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(EnthalpyValue, PsychrometricsViewModel.EnthalpyDataValueErrorMessage);
            }
            else if(recalculate)
            {
                Calculate();
            }
        }
    }
}
