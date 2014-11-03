using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace EodrLngMembrane
{
    public partial class EodrLngMembraneCaltureForm : Form
    {
        private const string _displayNameEN = "英語";
        private const string _displayNameJP = "日本語 (日本)";

        public EodrLngMembraneCaltureForm()
        {
            InitializeComponent();
        }

        private void EodrLngMembraneCaltureForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    ProcessTabKey(false);
                else
                    ProcessTabKey(true);
            }
        }

        private void EodrLngMembraneCaltureForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult result = MessageBox.Show(EodrLngMembraneMessageResource.QuitProgram,
                                                      EodrLngMembraneMessageResource.MessageTitle,
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var displayName = _displayNameEN;
             if (this.comboBoxCalture.SelectedIndex == 0)
            {
                displayName = _displayNameJP;
            }
            foreach (CultureInfo culture in cultures)
            {
                if (culture.DisplayName == displayName)
                {
                    Thread.CurrentThread.CurrentUICulture = culture;
                    break;
                }
            }

            this.Close();
        }

        private void EodrLngMembraneCaltureForm_Load(object sender, EventArgs e)
        {
            this.comboBoxCalture.SelectedIndex = 0;
        }
    }
}
