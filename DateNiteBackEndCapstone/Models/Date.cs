using DateNiteBackEndCapstone.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class Date
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }

    }
}
