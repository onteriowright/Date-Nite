using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class DateBusiness
    {
        public int DateBusinessId { get; set; }
        public int DateId { get; set; }
        public Date Date { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
