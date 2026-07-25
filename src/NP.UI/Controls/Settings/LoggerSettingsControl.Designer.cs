namespace NP.UI.Controls.Settings
{
    partial class LoggerSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoConnect = new System.Windows.Forms.CheckBox();
            this.chkShowTime = new System.Windows.Forms.CheckBox();
            this.numMaxLines = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Max Lines :";
            // 
            // chkAutoConnect
            // 
            this.chkAutoConnect.AutoSize = true;
            this.chkAutoConnect.Location = new System.Drawing.Point(3, 26);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Size = new System.Drawing.Size(142, 17);
            this.chkAutoConnect.TabIndex = 5;
            this.chkAutoConnect.Text = "Enable Runtime Console";
            this.chkAutoConnect.UseVisualStyleBackColor = true;
            // 
            // chkShowTime
            // 
            this.chkShowTime.AutoSize = true;
            this.chkShowTime.Location = new System.Drawing.Point(3, 3);
            this.chkShowTime.Name = "chkShowTime";
            this.chkShowTime.Size = new System.Drawing.Size(79, 17);
            this.chkShowTime.TabIndex = 4;
            this.chkShowTime.Text = "Show Time";
            this.chkShowTime.UseVisualStyleBackColor = true;
            // 
            // numMaxLines
            // 
            this.numMaxLines.Location = new System.Drawing.Point(70, 44);
            this.numMaxLines.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxLines.Name = "numMaxLines";
            this.numMaxLines.Size = new System.Drawing.Size(46, 20);
            this.numMaxLines.TabIndex = 7;
            this.numMaxLines.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // LoggerSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numMaxLines);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAutoConnect);
            this.Controls.Add(this.chkShowTime);
            this.Name = "LoggerSettingsControl";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoConnect;
        private System.Windows.Forms.CheckBox chkShowTime;
        private System.Windows.Forms.NumericUpDown numMaxLines;
    }
}
