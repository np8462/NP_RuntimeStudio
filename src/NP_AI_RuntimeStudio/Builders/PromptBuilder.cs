using System.IO;
using NP.Core.Models;
using System.Text;

namespace NP.AI.Builders
{
    public static class PromptBuilder
    {
        public static string Build(
            AiContext context)
        {
            //string attachmentText =
            //    string.Empty;

            //if (context.SourceAttachment != null)
            //{
            //    if (File.Exists(
            //        context.SourceAttachment.TempFilePath))
            //    {
            //        attachmentText =
            //            File.ReadAllText(
            //                context.SourceAttachment.TempFilePath);
            //    }
            //}

            string attachmentText = string.Empty;

            AttachmentInfo attachment =
                context.UserAttachment
                ?? context.SourceAttachment;

            if (attachment != null)
            {
                if (File.Exists(
                    attachment.TempFilePath))
                {
                    attachmentText =
                        File.ReadAllText(
                            attachment.TempFilePath);
                }
            }

            //return string.Format(
            //    "FILE: {0}\r\n\r\n" +
            //    "FILE PATH: {1}\r\n\r\n" +
            //    "SELECTED CODE:\r\n{2}\r\n\r\n" +
            //    "ATTACHMENT:\r\n{3}\r\n\r\n" +
            //    "TASK:\r\n{4}",
            //    context.FileName,
            //    context.FilePath,
            //    context.SelectedCode,
            //    attachmentText,
            //    context.UserPrompt
            //);
            //return string.Format(
            //    "[FILE]\r\n{0}\r\n\r\n" +
            //    "[FILE_PATH]\r\n{1}\r\n\r\n" +
            //    "[SELECTED_CODE]\r\n{2}\r\n\r\n" +
            //    "[ATTACHMENT]\r\n{3}\r\n\r\n" +
            //    "[TASK]\r\n{4}",
            //    context.FileName,
            //    context.FilePath,
            //    context.SelectedCode,
            //    attachmentText,
            //    context.UserPrompt
            //);

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(context.FileName))
            {
                sb.AppendLine("FILE");
                sb.AppendLine(context.FileName);
                sb.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(context.FilePath))
            {
                sb.AppendLine("FILE_PATH");
                sb.AppendLine(context.FilePath);
                sb.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(context.SelectedCode))
            {
                sb.AppendLine("SELECTED_CODE");
                sb.AppendLine(context.SelectedCode);
                sb.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(attachmentText))
            {
                sb.AppendLine("ATTACHMENT");
                sb.AppendLine(attachmentText);
                sb.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(context.UserPrompt))
            {
                sb.AppendLine("USER_REQUEST");
                sb.AppendLine(context.UserPrompt);
            }

            return sb.ToString();
        }
    }
}