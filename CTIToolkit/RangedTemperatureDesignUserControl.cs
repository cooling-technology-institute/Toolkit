using Models;
using System;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class RangedTemperatureDesignUserControl : UserControl
    {
        public RangedTemperatureDesignViewModel RangedTemperatureDesignViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public RangedTemperatureDesignUserControl(bool isDemo, bool isInternationalSystemOfUnits_SI_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_SI_;

            InitializeComponent();

            RangedTemperatureDesignViewModel = new RangedTemperatureDesignViewModel(IsDemo, IsInternationalSystemOfUnits_SI_);

            string errorMessage = string.Empty;
            
            Setup(out errorMessage);
        }

        public bool LoadData(RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
               
            if(!RangedTemperatureDesignViewModel.LoadData(rangedTemperaturesDesignData, out errorMessage))
            {
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
                returnValue = false;
            }
            if (!Setup(out errorMessage))
            {
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
                returnValue = false;
            }
            return returnValue;
        }

        private bool Setup(out string errorMessage)
        {
            bool returnValue = true;
            errorMessage = string.Empty;
            try
            {
                TowerDesignDataWetBulbTemperature1.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature1, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1Tooltip);

                TowerDesignDataWetBulbTemperature2.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature2, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue2Tooltip);

                TowerDesignDataWetBulbTemperature3.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature3, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue3Tooltip);

                TowerDesignDataWetBulbTemperature4.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature4, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue4Tooltip);

                TowerDesignDataWetBulbTemperature5.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature5, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue5Tooltip);

                TowerDesignDataWetBulbTemperature6.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature6, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue6Tooltip);

                // Range 1
                TowerDesignDataRange1ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange1ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange1ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange1ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange1ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange1ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue6Tooltip);

                // Range 2
                TowerDesignDataRange2ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange2ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange2ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange2ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange2ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange2ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue6Tooltip);

                // Range 3
                TowerDesignDataRange3ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange3ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange3ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange3ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange3ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange3ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue6Tooltip);

                // Range 4
                TowerDesignDataRange4ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange4ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange4ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange4ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange4ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange4ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue6Tooltip);

                // Range 5
                TowerDesignDataRange5ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange5ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange5ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange5ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange5ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange5ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue6Tooltip);
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }
    }
}