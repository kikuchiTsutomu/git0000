using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EodrLngMembrane
{
    public partial class EodrLngMembraneTankForm : Form
    {
        public EodrLngMembraneTankForm()
        {
            InitializeComponent();
        }

        private void EodrLngMembraneTankForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    ProcessTabKey(false);
                else
                    ProcessTabKey(true);
            }
        }

        private void EodrLngMembraneTankForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonClose_Click(sender, e);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(EodrLngMembraneMessageResource.SaveEntryForm,
                                     EodrLngMembraneMessageResource.MessageTitle,
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Exclamation,
                                     MessageBoxDefaultButton.Button1);
            if (result != DialogResult.OK)
            {
                result = MessageBox.Show(EodrLngMembraneMessageResource.CloseFormConfirmation,
                                         EodrLngMembraneMessageResource.MessageTitle,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Exclamation,
                                         MessageBoxDefaultButton.Button1);
                if (result != DialogResult.OK) return;
            }

            this.Close();
        }

        private void checkBoxIntersection1_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA1, this.comboBoxPlanePortB1, this.comboBoxPlanePortC1);
        }

        private void ChengeEnabledComboBox(ComboBox comboBoxPA, ComboBox comboBoxPB, ComboBox comboBoxPC)
        {
            comboBoxPA.Enabled = (comboBoxPA.Enabled) ? false : true;
            comboBoxPB.Enabled = (comboBoxPB.Enabled) ? false : true;
            comboBoxPC.Enabled = (comboBoxPC.Enabled) ? false : true;
        }

        private void checkBoxIntersection2_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA2, this.comboBoxPlanePortB2, this.comboBoxPlanePortC2);
        }

        private void checkBoxIntersection3_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA3, this.comboBoxPlanePortB3, this.comboBoxPlanePortC3);
        }

        private void checkBoxIntersection4_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA4, this.comboBoxPlanePortB4, this.comboBoxPlanePortC4);
        }

        private void checkBoxIntersection5_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA5, this.comboBoxPlanePortB5, this.comboBoxPlanePortC5);
        }

        private void checkBoxIntersection6_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA6, this.comboBoxPlanePortB6, this.comboBoxPlanePortC6);
        }

        private void checkBoxIntersection7_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledComboBox(this.comboBoxPlanePortA7, this.comboBoxPlanePortB7, this.comboBoxPlanePortC7);
        }
    }
}
