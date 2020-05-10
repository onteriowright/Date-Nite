using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.BusinessViewModals
{
    public class BusinessListViewModel
    {
        [JsonPropertyName("businesses")]
        public IEnumerable<Business> Businesses { get; set; }
    }
}
