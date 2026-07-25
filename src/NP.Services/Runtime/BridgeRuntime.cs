using NP.Services.Runtime;

namespace NP.Services.Bridge
{
    public class BridgeRuntime
    {
        private static BridgeRuntime _instance =
            new BridgeRuntime();

        public static BridgeRuntime Instance
        {
            get
            {
                return _instance;
            }
        }

        public BridgeSessionService BridgeSession
        {
            get;
            set;
        }

        public RuntimeContext Runtime
        {
            get;
            set;
        }
    }
}

//using NP.Services.Bridge;

//namespace NP.Services.Runtime
//{
//    public static class BridgeRuntime
//    {
//        public static BridgeSessionService Session
//        {
//            get;
//            set;
//        }
//    }
//}
