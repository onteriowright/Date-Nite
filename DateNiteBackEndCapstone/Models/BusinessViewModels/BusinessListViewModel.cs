using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.BusinessViewModels
{
    public class BusinessListViewModel
    {
        [JsonPropertyName("businesses")]
        public List<Business> Businesses { get; set; }
        public Date Date { get; set; }
        public int DateId { get; set; }
        [Display(Name = "Date")]
        public DateTime? DateTime { get; set; }
        public string LocationType { get; set; }
    }
}
