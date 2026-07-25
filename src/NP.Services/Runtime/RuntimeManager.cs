using NP.Services.Commands;

namespace NP.Services.Runtime
{
    public class RuntimeManager
    {
        public RuntimeStateBag Context
        {
            get;
            private set;
        }

        public RuntimeState State
        {
            get;
            private set;
        }

        public SessionManager Sessions
        {
            get;
            private set;
        }

        public CommandBus Commands
        {
            get;
            private set;
        }

        public RuntimeManager()
        {
            Context = new RuntimeStateBag();

            Sessions = new SessionManager();

            Commands = new CommandBus();

            State = RuntimeState.Stopped;
        }

        public void Start()
        {
            State = RuntimeState.Running;
        }

        public void Pause()
        {
            State = RuntimeState.Paused;
        }

        public void Stop()
        {
            State = RuntimeState.Stopped;
        }
    }
}