using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CXS.Api.Business;
using CXS.Api.BusinessObjects;

namespace CXS.Api.Controllers
{
    [Route("iVendAPI/V1.0/[controller]")]
    public class UserController : Controller
    {
     
        [FromServices]
        public IUserRepository _repository { get; set; }

        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="Username">The user name for login</param>
        /// <param name="Password">The password for login in clear text</param>
        /// <returns>Logs user into the system</returns>
        [HttpGet("Userslogin/{Username}/{Password}")]
        public IActionResult Login(string Username, string Password)
        {
            if (Username == "test" && Password == "test")
            {
                HttpContext.Response.StatusCode = 200;
                return new ObjectResult(new { Message = "Successfully Login....." });
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
                return new ObjectResult(new { Message = "Invalid UserName && Password......" });
            }
        }

        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        /// <returns>Logs out current logged in user session</returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Response.StatusCode = 200;
            return new ObjectResult(new { Message = "logged out successfully......" });
        }



        /// <summary>
        ///Create a new User
        /// </summary>
        /// <param name="user">user object is required to create a User</param>
        /// <returns>201</returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddUser([FromBody]UserManagement user)
        {
            if (ModelState.IsValid)
            {
                long id = _repository.AddUser(user);

                if (id != 0)
                {
                    HttpContext.Response.StatusCode = 201;
                    return new ObjectResult(new { Message = "Successfully save user details" });
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                    return new ObjectResult(new { Message = "Failed to save user details" });
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
                return new ObjectResult(new { Message = "User model is invalid" });
            }
        }




       

    }
}
