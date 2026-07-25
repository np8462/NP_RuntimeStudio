namespace NP.UI.Controls.JsonViewer
{
    partial class JsonTreeView
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
            this.treeViewJson = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewJson
            // 
            this.treeViewJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewJson.Location = new System.Drawing.Point(0, 0);
            this.treeViewJson.Name = "treeViewJson";
            this.treeViewJson.Size = new System.Drawing.Size(150, 150);
            this.treeViewJson.TabIndex = 0;
            // 
            // JsonTreeView
            // 
            this.Controls.Add(this.treeViewJson);
            this.Name = "JsonTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewJson;

    }
}
