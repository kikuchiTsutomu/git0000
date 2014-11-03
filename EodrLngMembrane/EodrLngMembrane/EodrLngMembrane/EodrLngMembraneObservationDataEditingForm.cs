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
    public partial class EodrLngMembraneObservationDataEditingForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter;

        public EodrLngMembraneObservationDataEditingForm(EodrLngMembraneMenuParameter eodrLngMembraneMenuParameter)
        {
            InitializeComponent();
            _eodrLngMembraneMenuParameter = eodrLngMembraneMenuParameter;
        }

        private void comboBoxPlaneCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMeasurementData((string)this.comboBoxPlaneCode.SelectedItem);
        }

        private void EodrLngMembraneObservationDataEditingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterAction(e);
                return;
            }

            KeyFunctionAction(e);
        }

        private void EodrLngMembraneObservationDataEditingForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonClose_Click(sender, e);
            }
        }

        private void EodrLngMembraneObservationDataEditingForm_Load(object sender, EventArgs e)
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
                !(e.KeyCode == Keys.F9) &&
                !(e.KeyCode == Keys.F10)) return;

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
                                                      MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button2);
                if (result != DialogResult.OK) return;

                DeleteMeasurementData();
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
            string message = string.Format(EodrLngMembraneMessageResource.PrintConfirmation, EodrLngMembraneMessageResource.TankMeasurementReport);
            DialogResult result = MessageBox.Show(message,
                                                  EodrLngMembraneMessageResource.MessageTitle,
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Exclamation,
                                                  MessageBoxDefaultButton.Button1);
            if (result != DialogResult.OK) return;

            //SaveFileDialogにするか？（ユーザと調整）
            PrintTankMeasurementData();
        }

        private void PrintTankMeasurementData()
        {
            this.labelFunction10.Enabled = false;
            System.Threading.Thread.Sleep(1000);
            this.labelFunction10.Enabled = true;
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

        private void GetMeasurementData(string planeCode)
        {
            dataSetMeasurementData.DataTableMeasurementData.Clear();

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
                    dataSetMeasurementData.DataTableMeasurementData.AddDataTableMeasurementDataRow(
                        string.Format("{0,3:##0}",no),
                        planeCode,
                        string.Format("{0,1:0}", position),
                        string.Format("{0,3:##0}", section + 1),
                        string.Format("{0,3:##0}", point + 1),
                        "30.2233",
                        "45.1122",
                        "23.156",
                        "18.256",
                        "5.236",
                        "6.256",
                        "-2",
                        "");
                }
            }
        }
    }
}
