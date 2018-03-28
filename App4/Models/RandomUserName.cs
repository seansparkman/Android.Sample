using Newtonsoft.Json;

namespace App4.Models
{
    public class RandomUserName
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("first")]
        public string First { get; set; }
        [JsonProperty("last")]
        public string Last { get; set; }
    }

}