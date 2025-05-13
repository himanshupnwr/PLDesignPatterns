using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Adaptor.V2_Implementation.Models
{
    public class Character
    {
        [JsonPropertyName("name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [JsonPropertyName("hair_color")]
        public string Hair { get; set; }
    }
}
