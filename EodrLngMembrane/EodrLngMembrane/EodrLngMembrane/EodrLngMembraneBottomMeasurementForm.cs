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
    public partial class EodrLngMembraneBottomMeasurementForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter;
        EodrMeasurementParameter _eodrMeasurementParameter = new EodrMeasurementParameter();

        public EodrLngMembraneBottomMeasurementForm(EodrLngMembraneMenuParameter eodrLngMembraneMenuParameter)
        {
            InitializeComponent();
            _eodrLngMembraneMenuParameter = eodrLngMembraneMenuParameter;
        }

        private void EodrLngMembraneBottomMeasurementForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterAction(e);
                return;
            }

            KeyFunctionAction(e);
        }

        private void EodrLngMembraneBottomMeasurementForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonClose_Click(sender, e);
            }
        }

        private void EodrLngMembraneBottomMeasurementForm_Load(object sender, EventArgs e)
        {
            this.labelReportNo.Text = _eodrLngMembraneMenuParameter.ReportNo;
            this.labelTankNo.Text = _eodrLngMembraneMenuParameter.TankNo;
            this.numTextBoxHeightFromBottom.Text = "0.000";
            this.numTextBoxMeasurementSectionNo.Text = "1";

            this.comboBoxEodrPositionNo.SelectedIndex = 0;
            this.comboBoxMeasurementPitch.SelectedIndex = 2;

            _eodrMeasurementParameter.InitializeParameter();
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

        private void KeyEnterAction(KeyEventArgs e)
        {
            if (e.Shift)
                ProcessTabKey(false);
            else
                ProcessTabKey(true);
        }

        private void KeyFunctionAction(KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.F1) &&
                !(e.KeyCode == Keys.F5) &&
                !(e.KeyCode == Keys.F9)) return;

            if (e.KeyCode == Keys.F5)
            {
                //スタブメソッドをこのクラスに生成する
                CalculatePlaneDeviation();
                return;
            }
            if (e.KeyCode == Keys.F9)
            {
                DialogResult result = MessageBox.Show(EodrLngMembraneMessageResource.DeleteDataConfirmation,
                                                      EodrLngMembraneMessageResource.MessageTitle,
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Question,
                                                      MessageBoxDefaultButton.Button2);
                if (result != DialogResult.OK) return;

                DeleteMeasurementData();
                return;
            }

            // 設計のための計測フォームを開く処理
            // 以降は画面設計のためのコード記述
            if (!BhdPlaneMeasurementValidateCheck()) return;
            BhdPlaneMeasurement();
        }

        private void DeleteMeasurementData()
        {
            int index = MeasurementDataSelectedIndex();
            this.dataGridViewMeasurementData.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
            dataSetMeasurementData.DataTableMeasurementData.Rows[index]["Deviation"] = "Del";
        }

        private int MeasurementDataSelectedIndex()
        {
            foreach (DataGridViewRow selectedRow in this.dataGridViewMeasurementData.SelectedRows)
            {
                return selectedRow.Index;
            }
            return 0;
        }
        private void BhdPlaneMeasurement()
        {
            _eodrMeasurementParameter.Location_X = this.Location.X;
            _eodrMeasurementParameter.Location_Y = this.Height;
            _eodrMeasurementParameter.Size_Width = this.Width;
            _eodrMeasurementParameter.CuurentFormName = "BHD MEASUREMENT";
            _eodrMeasurementParameter.MeasurementStartSectionNo = int.Parse(this.numTextBoxMeasurementSectionNo.Text);


            _eodrMeasurementParameter.SetSectionNo();
            _eodrMeasurementParameter.CalcPlanedValue();

            EodrMeasurementForm newForm = new EodrMeasurementForm(_eodrMeasurementParameter);
            newForm.ShowDialog();

            if (_eodrMeasurementParameter.ApplyFlg) ApplyMeasurementData();
        }

        private bool BhdPlaneMeasurementValidateCheck()
        {
            if (string.IsNullOrEmpty(this.numTextBoxMeasurementSectionNo.Text))
            {
                MessageBox.Show(EodrLngMembraneMessageResource.NoRequiredData,
                                EodrLngMembraneMessageResource.ErrorMessageTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                this.numTextBoxMeasurementSectionNo.Focus();
                return false;
            }

            return true;
        }

        private void CalculatePlaneDeviation()
        {
            Random r = new System.Random(1000);
            foreach (DataGridViewRow selectedRow in this.dataGridViewMeasurementData.Rows)
            {
                if ((string)dataSetMeasurementData.DataTableMeasurementData.Rows[selectedRow.Index]["Deviation"] == "Del") continue;
                int dev = r.Next(-50, 50);
                dataSetMeasurementData.DataTableMeasurementData.Rows[selectedRow.Index]["Deviation"] = string.Format("{0,3:##0}", dev);
            }
        }

        private void ApplyMeasurementData()
        {
            AddMeasurementData();
            this.numTextBoxMeasurementSectionNo.Text = string.Format("{0}", _eodrMeasurementParameter.MeasurementSectionNo);
            this.dataGridViewMeasurementData.FirstDisplayedScrollingRowIndex = this.dataGridViewMeasurementData.Rows.Count - 1;
        }

        private void AddMeasurementData()
        {
            dataSetMeasurementData.DataTableMeasurementData.AddDataTableMeasurementDataRow(
                string.Format("{0,3:000}", this.dataGridViewMeasurementData.RowCount + 1),
                "BTTM",
                (string)this.comboBoxEodrPositionNo.SelectedItem,
                string.Format("{0,2:00}", _eodrMeasurementParameter.MeasurementSectionNo),
                string.Format("{0,2:00}", _eodrMeasurementParameter.MeasurementPointNo),
                string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.HorizontalAngle)),
                string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.VarticalAngle)),
                string.Format("{0,7:##0.000}", double.Parse(_eodrMeasurementParameter.SlopeDistance)),
                string.Format("{0,9:##0.00000}", CalculateXCoordinate()),
                string.Format("{0,9:##0.00000}", CalculateYCoordinate()),
                string.Format("{0,9:##0.00000}", CalculateZCoordinate(double.Parse(this.numTextBoxHeightFromBottom.Text))),
                "",
                "");
        }

        private double CalculateZCoordinate(double z0)
        {
            double pi = 3.1415926;
            double ha = pi * double.Parse(_eodrMeasurementParameter.HorizontalAngle) / 180.0;
            double va = pi * double.Parse(_eodrMeasurementParameter.VarticalAngle) / 180.0;

            return double.Parse(_eodrMeasurementParameter.SlopeDistance) * Math.Sin(va) * Math.Sin(ha) - z0;
        }

        private double CalculateYCoordinate()
        {
            double pi = 3.1415926;
            double va = pi * double.Parse(_eodrMeasurementParameter.VarticalAngle) / 180.0;

            return double.Parse(_eodrMeasurementParameter.SlopeDistance) * Math.Cos(va);
        }

        private double CalculateXCoordinate()
        {
            double pi = 3.1415926;
            double ha = pi * double.Parse(_eodrMeasurementParameter.HorizontalAngle) / 180.0;
            double va = pi * double.Parse(_eodrMeasurementParameter.VarticalAngle) / 180.0;

            return double.Parse(_eodrMeasurementParameter.SlopeDistance) * Math.Sin(va) * Math.Cos(ha);
        }

        private void comboBoxMeasurementPitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pitch = (string)this.comboBoxMeasurementPitch.SelectedItem;

            this.labelNumOfHorSection.Text = string.Format("{0,2:#0}", 50.0 / double.Parse(pitch));
            this.labelNumOfVarSection.Text = string.Format("{0,2:#0}", 40.0 / double.Parse(pitch));
            this.labelNumOfMeasurementPoint.Text = string.Format("{0,2:#0}", double.Parse(this.labelNumOfHorSection.Text) * double.Parse(this.labelNumOfVarSection.Text));
        }
    }
}
