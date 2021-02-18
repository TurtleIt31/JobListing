using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Model
{
    public class Job_Listing
    {
        public int Job_ListingId { get; set; }
        public string JobDescription { get; set; }
        public string JobPosition { get; set; }
        public decimal Salary { get; set; }
        public bool IsAvailable { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
