using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Model
{
    public class Job_Applicant
    {
        public int Job_ApplicantId { get; set; }
        [Required]
        public string ApplicantName { get; set; }
        [Required]
        public string ApplicantSurname { get; set; }
        public string ApplicationNo { get; set; }
        [Required]
        public string ApplicantEmail { get; set; }
        public string Expertise { get; set; }
        public bool IsEmployed { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public int Job_ListingId { get; set; }
        public virtual Job_Listing Job_Listing { get; set; }
    }
}
