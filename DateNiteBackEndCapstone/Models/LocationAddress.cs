using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class LocationAddress
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        [JsonPropertyName("display_address")]
        public List<string> DisplayAddress { get; set; }
    }
}
