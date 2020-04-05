using Newtonsoft.Json;
using System;
using System.Net;
using System.Xml;
using VoteSystemL2j.Models;
using static VoteSystemL2j.Models.XmlL2jBrasil;

namespace VoteSystemL2j.Services
{
    public sealed class VoteSystemService
    {
        public ResultL2jBrasil VerificarL2jBrasil(string ipUsuario)
        {
            var html = "";
            string url = String.Format(@"https://top.l2jbrasil.com/votesystem/index.php?username={0}&ip={1}", new AppConfigurationManager().TopL2jBrasil(), ipUsuario);
            
            
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                     "Windows NT 5.2; .NET CLR 1.0.3705;)");
                html = wc.DownloadString(url);
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(html);
            var xmlObject = Load(doc);

            return xmlObject.Voto;
        }
        public MMOTop VerificarTopMMo(string ipUsuario)
        {
            var html = "";
            string url = String.Format(@"https://mmotop.eu/l2/data/{0}/{1}", new AppConfigurationManager().TopMMo(), ipUsuario);
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                     "Windows NT 5.2; .NET CLR 1.0.3705;)");

                html = wc.DownloadString(url);
            }
            return JsonConvert.DeserializeObject<MMOTop>(html);
        }
    }
}
