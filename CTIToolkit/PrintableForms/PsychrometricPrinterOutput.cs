// Copyright Cooling Technology Institute 2019-2021

using System.Data;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit.PrintableForms
{
    public partial class PsychrometricPrinterOutput : UserControl
    {
        public PsychrometricPrinterOutput(int bottomOfPage, string calculationProperty, string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable, PsychrometricsViewModel psychrometricsViewModel)
        {
            InitializeComponent();

            CalculationProperty.Text = calculationProperty;
            OptionalLabelTextBox.Text = optionalLabel;
            InputPropertiesDataGridView.DataSource = new DataView(nameValueUnitsDataTable.DataTable);
            DataGridView.DataSource = new DataView(psychrometricsViewModel.GetDataTable());
            this.Height = bottomOfPage + 10;
        }
    }
}
