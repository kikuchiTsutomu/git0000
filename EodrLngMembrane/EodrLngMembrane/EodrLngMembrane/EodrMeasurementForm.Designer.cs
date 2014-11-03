namespace EodrLngMembrane
{
    partial class EodrMeasurementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EodrMeasurementForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMeasurementResults = new System.Windows.Forms.Label();
            this.labelPlanedMeasurementPoint = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonMeasurent = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelPressF1Key = new System.Windows.Forms.Label();
            this.labelMeasuring = new System.Windows.Forms.Label();
            this.labelPositionNo = new System.Windows.Forms.Label();
            this.labelSectionNo = new System.Windows.Forms.Label();
            this.numTextBoxPointNo = new EodrLngMembrane.NumTextBox();
            this.numTextBoxSectionNo = new EodrLngMembrane.NumTextBox();
            this.numTextBoxPlanedSlopeDistance = new EodrLngMembrane.NumTextBox();
            this.numTextBoxPlanedVarAngle = new EodrLngMembrane.NumTextBox();
            this.numTextBoxPlanedHorAngle = new EodrLngMembrane.NumTextBox();
            this.numTextBoxSlopeDistance = new EodrLngMembrane.NumTextBox();
            this.numTextBoxVarAngle = new EodrLngMembrane.NumTextBox();
            this.numTextBoxHorAngle = new EodrLngMembrane.NumTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // labelMeasurementResults
            // 
            resources.ApplyResources(this.labelMeasurementResults, "labelMeasurementResults");
            this.labelMeasurementResults.Name = "labelMeasurementResults";
            // 
            // labelPlanedMeasurementPoint
            // 
            resources.ApplyResources(this.labelPlanedMeasurementPoint, "labelPlanedMeasurementPoint");
            this.labelPlanedMeasurementPoint.Name = "labelPlanedMeasurementPoint";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonMeasurent
            // 
            this.buttonMeasurent.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.buttonMeasurent, "buttonMeasurent");
            this.buttonMeasurent.Name = "buttonMeasurent";
            this.buttonMeasurent.UseVisualStyleBackColor = false;
            this.buttonMeasurent.Click += new System.EventHandler(this.buttonMeasurent_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelPressF1Key
            // 
            resources.ApplyResources(this.labelPressF1Key, "labelPressF1Key");
            this.labelPressF1Key.Name = "labelPressF1Key";
            // 
            // labelMeasuring
            // 
            resources.ApplyResources(this.labelMeasuring, "labelMeasuring");
            this.labelMeasuring.ForeColor = System.Drawing.Color.Red;
            this.labelMeasuring.Name = "labelMeasuring";
            // 
            // labelPositionNo
            // 
            resources.ApplyResources(this.labelPositionNo, "labelPositionNo");
            this.labelPositionNo.Name = "labelPositionNo";
            // 
            // labelSectionNo
            // 
            resources.ApplyResources(this.labelSectionNo, "labelSectionNo");
            this.labelSectionNo.Name = "labelSectionNo";
            // 
            // numTextBoxPointNo
            // 
            this.numTextBoxPointNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxPointNo, "numTextBoxPointNo");
            this.numTextBoxPointNo.Name = "numTextBoxPointNo";
            this.numTextBoxPointNo.ReadOnly = true;
            this.numTextBoxPointNo.TabStop = false;
            this.numTextBoxPointNo.Tag = "";
            // 
            // numTextBoxSectionNo
            // 
            this.numTextBoxSectionNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxSectionNo, "numTextBoxSectionNo");
            this.numTextBoxSectionNo.Name = "numTextBoxSectionNo";
            this.numTextBoxSectionNo.ReadOnly = true;
            this.numTextBoxSectionNo.TabStop = false;
            this.numTextBoxSectionNo.Tag = "";
            // 
            // numTextBoxPlanedSlopeDistance
            // 
            this.numTextBoxPlanedSlopeDistance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxPlanedSlopeDistance, "numTextBoxPlanedSlopeDistance");
            this.numTextBoxPlanedSlopeDistance.Name = "numTextBoxPlanedSlopeDistance";
            this.numTextBoxPlanedSlopeDistance.ReadOnly = true;
            this.numTextBoxPlanedSlopeDistance.TabStop = false;
            this.numTextBoxPlanedSlopeDistance.Tag = "{0,7:##0.000}";
            // 
            // numTextBoxPlanedVarAngle
            // 
            this.numTextBoxPlanedVarAngle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxPlanedVarAngle, "numTextBoxPlanedVarAngle");
            this.numTextBoxPlanedVarAngle.Name = "numTextBoxPlanedVarAngle";
            this.numTextBoxPlanedVarAngle.ReadOnly = true;
            this.numTextBoxPlanedVarAngle.TabStop = false;
            this.numTextBoxPlanedVarAngle.Tag = "{0,8:##0.0000}";
            // 
            // numTextBoxPlanedHorAngle
            // 
            this.numTextBoxPlanedHorAngle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxPlanedHorAngle, "numTextBoxPlanedHorAngle");
            this.numTextBoxPlanedHorAngle.Name = "numTextBoxPlanedHorAngle";
            this.numTextBoxPlanedHorAngle.ReadOnly = true;
            this.numTextBoxPlanedHorAngle.TabStop = false;
            this.numTextBoxPlanedHorAngle.Tag = "{0,8:##0.0000}";
            // 
            // numTextBoxSlopeDistance
            // 
            this.numTextBoxSlopeDistance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxSlopeDistance, "numTextBoxSlopeDistance");
            this.numTextBoxSlopeDistance.Name = "numTextBoxSlopeDistance";
            this.numTextBoxSlopeDistance.ReadOnly = true;
            this.numTextBoxSlopeDistance.TabStop = false;
            this.numTextBoxSlopeDistance.Tag = "{0,7:##0.000}";
            // 
            // numTextBoxVarAngle
            // 
            this.numTextBoxVarAngle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxVarAngle, "numTextBoxVarAngle");
            this.numTextBoxVarAngle.Name = "numTextBoxVarAngle";
            this.numTextBoxVarAngle.ReadOnly = true;
            this.numTextBoxVarAngle.TabStop = false;
            this.numTextBoxVarAngle.Tag = "{0,8:##0.0000}";
            // 
            // numTextBoxHorAngle
            // 
            this.numTextBoxHorAngle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            resources.ApplyResources(this.numTextBoxHorAngle, "numTextBoxHorAngle");
            this.numTextBoxHorAngle.Name = "numTextBoxHorAngle";
            this.numTextBoxHorAngle.ReadOnly = true;
            this.numTextBoxHorAngle.TabStop = false;
            this.numTextBoxHorAngle.Tag = "{0,8:##0.0000}";
            // 
            // EodrMeasurementForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Controls.Add(this.labelPositionNo);
            this.Controls.Add(this.labelSectionNo);
            this.Controls.Add(this.numTextBoxPointNo);
            this.Controls.Add(this.numTextBoxSectionNo);
            this.Controls.Add(this.labelMeasuring);
            this.Controls.Add(this.labelPressF1Key);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMeasurent);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.labelPlanedMeasurementPoint);
            this.Controls.Add(this.numTextBoxPlanedSlopeDistance);
            this.Controls.Add(this.numTextBoxPlanedVarAngle);
            this.Controls.Add(this.numTextBoxPlanedHorAngle);
            this.Controls.Add(this.labelMeasurementResults);
            this.Controls.Add(this.numTextBoxSlopeDistance);
            this.Controls.Add(this.numTextBoxVarAngle);
            this.Controls.Add(this.numTextBoxHorAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "EodrMeasurementForm";
            this.Load += new System.EventHandler(this.EodrMeasurementForm_Load);
            this.Shown += new System.EventHandler(this.EodrMeasurementForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EodrMeasurementForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EodrMeasurementForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private NumTextBox numTextBoxHorAngle;
        private NumTextBox numTextBoxVarAngle;
        private NumTextBox numTextBoxSlopeDistance;
        private System.Windows.Forms.Label labelMeasurementResults;
        private System.Windows.Forms.Label labelPlanedMeasurementPoint;
        private NumTextBox numTextBoxPlanedSlopeDistance;
        private NumTextBox numTextBoxPlanedVarAngle;
        private NumTextBox numTextBoxPlanedHorAngle;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonMeasurent;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelPressF1Key;
        private System.Windows.Forms.Label labelMeasuring;
        private NumTextBox numTextBoxPointNo;
        private NumTextBox numTextBoxSectionNo;
        private System.Windows.Forms.Label labelPositionNo;
        private System.Windows.Forms.Label labelSectionNo;
    }
}