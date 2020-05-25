using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule_Master_2000_webapi.Services;
using ScheduleMaster;
using ScheduleMaster.Services;

namespace Schedule_Master_2000_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static UserAuthenticator userAuth = new UserAuthenticator();

        //[HttpGet]
        //public async void Login([FromForm] string email, string password)
        //{

        //    var user = userAuth.GetUser(email, password);

        //    if (user == null)
        //    {
        //        //User doesn't exist
        //    }

        //    var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };

        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity));
        //}




        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string email, [FromForm]string password)
        {

            User user = new User(email, password);
            if(user == null)
            {
                Console.WriteLine("User Doesn't exist in Database");
            }
            //conditions, to determine wheter user IS the admin
            else if (user.Password != "admin" || user.Email != "admin@admin.com")
            {
                //do something, Give access to everything
                return new StatusCodeResult(401);
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // redirect to: a different webpage (home for example)
            return new StatusCodeResult(200);
        }


        [Authorize]
        [HttpGet]
        public void Logout()
        {
            //go to logout Page
            return;
        }



        [Authorize]
        [HttpPost]
        public async Task<string> LogoutPost()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "LogOut successful!";
        }




    }
}