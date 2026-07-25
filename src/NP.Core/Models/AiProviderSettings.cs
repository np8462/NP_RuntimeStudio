namespace NP.Core.Models
{
    public class AiProviderSettings
    {
        public string Url
        {
            get;
            set;
        }

        public string ApiKey
        {
            get;
            set;
        }

        public string Model
        {
            get;
            set;
        }

        public int TimeoutSeconds
        {
            get;
            set;
        }
    }
}