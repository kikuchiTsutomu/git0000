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
    public partial class EodrLngMembraneVesselForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter;

        public EodrLngMembraneVesselForm(EodrLngMembraneMenuParameter eodrLngMembraneMenuParameter)
        {
            InitializeComponent();
            _eodrLngMembraneMenuParameter = eodrLngMembraneMenuParameter;
        }

        private void EodrLngMembraneVesselForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    ProcessTabKey(false);
                else
                    ProcessTabKey(true);
            }
        }

        private void EodrLngMembraneVesselForm_KeyPress(object sender, KeyPressEventArgs e)
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
            if (string.IsNullOrEmpty(this.numTextBoxNumberOfTank.Text))
            {
                MessageBox.Show(EodrLngMembraneMessageResource.NoRequiredData,
                                EodrLngMembraneMessageResource.ErrorMessageTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                this.numTextBoxNumberOfTank.Focus();
                return false;
            }
            _eodrLngMembraneMenuParameter.numberOTank = int.Parse(this.numTextBoxNumberOfTank.Text);
            return true;
        }

        private void EodrLngMembraneVesselForm_Load(object sender, EventArgs e)
        {
            this.labelReportNo.Text = _eodrLngMembraneMenuParameter.ReportNo;
        }
    }
}
