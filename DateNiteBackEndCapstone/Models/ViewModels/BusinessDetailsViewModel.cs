using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.ViewModels
{
    public class BusinessDetailsViewModel
    {
        public Business Business { get; set; }
        public List<SelectListItem> LocationTypesOptions { get; set; }
    }
}
