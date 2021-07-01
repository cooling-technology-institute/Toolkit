// Copyright Cooling Technology Institute 2019-2021

namespace CTIToolkit
{
    // Assembly Information

    public static class AssemblyInformation
    {
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
    }
}
