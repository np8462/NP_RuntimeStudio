namespace NP.UI.Controls.Settings
{
    partial class SettingsControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAI = new System.Windows.Forms.TabPage();
            this.tabRuntime = new System.Windows.Forms.TabPage();
            this.tabTheme = new System.Windows.Forms.TabPage();
            this.tabChrome = new System.Windows.Forms.TabPage();
            this.tabVS2012 = new System.Windows.Forms.TabPage();
            this.tabJsonViewer = new System.Windows.Forms.TabPage();
            this.tabLogger = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAI);
            this.tabControl1.Controls.Add(this.tabRuntime);
            this.tabControl1.Controls.Add(this.tabTheme);
            this.tabControl1.Controls.Add(this.tabChrome);
            this.tabControl1.Controls.Add(this.tabVS2012);
            this.tabControl1.Controls.Add(this.tabJsonViewer);
            this.tabControl1.Controls.Add(this.tabLogger);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAI
            // 
            this.tabAI.Location = new System.Drawing.Point(4, 22);
            this.tabAI.Name = "tabAI";
            this.tabAI.Padding = new System.Windows.Forms.Padding(3);
            this.tabAI.Size = new System.Drawing.Size(433, 352);
            this.tabAI.TabIndex = 0;
            this.tabAI.Text = "AI";
            this.tabAI.UseVisualStyleBackColor = true;
            // 
            // tabRuntime
            // 
            this.tabRuntime.Location = new System.Drawing.Point(4, 22);
            this.tabRuntime.Name = "tabRuntime";
            this.tabRuntime.Padding = new System.Windows.Forms.Padding(3);
            this.tabRuntime.Size = new System.Drawing.Size(665, 352);
            this.tabRuntime.TabIndex = 1;
            this.tabRuntime.Text = "Runtime";
            this.tabRuntime.UseVisualStyleBackColor = true;
            // 
            // tabTheme
            // 
            this.tabTheme.Location = new System.Drawing.Point(4, 22);
            this.tabTheme.Name = "tabTheme";
            this.tabTheme.Size = new System.Drawing.Size(665, 352);
            this.tabTheme.TabIndex = 2;
            this.tabTheme.Text = "Theme";
            this.tabTheme.UseVisualStyleBackColor = true;
            // 
            // tabChrome
            // 
            this.tabChrome.Location = new System.Drawing.Point(4, 22);
            this.tabChrome.Name = "tabChrome";
            this.tabChrome.Size = new System.Drawing.Size(665, 352);
            this.tabChrome.TabIndex = 3;
            this.tabChrome.Text = "Chrome";
            this.tabChrome.UseVisualStyleBackColor = true;
            // 
            // tabVS2012
            // 
            this.tabVS2012.Location = new System.Drawing.Point(4, 22);
            this.tabVS2012.Name = "tabVS2012";
            this.tabVS2012.Size = new System.Drawing.Size(665, 352);
            this.tabVS2012.TabIndex = 4;
            this.tabVS2012.Text = "VS2012";
            this.tabVS2012.UseVisualStyleBackColor = true;
            // 
            // tabJsonViewer
            // 
            this.tabJsonViewer.Location = new System.Drawing.Point(4, 22);
            this.tabJsonViewer.Name = "tabJsonViewer";
            this.tabJsonViewer.Size = new System.Drawing.Size(665, 352);
            this.tabJsonViewer.TabIndex = 5;
            this.tabJsonViewer.Text = "JsonViewer";
            this.tabJsonViewer.UseVisualStyleBackColor = true;
            // 
            // tabLogger
            // 
            this.tabLogger.Location = new System.Drawing.Point(4, 22);
            this.tabLogger.Name = "tabLogger";
            this.tabLogger.Size = new System.Drawing.Size(665, 352);
            this.tabLogger.TabIndex = 6;
            this.tabLogger.Text = "Logger";
            this.tabLogger.UseVisualStyleBackColor = true;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(441, 378);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAI;
        private System.Windows.Forms.TabPage tabRuntime;
        private System.Windows.Forms.TabPage tabTheme;
        private System.Windows.Forms.TabPage tabChrome;
        private System.Windows.Forms.TabPage tabVS2012;
        private System.Windows.Forms.TabPage tabJsonViewer;
        private System.Windows.Forms.TabPage tabLogger;
    }
}
