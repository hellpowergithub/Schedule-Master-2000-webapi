using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleMaster;

namespace Schedule_Master_2000_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        [HttpGet]
        public void Login()
        {
            //user, would login from here
            //MISSING: page to login
            return;
        }






        [HttpPost]
        public async void Login(string email, string userName, string password)
        {

            User user = new User(email, userName, password);
            if(user == null)
            {

            }
            //conditions, to determine wheter user IS the admin
            else if (user.Password == "admin" && user.Email == "admin@admin.com")
            {
                //do something, Give access to everything
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // redirect to: a different webpage (home for example)
            return;
        }


        [Authorize]
        [HttpGet]
        public void Logout()
        {
            return;
        }



        [Authorize]
        [HttpPost]
        public async void LogoutPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return;
        }




    }
}