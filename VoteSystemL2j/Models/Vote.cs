using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteSystemL2j.Models
{

    public class L2jBrasilTop
    {
        [JsonProperty(PropertyName = "vote")]
        public ResultMMO Data { get; set; }
    }

    public class MMOTop
    {
        [JsonProperty(PropertyName = "result")]
        public ResultMMO Data { get; set; }
    }

    public class ResultMMO
    {
        public bool is_voted { get; set; }
        public string vote_time { get; set; }
        public string server_time { get; set; }
    }
    public class ResultL2jBrasil
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string ip { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string server_time { get; set; }
        public string hours_since_vote { get; set; }
    }
}
