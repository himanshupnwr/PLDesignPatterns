using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Adaptor.V2_Implementation.Models
{
    public class Person
    {
        public virtual string Name { get; set; }
        public virtual string Gender { get; set; }
        [JsonPropertyName("hair_color")]
        public virtual string HairColor { get; set; }
    }
}
