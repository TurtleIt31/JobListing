using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobListing.Model;
using JobListing.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicantController : ControllerBase
    {
        protected readonly App_Context _context;
        public JobApplicantController(App_Context context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<User_Type>> GetUserTypes()
        {
            try
            {

                return await _context.USER_TYPE.ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Job_Applicant>> GetAllApplication()
        {
            try
            {
                
                    return await _context.JOB_APPLICANT
                        .Include(f => f.Job_Listing)
                        .ThenInclude(f => f.Company)
                        .Include(f => f.User).ToListAsync();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAplication([FromBody] JobApplicantModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ApplicationNo = GenerateApplicationNumber();
                    User user = new User()
                    {
                        Active = true,
                        Password = model.Password,
                        User_TypeId = 2,
                        UserName = model.UserName
                    };
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    Job_Applicant job_Applicant = new Job_Applicant()
                    {
                        Age = model.Age,
                        ApplicantEmail = model.ApplicantEmail,
                        ApplicantName = model.ApplicantName,
                        ApplicantSurname = model.ApplicantSurname,
                        ApplicationNo = ApplicationNo,
                        Expertise = model.Expertise,
                        IsEmployed = model.IsEmployed,
                        Job_ListingId = model.Job_ListingId,
                        UserId = user.UserId

                    };
                    
                    _context.Add(job_Applicant);
                    await _context.SaveChangesAsync();
                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Ok(model);
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Job_Applicant>> GetApplicantByCompanyId(int companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    return await _context.JOB_APPLICANT
                        .Include(f => f.Job_Listing)
                        .ThenInclude(f => f.Company)
                        .Include(f => f.User)
                        .Where(f => f.Job_Listing.CompanyId == companyId).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Job_Applicant>> GetApplicant(string UserName)
        {
            try
            {
                if (!string.IsNullOrEmpty(UserName))
                {
                    return await _context.JOB_APPLICANT
                        .Include(f => f.Job_Listing)
                        .ThenInclude(f => f.Company)
                        .Include(f => f.User)
                        .Where(f => f.User.UserName == UserName).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Job_Applicant>> GetApplicantByJob(int JobListId)
        {
            try
            {
                if (JobListId > 0)
                {
                    return await _context.JOB_APPLICANT
                        .Include(f => f.Job_Listing)
                        .ThenInclude(f => f.Company)
                        .Include(f => f.User)
                        .Where(f => f.Job_ListingId == JobListId).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
        private string GenerateApplicationNumber()
        {
            try
            {
                string prefix = "JOB";

                var paymentIdToString = DateTime.Now.Millisecond.ToString();

                string suffix = paymentIdToString.PadLeft((10 - paymentIdToString.Length), '0');

                return string.Format("{0}-{1}", prefix, suffix);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}