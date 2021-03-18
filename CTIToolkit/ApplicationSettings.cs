using System;
using System.Configuration;

namespace CTIToolkit
{
    public enum UnitsSelection
    {
        United_States_Customary_Units_IP,
        International_System_Of_Units_SI
    }

    public class ApplicationSettings
    {
        private UnitsSelection _UnitsSelection = UnitsSelection.United_States_Customary_Units_IP;
        private bool _IsDemo = false;

        public UnitsSelection UnitsSelection
        {
            get { return _UnitsSelection; }
            set
            {
                if (_UnitsSelection != value)
                {
                    _UnitsSelection = value;
                    UpdateSettings();
                }
            }
        }

        public bool IsDemo
        {
            get { return _IsDemo; }
        }

        private void UpdateSettings()
        {
            Properties.Settings.Default.UnitsSelection = UnitsSelection.ToString();
            Properties.Settings.Default.Save();
        }

        public void Read()
        {
            UnitsSelection initialUnitsSelection = UnitsSelection.United_States_Customary_Units_IP;

            string appSettingsUnitsSelection = null;
            try
            {
                appSettingsUnitsSelection = Properties.Settings.Default.UnitsSelection;
            }
            catch
            { }

            if (string.IsNullOrWhiteSpace(appSettingsUnitsSelection))
            {
                _UnitsSelection = initialUnitsSelection;
            }
            else if(Enum.TryParse<UnitsSelection>(appSettingsUnitsSelection, out initialUnitsSelection))
            {
                _UnitsSelection = initialUnitsSelection; 
            }
        }
    }
}
