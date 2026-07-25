using System.IO;
using NP.Storage.Models;

namespace NP.Storage.Repositories
{
    public class JsonRepository
    {
        public JsonDocument Load(string fileName)
        {
            JsonDocument doc = new JsonDocument();

            doc.FullPath = fileName;
            doc.FileName = Path.GetFileName(fileName);
            doc.JsonText = File.ReadAllText(fileName);

            return doc;
        }

        public void Save(JsonDocument document)
        {
            File.WriteAllText(
                document.FullPath,
                document.JsonText);
        }
    }
}