﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class Date
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime TimeOfDate { get; set; }
        public string UserId { get; set; }


    }
}
