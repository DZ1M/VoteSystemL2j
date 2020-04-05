using Newtonsoft.Json;

namespace VoteSystemL2j.Models
{

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

}
