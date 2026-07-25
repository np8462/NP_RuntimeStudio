using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NP.Core.Models;
using NP.Storage.Runtime;

namespace NP.Storage.Repositories
{
    public class ChatRepository
    {
        private string _currentProject = "NP_AI_RuntimeStudio";
        private string _currentChat = "MAIN";

        public List<ChatMessage> Load()
        {
            return LoadChat(
                _currentProject,
                _currentChat);
        }

        public List<ChatMessage> GetAll()
        {
            return Load();
        }

        public void Save(List<ChatMessage> messages)
        {
            SaveChat(
                _currentProject,
                _currentChat,
                messages);
        }

        public string CreateChat(
            string projectName,
            string title)
        {
            string chatId =
                Guid.NewGuid().ToString();

            ChatInfo chat =
                new ChatInfo();

            chat.Id =
                chatId;

            chat.ProjectId =
                projectName;

            chat.Title =
                title;

            chat.CreatedAt =
                DateTime.Now;

            string chatsFolder =
                StoragePaths.GetChatsFolder(
                    projectName);

            Directory.CreateDirectory(
                chatsFolder);

            string fileName =
                chatId + ".json";

            string filePath =
                Path.Combine(
                    chatsFolder,
                    fileName);

            string json =
                JsonConvert.SerializeObject(
                    new List<ChatMessage>(),
                    Formatting.Indented);

            File.WriteAllText(
                filePath,
                json);

            return chatId;
        }

        public List<ChatMessage> LoadChat(
            string projectName,
            string chatId)
        {
            string path =
                Path.Combine(
                    StoragePaths.GetChatsFolder(
                        projectName),
                    chatId + ".json");

            //if (!File.Exists(path))
            //{
            //    return new List<ChatMessage>();
            //}


            if (!File.Exists(path))
            {
                SaveChat(
                    projectName,
                    chatId,
                    new List<ChatMessage>());

                return new List<ChatMessage>();
            }


            string json =
                File.ReadAllText(path);

            return
                JsonConvert.DeserializeObject
                <List<ChatMessage>>(json)
                ?? new List<ChatMessage>();
        }

        public void SaveChat(string projectName,string chatId,List<ChatMessage> messages)
        {
            string path =
                Path.Combine(
                    StoragePaths.GetChatsFolder(
                        projectName),
                    chatId + ".json");

            string folder =
                Path.GetDirectoryName(path);

            Directory.CreateDirectory(
                folder);

            string json =
                JsonConvert.SerializeObject(
                    messages,
                    Formatting.Indented);

            File.WriteAllText(
                path,
                json);
        }

        //public void SaveChat(
        //    string projectName,
        //    string chatId,
        //    List<ChatMessage> messages)
        //{
        //    string path =
        //        Path.Combine(
        //            StoragePaths.GetChatsFolder(
        //                projectName),
        //            chatId + ".json");

        //    string json =
        //        JsonConvert.SerializeObject(
        //            messages,
        //            Formatting.Indented);

        //    string folder = Path.GetDirectoryName(path);

        //    Directory.CreateDirectory(folder);

        //    File.WriteAllText(
        //        path,
        //        json);
        //}
    }
}


/*
namespace NP.Storage.Repositories
{
    public class ChatRepository
    {
        private JsonChatStorage storage =
            new JsonChatStorage();

        public void Insert(ChatMessage msg)
        {
            List<ChatMessage> list =
                storage.Load();

            list.Add(msg);

            storage.Save(list);
        }

        public List<ChatMessage> GetAll()
        {
            return storage.Load();
        }
    }
}
*/

//using NP.Core.Models;
//using NP.Storage.Database;
//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;

//namespace NP.Storage.Repositories
//{
//    public class ChatRepository
//    {
//        public void Insert(ChatMessage msg)
//        {
//            using (var con = DbManager.GetConnection())
//            {
//                con.Open();

//                string sql =
//@"INSERT INTO ChatMessages
//(
//    Id,
//    SessionId,
//    Role,
//    Content,
//    MessageType,
//    IsExecutable,
//    LinkedEntity,
//    CreatedAt,
//    ColorTag
//)
//VALUES
//(
//    @Id,
//    @SessionId,
//    @Role,
//    @Content,
//    @MessageType,
//    @IsExecutable,
//    @LinkedEntity,
//    @CreatedAt,
//    @ColorTag
//)";

//                using (var cmd = new SQLiteCommand(sql, con))
//                {
//                    cmd.Parameters.AddWithValue("@Id", msg.Id.ToString());
//                    cmd.Parameters.AddWithValue("@SessionId", msg.SessionId);
//                    cmd.Parameters.AddWithValue("@Role", msg.Role);
//                    cmd.Parameters.AddWithValue("@Content", msg.Content);
//                    cmd.Parameters.AddWithValue("@MessageType", (int)msg.Type);
//                    cmd.Parameters.AddWithValue("@IsExecutable", msg.IsExecutable ? 1 : 0);
//                    cmd.Parameters.AddWithValue("@LinkedEntity", msg.LinkedEntity);
//                    cmd.Parameters.AddWithValue("@CreatedAt", msg.CreatedAt.ToString("o"));
//                    cmd.Parameters.AddWithValue("@ColorTag", msg.ColorTag);

//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        public List<ChatMessage> GetAll()
//        {
//            List<ChatMessage> list =
//                new List<ChatMessage>();

//            using (var con = DbManager.GetConnection())
//            {
//                con.Open();

//                string sql =
//                    "SELECT * FROM ChatMessages ORDER BY CreatedAt";

//                using (var cmd = new SQLiteCommand(sql, con))
//                {
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            ChatMessage msg =
//                                new ChatMessage();

//                            msg.Id =
//                                Guid.Parse(reader["Id"].ToString());

//                            msg.SessionId =
//                                reader["SessionId"].ToString();

//                            msg.Role =
//                                reader["Role"].ToString();

//                            msg.Content =
//                                reader["Content"].ToString();

//                            msg.Type =
//                                (MessageType)
//                                Convert.ToInt32(
//                                    reader["MessageType"]);

//                            msg.IsExecutable =
//                                Convert.ToInt32(
//                                    reader["IsExecutable"]) == 1;

//                            msg.LinkedEntity =
//                                reader["LinkedEntity"].ToString();

//                            msg.CreatedAt =
//                                DateTime.Parse(
//                                    reader["CreatedAt"].ToString());

//                            msg.ColorTag =
//                                reader["ColorTag"].ToString();

//                            list.Add(msg);
//                        }
//                    }
//                }
//            }

//            return list;
//        }
//    }
//}