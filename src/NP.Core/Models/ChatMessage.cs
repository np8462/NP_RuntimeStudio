using System;

namespace NP.Core.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; }

        public string SessionId { get; set; }

        public string Role { get; set; }

        public string Content { get; set; }

        public MessageType Type { get; set; }

        public bool IsExecutable { get; set; }

        public string LinkedEntity { get; set; }

        public string ParentMessageId { get; set; }

        public string Manufacturer { get; set; }

        public string Intent { get; set; }

        public string Tags { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ColorTag { get; set; }

        public string RawContent { get; set; }

    }
}


//using System;

//namespace NP.Core.Models
//{
//    public class ChatMessage
//    {
//        public Guid Id { get; set; }

//        public string SessionId { get; set; }

//        public string Role { get; set; }

//        public string Content { get; set; }

//        public MessageType Type { get; set; }

//        public bool IsExecutable { get; set; }

//        public string LinkedEntity { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public string ColorTag { get; set; }
//    }
//}