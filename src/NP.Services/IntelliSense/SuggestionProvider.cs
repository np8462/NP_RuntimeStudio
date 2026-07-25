using NP.Core.Catalogs;
using NP.Core.Models;
using System.Collections.Generic;

namespace NP.Services.IntelliSense
{
    public class SuggestionProvider
    {
        public List<string> GetSuggestions(
            MessageType type)
        {
            switch (type)
            {
                case MessageType.Command:
                    return SuggestionCatalog.Commands;

                case MessageType.Planning:
                    return SuggestionCatalog.Planning;

                case MessageType.Meta:
                    return SuggestionCatalog.Meta;

                case MessageType.Memory:
                    return SuggestionCatalog.Memory;

                case MessageType.Debug:
                    return SuggestionCatalog.Debug;

                case MessageType.AIRequest:
                    return SuggestionCatalog.AIRequests;

                default:
                    return new List<string>();
            }
        }
    }
}



//using System.Collections.Generic;
//using NP.Core.Models;

//namespace NP.Services.IntelliSense
//{
//    public class SuggestionProvider
//    {
//        public List<string> GetSuggestions(
//            MessageType type)
//        {
//            switch (type)
//            {
//                case MessageType.Command:

//                    return new List<string>
//                    {
//                        "/createfolder",
//                        "/createfile",
//                        "/writefile",
//                        "/readfile",
//                        "/listfiles",
//                        "/createclass",
//                        "/createform",
//                        "/help"
//                    };

//                case MessageType.Planning:

//                    return new List<string>
//                    {
//                        "Design Module",
//                        "Create Architecture",
//                        "Add Workflow",
//                        "Create Entity"
//                    };

//                case MessageType.Meta:

//                    return new List<string>
//                    {
//                        "Developer Note",
//                        "Internal Note",
//                        "Future Task"
//                    };

//                case MessageType.Memory:

//                    return new List<string>
//                    {
//                        "Remember Project Goal",
//                        "Remember Entity",
//                        "Remember Runtime State"
//                    };

//                case MessageType.Debug:

//                    return new List<string>
//                    {
//                        "Runtime Error",
//                        "Compile Error",
//                        "Trace Event"
//                    };

//                default:

//                    return new List<string>();
//            }
//        }
//    }
//}