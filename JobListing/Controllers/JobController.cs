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
    public class JobController : ControllerBase
    {
        protected readonly App_Context _context;
        public JobController(App_Context context)
        {
            _context = context;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateJob ([FromBody] JobListModel model)
        {
            try
            {
                Job_Listing job_Listing = new Job_Listing()
                {
                    CompanyId = model.CompanyId,
                    Salary = model.Salary,
                    JobDescription = model.JobDescription,
                    IsAvailable = model.IsAvailable,
                    JobPosition = model.JobPosition
                };

                _context.Add(job_Listing);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return Ok(model);
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Job_Listing>> GetJobList()
        {
            try
            {
                    return await _context.JOB_LISTING
                        .Include(f => f.Company).ToListAsync();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Job_Listing>> GetJobListByCompanyId(int companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    return await _context.JOB_LISTING
                        .Include(f => f.Company)
                        .Where(f => f.CompanyId == companyId).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }

        [HttpGet("[action]")]
        public async Task<Job_Listing> GetJobListByJobId(int JobListingId)
        {
            try
            {
                if (JobListingId > 0)
                {
                    return await _context.JOB_LISTING
                        .Include(f=>f.Company)
                        .Where(f => f.Job_ListingId == JobListingId).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
    }
}