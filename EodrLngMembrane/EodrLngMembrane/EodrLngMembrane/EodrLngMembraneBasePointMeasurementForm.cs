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
    public partial class EodrLngMembraneBasePointMeasurementForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter;
        EodrMeasurementParameter _eodrMeasurementParameter = new EodrMeasurementParameter();

        public EodrLngMembraneBasePointMeasurementForm(EodrLngMembraneMenuParameter eodrLngMembraneMenuParameter)
        {
            InitializeComponent();
            _eodrLngMembraneMenuParameter = eodrLngMembraneMenuParameter;
        }

        private void EodrLngMembraneBasePointMeasurementForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterAction(e);
                return;
            }

            KeyFunctionAction(e);
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
            if (!(e.KeyCode == Keys.F1) && !(e.KeyCode == Keys.F5) && !(e.KeyCode == Keys.F7)) return;

            if (e.KeyCode == Keys.F5)
            {
                CalculateCoordinateTransform();
                return;
            }

            if (e.KeyCode == Keys.F7)
            {
                SetHorizontalAngleToZero();
                return;
            }

            // TODO 計測フォームを開く処理
            BasePointMeasurement();
        }

        private void SetHorizontalAngleToZero()
        {
            //本来は、EODRに対して、ゼロセット要求（画面を開くか？）
            // スタブ計測フォームを開く
            _eodrMeasurementParameter.Location_X = this.Location.X;
            _eodrMeasurementParameter.Location_Y = this.Height;
            _eodrMeasurementParameter.Size_Width = this.Width;
            _eodrMeasurementParameter.CuurentFormName = "ZERO SET";

            EodrMeasurementForm newForm = new EodrMeasurementForm(_eodrMeasurementParameter);
            newForm.ShowDialog();

            this.radioButtonHAngleZeroSetFlag.Checked = true;
        }

        //F1スタブメソッド
        private void BasePointMeasurement()
        {
            // スタブ計測フォームを開く
            _eodrMeasurementParameter.Location_X = this.Location.X;
            _eodrMeasurementParameter.Location_Y = this.Height;
            _eodrMeasurementParameter.Size_Width = this.Width;
            _eodrMeasurementParameter.CuurentFormName = "BASE POINT";
            _eodrMeasurementParameter.BasePointIndex = BasePointSelectedIndex();

            EodrMeasurementForm newForm = new EodrMeasurementForm(_eodrMeasurementParameter);
            newForm.ShowDialog();

            if (_eodrMeasurementParameter.ApplyFlg) ApplyMeasurementData();
        }

        private int BasePointSelectedIndex()
        {
            foreach (DataGridViewRow selectedRow in dataGridViewBasePoint.SelectedRows)
            {
                return selectedRow.Index;
            }
            return 0;
        }

        private void ApplyMeasurementData()
        {
            EditBasePointMeasurementData();
        }

        private void EditBasePointMeasurementData()
        {
            int index = BasePointSelectedIndex();
            foreach (DataGridViewRow selectedRow in dataGridViewBasePoint.SelectedRows)
            {
                index = selectedRow.Index;
            }

            dataSetBasePoint.DataTablebasePoint.Rows[index]["HorAngle"] = string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.HorizontalAngle));
            dataSetBasePoint.DataTablebasePoint.Rows[index]["VarAngle"] = string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.VarticalAngle));
            dataSetBasePoint.DataTablebasePoint.Rows[index]["SlopeDistance"] = string.Format("{0,7:##0.000}", double.Parse(_eodrMeasurementParameter.SlopeDistance));
            dataSetBasePoint.DataTablebasePoint.Rows[index]["XCoordinate"] = string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.HorizontalAngle));
            dataSetBasePoint.DataTablebasePoint.Rows[index]["YCoordinate"] = string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.HorizontalAngle));
            dataSetBasePoint.DataTablebasePoint.Rows[index]["ZCoordinate"] = string.Format("{0,8:##0.0000}", double.Parse(_eodrMeasurementParameter.HorizontalAngle));
        }

        //F5スタブメソッド
        private void CalculateCoordinateTransform()
        {
            ////画面設計なので結果を直接設定する
            this.dataGridViewCoordinateTransform.ClearSelection();
            //dataSetBasePointTransformation.DataTableBasePointTransformation
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[0]["XTransformation"] = "1.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[0]["YTransformation"] = "1.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[0]["ZTransformation"] = "1.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[1]["XTransformation"] = "2.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[1]["YTransformation"] = "2.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[1]["ZTransformation"] = "2.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[2]["XTransformation"] = "3.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[2]["YTransformation"] = "3.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[2]["ZTransformation"] = "3.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[3]["XTransformation"] = "4.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[3]["YTransformation"] = "4.00000";
            dataSetBasePointTransformation.DataTableBasePointTransformation.Rows[3]["ZTransformation"] = "4.00000";
        }

        private void EodrLngMembraneBasePointMeasurementForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void EodrLngMembraneBasePointMeasurementForm_Load(object sender, EventArgs e)
        {
            this.labelReportNo.Text = _eodrLngMembraneMenuParameter.ReportNo;
            this.labelTankNo.Text = _eodrLngMembraneMenuParameter.TankNo;

            this.labelEodrHeight.Text = "1.452";
            this.labelEodrTemperature.Text = "18.0";

            SetBasePointData();
            SetCoordinateTransformData();
            this.dataGridViewCoordinateTransform.ClearSelection();
        }

        private void SetCoordinateTransformData()
        {
            dataSetBasePointTransformation.DataTableBasePointTransformation.Clear();
            dataSetBasePointTransformation.DataTableBasePointTransformation.AddDataTableBasePointTransformationRow("BASE 0", "", "", "");
            dataSetBasePointTransformation.DataTableBasePointTransformation.AddDataTableBasePointTransformationRow("BASE A", "", "", "");
            dataSetBasePointTransformation.DataTableBasePointTransformation.AddDataTableBasePointTransformationRow("BASE B", "", "", "");
            dataSetBasePointTransformation.DataTableBasePointTransformation.AddDataTableBasePointTransformationRow("BASE C", "", "", "");
        }

        private void SetBasePointData()
        {
            dataSetBasePoint.DataTablebasePoint.Clear();
            dataSetBasePoint.DataTablebasePoint.AddDataTablebasePointRow("BASE 0", "", "", "", "", "", "");
            dataSetBasePoint.DataTablebasePoint.AddDataTablebasePointRow("BASE A", "", "", "", "", "", "");
            dataSetBasePoint.DataTablebasePoint.AddDataTablebasePointRow("BASE B", "", "", "", "", "", "");
            dataSetBasePoint.DataTablebasePoint.AddDataTablebasePointRow("BASE C", "", "", "", "", "", "");
        }

        private void comboBoxEodrPositionNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //本来はデータをセットする
            SetBasePoisitionData();
        }

        private void SetBasePoisitionData()
        {
            SetBasePointData();
            SetCoordinateTransformData();
            this.radioButtonHAngleZeroSetFlag.Checked = false;
            this.dataGridViewCoordinateTransform.ClearSelection();
        }
    }
}
