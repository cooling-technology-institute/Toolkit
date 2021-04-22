using System.Data;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit.PrintableForms
{
    public partial class MerkelPrinterOutput : UserControl
    {
        public MerkelPrinterOutput(string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable, MerkelViewModel merkelViewModel)
        {
            InitializeComponent();

            OptionalLabelTextBox.Text = optionalLabel;
            InputPropertiesDataGridView.DataSource = new DataView(nameValueUnitsDataTable.DataTable);
            DataGridView.DataSource = merkelViewModel.GetDataTable();
        }
    }
}
