using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KustBot.Config
{
    public class ConfigReader
    {
        [JsonProperty("Token")]
        public string token { get; set; }
        [JsonProperty("TokenIgor")]
        public string tokenIgor { get; set; }
        [JsonProperty("Prefix")]
        public string[] prefix { get; set; }
        [JsonProperty("Game")]
        public string game { get; set; }
    }
}
