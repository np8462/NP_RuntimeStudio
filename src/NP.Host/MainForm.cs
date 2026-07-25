using NP.UI.Controls;
using NP.UI.Controls.Chrome;
using NP.UI.Controls.Commands;
using NP.UI.Controls.Components;
using NP.UI.Controls.JsonViewer;
using NP.UI.Controls.Plugins;
using NP.UI.Controls.Runtime;
using NP.UI.Controls.Settings;
using NP.UI.Controls.VSExtension;
using NP.UI.Forms;
using System;
using System.Windows.Forms;


namespace NP.Host
{
    public partial class MainForm : HostForm
    {
        public MainForm()
        {
            InitializeComponent();

            JsonViewerControl jsonViewerControl = new JsonViewerControl();
            jsonViewerControl.Dock = DockStyle.Fill;
            tabJsonViewer.Controls.Add(jsonViewerControl);

            RuntimeStudioControl runtimeStudioControl1 = new RuntimeStudioControl();
            runtimeStudioControl1.Dock = DockStyle.Fill;
            tabAIChat.Controls.Add(runtimeStudioControl1);

            RuntimeConsoleControl console =
                new RuntimeConsoleControl();
            console.Dock = DockStyle.Fill;
            tabRuntimeConsole.Controls.Add(console);

            CommandViewerControl commandViewerControl = new CommandViewerControl();
            commandViewerControl.Dock = DockStyle.Fill;
            tabCommandViewer.Controls.Add(commandViewerControl);

            PluginExplorerControl pluginExplorerControl = new PluginExplorerControl();
            pluginExplorerControl.Dock = DockStyle.Fill;
            tabPluginExplorer.Controls.Add(pluginExplorerControl);

            VsAddinControl vsAddinControl = new VsAddinControl();
            vsAddinControl.Dock = DockStyle.Fill;
            tabVS2012Addin.Controls.Add(vsAddinControl);

            BridgeConsoleControl bridgeConsoleControl = new BridgeConsoleControl();
            SetLogView(bridgeConsoleControl);
            bridgeConsoleControl.Dock = DockStyle.Fill;
            tabChromeExtension.Controls.Add(bridgeConsoleControl);

            SettingsControl settingsControl = new SettingsControl();
            settingsControl.Dock = DockStyle.Fill;
            tabSettings.Controls.Add(settingsControl);

            NP.UI.Controls.RuntimeStudio.RuntimeStudioControl runtimeStudioCtrl = new NP.UI.Controls.RuntimeStudio.RuntimeStudioControl();
            runtimeStudioCtrl.Dock = DockStyle.Fill;
            tabRuntimeStudio.Controls.Add(runtimeStudioCtrl);

            RuntimeWorkspaceControl runtimeWorkspaceCtrl = new RuntimeWorkspaceControl();
            runtimeWorkspaceCtrl.Dock = DockStyle.Fill;
            tabRuntimeWorkspace.Controls.Add(runtimeWorkspaceCtrl);
        }



    }
}

/*
using NP.Host.Core;
using NP.Services.Commands;
using NP.Host.Server;
using NP.Host.Services;
using System;
using System.Windows.Forms;

namespace NP.Host
{
    public partial class MainForm : Form
    {
        private HttpServer _server;
        private MessageRouter _router;
        private SessionManager _sessionManager;
        private RuntimeContext _context;
        private ChromeBridgeService _chromeBridge;

        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //_context = RuntimeBuilder.Create(this);
            _context = new RuntimeContext();
            _context.CommandBus = new CommandBus();
            //_context.CommandBus.CommandReceived += OnCommandReceived;
            _chromeBridge = new ChromeBridgeService(this, _context.CommandBus);

            _sessionManager = new SessionManager();
            _router = new MessageRouter(this, _context.CommandBus);
            _server = new HttpServer(this, _router);
            _server.Start();
        }
        
        //private void OnCommandReceived(CommandPacket cmd)
        //{
        //    Log("Command : " + cmd.Command);
        //}

        public void Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Log), message);
                return;
            }

            richTextBox1.AppendText(
                DateTime.Now.ToString("HH:mm:ss")
                + " - "
                + message
                + Environment.NewLine);
        }
        /*
        public void Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Log), message);
                return;
            }

            //richTextBox1.AppendText(
            //    $"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            richTextBox1.AppendText(
                string.Format("{0:HH:mm:ss} - {1}{2}",
                    DateTime.Now,
                    message,
                    Environment.NewLine));
        }
        
    }
}
*/