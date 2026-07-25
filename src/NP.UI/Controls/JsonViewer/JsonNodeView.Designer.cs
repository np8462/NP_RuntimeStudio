namespace NP.UI.Controls.JsonViewer
{
    partial class JsonNodeView
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
            this.richTextBoxJson = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxJson
            // 
            this.richTextBoxJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxJson.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxJson.Name = "richTextBoxJson";
            this.richTextBoxJson.Size = new System.Drawing.Size(150, 150);
            this.richTextBoxJson.TabIndex = 0;
            this.richTextBoxJson.Text = "";
            // 
            // JsonNodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxJson);
            this.Name = "JsonNodeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxJson;


    }
}
