// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public abstract class DataValue
    {
        public double Default { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double Current { get; set; }
        public bool IsValid { get; set; }
        public string InputMessage { get; set; }
        public string InputValue { get; set; }
        public string Format { get; set; }
        public string ToolTip { get; set; }
        public bool IsInternationalSystemOfUnits_SI_ { get; set; }
        public bool IsDemo { get; set; }
        public bool IsZeroValid { get; set; }

        public DataValue()
        {
            Default = 0.0;
            Minimum = 0.0;
            Maximum = 0.0;
            Current = 0.0;
            IsZeroValid = false;
            IsValid = false;
            IsDemo = true;
            IsInternationalSystemOfUnits_SI_ = false;
            InputMessage = string.Empty;
            InputValue = string.Empty;
            Format = string.Empty;
            ToolTip = string.Empty;
        }

        public abstract void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false);

        public bool UpdateValue(string input, out string errorMessage)
        {
            InputValue = input;
            return IsValidValue(out errorMessage);
        }

        public bool UpdateCurrentValue(double input, out string errorMessage)
        {
            InputValue = input.ToString();
            return IsValidValue(out errorMessage);
        }

        private bool IsValidValue(out string message)
        {
            message = string.Empty;
            double value = Current;

            if (!string.IsNullOrEmpty(InputValue))
            {
                if (double.TryParse(InputValue, out value))
                {
                    if (IsZeroValid && value == 0)
                    {
                        Current = value;
                        IsValid = true;
                    }
                    else if ((value < Minimum) || (value > Maximum))
                    {
                        value = Current;
                        message = string.Format("The {0} input must be between {1} and {2}", InputMessage, Minimum, Maximum);
                        IsValid = false;
                    }
                    else
                    {
                        Current = value;
                        IsValid = true;
                    }
                }
                else
                {
                    message = string.Format("The {0} input is not a valid number", InputMessage);
                    IsValid = false;
                }
            }
            else
            {
                message = string.Format("The {0} input is not a valid number", InputMessage);
                IsValid = false;
            }

            return IsValid;
        }

        public void InitializeValue(double value)
        {
            Current = value;
            InputValue = Current.ToString(Format);
        }
    }
}