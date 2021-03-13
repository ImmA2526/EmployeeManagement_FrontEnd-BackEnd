using EmployeeBusinessLayer.IEmployeeBusiness;
using EmployeeModel;
using EmployeeModelLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgtBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusines employeeBusiness;
        private readonly IConfiguration configuration;
        
        private IDistributedCache cache;
        private string cacheKey;
        private DistributedCacheEntryOptions options;

        public EmployeeController(IEmployeeBusines employeeBusines,IConfiguration configuration, IDistributedCache cache)
        {
            this.employeeBusiness = employeeBusines;
            this.configuration = configuration;
            this.cache = cache;
            this.cacheKey = "EmployeeMgt";
            this.options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(3.0));
        }

    /// <summary>
    /// JWTs Token genration.
    /// </summary>
    /// <param name="Email">The email.</param>
    /// <returns></returns>

    private string JWTTokenGenration(string Email)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Email",Email)
            };
            var tokenOption = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return token;
        }

        /// <summary>
        /// Register the Employee.
        /// </summary>
        /// <param name="create">The create.</param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult RegisterEmployee([FromBody] EmployeeModels create)
        {
            try
            {
                var result = this.employeeBusiness.RegisterEmployee(create);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Added Succesfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Error While Adding Employee" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Login User.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser([FromBody] LoginModel login)
        {
            try
            {
                var logins = this.employeeBusiness.LoginUser(login);
                if (logins != null)
                {
                    var token = JWTTokenGenration(logins.Email);
                    return this.Ok(new { Status = true, Message = "Login Success", Data = token,logins.EmployeeId });
                }
                return this.NotFound(new { Status = false, Message = "Login Failed" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Retrive All Employee
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            try
            {
                IEnumerable<EmployeeModels>getResult=this.employeeBusiness.GetAllEmployees() ;
                if (getResult != null)
                {
                    this.cache.SetString(this.cacheKey, JsonConvert.SerializeObject(getResult));
                }
                
                if (this.cache.GetString(this.cacheKey)!= null)
                {
                    var data = JsonConvert.DeserializeObject<List<EmployeeModels>>(this.cache.GetString(this.cacheKey));
                    return this.Ok(new { Status = true, Meessage = "Employee Data Retrived Successfully", Data = data });
                }
                return this.NotFound(new { Status = false, Message = "Employee Data Not Found" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });            
            }
        }

        /// <summary>
        /// Retrive Employee By Employee ID for Performing Update Operation 
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>

        [HttpGet]
        [Route("getBy/{employeeId}")]
        public IActionResult GetEmployee_ID(int employeeId)
        {
            try
            {
                IEnumerable<EmployeeModels> getResult = this.employeeBusiness.GetEmployee_ID(employeeId);
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Meessage = "Employee Data Retrived Successfully", Data = getResult });
                }
                return this.BadRequest(new { Status = false, Message = "Employee Data Not Found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>

        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeModels updateEmployee)
        {
            try
            {
                var updateResult = this.employeeBusiness.UpdateEmployee(updateEmployee);
                if (updateResult != null)
                {
                    return this.Ok(new { Status = true, Meessage = "Employee Record Updated Successfully", Data = updateResult });
                }
                return this.NotFound(new { Status = false, Message = "Employee Data Not Found" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>

        [HttpDelete]
        [Route("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            try
            {
                var deleteEmployee = this.employeeBusiness.DeleteEmployee(employeeId);
                if (deleteEmployee != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Removed Succesfully" });
                }
                return this.NotFound(new { Status = false, Message = "Error While Deleting Employee Record" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }
    }
}
