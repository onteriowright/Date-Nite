﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.BusinessViewModals
{
    public class BusinessListViewModel
    {
        [JsonPropertyName("businesses")]
        public List<Business> Businesses { get; set; }
        public Date Date { get; set; }
        public int DateId { get; set; }
    }
}
