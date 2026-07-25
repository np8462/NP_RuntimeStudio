using System;
using System.Windows.Forms;
using NP.Services.Bridge;
using NP.Core.Models;
using NP.Services.Abstractions;

namespace NP.UI.Controls.Chrome
{
    public partial class BridgeConsoleControl : UserControl, ILogView
    {
        public BridgeConsoleControl()
        {
            InitializeComponent();
        }

        public void Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Log), message);
                return;
            }

            richTextBoxChromeLog.AppendText(
                DateTime.Now.ToString("HH:mm:ss") +
                " - " +
                message +
                Environment.NewLine);

            richTextBoxChromeLog.SelectionStart =
                richTextBoxChromeLog.TextLength;

            richTextBoxChromeLog.ScrollToCaret();
        }

        private void btnReceive_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                BridgeService service =
                    new BridgeService();

                BridgeRequest request =
                    service.Load();

                if (request == null)
                {
                    MessageBox.Show(
                        "No bridge request found.");

                    return;
                }

                txtProject.Text =
                    request.ProjectName;

                txtFile.Text =
                    request.FileName;

                txtPath.Text =
                    request.FilePath;

                richTextBoxCode.Text =
                    request.SelectedCode;

                Log("Bridge request loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                Log("Error : " + ex.Message);
            }
        }
    }
}