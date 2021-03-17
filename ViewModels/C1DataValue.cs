// Copyright Cooling Technology Institute 2019-2021

namespace ViewModels
{
    public class C1DataValue : DataValue
    {
        public const string C1ToolTipFormat = "C Value.\nValue should be between {0} and {1}.";

        public C1DataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "C";
            Format = "F1";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isIS, bool doConversion = false)
        {
            if (IsDemo)
            {
                Default = 2.0;
                Minimum = 2.0;
            }
            else
            {
                Default = 0;
                Minimum = 0;
            }

            Maximum = 10;
            Current = Default;

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(C1ToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isIS;
        }
    }
}