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
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_IS_)
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

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_IS_)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(C1ToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }
    }
}