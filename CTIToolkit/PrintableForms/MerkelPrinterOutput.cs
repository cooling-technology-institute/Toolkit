using System.Data;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit.PrintableForms
{
    public partial class MerkelPrinterOutput : UserControl
    {
        public MerkelPrinterOutput(int bottomOfPage, string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable, MerkelViewModel merkelViewModel)
        {
            InitializeComponent();

            OptionalLabelTextBox.Text = optionalLabel;
            InputPropertiesDataGridView.DataSource = new DataView(nameValueUnitsDataTable.DataTable);
            DataGridView.DataSource = merkelViewModel.GetDataTable();
            this.Height = bottomOfPage + 10;
            Beta.Location = new System.Drawing.Point(0, bottomOfPage - Beta.Height);
        }
    }
}
