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
    public partial class EodrMeasurementForm : Form
    {
        private EodrMeasurementParameter _eodrMeasurementParameter;

        public EodrMeasurementForm(EodrMeasurementParameter eodrMeasurementParameter)
        {
            InitializeComponent();
            _eodrMeasurementParameter = eodrMeasurementParameter;
        }

        private void EodrMeasurementForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    ProcessTabKey(false);
                else
                    ProcessTabKey(true);
            }
            if (e.KeyCode == Keys.F1)
            {
                buttonMeasurent_Click(sender, e);
            }
        }

        private void EodrMeasurementForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                _eodrMeasurementParameter.ApplyFlg = false;
                this.Close();
            }
        }

        private void EodrMeasurementForm_Load(object sender, EventArgs e)
        {
            InitializeDisplay();
        }

        private void EodrZeroSet()
        {
            //計測中に見せかける
            this.labelPressF1Key.Visible = false;
            this.labelMeasuring.Visible = true;
            this.buttonMeasurent.Visible = false;
            ClearMeasurementResults();
            this.Refresh();
            System.Threading.Thread.Sleep(3000);
        }

        private void InitializeDisplay()
        {
            this.Width = _eodrMeasurementParameter.Size_Width;
            this.Height = _eodrMeasurementParameter.Size_Height;
            this.Location = new Point(_eodrMeasurementParameter.Location_X, _eodrMeasurementParameter.Location_Y);

            this.buttonApply.Visible = false;
            this.labelMeasuring.Visible = false;
            _eodrMeasurementParameter.ApplyFlg = false;

            if (_eodrMeasurementParameter.CuurentFormName == "BASE POINT" || _eodrMeasurementParameter.CuurentFormName == "ZERO SET")
            {
                this.labelPlanedMeasurementPoint.Visible = false;
                this.numTextBoxPlanedHorAngle.Visible = false;
                this.numTextBoxPlanedVarAngle.Visible = false;
                this.numTextBoxPlanedSlopeDistance.Visible = false;
                this.numTextBoxPointNo.Visible = false;
                this.numTextBoxSectionNo.Visible = false;
                this.labelSectionNo.Visible = false;
                this.labelPositionNo.Visible = false;
            }
            else
            {
                this.numTextBoxPointNo.Text = string.Format("{0,3:##0}", _eodrMeasurementParameter.MeasurementPointNo);
                this.numTextBoxSectionNo.Text = string.Format("{0,3:##0}", _eodrMeasurementParameter.MeasurementSectionNo);

                this.numTextBoxPlanedHorAngle.Text = _eodrMeasurementParameter.PlanedHorizontalAngle;
                this.numTextBoxPlanedVarAngle.Text = _eodrMeasurementParameter.PlanedVarticalAngle;
                this.numTextBoxPlanedSlopeDistance.Text = _eodrMeasurementParameter.PlanedSlopeDistance;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _eodrMeasurementParameter.ApplyFlg = false;
            this.Close();
        }

        private void buttonMeasurent_Click(object sender, EventArgs e)
        {
            //計測中に見せかける
            this.labelPressF1Key.Visible = false;
            this.labelMeasuring.Visible = true;
            ClearMeasurementResults();
            this.Refresh();
            System.Threading.Thread.Sleep(3000);

            //計測結果を表示する
            GetMeasurementResults();
            this.labelMeasuring.Visible = false;
            this.buttonApply.Visible = true;
            this.labelPressF1Key.Visible = true;
            this.buttonApply.Focus();
            this.Refresh();
        }

        private void GetMeasurementResults()
        {
            this.numTextBoxHorAngle.Text = "56.3254";
            this.numTextBoxVarAngle.Text = "42.5544";
            this.numTextBoxSlopeDistance.Text = "35.052";
        }

        private void ClearMeasurementResults()
        {
            this.numTextBoxHorAngle.Text = "";
            this.numTextBoxVarAngle.Text = "";
            this.numTextBoxSlopeDistance.Text = "";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            _eodrMeasurementParameter.HorizontalAngle = this.numTextBoxHorAngle.Text;
            _eodrMeasurementParameter.VarticalAngle = this.numTextBoxVarAngle.Text;
            _eodrMeasurementParameter.SlopeDistance = this.numTextBoxSlopeDistance.Text;
            _eodrMeasurementParameter.ApplyFlg = true;
            this.Close();
        }

        private void EodrMeasurementForm_Shown(object sender, EventArgs e)
        {
            if (_eodrMeasurementParameter.CuurentFormName == "ZERO SET")
            {
                EodrZeroSet();
                this.Close();
            }
        }
    }
}
