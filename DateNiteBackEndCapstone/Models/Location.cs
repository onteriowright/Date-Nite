using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class Location
    {
        [JsonPropertyName("display_address")]
        public List<string> DisplayAddress { get; set; }
    }
}
