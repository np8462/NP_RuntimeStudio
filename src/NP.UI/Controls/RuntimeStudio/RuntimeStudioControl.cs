using System.Windows.Forms;

namespace NP.UI.Controls.RuntimeStudio
{
    public partial class RuntimeStudioControl : UserControl
    {
        public RuntimeStudioControl()
        {
            InitializeComponent();

            LoadRuntimeInfo();
        }

        private void LoadRuntimeInfo()
        {
            lblRuntimeState.Text =
                "Running";

            lblAiState.Text =
                "Ready";

            lblChromeState.Text =
                "Connected";

            lblVsState.Text =
                "Waiting";

            lblPluginCount.Text =
                "7";

            lblCommandCount.Text =
                "0";

            lblLogCount.Text =
                "0";

            listBoxModules.Items.Clear();

            listBoxModules.Items.Add(
                "JsonViewer");

            listBoxModules.Items.Add(
                "RuntimeConsole");

            listBoxModules.Items.Add(
                "AIChat");

            listBoxModules.Items.Add(
                "CommandViewer");

            listBoxModules.Items.Add(
                "PluginExplorer");

            listBoxModules.Items.Add(
                "ChromeExtension");

            listBoxModules.Items.Add(
                "VS2012Addin");
        }
    }
}