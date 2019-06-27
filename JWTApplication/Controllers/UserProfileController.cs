using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        //Get: /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };

        }


        [HttpGet]
        [Route("ForAdmin")]
        [Authorize(Roles ="Admin")]
        public string GetForAdmin()
        {
            return "Web Method for Admin";
        }

        [HttpGet]
        [Route("ForCustomer")]
        [Authorize(Roles = "Customer")]
        public string GetForCustomer()
        {
            return "Web Method for Customer";
        }

        [HttpGet]
        [Route("ForAdminOrCustomer")]
        [Authorize(Roles = "Admin,Customer")]
        public string GetForAdminOrCustomer()
        {
            return "Web Method for Admin or Customer";
        }
    }
}