using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.BusinessViewModels
{
    public class SearchBusinessViewModel
    {
        public List<SelectListItem> ListOfStateOptions { get; set; }
        public string Value { get; set; }
    }
}