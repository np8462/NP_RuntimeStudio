using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using NP.Core.Models;

namespace NP.Services.Json
{
    public class JsonTreeBuilder
    {
        public JsonNodeModel Build(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            object data = serializer.DeserializeObject(json);

            return ParseObject("Root", data);
        }

        private JsonNodeModel ParseObject(string name, object obj)
        {
            JsonNodeModel node = new JsonNodeModel();
            node.Name = name;

            if (obj is Dictionary<string, object>)
            {
                var dict = (Dictionary<string, object>)obj;

                foreach (var item in dict)
                {
                    node.Children.Add(ParseObject(item.Key, item.Value));
                }
            }
            else if (obj is object[])
            {
                object[] arr = (object[])obj;

                int index = 0;

                foreach (var item in arr)
                {
                    node.Children.Add(ParseObject("[" + index + "]", item));

                    index++;
                }
            }
            else
            {
                node.Value = obj != null ? obj.ToString() : "null";
            }

            return node;
        }
    }
}