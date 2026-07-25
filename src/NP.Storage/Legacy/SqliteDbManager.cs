//using System.Data.SQLite;
//using System.IO;

//namespace NP.Storage.Database
//{
//    public static class DbManager
//    {
//        private static string DbFile =
//            "NP_Runtime.db";

//        private static string ConnectionString =
//            "Data Source=NP_Runtime.db;Version=3;";

//        public static SQLiteConnection GetConnection()
//        {
//            return new SQLiteConnection(ConnectionString);
//        }

//        public static void Initialize()
//        {
//            if (!File.Exists(DbFile))
//            {
//                SQLiteConnection.CreateFile(DbFile);
//            }

//            using (var con = GetConnection())
//            {
//                con.Open();

//                string sql =
//@"
//CREATE TABLE IF NOT EXISTS ChatMessages
//(
//    Id TEXT PRIMARY KEY,
//    SessionId TEXT,
//    Role TEXT,
//    Content TEXT,
//    MessageType INTEGER,
//    IsExecutable INTEGER,
//    LinkedEntity TEXT,
//    CreatedAt TEXT,
//    ColorTag TEXT
//);
//";

//                SQLiteCommand cmd =
//                    new SQLiteCommand(sql, con);

//                cmd.ExecuteNonQuery();
//            }
//        }
//    }
//}