namespace NP.UI.Controls.Settings
{
    partial class ChromeSettingsControl
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
            this.chkEnableChromeBridge = new System.Windows.Forms.CheckBox();
            this.chkAutoConnect = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkEnableChromeBridge
            // 
            this.chkEnableChromeBridge.AutoSize = true;
            this.chkEnableChromeBridge.Location = new System.Drawing.Point(3, 3);
            this.chkEnableChromeBridge.Name = "chkEnableChromeBridge";
            this.chkEnableChromeBridge.Size = new System.Drawing.Size(131, 17);
            this.chkEnableChromeBridge.TabIndex = 0;
            this.chkEnableChromeBridge.Text = "Enable Chrome Bridge";
            this.chkEnableChromeBridge.UseVisualStyleBackColor = true;
            // 
            // chkAutoConnect
            // 
            this.chkAutoConnect.AutoSize = true;
            this.chkAutoConnect.Location = new System.Drawing.Point(3, 26);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Size = new System.Drawing.Size(91, 17);
            this.chkAutoConnect.TabIndex = 1;
            this.chkAutoConnect.Text = "Auto Connect";
            this.chkAutoConnect.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(34, 43);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8080";
            // 
            // ChromeSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAutoConnect);
            this.Controls.Add(this.chkEnableChromeBridge);
            this.Name = "ChromeSettingsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnableChromeBridge;
        private System.Windows.Forms.CheckBox chkAutoConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
    }
}
