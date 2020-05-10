using DateNiteBackEndCapstone.DateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models.DateViewModels
{
    public class DateDetailViewModel
    {
        public Date Date { get; set; }
        public IEnumerable<DateLineViewModel> DateLine { get; set; }
    }
}
