using System;
using System.Windows.Forms;
using NP.Core.Models;
using NP.Services.Commands;

namespace NP.UI.Controls.Commands
{
    public partial class CommandViewerControl :
        UserControl
    {
        private CommandManager _manager;

        public CommandViewerControl()
        {
            InitializeComponent();

            _manager =
                new CommandManager();

            _manager.CommandAdded +=
                Manager_CommandAdded;
        }

        void Manager_CommandAdded(
            CommandModel item)
        {
            dataGridViewCommands.Rows.Add(
                item.Time.ToString("HH:mm:ss"),
                item.Source,
                item.Command,
                item.Details);
        }

        public CommandManager Manager
        {
            get
            {
                return _manager;
            }
        }
        private void toolStripButtonTest_Click(object sender,       EventArgs e)
        {
            _manager.Add(
                "Runtime",
                "Initialize",
                "Program started");
        }
        private void toolStripButtonClear_Click(object sender,    EventArgs e)
        {
            dataGridViewCommands.Rows.Clear();

            _manager.Clear();
        }
    }
}