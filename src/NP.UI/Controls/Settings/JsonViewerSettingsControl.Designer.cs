namespace NP.UI.Controls.Settings
{
    partial class JsonViewerSettingsControl
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
            this.chkWordWrap = new System.Windows.Forms.CheckBox();
            this.chkHighlightSearch = new System.Windows.Forms.CheckBox();
            this.chkExpandTree = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkWordWrap
            // 
            this.chkWordWrap.AutoSize = true;
            this.chkWordWrap.Location = new System.Drawing.Point(3, 49);
            this.chkWordWrap.Name = "chkWordWrap";
            this.chkWordWrap.Size = new System.Drawing.Size(81, 17);
            this.chkWordWrap.TabIndex = 8;
            this.chkWordWrap.Text = "Word Wrap";
            this.chkWordWrap.UseVisualStyleBackColor = true;
            // 
            // chkHighlightSearch
            // 
            this.chkHighlightSearch.AutoSize = true;
            this.chkHighlightSearch.Location = new System.Drawing.Point(3, 26);
            this.chkHighlightSearch.Name = "chkHighlightSearch";
            this.chkHighlightSearch.Size = new System.Drawing.Size(104, 17);
            this.chkHighlightSearch.TabIndex = 7;
            this.chkHighlightSearch.Text = "Highlight Search";
            this.chkHighlightSearch.UseVisualStyleBackColor = true;
            // 
            // chkExpandTree
            // 
            this.chkExpandTree.AutoSize = true;
            this.chkExpandTree.Location = new System.Drawing.Point(3, 3);
            this.chkExpandTree.Name = "chkExpandTree";
            this.chkExpandTree.Size = new System.Drawing.Size(87, 17);
            this.chkExpandTree.TabIndex = 6;
            this.chkExpandTree.Text = "Expand Tree";
            this.chkExpandTree.UseVisualStyleBackColor = true;
            // 
            // JsonViewerSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkWordWrap);
            this.Controls.Add(this.chkHighlightSearch);
            this.Controls.Add(this.chkExpandTree);
            this.Name = "JsonViewerSettingsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWordWrap;
        private System.Windows.Forms.CheckBox chkHighlightSearch;
        private System.Windows.Forms.CheckBox chkExpandTree;
    }
}
