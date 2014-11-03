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
    public partial class EodrLngMembraneMenuForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter = new EodrLngMembraneMenuParameter();

        public EodrLngMembraneMenuForm()
        {
            InitializeComponent();
        }

        private void EodrLngMembraneMenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    ProcessTabKey(false);
                else
                    ProcessTabKey(true);
            }
        }

        private void EodrLngMembraneMenuForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonClose_Click(sender,e);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(EodrLngMembraneMessageResource.ExitConfirmation,
                                                  EodrLngMembraneMessageResource.MessageTitle,
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Exclamation,
                                                  MessageBoxDefaultButton.Button1);
            if (result != DialogResult.OK) return;

            this.Close();
        }

        private void buttonVesselInformation_Click(object sender, EventArgs e)
        {
            if (!ReportNoValidateCheck()) return;
            SetMenuParameter();
            EodrLngMembraneVesselForm newForm = new EodrLngMembraneVesselForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();

            SetComboBoxTankNo();
        }

        private void SetComboBoxTankNo()
        {
            this.comboBoxTankNo.Items.Clear();
             for (int n = 1; n <= _eodrLngMembraneMenuParameter.numberOTank; ++n)
            {
                this.comboBoxTankNo.Items.Add(n.ToString());
            }
        }

        private void buttonTankInformation_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneTankForm newForm = new EodrLngMembraneTankForm();
            newForm.ShowDialog();
        }

        private void buttonTankPlane_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneTankPlaneForm newForm = new EodrLngMembraneTankPlaneForm();
            newForm.ShowDialog();
        }

        private void buttonEodrInformation_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneEodrPositionForm newForm = new EodrLngMembraneEodrPositionForm();
            newForm.ShowDialog();
        }

        private void buttonBasePointMeasurement_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneBasePointMeasurementForm newForm = new EodrLngMembraneBasePointMeasurementForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonTankAftBhdMeasurement_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            _eodrLngMembraneMenuParameter.PlaneCode = "A-BHD";
            EodrLngMembraneBHDMeasurementForm newForm = new EodrLngMembraneBHDMeasurementForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonTankForeBhdMeasurement_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            _eodrLngMembraneMenuParameter.PlaneCode = "F-BHD";
            EodrLngMembraneBHDMeasurementForm newForm = new EodrLngMembraneBHDMeasurementForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonTankShellMeasurement_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneCrossSectionMeasurementForm newForm = new EodrLngMembraneCrossSectionMeasurementForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonTankBottomMeasurement_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneBottomMeasurementForm newForm = new EodrLngMembraneBottomMeasurementForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonObservationDataEditing_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneObservationDataEditingForm newForm = new EodrLngMembraneObservationDataEditingForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonCoordinateTransformation_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneCoordinateTransformationForm newForm = new EodrLngMembraneCoordinateTransformationForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void buttonTnakShapeData_Click(object sender, EventArgs e)
        {
            SetMenuParameter();
            EodrLngMembraneTankShapeForm newForm = new EodrLngMembraneTankShapeForm(_eodrLngMembraneMenuParameter);
            newForm.ShowDialog();
        }

        private void SetMenuParameter()
        {
            _eodrLngMembraneMenuParameter.ReportNo = (string)this.comboBoxReportNo.SelectedItem;
            _eodrLngMembraneMenuParameter.TankNo = (string)this.comboBoxTankNo.SelectedItem;
        }

        private void EodrLngMembraneMenuForm_Load(object sender, EventArgs e)
        {
            this.comboBoxTankNo.SelectedIndex = 0;
        }

        private void groupBoxMeasurementForTank_Enter(object sender, EventArgs e)
        {
            ReportNoValidateCheck();
        }

        private bool ReportNoValidateCheck()
        {
            if (string.IsNullOrEmpty((string)this.comboBoxReportNo.SelectedItem))
            {
                MessageBox.Show(EodrLngMembraneMessageResource.NoRequiredData,
                                EodrLngMembraneMessageResource.ErrorMessageTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                this.comboBoxReportNo.Focus();
                return false;
            }
            return true;
        }

        private void groupBoxAftermeasurement_Enter(object sender, EventArgs e)
        {
            ReportNoValidateCheck();
        }
    }

    public class EodrLngMembraneMenuParameter
    {
        string _reportNo;
        string _tankNo;
        string _planeCode;
        int _numberOTank = 0;

        public string ReportNo
        {
            set { _reportNo = value; }
            get { return _reportNo; }
        }

        public int numberOTank
        {
            set { _numberOTank = value; }
            get { return _numberOTank; }
        }

        public string TankNo
        {
            set { _tankNo = value; }
            get { return _tankNo; }
        }

        public string PlaneCode
        {
            set { _planeCode = value; }
            get { return _planeCode; }
        }

    }
}
