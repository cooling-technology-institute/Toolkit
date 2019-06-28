using System;
using System.Configuration;

namespace ToolkitLibrary
{
    public enum UnitsSelection
    {
        United_States_Customary_Units_IP,
        International_System_Of_Units_SI
    }

    public static class Globals
    {
        static private UnitsSelection _UnitsSelection = UnitsSelection.United_States_Customary_Units_IP;

        static public UnitsSelection UnitsSelection
        {
            get { return _UnitsSelection; }
            set
            {
                if (_UnitsSelection != value)
                {
                    _UnitsSelection = value;
                    UpdateConfigurationFile();
                }
            }
        }

        static private void UpdateConfigurationFile()
        {
            //Load appsettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //Check if key exists in the settings
            if (config.AppSettings.Settings["UnitsSelection"] != null)
            {
                //If key exists, delete it
                config.AppSettings.Settings.Remove("UnitsSelection");
            }

            //Add new key-value pair
            config.AppSettings.Settings.Add("UnitsSelection", UnitsSelection.ToString());
            
            //Save the changed settings
            config.Save(ConfigurationSaveMode.Full);
        }

        static public void ReadConfigurationFile()
        {
            UnitsSelection initialUnitsSelection = UnitsSelection.United_States_Customary_Units_IP;

            string appSettingsUnitsSelection = ConfigurationManager.AppSettings.Get("UnitsSelection");

            if (string.IsNullOrWhiteSpace(appSettingsUnitsSelection))
            {
                UnitsSelection = initialUnitsSelection;
                UpdateConfigurationFile();
            }
            else if(Enum.TryParse<UnitsSelection>(appSettingsUnitsSelection, out initialUnitsSelection))
            {
                UnitsSelection = initialUnitsSelection; 
            }
        }
    }
}
