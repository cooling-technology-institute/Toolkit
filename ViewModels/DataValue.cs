// Copyright Cooling Technology Institute 2019-2021

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
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsDemo { get; set; }
        public bool IsZeroValid { get; set; }
        public string ErrorMessage { get; set; }

        public DataValue()
        {
            Default = 0.0;
            Minimum = 0.0;
            Maximum = 0.0;
            Current = 0.0;
            IsZeroValid = false;
            IsValid = false;
            IsDemo = true;
            IsInternationalSystemOfUnits_SI = false;
            InputMessage = string.Empty;
            InputValue = string.Empty;
            Format = string.Empty;
            ToolTip = string.Empty;
            ErrorMessage = string.Empty;
        }

        public abstract void ConvertValue(bool isInternationalSystemOfUnits_SI);

        public bool UpdateValue(string input)
        {
            InputValue = input;
            return IsValidValue();
        }

        public bool UpdateCurrentValue(double input)
        {
            InputValue = input.ToString(Format);
            return IsValidValue();
        }

        private bool IsValidValue()
        {
            ErrorMessage = string.Empty;
            double value;

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
                        ErrorMessage = string.Format("The {0} input must be between {1} and {2}", InputMessage, Minimum, Maximum);
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
                    ErrorMessage = string.Format("The {0} input is not a valid number", InputMessage);
                    IsValid = false;
                }
            }
            else
            {
                ErrorMessage = string.Format("The {0} input is not a valid number", InputMessage);
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