using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.DateViewModels
{
    public class ViewDateViewModel
    {
        public Date Date { get; set; }

        [JsonPropertyName("businesses")]
        public List<Business> Businesses { get; set; }
    }
}
