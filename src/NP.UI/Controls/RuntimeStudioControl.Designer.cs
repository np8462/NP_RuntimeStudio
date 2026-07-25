namespace NP.UI.Controls
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMsgType = new System.Windows.Forms.ComboBox();
            this.lstSuggestions = new System.Windows.Forms.ListBox();
            this.pnlAttach = new System.Windows.Forms.Panel();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lnklblAttach = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAiSettings = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.pnlAttach.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChat.Location = new System.Drawing.Point(12, 127);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(260, 122);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 33);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(260, 51);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(197, 90);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Message:";
            // 
            // cmbMsgType
            // 
            this.cmbMsgType.FormattingEnabled = true;
            this.cmbMsgType.Items.AddRange(new object[] {
            "Comment",
            "Command",
            "Meta",
            "Planning",
            "Memory",
            "Debug",
            "AIResponse",
            "Generation",
            "Execution",
            "RuntimeEvent",
            "System",
            "Error"});
            this.cmbMsgType.Location = new System.Drawing.Point(80, 6);
            this.cmbMsgType.Name = "cmbMsgType";
            this.cmbMsgType.Size = new System.Drawing.Size(192, 21);
            this.cmbMsgType.TabIndex = 5;
            this.cmbMsgType.Text = "Message Type:";
            this.cmbMsgType.SelectedIndexChanged += new System.EventHandler(this.cmbMsgType_SelectedIndexChanged);
            // 
            // lstSuggestions
            // 
            this.lstSuggestions.BackColor = System.Drawing.SystemColors.Info;
            this.lstSuggestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSuggestions.FormattingEnabled = true;
            this.lstSuggestions.ItemHeight = 15;
            this.lstSuggestions.Location = new System.Drawing.Point(12, 127);
            this.lstSuggestions.Name = "lstSuggestions";
            this.lstSuggestions.Size = new System.Drawing.Size(179, 154);
            this.lstSuggestions.TabIndex = 6;
            this.lstSuggestions.Visible = false;
            this.lstSuggestions.DoubleClick += new System.EventHandler(this.lstSuggestions_DoubleClick);
            // 
            // pnlAttach
            // 
            this.pnlAttach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttach.Controls.Add(this.btnAttach);
            this.pnlAttach.Controls.Add(this.lnklblAttach);
            this.pnlAttach.Controls.Add(this.label3);
            this.pnlAttach.Location = new System.Drawing.Point(12, 90);
            this.pnlAttach.Name = "pnlAttach";
            this.pnlAttach.Size = new System.Drawing.Size(179, 23);
            this.pnlAttach.TabIndex = 7;
            // 
            // btnAttach
            // 
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(3, 1);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(18, 20);
            this.btnAttach.TabIndex = 2;
            this.btnAttach.Text = "+";
            this.btnAttach.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // lnklblAttach
            // 
            this.lnklblAttach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnklblAttach.Location = new System.Drawing.Point(47, 5);
            this.lnklblAttach.Name = "lnklblAttach";
            this.lnklblAttach.Size = new System.Drawing.Size(129, 17);
            this.lnklblAttach.TabIndex = 1;
            this.lnklblAttach.TabStop = true;
            this.lnklblAttach.Text = "linkLabel1";
            this.lnklblAttach.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblAttach_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "📎:";
            // 
            // btnAiSettings
            // 
            this.btnAiSettings.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAiSettings.BackgroundImage = global::NP.UI.Properties.Resources.Setting;
            this.btnAiSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAiSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAiSettings.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAiSettings.Location = new System.Drawing.Point(3, 3);
            this.btnAiSettings.Name = "btnAiSettings";
            this.btnAiSettings.Size = new System.Drawing.Size(26, 26);
            this.btnAiSettings.TabIndex = 8;
            this.btnAiSettings.UseVisualStyleBackColor = false;
            this.btnAiSettings.Click += new System.EventHandler(this.btnAiSettings_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpSettings.Location = new System.Drawing.Point(12, 33);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(260, 163);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Setting";
            // 
            // RuntimeStudioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.pnlAttach);
            this.Controls.Add(this.btnAiSettings);
            this.Controls.Add(this.lstSuggestions);
            this.Controls.Add(this.cmbMsgType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.rtbChat);
            this.Name = "RuntimeStudioControl";
            this.Size = new System.Drawing.Size(284, 261);
            this.Load += new System.EventHandler(this.ChatStudioForm_Load);
            this.pnlAttach.ResumeLayout(false);
            this.pnlAttach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMsgType;
        private System.Windows.Forms.ListBox lstSuggestions;
        private System.Windows.Forms.Panel pnlAttach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.LinkLabel lnklblAttach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAiSettings;
        private System.Windows.Forms.GroupBox grpSettings;
    }
}

