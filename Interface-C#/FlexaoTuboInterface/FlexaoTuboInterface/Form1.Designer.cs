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
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.buttonSetLength = new System.Windows.Forms.Button();
            this.textBoxTubeLength = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(197, 3);
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
            this.labelStatus.Location = new System.Drawing.Point(403, 24);
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
            this.comboBoxCOM.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(179, 24);
            this.comboBoxCOM.TabIndex = 4;
            this.comboBoxCOM.Text = "Selecione a porta COM";
            // 
            // labelFlexion
            // 
            this.labelFlexion.AutoSize = true;
            this.labelFlexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlexion.Location = new System.Drawing.Point(133, 173);
            this.labelFlexion.Name = "labelFlexion";
            this.labelFlexion.Size = new System.Drawing.Size(398, 54);
            this.labelFlexion.TabIndex = 5;
            this.labelFlexion.Text = "Flexão Atual: 0.00";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(731, 248);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(15, 16);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(731, 280);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(16, 16);
            this.labelY.TabIndex = 8;
            this.labelY.Text = "Y";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(731, 312);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(15, 16);
            this.labelZ.TabIndex = 9;
            this.labelZ.Text = "Z";
            // 
            // buttonSetLength
            // 
            this.buttonSetLength.Location = new System.Drawing.Point(197, 80);
            this.buttonSetLength.Name = "buttonSetLength";
            this.buttonSetLength.Size = new System.Drawing.Size(188, 56);
            this.buttonSetLength.TabIndex = 10;
            this.buttonSetLength.Text = "Tubo";
            this.buttonSetLength.UseVisualStyleBackColor = true;
            this.buttonSetLength.Click += new System.EventHandler(this.buttonSetLength_Click);
            // 
            // textBoxTubeLength
            // 
            this.textBoxTubeLength.Location = new System.Drawing.Point(12, 80);
            this.textBoxTubeLength.Name = "textBoxTubeLength";
            this.textBoxTubeLength.Size = new System.Drawing.Size(179, 22);
            this.textBoxTubeLength.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 508);
            this.Controls.Add(this.textBoxTubeLength);
            this.Controls.Add(this.buttonSetLength);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
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
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Button buttonSetLength;
        private System.Windows.Forms.TextBox textBoxTubeLength;
    }
}

