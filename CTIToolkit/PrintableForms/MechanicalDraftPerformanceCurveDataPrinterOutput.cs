using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurveDataPrinterOutput : UserControl
    {
        public MechanicalDraftPerformanceCurveDataPrinterOutput(string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable, MechanicalDraftPerformanceCurveViewModel viewModel)
        {
                InitializeComponent();
        }
    }
}
