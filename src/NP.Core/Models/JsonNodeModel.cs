using System.Collections.Generic;

namespace NP.Core.Models
{
    public class JsonNodeModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }

        public List<JsonNodeModel> Children { get; private set; }

        public JsonNodeModel()
        {
            Children = new List<JsonNodeModel>();
        }
    }
}