using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class TowerDesignCurveDataUserControl : UserControl
    {
        MechanicalDraftPerformanceCurveTowerDesignViewModel MechanicalDraftPerformanceCurveTowerDesignViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public TowerDesignCurveDataUserControl(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            MechanicalDraftPerformanceCurveTowerDesignViewModel = new MechanicalDraftPerformanceCurveTowerDesignViewModel(IsDemo, IsInternationalSystemOfUnits_IS_);

            Setup();
        }

        private void Setup()
        {
            //TowerDesignDataOwnerName = MechanicalDraftPerformanceCurveTowerDesignViewModel.
            //PerformanceCurveWaterFlowRateLabel.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputMessage + ":";
            //PerformanceCurveWaterFlowRateLabel.TextAlign = ContentAlignment.MiddleRight;
            //PerformanceCurveTestWaterFlowRate.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputValue;
            //toolTip1.SetToolTip(PerformanceCurveTestHotWaterTemperature, MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueTooltip);
        }
    }
}
