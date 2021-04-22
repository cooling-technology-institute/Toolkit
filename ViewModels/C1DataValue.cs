// Copyright Cooling Technology Institute 2019-2021

namespace ViewModels
{
    public class C1DataValue : DataValue
    {
        public const string C1ToolTipFormat = "C Value.\nValue should be between {0} and {1}.";

        public C1DataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "C";
            Format = "F1";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
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
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(C1ToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}