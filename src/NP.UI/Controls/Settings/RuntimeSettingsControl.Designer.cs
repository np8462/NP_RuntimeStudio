namespace NP.UI.Controls.Settings
{
    partial class RuntimeSettingsControl
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
            this.chkAutoStartRuntime = new System.Windows.Forms.CheckBox();
            this.chkVerboseMode = new System.Windows.Forms.CheckBox();
            this.chkEnableLogger = new System.Windows.Forms.CheckBox();
            this.numMaxCommands = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCommands)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAutoStartRuntime
            // 
            this.chkAutoStartRuntime.AutoSize = true;
            this.chkAutoStartRuntime.Location = new System.Drawing.Point(3, 3);
            this.chkAutoStartRuntime.Name = "chkAutoStartRuntime";
            this.chkAutoStartRuntime.Size = new System.Drawing.Size(115, 17);
            this.chkAutoStartRuntime.TabIndex = 0;
            this.chkAutoStartRuntime.Text = "Auto Start Runtime";
            this.chkAutoStartRuntime.UseVisualStyleBackColor = true;
            // 
            // chkVerboseMode
            // 
            this.chkVerboseMode.AutoSize = true;
            this.chkVerboseMode.Location = new System.Drawing.Point(3, 26);
            this.chkVerboseMode.Name = "chkVerboseMode";
            this.chkVerboseMode.Size = new System.Drawing.Size(95, 17);
            this.chkVerboseMode.TabIndex = 1;
            this.chkVerboseMode.Text = "Verbose Mode";
            this.chkVerboseMode.UseVisualStyleBackColor = true;
            // 
            // chkEnableLogger
            // 
            this.chkEnableLogger.AutoSize = true;
            this.chkEnableLogger.Location = new System.Drawing.Point(3, 49);
            this.chkEnableLogger.Name = "chkEnableLogger";
            this.chkEnableLogger.Size = new System.Drawing.Size(95, 17);
            this.chkEnableLogger.TabIndex = 2;
            this.chkEnableLogger.Text = "Enable Logger";
            this.chkEnableLogger.UseVisualStyleBackColor = true;
            // 
            // numMaxCommands
            // 
            this.numMaxCommands.Location = new System.Drawing.Point(94, 72);
            this.numMaxCommands.Name = "numMaxCommands";
            this.numMaxCommands.Size = new System.Drawing.Size(46, 20);
            this.numMaxCommands.TabIndex = 3;
            this.numMaxCommands.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Max Commands:";
            // 
            // RuntimeSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMaxCommands);
            this.Controls.Add(this.chkEnableLogger);
            this.Controls.Add(this.chkVerboseMode);
            this.Controls.Add(this.chkAutoStartRuntime);
            this.Name = "RuntimeSettingsControl";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCommands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoStartRuntime;
        private System.Windows.Forms.CheckBox chkVerboseMode;
        private System.Windows.Forms.CheckBox chkEnableLogger;
        private System.Windows.Forms.NumericUpDown numMaxCommands;
        private System.Windows.Forms.Label label1;
    }
}
