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
        private bool _IsDemo = true;
        private string _SerialNumber = "Demo";
        //private string _ActivationDate;
        //private bool _IsActivated = false;

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

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                if(!string.IsNullOrWhiteSpace(value) && TestSerialNumber(value))
                {
                    _SerialNumber = value;

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
            Properties.Settings.Default.SerialNumber = _SerialNumber;
            Properties.Settings.Default.Demo = _IsDemo;
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

            string serialNumber = string.Empty;
            try
            {
                serialNumber = Properties.Settings.Default.SerialNumber;
            }
            catch
            { }

            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                _SerialNumber = string.Empty;
                _IsDemo = true;
            }
            else
            {
                _SerialNumber = serialNumber;
            }

            //string activationDate;
            //try
            //{
            //    activationDate = Properties.Settings.Default.ActivationDate;
            //    if (!string.IsNullOrWhiteSpace(activationDate))
            //    {
            //        _IsActivated = true;
            //        _ActivationDate = activationDate;
            //    }
            //    else
            //    {
            //        // message box need to activate
            //    }
            //}
            //catch
            //{ }
        }

        // 012345678901234567890
        // aa99-a999-a9aa
        public static bool TestSerialNumber(string serialNumber)
        {
            bool isGood = (serialNumber.Length == 14);

            // check the serial number 
            for (int x = 0; x < serialNumber.Length && isGood; x++)
            {
                switch (x)
                {
                    // alphabetic
                    case 0:
                    case 1:
                    case 5:
                    case 10:
                    case 12:
                    case 13:
                        isGood &= (char.IsLetter(serialNumber[x]));
                        break;
                    case 2:
                    case 3:
                    case 6:
                    case 7:
                    case 8:
                    case 11:
                        isGood &= (char.IsDigit(serialNumber[x]));
                        break;
                    case 4:
                    case 9:
                        isGood &= (serialNumber[x] == '-');
                        break;
                    default:
                        isGood = false;
                        break;
                }
            }
            return isGood;
        }
    }
}
