using NP.Services.Abstractions;
using NP.Services.Bridge;
using NP.Services.Commands;
using NP.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP.UI.Forms
{
    public class HostForm:Form
    {
        private RuntimeContext _context;
        private RuntimeLogger _logger;
        private ILogView _logView;

        public HostForm()
        {
            _logger = new RuntimeLogger();

            _logger.Write(
                "Runtime",
                "Runtime initialized");

            _logger.Write(
                "JsonViewer",
                "JsonViewer loaded");

            _logger.Write(
                "Chrome",
                "Chrome Extension ready");
        }

        public void SetLogView(ILogView logView)
        {
            _logView = logView;
        }

        public void Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Log), message);
                return;
            }

            if (_logView != null)
                _logView.Log(message);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _context = RuntimeBuilder.Build(this);
            _context.VSBridge = new VSBridgeService();
            _context.VSBridge.OnInsertText += OnVsInsertText;
            _context.CommandBus.CommandReceived += _context.VSBridge.Handle;
        }

        private void OnVsInsertText(string text)
        {
            Log("VS Insert: " + text);
        }



        private void OnCommandReceived(CommandPacket cmd)
        {
            if (cmd.Command == "log")
            {
                Log(cmd.Data);
                return;
            }

            Log("Command : " + cmd.Command);
        }

    }
}
