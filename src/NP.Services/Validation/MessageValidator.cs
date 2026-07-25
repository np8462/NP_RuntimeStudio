using NP.Core.Models;
using System;

namespace NP.Services.Validation
{
    public class MessageValidator
    {
        public bool Validate(
            MessageType type,
            string content,
            out string error)
         {
            error = "";

            try
            {
                if (string.IsNullOrWhiteSpace(content))
                {
                    error =
                        "Message is empty.";

                    return false;
                }

                switch (type)
                {
                    // COMMAND

                    case MessageType.Command:

                        if (!content.StartsWith("/"))
                        {
                            error =
                                "Command must start with /";

                            return false;
                        }

                        break;

                    // META

                    case MessageType.Meta:

                        if (content.StartsWith("/"))
                        {
                            error =
                                "Meta cannot contain executable command.";

                            return false;
                        }

                        break;

                    // PLANNING

                    case MessageType.Planning:

                        if (content.StartsWith("/"))
                        {
                            error =
                                "Planning message cannot execute commands.";

                            return false;
                        }

                        break;

                    // MEMORY

                    case MessageType.Memory:

                        if (content.Length < 3)
                        {
                            error =
                                "Memory message too short.";

                            return false;
                        }

                        break;

                    // DEBUG

                    case MessageType.Debug:

                        if (content.Length < 5)
                        {
                            error =
                                "Debug message too short.";

                            return false;
                        }

                        break;

                    // AI RESPONSE

                    case MessageType.AIResponse:

                        error =
                            "AIResponse messages are system generated.";

                        return false;

                    // GENERATION

                    case MessageType.Generation:

                        error =
                            "Generation messages are runtime generated.";

                        return false;

                    // EXECUTION

                    case MessageType.Execution:

                        error =
                            "Execution messages are runtime only.";

                        return false;

                    // RUNTIME EVENT

                    case MessageType.RuntimeEvent:

                        error =
                            "Runtime events are system generated.";

                        return false;

                    // SYSTEM

                    case MessageType.System:

                        error =
                            "System messages are protected.";

                        return false;

                    // ERROR

                    case MessageType.Error:

                        if (content.Length < 3)
                        {
                            error =
                                "Error message invalid.";

                            return false;
                        }

                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;

                return false;
            }
        }
    }
}




//using NP.Core.Models;

//namespace NP.Services.Validation
//{
//    public class MessageValidator
//    {
//        public bool Validate(
//            MessageType type,
//            string content,
//            out string error)
//        {
//            error = "";

//            // Command

//            if (type == MessageType.Command)
//            {
//                if (!content.StartsWith("/"))
//                {
//                    error =
//                        "Command must start with /";

//                    return false;
//                }
//            }

//            // AIResponse

//            if (type == MessageType.AIResponse)
//            {
//                error =
//                    "AIResponse is system generated.";

//                return false;
//            }

//            // Execution

//            if (type == MessageType.Execution)
//            {
//                error =
//                    "Execution messages are runtime only.";

//                return false;
//            }

//            return true;
//        }
//    }
//}