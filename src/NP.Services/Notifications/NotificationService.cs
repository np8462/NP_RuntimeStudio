using System;
using NP.Services.Commands;
using System.Windows.Forms;
using NP.Services.Infrastructure;
using NP.Services.Runtime;
using NP.UI.Forms;

namespace NP.Services.Notifications
{
    public class NotificationService : ServiceBase
    {
        public NotificationService(
            HostForm form,
            CommandBus bus)
            : base(form, bus)
        {
            bus.CommandReceived += OnCommandReceived;
        }

        void OnCommandReceived(CommandPacket cmd)
        {
            if (cmd.Command == "show_notification")
            {
                Form.Log("Notification : " + cmd.Data);
            }
        }
    }
}