namespace NP.UI.Controls.RuntimeStudio
{
    partial class RuntimeStudioControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuntimeStudioControl));
            this.groupBoxRuntime = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxModules = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTest = new System.Windows.Forms.ToolStripButton();
            this.lblPluginCount = new System.Windows.Forms.Label();
            this.lblCommandCount = new System.Windows.Forms.Label();
            this.lblLogCount = new System.Windows.Forms.Label();
            this.lblChromeState = new System.Windows.Forms.Label();
            this.lblAiState = new System.Windows.Forms.Label();
            this.lblRuntimeState = new System.Windows.Forms.Label();
            this.lblVsState = new System.Windows.Forms.Label();
            this.groupBoxRuntime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRuntime
            // 
            this.groupBoxRuntime.Controls.Add(this.lblVsState);
            this.groupBoxRuntime.Controls.Add(this.lblChromeState);
            this.groupBoxRuntime.Controls.Add(this.lblRuntimeState);
            this.groupBoxRuntime.Controls.Add(this.lblAiState);
            this.groupBoxRuntime.Location = new System.Drawing.Point(3, 28);
            this.groupBoxRuntime.Name = "groupBoxRuntime";
            this.groupBoxRuntime.Size = new System.Drawing.Size(200, 116);
            this.groupBoxRuntime.TabIndex = 0;
            this.groupBoxRuntime.TabStop = false;
            this.groupBoxRuntime.Text = "Runtime";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLogCount);
            this.groupBox1.Controls.Add(this.lblCommandCount);
            this.groupBox1.Controls.Add(this.lblPluginCount);
            this.groupBox1.Location = new System.Drawing.Point(3, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // listBoxModules
            // 
            this.listBoxModules.FormattingEnabled = true;
            this.listBoxModules.Items.AddRange(new object[] {
            "JsonViewer",
            "RuntimeConsole",
            "AIChat",
            "CommandViewer",
            "PluginExplorer",
            "ChromeExtension",
            "VS2012Addin"});
            this.listBoxModules.Location = new System.Drawing.Point(209, 38);
            this.listBoxModules.Name = "listBoxModules";
            this.listBoxModules.Size = new System.Drawing.Size(137, 212);
            this.listBoxModules.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripButtonClear,
            this.toolStripButtonTest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(369, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClear.Text = "Clear";
            // 
            // toolStripButtonTest
            // 
            this.toolStripButtonTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTest.Image")));
            this.toolStripButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTest.Name = "toolStripButtonTest";
            this.toolStripButtonTest.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTest.Text = "Test";
            // 
            // lblPluginCount
            // 
            this.lblPluginCount.AutoSize = true;
            this.lblPluginCount.Location = new System.Drawing.Point(16, 26);
            this.lblPluginCount.Name = "lblPluginCount";
            this.lblPluginCount.Size = new System.Drawing.Size(56, 13);
            this.lblPluginCount.TabIndex = 0;
            this.lblPluginCount.Text = "Plugins : 7";
            // 
            // lblCommandCount
            // 
            this.lblCommandCount.AutoSize = true;
            this.lblCommandCount.Location = new System.Drawing.Point(16, 48);
            this.lblCommandCount.Name = "lblCommandCount";
            this.lblCommandCount.Size = new System.Drawing.Size(80, 13);
            this.lblCommandCount.TabIndex = 1;
            this.lblCommandCount.Text = "Commands : 12";
            // 
            // lblLogCount
            // 
            this.lblLogCount.AutoSize = true;
            this.lblLogCount.Location = new System.Drawing.Point(16, 70);
            this.lblLogCount.Name = "lblLogCount";
            this.lblLogCount.Size = new System.Drawing.Size(51, 13);
            this.lblLogCount.TabIndex = 2;
            this.lblLogCount.Text = "Logs : 32";
            // 
            // lblChromeState
            // 
            this.lblChromeState.AutoSize = true;
            this.lblChromeState.Location = new System.Drawing.Point(20, 69);
            this.lblChromeState.Name = "lblChromeState";
            this.lblChromeState.Size = new System.Drawing.Size(104, 13);
            this.lblChromeState.TabIndex = 5;
            this.lblChromeState.Text = "Chrome : Connected";
            // 
            // lblAiState
            // 
            this.lblAiState.AutoSize = true;
            this.lblAiState.Location = new System.Drawing.Point(20, 47);
            this.lblAiState.Name = "lblAiState";
            this.lblAiState.Size = new System.Drawing.Size(57, 13);
            this.lblAiState.TabIndex = 4;
            this.lblAiState.Text = "AI : Ready";
            // 
            // lblRuntimeState
            // 
            this.lblRuntimeState.AutoSize = true;
            this.lblRuntimeState.Location = new System.Drawing.Point(20, 25);
            this.lblRuntimeState.Name = "lblRuntimeState";
            this.lblRuntimeState.Size = new System.Drawing.Size(95, 13);
            this.lblRuntimeState.TabIndex = 3;
            this.lblRuntimeState.Text = "Runtime : Running";
            // 
            // lblVsState
            // 
            this.lblVsState.AutoSize = true;
            this.lblVsState.Location = new System.Drawing.Point(20, 91);
            this.lblVsState.Name = "lblVsState";
            this.lblVsState.Size = new System.Drawing.Size(90, 13);
            this.lblVsState.TabIndex = 6;
            this.lblVsState.Text = "VS2012 : Waiting";
            // 
            // RuntimeStudioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listBoxModules);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxRuntime);
            this.Name = "RuntimeStudioControl";
            this.Size = new System.Drawing.Size(369, 282);
            this.groupBoxRuntime.ResumeLayout(false);
            this.groupBoxRuntime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRuntime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxModules;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripButton toolStripButtonTest;
        private System.Windows.Forms.Label lblLogCount;
        private System.Windows.Forms.Label lblCommandCount;
        private System.Windows.Forms.Label lblPluginCount;
        private System.Windows.Forms.Label lblVsState;
        private System.Windows.Forms.Label lblChromeState;
        private System.Windows.Forms.Label lblRuntimeState;
        private System.Windows.Forms.Label lblAiState;
    }
}
