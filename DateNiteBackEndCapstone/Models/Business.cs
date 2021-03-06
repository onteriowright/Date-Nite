﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public LocationAddress LocationAddress { get; set; }
        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("display_phone")]
        public string Phone { get; set; }

        [JsonPropertyName("rating")]
        public decimal Rating { get; set; }

        [JsonPropertyName("image_url")]
        public string Img { get; set; }
        public string UserId { get; set; }
        public int? DateId { get; set; }
        public ApplicationUser ApplicatonUser { get; set; }

    }
}
