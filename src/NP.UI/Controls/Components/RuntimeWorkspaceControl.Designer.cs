namespace NP.UI.Controls.Components
{
    partial class RuntimeWorkspaceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuntimeWorkspaceControl));
            this.toolStripRuntime = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.groupBoxProject = new System.Windows.Forms.GroupBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBuildFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBuildFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripRuntime.SuspendLayout();
            this.groupBoxProject.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripRuntime
            // 
            this.toolStripRuntime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBrowse,
            this.toolStripSeparator,
            this.toolStripButtonBuildFile,
            this.toolStripButtonBuildFolder,
            this.toolStripSeparator1,
            this.toolStripButtonClose});
            this.toolStripRuntime.Location = new System.Drawing.Point(0, 0);
            this.toolStripRuntime.Name = "toolStripRuntime";
            this.toolStripRuntime.Size = new System.Drawing.Size(702, 25);
            this.toolStripRuntime.TabIndex = 0;
            this.toolStripRuntime.Text = "toolStrip1";
            // 
            // toolStripButtonBrowse
            // 
            this.toolStripButtonBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBrowse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBrowse.Image")));
            this.toolStripButtonBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBrowse.Name = "toolStripButtonBrowse";
            this.toolStripButtonBrowse.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBrowse.Text = "Browse";
            this.toolStripButtonBrowse.Click += new System.EventHandler(this.toolStripButtonBrowse_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // groupBoxProject
            // 
            this.groupBoxProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProject.Controls.Add(this.txtFolder);
            this.groupBoxProject.Location = new System.Drawing.Point(3, 28);
            this.groupBoxProject.Name = "groupBoxProject";
            this.groupBoxProject.Size = new System.Drawing.Size(696, 51);
            this.groupBoxProject.TabIndex = 1;
            this.groupBoxProject.TabStop = false;
            this.groupBoxProject.Text = "Project";
            // 
            // txtFolder
            // 
            this.txtFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolder.Location = new System.Drawing.Point(3, 16);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(690, 20);
            this.txtFolder.TabIndex = 0;
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLog.Controls.Add(this.listBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(3, 85);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(696, 330);
            this.groupBoxLog.TabIndex = 2;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 16);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(690, 311);
            this.listBoxLog.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonBuildFile
            // 
            this.toolStripButtonBuildFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBuildFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBuildFile.Image")));
            this.toolStripButtonBuildFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBuildFile.Name = "toolStripButtonBuildFile";
            this.toolStripButtonBuildFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBuildFile.Text = "Build File";
            this.toolStripButtonBuildFile.Click += new System.EventHandler(this.toolStripButtonBuildFile_Click);
            // 
            // toolStripButtonBuildFolder
            // 
            this.toolStripButtonBuildFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBuildFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBuildFolder.Image")));
            this.toolStripButtonBuildFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBuildFolder.Name = "toolStripButtonBuildFolder";
            this.toolStripButtonBuildFolder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBuildFolder.Text = "Build Folder";
            this.toolStripButtonBuildFolder.Click += new System.EventHandler(this.toolStripButtonBuildFolder_Click);
            // 
            // RuntimeWorkspaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxProject);
            this.Controls.Add(this.toolStripRuntime);
            this.Name = "RuntimeWorkspaceControl";
            this.Size = new System.Drawing.Size(702, 418);
            this.toolStripRuntime.ResumeLayout(false);
            this.toolStripRuntime.PerformLayout();
            this.groupBoxProject.ResumeLayout(false);
            this.groupBoxProject.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripRuntime;
        private System.Windows.Forms.ToolStripButton toolStripButtonBrowse;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.GroupBox groupBoxProject;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuildFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuildFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}
