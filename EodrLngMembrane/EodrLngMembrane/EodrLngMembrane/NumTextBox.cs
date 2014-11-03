using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EodrLngMembrane
{
    public partial class NumTextBox : TextBox
    {
        public NumTextBox()
        {
            InitializeComponent();
        }

        private void NumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void NumTextBox_Leave(object sender, EventArgs e)
        {
            this.Text = FormatTextValue(this.Text, this.Tag);
        }

        private string FormatTextValue(string text, object formatText)
        {
            double value;
            if (string.IsNullOrEmpty(text)) return text;

            while (text.Contains(".."))
            {
                text = text.Replace("..", ".");
            }

            if (double.TryParse(text, out value))
            {
                if (string.IsNullOrEmpty((string)formatText)) return text;
                return string.Format((string)formatText, value);
            }

            return string.Empty;
        }
    }
}
