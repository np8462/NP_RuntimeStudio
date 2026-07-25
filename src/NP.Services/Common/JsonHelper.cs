using System;
using System.Web.Script.Serialization;

namespace NP.Services.Common
{
    public static class JsonHelper
    {
        static JavaScriptSerializer _serializer =
            new JavaScriptSerializer();

        public static T Deserialize<T>(string json)
        {
            try
            {
                return _serializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Json deserialize error : "
                    + ex.Message
                    + "\nJson="
                    + json);
            }
        }

        public static string Serialize(object obj)
        {
            return _serializer.Serialize(obj);
        }
    }
}