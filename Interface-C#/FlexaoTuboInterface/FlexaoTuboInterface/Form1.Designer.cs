namespace FlexaoTuboInterface
{
    partial class Form1
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonCalibrate = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelReference = new System.Windows.Forms.Label();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.labelFlexion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(239, 27);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(188, 58);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Conectar";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click_1);
            // 
            // buttonCalibrate
            // 
            this.buttonCalibrate.Location = new System.Drawing.Point(83, 370);
            this.buttonCalibrate.Name = "buttonCalibrate";
            this.buttonCalibrate.Size = new System.Drawing.Size(183, 56);
            this.buttonCalibrate.TabIndex = 1;
            this.buttonCalibrate.Text = "Calibrar";
            this.buttonCalibrate.UseVisualStyleBackColor = true;
            this.buttonCalibrate.Click += new System.EventHandler(this.buttonCalibrate_Click_1);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(469, 45);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(96, 16);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Desconectado";
            // 
            // labelReference
            // 
            this.labelReference.AutoSize = true;
            this.labelReference.Location = new System.Drawing.Point(294, 370);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(103, 16);
            this.labelReference.TabIndex = 3;
            this.labelReference.Text = "Referência: N/D";
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(31, 45);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(179, 24);
            this.comboBoxCOM.TabIndex = 4;
            this.comboBoxCOM.Text = "Selecione a porta COM";
            // 
            // labelFlexion
            // 
            this.labelFlexion.AutoSize = true;
            this.labelFlexion.Location = new System.Drawing.Point(264, 185);
            this.labelFlexion.Name = "labelFlexion";
            this.labelFlexion.Size = new System.Drawing.Size(162, 16);
            this.labelFlexion.TabIndex = 5;
            this.labelFlexion.Text = "Current Flexion: 0.00 graus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelFlexion);
            this.Controls.Add(this.comboBoxCOM);
            this.Controls.Add(this.labelReference);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonCalibrate);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonCalibrate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelReference;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.Label labelFlexion;
    }
}

