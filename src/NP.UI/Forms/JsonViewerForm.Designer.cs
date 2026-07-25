namespace NP.UI.Forms
{
    partial class JsonViewerForm
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
            this.richTextBoxJsonRaw = new System.Windows.Forms.RichTextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jsonTreeView1 = new NP.UI.Controls.JsonViewer.JsonTreeView();
            this.jsonNodeView1 = new NP.UI.Controls.JsonViewer.JsonNodeView();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lnklblFilePath = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxJsonRaw
            // 
            this.richTextBoxJsonRaw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxJsonRaw.Location = new System.Drawing.Point(12, 151);
            this.richTextBoxJsonRaw.Name = "richTextBoxJsonRaw";
            this.richTextBoxJsonRaw.Size = new System.Drawing.Size(443, 242);
            this.richTextBoxJsonRaw.TabIndex = 0;
            this.richTextBoxJsonRaw.Text = "";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(196, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(467, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.jsonTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.jsonNodeView1);
            this.splitContainer1.Size = new System.Drawing.Size(443, 88);
            this.splitContainer1.SplitterDistance = 166;
            this.splitContainer1.TabIndex = 3;
            // 
            // jsonTreeView1
            // 
            this.jsonTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTreeView1.Location = new System.Drawing.Point(0, 0);
            this.jsonTreeView1.Name = "jsonTreeView1";
            this.jsonTreeView1.Size = new System.Drawing.Size(166, 88);
            this.jsonTreeView1.TabIndex = 4;
            this.jsonTreeView1.NodeChanged += new System.Action<NP.UI.Controls.JsonViewer.JsonNodeEventArgs>(this.JsonTreeView1_NodeChanged);
            // 
            // jsonNodeView1
            // 
            this.jsonNodeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonNodeView1.BackColor = System.Drawing.SystemColors.Control;
            this.jsonNodeView1.JsonText = "";
            this.jsonNodeView1.Location = new System.Drawing.Point(2, 3);
            this.jsonNodeView1.Name = "jsonNodeView1";
            this.jsonNodeView1.Size = new System.Drawing.Size(268, 82);
            this.jsonNodeView1.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(214, 31);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(241, 20);
            this.txtPath.TabIndex = 4;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(397, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(58, 23);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lnklblFilePath
            // 
            this.lnklblFilePath.Location = new System.Drawing.Point(12, 2);
            this.lnklblFilePath.Name = "lnklblFilePath";
            this.lnklblFilePath.Size = new System.Drawing.Size(379, 23);
            this.lnklblFilePath.TabIndex = 8;
            // 
            // JsonViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 418);
            this.Controls.Add(this.lnklblFilePath);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.richTextBoxJsonRaw);
            this.Name = "JsonViewerForm";
            this.Text = "JsonViewerForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxJsonRaw;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.JsonViewer.JsonNodeView jsonNodeView1;
        private Controls.JsonViewer.JsonTreeView jsonTreeView1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.LinkLabel lnklblFilePath;
    }
}