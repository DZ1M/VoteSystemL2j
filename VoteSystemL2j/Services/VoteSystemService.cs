using Newtonsoft.Json;
using System;
using System.Net;
using VoteSystemL2j.Models;

namespace VoteSystemL2j.Services
{
    public sealed class VoteSystemService
    {
        public L2jBrasilTop VerificarL2jBrasil(string ipUsuario)
        {
            var html = "";
            string url = String.Format(@"https://top.l2jbrasil.com/votesystem/index.php?username={0}&ip={1}", new AppConfigurationManager().TopL2jBrasil(), ipUsuario);
            using (WebClient wc = new WebClient())
            {
                //seta cookie para fazer requisição
                wc.Headers["Cookie"] = "security=true";
                html = wc.DownloadString(url);
            }
           return JsonConvert.DeserializeObject<L2jBrasilTop>(html);
        }
        public MMOTop VerificarTopMMo(string ipUsuario)
        {
            var html = "";
            string url = String.Format(@"https://mmotop.eu/l2/data/{0}/{1}", new AppConfigurationManager().TopMMo(), ipUsuario);
            using (WebClient wc = new WebClient())
            {
                //seta cookie para fazer requisição
                wc.Headers["Cookie"] = "security=true";
                html = wc.DownloadString(url);
            }
            return JsonConvert.DeserializeObject<MMOTop>(html);
        }
    }
}
