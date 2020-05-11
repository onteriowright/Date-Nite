using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.DateViewModels
{
    public class ListOfDatesViewModel
    {
        public List<ViewDateViewModel> ListOfDates { get; set; } = new List<ViewDateViewModel>();
    }
}
