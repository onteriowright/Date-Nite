using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateNiteBackEndCapstone.Models
{
    public class UserBusiness
    {
        [Key]
        public int UserBusinessId { get; set; }
        public string UserId { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }

    }
}
