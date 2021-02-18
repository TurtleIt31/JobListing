using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.ViewModel
{
    public class JobApplicantModel
    {
        public int Job_ApplicantId { get; set; }
        [Required]
        public string ApplicantName { get; set; }
        [Required]
        public string ApplicantSurname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string ApplicantEmail { get; set; }
        public string Expertise { get; set; }
        public bool IsEmployed { get; set; }
        public int Age { get; set; }
        [Required]
        public int Job_ListingId { get; set; }
    }
}
