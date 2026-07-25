using NP.Core.Models;

namespace NP.Services.Classification
{
    public class MessageClassifier
    {
        public MessageType Classify(
            string text)
        {
            string t =
                text.ToLower();

            // Commands

            if (t.StartsWith("/"))
                return MessageType.Command;

            // Meta

            if (
                t.Contains("متا") ||
                t.Contains("پشت صحنه")
               )
            {
                return MessageType.Meta;
            }

            // Planning

            if (
                t.Contains("معماری") ||
                t.Contains("طراحی") ||
                t.Contains("ساختار") ||
                t.Contains("ایده") ||
                t.Contains("توسعه")
               )
            {
                return MessageType.Planning;
            }

            // Memory

            if (
                t.Contains("حافظه") ||
                t.Contains("تاریخچه") ||
                t.Contains("هیستوری")
               )
            {
                return MessageType.Memory;
            }

            // Debug

            if (
                t.Contains("دیباگ") ||
                t.Contains("لاگ")
               )
            {
                return MessageType.Debug;
            }

            // Error

            if (
                t.Contains("خطا") ||
                t.Contains("ارور") ||
                t.Contains("exception")
               )
            {
                return MessageType.Error;
            }

            return MessageType.Comment;
        }
    }
}





//using NP.Core.Models;

//namespace NP.Services.Classification
//{
//    public class MessageClassifier
//    {
//        public MessageType Classify(
//            string text)
//        {
//            string t =
//                text.ToLower();

//            if (t.StartsWith("/"))
//                return MessageType.Command;

//            if (
//                t.Contains("معماری") ||
//                t.Contains("طراحی") ||
//                t.Contains("ساختار") ||
//                t.Contains("سیستم")
//               )
//            {
//                return MessageType.Planning;
//            }

//            if (
//                t.Contains("حافظه") ||
//                t.Contains("تاریخچه")
//               )
//            {
//                return MessageType.Memory;
//            }

//            if (
//                t.Contains("خطا") ||
//                t.Contains("ارور")
//               )
//            {
//                return MessageType.Error;
//            }

//            if (
//                t.Contains("متا")
//               )
//            {
//                return MessageType.Meta;
//            }

//            return MessageType.Comment;
//        }
//    }



//using NP.Core.Models;

//namespace NP.Services.Classification
//{
//    public class MessageClassifier
//    {
//        public MessageType Classify(
//            string text)
//        {
//            text = text.ToLower();

//            if (text.StartsWith("/"))
//                return MessageType.Command;

//            if (text.Contains("طراحی") ||
//                text.Contains("معماری") ||
//                text.Contains("سیستم") ||
//                text.Contains("ایده"))
//            {
//                return MessageType.Planning;
//            }

//            if (text.Contains("خطا") ||
//                text.Contains("ارور"))
//            {
//                return MessageType.Error;
//            }

//            return MessageType.Comment;
//        }
//    }
//}