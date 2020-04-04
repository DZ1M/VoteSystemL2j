using System.Configuration;

namespace VoteSystemL2j
{
    public class AppConfigurationManager
    {
        public string TopL2jBrasil()
        {
            return ConfigurationManager.AppSettings["l2jbrasil"];
        }
        public string TopMMo()
        {
            return ConfigurationManager.AppSettings["topmmo"];
        }

        public string HostDb()
        {
            return ConfigurationManager.AppSettings["host"];
        }
        public string PortaDb()
        {
            return ConfigurationManager.AppSettings["porta"];
        }
        public string DatabaseDb()
        {
            return ConfigurationManager.AppSettings["database"];
        }
        public string UserDb()
        {
            return ConfigurationManager.AppSettings["user"];
        }
        public string SenhaDb()
        {
            return ConfigurationManager.AppSettings["senha"];
        }
    }
}
