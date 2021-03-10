using System;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class CustomMenuItem : MenuItem
    {
        public int TabIndex { get; set; }

        public CustomMenuItem(string text, EventHandler onClick, int tabIndex) : base(text, onClick)
        {
            TabIndex = tabIndex;
        }
    }
}
