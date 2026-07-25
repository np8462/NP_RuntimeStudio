namespace NP.UI.Controls.Settings
{
    partial class ThemeSettingsControl
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
            this.radioLight = new System.Windows.Forms.RadioButton();
            this.radioDark = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioLight
            // 
            this.radioLight.AutoSize = true;
            this.radioLight.Location = new System.Drawing.Point(3, 3);
            this.radioLight.Name = "radioLight";
            this.radioLight.Size = new System.Drawing.Size(48, 17);
            this.radioLight.TabIndex = 0;
            this.radioLight.TabStop = true;
            this.radioLight.Text = "Light";
            this.radioLight.UseVisualStyleBackColor = true;
            // 
            // radioDark
            // 
            this.radioDark.AutoSize = true;
            this.radioDark.Location = new System.Drawing.Point(3, 26);
            this.radioDark.Name = "radioDark";
            this.radioDark.Size = new System.Drawing.Size(48, 17);
            this.radioDark.TabIndex = 1;
            this.radioDark.TabStop = true;
            this.radioDark.Text = "Dark";
            this.radioDark.UseVisualStyleBackColor = true;
            // 
            // ThemeSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioDark);
            this.Controls.Add(this.radioLight);
            this.Name = "ThemeSettingsControl";
            this.Size = new System.Drawing.Size(112, 109);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioLight;
        private System.Windows.Forms.RadioButton radioDark;
    }
}
