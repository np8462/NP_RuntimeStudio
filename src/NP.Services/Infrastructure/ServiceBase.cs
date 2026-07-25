using NP.Services.Commands;
using NP.UI.Forms;
using System.Windows.Forms;

namespace NP.Services.Infrastructure
{
    public abstract class ServiceBase
    {
        protected HostForm Form;
        protected CommandBus Bus;

        protected ServiceBase(HostForm form,
                              CommandBus bus)
        {
            Form = form;
            Bus = bus;
        }
    }
}

