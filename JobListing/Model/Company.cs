using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Model
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public virtual User User {get;set;}
    }
}
