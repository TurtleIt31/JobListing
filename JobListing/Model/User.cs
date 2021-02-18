using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Model
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Active { get; set; }
        public int User_TypeId { get; set; }
        public virtual User_Type User_Type { get; set; }
    }
}
