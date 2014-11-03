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
    public partial class EodrLngMembraneTankShapeForm : Form
    {
        EodrLngMembraneMenuParameter _eodrLngMembraneMenuParameter;

        public EodrLngMembraneTankShapeForm(EodrLngMembraneMenuParameter eodrLngMembraneMenuParameter)
        {
            InitializeComponent();
            _eodrLngMembraneMenuParameter = eodrLngMembraneMenuParameter;
        }

        private void EodrLngMembraneTankShapeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterAction(e);
                return;
            }

            KeyFunctionAction(e);
        }

        private void EodrLngMembraneTankShapeForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonClose_Click(sender, e);
            }
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
                CalculateTankShape();
                return;
            }
            if (e.KeyCode == Keys.F10)
            {
                string message = string.Format(EodrLngMembraneMessageResource.PrintConfirmation, EodrLngMembraneMessageResource.TankShapeReport);
                DialogResult result = MessageBox.Show(message,
                                                      EodrLngMembraneMessageResource.MessageTitle,
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result != DialogResult.OK) return;

                //SaveFileDialogにするか？（ユーザと調整）
                PrintTankShapeData();
                return;
            }
        }

        private void PlanedTankShape()
        {
            this.labelPlanedAftBHD.Text = "0.000";

            this.labelPlanedWLAft1.Text = "0.000";
            this.labelPlanedWLAft2.Text = "0.000";
            this.labelPlanedWLAft3.Text = "2.000";
            this.labelPlanedWLAft4.Text = "10.000";
            this.labelPlanedWLAft5.Text = "12.000";
            this.labelPlanedWLAft6.Text = "12.000";
            this.labelPlanedWLAft7.Text = "0.000";
            this.labelPlanedBredthAft1.Text = "0.000";
            this.labelPlanedBredthAft2.Text = "20.000";
            this.labelPlanedBredthAft3.Text = "24.000";
            this.labelPlanedBredthAft4.Text = "24.000";
            this.labelPlanedBredthAft5.Text = "20.000";
            this.labelPlanedBredthAft6.Text = "0.000";
            this.labelPlanedBredthAft7.Text = "0.000";

            this.labelPlanedForeBHD.Text = "35.000";

            this.labelPlanedWLFore1.Text = "0.000";
            this.labelPlanedWLFore2.Text = "0.000";
            this.labelPlanedWLFore3.Text = "2.000";
            this.labelPlanedWLFore4.Text = "10.000";
            this.labelPlanedWLFore5.Text = "12.000";
            this.labelPlanedWLFore6.Text = "12.000";
            this.labelPlanedWLFore7.Text = "0.000";
            this.labelPlanedBredthFore1.Text = "0.000";
            this.labelPlanedBredthFore2.Text = "20.000";
            this.labelPlanedBredthFore3.Text = "24.000";
            this.labelPlanedBredthFore4.Text = "24.000";
            this.labelPlanedBredthFore5.Text = "20.000";
            this.labelPlanedBredthFore6.Text = "0.000";
            this.labelPlanedBredthFore7.Text = "0.000";
        }

        private void CalculateTankShape()
        {
            this.labelMeasuredAftBHD.Text = "0.000";

            this.labelMeasuredWLAft1.Text = "0.000";
            this.labelMeasuredWLAft2.Text = "0.000";
            this.labelMeasuredWLAft3.Text = "1.995";
            this.labelMeasuredWLAft4.Text = "10.002";
            this.labelMeasuredWLAft5.Text = "12.003";
            this.labelMeasuredWLAft6.Text = "12.003";
            this.labelMeasuredWLAft7.Text = "0.000";
            this.labelMeasuredBredthAft1.Text = "0.000";
            this.labelMeasuredBredthAft2.Text = "19.952";
            this.labelMeasuredBredthAft3.Text = "23.995";
            this.labelMeasuredBredthAft4.Text = "23.995";
            this.labelMeasuredBredthAft5.Text = "19.955";
            this.labelMeasuredBredthAft6.Text = "0.000";
            this.labelMeasuredBredthAft7.Text = "0.000";

            this.labelMeasuredForeBHD.Text = "34.988";

            this.labelMeasuredWLFore1.Text = "0.000";
            this.labelMeasuredWLFore2.Text = "0.000";
            this.labelMeasuredWLFore3.Text = "1.995";
            this.labelMeasuredWLFore4.Text = "10.002";
            this.labelMeasuredWLFore5.Text = "12.003";
            this.labelMeasuredWLFore6.Text = "12.003";
            this.labelMeasuredWLFore7.Text = "0.000";
            this.labelMeasuredBredthFore1.Text = "0.000";
            this.labelMeasuredBredthFore2.Text = "19.952";
            this.labelMeasuredBredthFore3.Text = "23.995";
            this.labelMeasuredBredthFore4.Text = "23.995";
            this.labelMeasuredBredthFore5.Text = "19.955";
            this.labelMeasuredBredthFore6.Text = "0.000";
            this.labelMeasuredBredthFore7.Text = "0.000";
        }

        private void PrintTankShapeData()
        {
            this.labelFunction10.Enabled = false;
            System.Threading.Thread.Sleep(1000);
            this.labelFunction10.Enabled = true;
        }

        private void EodrLngMembraneTankShapeForm_Load(object sender, EventArgs e)
        {
            this.labelReportNo.Text = _eodrLngMembraneMenuParameter.ReportNo;
            this.comboBoxTankNo.SelectedIndex = 0;

            PlanedTankShape();
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

        private void comboBoxTankNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //実際は、ファイルのデータを読み込んで表示
            PlanedTankShape();
            ClearCalculateTankShape();

        }

        private void ClearCalculateTankShape()
        {
            this.labelMeasuredAftBHD.Text = "";

            this.labelMeasuredWLAft1.Text = "";
            this.labelMeasuredWLAft2.Text = "";
            this.labelMeasuredWLAft3.Text = "";
            this.labelMeasuredWLAft4.Text = "";
            this.labelMeasuredWLAft5.Text = "";
            this.labelMeasuredWLAft6.Text = "";
            this.labelMeasuredWLAft7.Text = "";
            this.labelMeasuredBredthAft1.Text = "";
            this.labelMeasuredBredthAft2.Text = "";
            this.labelMeasuredBredthAft3.Text = "";
            this.labelMeasuredBredthAft4.Text = "";
            this.labelMeasuredBredthAft5.Text = "";
            this.labelMeasuredBredthAft6.Text = "";
            this.labelMeasuredBredthAft7.Text = "";

            this.labelMeasuredForeBHD.Text = "";

            this.labelMeasuredWLFore1.Text = "";
            this.labelMeasuredWLFore2.Text = "";
            this.labelMeasuredWLFore3.Text = "";
            this.labelMeasuredWLFore4.Text = "";
            this.labelMeasuredWLFore5.Text = "";
            this.labelMeasuredWLFore6.Text = "";
            this.labelMeasuredWLFore7.Text = "";
            this.labelMeasuredBredthFore1.Text = "";
            this.labelMeasuredBredthFore2.Text = "";
            this.labelMeasuredBredthFore3.Text = "";
            this.labelMeasuredBredthFore4.Text = "";
            this.labelMeasuredBredthFore5.Text = "";
            this.labelMeasuredBredthFore6.Text = "";
            this.labelMeasuredBredthFore7.Text = "";
        }
    }
}
