using System;
using System.IO;
using NP.Core.Models;
using NP.Storage.Runtime;

namespace NP.Storage.Services
{
    public class AttachmentService
    {
        public AttachmentInfo CreateUserAttachment(
    string filePath)
        {
            AttachmentInfo info =
                new AttachmentInfo();

            info.Id =
                Guid.NewGuid().ToString();

            info.FileName =
                Path.GetFileName(
                    filePath);

            info.OriginalFilePath =
                filePath;

            info.TempFilePath =
                filePath;

            info.CreatedAt =
                DateTime.Now;

            return info;
        }
        public AttachmentInfo CreateTempAttachment(
            string originalFile,
            string selectedCode)
        {
            string dateFolder =
                DateTime.Now
                .ToString("yyyyMMdd");

            //string tempFolder =
            //    Path.Combine(
            //        StoragePaths.TempFolder,
            //        dateFolder);
            string tempFolder =
    StoragePaths.TempFolder;

            Directory.CreateDirectory(
                tempFolder);

            string fileName =
                Path.GetFileName(
                    originalFile);

            //string tempFile =
            //    Path.Combine(
            //        tempFolder,
            //        fileName + ".txt");
            string tempFile =
                Path.Combine(
                    tempFolder,
                    fileName + ".tmp");

            File.WriteAllText(
                tempFile,
                selectedCode);

            AttachmentInfo info =
                new AttachmentInfo();

            info.FileName =
                fileName;

            info.OriginalFilePath  =
                originalFile;

            info.TempFilePath  =
                tempFile;

            info.CreatedAt =
                DateTime.Now;

            //info.IsTemporary =
            //    true;

            return info;
        }
    }
}