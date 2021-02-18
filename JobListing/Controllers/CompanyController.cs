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
    public class CompanyController : ControllerBase
    {
        protected readonly App_Context _context;
        public CompanyController(App_Context context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Company>> GetCompany()
        {
            try
            {
                return await _context.COMPANY
                    .Include(f => f.User).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany([FromBody] AddCompanyModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User()
                    {
                        Active = true,
                        Password = model.Password,
                        User_TypeId = 1,
                        UserName = model.UserName
                    };
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    Company company = new Company()
                    {
                        Active = true,
                        CompanyName = model.CompanyName,
                        UserId = user.UserId
                    };
                    _context.Add(company);
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
        public async Task<Company> GetCompanyId(int companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    return await _context.COMPANY
                        .Include(f => f.User)
                        .Where(f => f.CompanyId == companyId).FirstOrDefaultAsync();
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