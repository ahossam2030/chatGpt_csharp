using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace GPT
{
    public class GPTRequest
    {
        [JsonPropertyName("model")]
        public string Model
        {
            // use text-davinci-003 for chat module
            get;
            set;
        }
        [JsonPropertyName("prompt")]
        public string Prompt
        {
            get;
            set;
        }
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens
        {
            get;
            set;
        }
    }
}
