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
    public partial class EodrLngMembraneCoordinateTransformationForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter;

        public EodrLngMembraneCoordinateTransformationForm(EodrLngMembraneMenuParameter eodrLngMembraneMenuParameter)
        {
            InitializeComponent();
            _eodrLngMembraneMenuParameter = eodrLngMembraneMenuParameter;
        }

        private void EodrLngMembraneCoordinateTransformationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterAction(e);
                return;
            }

            KeyFunctionAction(e);
        }

        private void EodrLngMembraneCoordinateTransformationForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonClose_Click(sender, e);
            }
        }

        private void EodrLngMembraneCoordinateTransformationForm_Load(object sender, EventArgs e)
        {
            this.labelReportNo.Text = _eodrLngMembraneMenuParameter.ReportNo;
            this.comboBoxTankNo.SelectedIndex = 0;
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

        private void comboBoxPlaneCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTransformationData((string)this.comboBoxPlaneCode.SelectedItem);
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
            if (!(e.KeyCode == Keys.F5) &&
                !(e.KeyCode == Keys.F10)) return;

            if (e.KeyCode == Keys.F5)
            {
                //スタブメソッドをこのクラスに生成する
                CalculatePlaneDeviation();
                CalculatePlaneCoefficient();
                return;
            }
            if (e.KeyCode == Keys.F10)
            {
                SavePrintReportFile();
                return;
            }
        }

        private void SavePrintReportFile()
        {
            //印刷用レポートファイルを出力、規定の場所に上書き保存
            string message = string.Format(EodrLngMembraneMessageResource.PrintConfirmation, EodrLngMembraneMessageResource.TankCalculationReport);
            DialogResult result = MessageBox.Show(message,
                                                  EodrLngMembraneMessageResource.MessageTitle,
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Exclamation,
                                                  MessageBoxDefaultButton.Button1);
            if (result != DialogResult.OK) return;

            //SaveFileDialogにするか？（ユーザと調整）
            PrintTankCalculationData();
        }

        private void PrintTankCalculationData()
        {
            this.labelFunction10.Enabled = false;
            System.Threading.Thread.Sleep(1000);
            this.labelFunction10.Enabled = true;
        }

        private void CalculatePlaneCoefficient()
        {
            this.labelCoefficientA.Text = "1.325688E1";
            this.labelCoefficientB.Text = "1.325688E-1";
            this.labelCoefficientC.Text = "0.456980E-2";
            this.labelCoefficientD.Text = "2.136658E2";
        }

        private void CalculatePlaneDeviation()
        {
            Random r = new System.Random(1000);
            foreach (DataGridViewRow selectedRow in this.dataGridViewMeasurementData.Rows)
            {
                int dev = r.Next(-50, 50);
                dataSetCoordinateTransformation.DataTableCoordinateTramsformation.Rows[selectedRow.Index]["XCoordinateTransformation"] = "18.256";
                dataSetCoordinateTransformation.DataTableCoordinateTramsformation.Rows[selectedRow.Index]["YCoordinateTransformation"] = "5.236";
                dataSetCoordinateTransformation.DataTableCoordinateTramsformation.Rows[selectedRow.Index]["ZCoordinateTransformation"] = "6.256";
                dataSetCoordinateTransformation.DataTableCoordinateTramsformation.Rows[selectedRow.Index]["Deviation"] = string.Format("{0,3:##0}", dev);
            }
        }

        private void GetTransformationData(string planeCode)
        {
            dataSetCoordinateTransformation.DataTableCoordinateTramsformation.Clear();

            int no = 0;
            int section = 0;
            int point = 0;
            int position = 1;
            for (section = 0; section < 10; section++)
            {
                if (section == 5) position++;
                for (point = 0; point < 3; point++)
                {
                    no++;
                    dataSetCoordinateTransformation.DataTableCoordinateTramsformation.AddDataTableCoordinateTramsformationRow(
                        string.Format("{0,3:##0}", no),
                        planeCode,
                        string.Format("{0,1:0}", position),
                        "18.2233",
                        "8.1122",
                        "5.156",
                        "",
                        "",
                        "",
                        "",
                        "");
                }
            }
        }
    }
}
