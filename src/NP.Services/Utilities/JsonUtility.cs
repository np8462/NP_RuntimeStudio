using System.Web.Script.Serialization;

namespace NP.Services.Utilities
{
    public static class JsonUtility
    {
        public static string Serialize(object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Deserialize<T>(json);
        }
    }
}