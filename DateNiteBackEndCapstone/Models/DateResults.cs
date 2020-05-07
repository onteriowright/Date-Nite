using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class DateResults
    {
        public int Id { get; set; }

        [JsonPropertyName("businesses")]
        public List<Business> Businesses { get; set; }
    }
}
