﻿using System;
using System.Windows.Forms;

namespace CTIToolkit
{
    class NumberTextBox : System.Windows.Forms.TextBox
    {
        private string mPrevious;
        private int mMin;
        private int mMax;

        public NumberTextBox() : this(0, Int32.MaxValue) { }
        public NumberTextBox(int min, int max)
           : base()
        {
            if ((min > max) || min < 0 || max < 0)
            {
                throw new Exception("Minimum and maximum values are not supported");
            }
            mMin = min;
            mMax = max;
            this.Text = min.ToString();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            mPrevious = this.Text;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text == string.Empty)
            {
                return;
            }

            int num;
            if (Int32.TryParse(this.Text, out num))
            {
                if (num > mMax)
                {
                    this.Text = mPrevious;
                    this.Select(this.Text.Length, 0);
                }
            }
            else
            {
                this.Text = mPrevious;
                this.Select(this.Text.Length, 0);
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            int num;
            if (!Int32.TryParse(this.Text, out num) || num < mMin || num > mMax)
            {
                this.Text = mPrevious;
                // To move the cursor at last
                this.Select(this.Text.Length, 0);
            }
        }
    }
}
