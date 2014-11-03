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
    public partial class EodrLngMembraneEodrPositionForm : Form
    {
        public EodrLngMembraneEodrPositionForm()
        {
            InitializeComponent();
        }

        private void EodrLngMembraneEodrPositionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    ProcessTabKey(false);
                else
                    ProcessTabKey(true);
            }
        }

        private void EodrLngMembraneEodrPositionForm_KeyPress(object sender, KeyPressEventArgs e)
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
                this.Close();
                return;
            }

            if (!ValidateCheck()) return;
            this.Close();
        }

        private bool ValidateCheck()
        {
            if (!this.checkBoxEodrPositionFlg1.Checked)
            {
                ShowNoRequiredDataMessage();
                this.checkBoxEodrPositionFlg1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.numTextBoxEodrHeight1.Text))
            {
                ShowNoRequiredDataMessage();
                this.numTextBoxEodrHeight1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.numTextBoxEodrTemperature1.Text))
            {
                ShowNoRequiredDataMessage();
                this.numTextBoxEodrTemperature1.Focus();
                return false;
            }
            return true;
        }

        private void ShowNoRequiredDataMessage()
        {
            MessageBox.Show(EodrLngMembraneMessageResource.NoRequiredData,
                            EodrLngMembraneMessageResource.ErrorMessageTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
        }

        private void checkBoxEodrPositionFlg1_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledGroupBox(this.checkBoxEodrPositionFlg1,this.groupBoxEodrPositionNo2);
            if (!this.groupBoxEodrPositionNo2.Enabled) this.groupBoxEodrPositionNo3.Enabled = false;
            if ((this.groupBoxEodrPositionNo2.Enabled) && (this.checkBoxEodrPositionFlg2.Checked)) this.groupBoxEodrPositionNo3.Enabled = true;
        }

        private void ChengeEnabledGroupBox(CheckBox checkBox, GroupBox groupBox)
        {
            groupBox.Enabled = (checkBox.Checked) ? true : false; ;
        }

        private void checkBoxEodrPositionFlg2_CheckedChanged(object sender, EventArgs e)
        {
            ChengeEnabledGroupBox(this.checkBoxEodrPositionFlg2, this.groupBoxEodrPositionNo3);
        }

        private void EodrLngMembraneEodrPositionForm_Load(object sender, EventArgs e)
        {
            ChengeEnabledGroupeBox();
        }

        private void ChengeEnabledGroupeBox()
        {
            ChengeEnabledGroupBox(this.checkBoxEodrPositionFlg1, this.groupBoxEodrPositionNo2);
            ChengeEnabledGroupBox(this.checkBoxEodrPositionFlg2, this.groupBoxEodrPositionNo3);
        }
    }
}
