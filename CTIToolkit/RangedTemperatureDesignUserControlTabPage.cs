﻿using System.Windows.Forms;

namespace CTIToolkit
{
    public class RangedTemperatureDesignUserControlTabPage : TabPage
    {
        public RangedTemperatureDesignUserControl UserControl { get; private set; }

        public RangedTemperatureDesignUserControlTabPage(RangedTemperatureDesignUserControl userControl)
        {
            UserControl = userControl;
            this.Controls.Add(userControl);
        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            UserControl.SetUnitsStandard(applicationSettings);
        }
    }
}
