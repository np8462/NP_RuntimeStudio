namespace NP.UI.Controls.Settings
{
    partial class VsSettingsControl
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
            this.chkAutoConnectVs = new System.Windows.Forms.CheckBox();
            this.chkShowNotifications = new System.Windows.Forms.CheckBox();
            this.chkEnableVsAddin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkAutoConnectVs
            // 
            this.chkAutoConnectVs.AutoSize = true;
            this.chkAutoConnectVs.Location = new System.Drawing.Point(3, 49);
            this.chkAutoConnectVs.Name = "chkAutoConnectVs";
            this.chkAutoConnectVs.Size = new System.Drawing.Size(135, 17);
            this.chkAutoConnectVs.TabIndex = 5;
            this.chkAutoConnectVs.Text = "Auto Connect VS-2012";
            this.chkAutoConnectVs.UseVisualStyleBackColor = true;
            // 
            // chkShowNotifications
            // 
            this.chkShowNotifications.AutoSize = true;
            this.chkShowNotifications.Location = new System.Drawing.Point(3, 26);
            this.chkShowNotifications.Name = "chkShowNotifications";
            this.chkShowNotifications.Size = new System.Drawing.Size(114, 17);
            this.chkShowNotifications.TabIndex = 4;
            this.chkShowNotifications.Text = "Show Notifications";
            this.chkShowNotifications.UseVisualStyleBackColor = true;
            // 
            // chkEnableVsAddin
            // 
            this.chkEnableVsAddin.AutoSize = true;
            this.chkEnableVsAddin.Location = new System.Drawing.Point(3, 3);
            this.chkEnableVsAddin.Name = "chkEnableVsAddin";
            this.chkEnableVsAddin.Size = new System.Drawing.Size(106, 17);
            this.chkEnableVsAddin.TabIndex = 3;
            this.chkEnableVsAddin.Text = "Enable VS-Addin";
            this.chkEnableVsAddin.UseVisualStyleBackColor = true;
            // 
            // VsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAutoConnectVs);
            this.Controls.Add(this.chkShowNotifications);
            this.Controls.Add(this.chkEnableVsAddin);
            this.Name = "VsSettingsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoConnectVs;
        private System.Windows.Forms.CheckBox chkShowNotifications;
        private System.Windows.Forms.CheckBox chkEnableVsAddin;
    }
}
