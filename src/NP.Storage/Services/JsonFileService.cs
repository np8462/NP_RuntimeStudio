using NP.Storage.Models;
using NP.Storage.Repositories;

namespace NP.Storage.Services
{
    public class JsonFileService
    {
        private readonly JsonRepository _repository;

        public JsonFileService()
        {
            _repository = new JsonRepository();
        }

        public JsonDocument Open(string fileName)
        {
            return _repository.Load(fileName);
        }

        public void Save(JsonDocument document)
        {
            _repository.Save(document);
        }
    }
}