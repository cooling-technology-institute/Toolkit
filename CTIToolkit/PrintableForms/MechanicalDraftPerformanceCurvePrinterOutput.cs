using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurvePrinterOutput : UserControl
    {
        public MechanicalDraftPerformanceCurvePrinterOutput(string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable, MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            InitializeComponent();
        }
    }
}
