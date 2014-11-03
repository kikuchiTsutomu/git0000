namespace EodrLngMembrane
{
    partial class EodrLngMembraneCaltureForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCalture = new System.Windows.Forms.ComboBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCalture
            // 
            this.comboBoxCalture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalture.FormattingEnabled = true;
            this.comboBoxCalture.Items.AddRange(new object[] {
            "日本語",
            "English"});
            this.comboBoxCalture.Location = new System.Drawing.Point(52, 44);
            this.comboBoxCalture.Name = "comboBoxCalture";
            this.comboBoxCalture.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCalture.TabIndex = 0;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(265, 44);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = ">>GO";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // EodrLngMembraneCaltureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(418, 103);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.comboBoxCalture);
            this.KeyPreview = true;
            this.Name = "EodrLngMembraneCaltureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EODR LNG MembraneType Tank measuremento System Calture";
            this.Load += new System.EventHandler(this.EodrLngMembraneCaltureForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EodrLngMembraneCaltureForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EodrLngMembraneCaltureForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCalture;
        private System.Windows.Forms.Button buttonGo;
    }
}

