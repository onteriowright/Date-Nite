using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.BusinessViewModals
{
    public class BusinessFormViewModel : Business
    {
        public List<SelectListItem> LocationTypesOptions { get; set; }
    }
}
