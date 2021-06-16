// Copyright Cooling Technology Institute 2019-2021

using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace CTIToolkit
{
    // Assembly Information

    public static class AssemblyInformation
    {
        public static string Demo = "Demo";
        //private static string toolkitVersionKeyLocation = string.Format("SOFTWARE\\{0}", AssemblyInformation.Company, AssemblyInformation.Product, AssemblyInformation.AssemblyShortVersion);
        private static string toolkitVersionKeyLocation = string.Format(@"SOFTWARE\{0}\{1}\{2}", AssemblyInformation.Company, AssemblyInformation.Product, AssemblyInformation.AssemblyShortVersion);
        private static string serialNumber = Demo;
        private static string SerialNumberName = "SerialNumber";

        public static string Title
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyTitleAttribute), false);
                return ((System.Reflection.AssemblyTitleAttribute)attribute[0]).Title;
            }
        }

        public static string Description
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyDescriptionAttribute), false);
                return ((System.Reflection.AssemblyDescriptionAttribute)attribute[0]).Description;
            }
        }

        public static string Company
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyCompanyAttribute), false);
                return ((System.Reflection.AssemblyCompanyAttribute)attribute[0]).Company;
            }
        }

        public static string Product
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyProductAttribute), false);
                return ((System.Reflection.AssemblyProductAttribute)attribute[0]).Product;
            }
        }

        public static string Copyright
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyCopyrightAttribute), false);
                return ((System.Reflection.AssemblyCopyrightAttribute)attribute[0]).Copyright;
            }
        }

        public static string Trademark
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyTrademarkAttribute), false);
                return ((System.Reflection.AssemblyTrademarkAttribute)attribute[0]).Trademark;
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyShortVersion
        {
            get
            {
                return string.Format("{0}.{1}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
            }
        }

        public static string FileVersion
        {
            get
            {
                object[] attribute = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(System.Reflection.AssemblyFileVersionAttribute), false);
                return ((System.Reflection.AssemblyFileVersionAttribute)attribute[0]).Version;
            }
        }

        public static string Name
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            }
        }

        public static string FullName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().FullName.ToString();
            }
        }

        public static string Location
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
        }

        public static string CodeBase
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            }
        }

        public static string SerialNumber
        {
            get
            {
                RegistryKey localMachine = null;

                // open the key
                try
                {
                    localMachine = Registry.LocalMachine;

                    RegistryKey toolkitVersionKey = localMachine.OpenSubKey(toolkitVersionKeyLocation);
                    if (toolkitVersionKey != null)
                    {
                        serialNumber = (string)toolkitVersionKey.GetValue("SerialNumber");
                        toolkitVersionKey.Close();
                    }
                }
                catch
                {

                }

                if (localMachine != null)
                {
                    localMachine.Close();
                }

                if (!string.IsNullOrWhiteSpace(serialNumber))
                {
                    if (!TestSerialNumber(serialNumber))
                    {
                        serialNumber = string.Empty;
                    }
                }

                if(string.IsNullOrEmpty(serialNumber))
                {
                    serialNumber = Demo;
                }

                return serialNumber;
            }

            set
            {
                RegistryKey localMachine = null;
                string serialNumber = value;
                bool saved = false;

                // open the key
                try
                {
                    localMachine = Registry.LocalMachine;

                    RegistryKey toolkitVersionKey = localMachine.OpenSubKey(toolkitVersionKeyLocation, true);
                    if (toolkitVersionKey != null)
                    {
                        toolkitVersionKey.SetValue(SerialNumberName, serialNumber.ToUpper());
                        saved = true;
                        toolkitVersionKey.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to write serial number. " + e.ToString());
                }

                if (localMachine != null)
                {
                    localMachine.Close();
                }
                
                if (!saved)
                {
                    serialNumber = Demo;
                }
            }
        }

        // 012345678901234567890
        // aa99-a999-a9aa
        public static bool TestSerialNumber(string serialNumber)
        {
            bool isGood = (serialNumber.Length == 10);
            
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
