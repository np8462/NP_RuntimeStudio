namespace NP.Host
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAIChat = new System.Windows.Forms.TabPage();
            this.tabJsonViewer = new System.Windows.Forms.TabPage();
            this.tabRuntimeConsole = new System.Windows.Forms.TabPage();
            this.tabCommandViewer = new System.Windows.Forms.TabPage();
            this.tabPluginExplorer = new System.Windows.Forms.TabPage();
            this.tabChromeExtension = new System.Windows.Forms.TabPage();
            this.tabVS2012Addin = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabRuntimeStudio = new System.Windows.Forms.TabPage();
            this.tabRuntimeWorkspace = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRuntimeWorkspace);
            this.tabControl1.Controls.Add(this.tabAIChat);
            this.tabControl1.Controls.Add(this.tabJsonViewer);
            this.tabControl1.Controls.Add(this.tabRuntimeConsole);
            this.tabControl1.Controls.Add(this.tabCommandViewer);
            this.tabControl1.Controls.Add(this.tabPluginExplorer);
            this.tabControl1.Controls.Add(this.tabChromeExtension);
            this.tabControl1.Controls.Add(this.tabVS2012Addin);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabRuntimeStudio);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 531);
            this.tabControl1.TabIndex = 4;
            // 
            // tabAIChat
            // 
            this.tabAIChat.Location = new System.Drawing.Point(4, 22);
            this.tabAIChat.Name = "tabAIChat";
            this.tabAIChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabAIChat.Size = new System.Drawing.Size(890, 505);
            this.tabAIChat.TabIndex = 3;
            this.tabAIChat.Text = "AI Chat";
            this.tabAIChat.UseVisualStyleBackColor = true;
            // 
            // tabJsonViewer
            // 
            this.tabJsonViewer.Location = new System.Drawing.Point(4, 22);
            this.tabJsonViewer.Name = "tabJsonViewer";
            this.tabJsonViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabJsonViewer.Size = new System.Drawing.Size(890, 505);
            this.tabJsonViewer.TabIndex = 0;
            this.tabJsonViewer.Text = "Json Viewer";
            this.tabJsonViewer.UseVisualStyleBackColor = true;
            // 
            // tabRuntimeConsole
            // 
            this.tabRuntimeConsole.Location = new System.Drawing.Point(4, 22);
            this.tabRuntimeConsole.Name = "tabRuntimeConsole";
            this.tabRuntimeConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabRuntimeConsole.Size = new System.Drawing.Size(890, 505);
            this.tabRuntimeConsole.TabIndex = 1;
            this.tabRuntimeConsole.Text = "Runtime Console";
            this.tabRuntimeConsole.UseVisualStyleBackColor = true;
            // 
            // tabCommandViewer
            // 
            this.tabCommandViewer.Location = new System.Drawing.Point(4, 22);
            this.tabCommandViewer.Name = "tabCommandViewer";
            this.tabCommandViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommandViewer.Size = new System.Drawing.Size(890, 505);
            this.tabCommandViewer.TabIndex = 2;
            this.tabCommandViewer.Text = "Command Viewer";
            this.tabCommandViewer.UseVisualStyleBackColor = true;
            // 
            // tabPluginExplorer
            // 
            this.tabPluginExplorer.Location = new System.Drawing.Point(4, 22);
            this.tabPluginExplorer.Name = "tabPluginExplorer";
            this.tabPluginExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPluginExplorer.Size = new System.Drawing.Size(890, 505);
            this.tabPluginExplorer.TabIndex = 4;
            this.tabPluginExplorer.Text = "Plugin Explorer";
            this.tabPluginExplorer.UseVisualStyleBackColor = true;
            // 
            // tabChromeExtension
            // 
            this.tabChromeExtension.Location = new System.Drawing.Point(4, 22);
            this.tabChromeExtension.Name = "tabChromeExtension";
            this.tabChromeExtension.Size = new System.Drawing.Size(890, 505);
            this.tabChromeExtension.TabIndex = 7;
            this.tabChromeExtension.Text = "Chrome Extension";
            this.tabChromeExtension.UseVisualStyleBackColor = true;
            // 
            // tabVS2012Addin
            // 
            this.tabVS2012Addin.Location = new System.Drawing.Point(4, 22);
            this.tabVS2012Addin.Name = "tabVS2012Addin";
            this.tabVS2012Addin.Size = new System.Drawing.Size(890, 505);
            this.tabVS2012Addin.TabIndex = 8;
            this.tabVS2012Addin.Text = "VS2012 Addin";
            this.tabVS2012Addin.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(890, 505);
            this.tabSettings.TabIndex = 5;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tabRuntimeStudio
            // 
            this.tabRuntimeStudio.Location = new System.Drawing.Point(4, 22);
            this.tabRuntimeStudio.Name = "tabRuntimeStudio";
            this.tabRuntimeStudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabRuntimeStudio.Size = new System.Drawing.Size(890, 505);
            this.tabRuntimeStudio.TabIndex = 6;
            this.tabRuntimeStudio.Text = "Runtime Studio";
            this.tabRuntimeStudio.UseVisualStyleBackColor = true;
            // 
            // tabRuntimeWorkspace
            // 
            this.tabRuntimeWorkspace.Location = new System.Drawing.Point(4, 22);
            this.tabRuntimeWorkspace.Name = "tabRuntimeWorkspace";
            this.tabRuntimeWorkspace.Padding = new System.Windows.Forms.Padding(3);
            this.tabRuntimeWorkspace.Size = new System.Drawing.Size(890, 505);
            this.tabRuntimeWorkspace.TabIndex = 9;
            this.tabRuntimeWorkspace.Text = "Runtime Workspace";
            this.tabRuntimeWorkspace.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 531);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabJsonViewer;
        private System.Windows.Forms.TabPage tabRuntimeConsole;
        private System.Windows.Forms.TabPage tabCommandViewer;
        private System.Windows.Forms.TabPage tabAIChat;
        private System.Windows.Forms.TabPage tabPluginExplorer;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabRuntimeStudio;
        private System.Windows.Forms.TabPage tabChromeExtension;
        private System.Windows.Forms.TabPage tabVS2012Addin;
        private System.Windows.Forms.TabPage tabRuntimeWorkspace;
    }
}