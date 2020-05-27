using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Schedule_Master_2000_webapi.Model;
using ScheduleMaster.Domain;
using ScheduleMaster.Services;
using System.Web;
using Nancy.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Schedule_Master_2000_webapi.Services;
using System.Security.Claims;

namespace Schedule_Master_2000_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private static DataBaseService dbService = new DataBaseService();
        private static UserAuthenticator userAuth = new UserAuthenticator();
        //private readonly ScheduleContext _context;

       





        private static List<Schedule> allScheduleOfUser;



        [HttpGet("[action]")]
        public IEnumerable<Schedule> UserSchedules()
        {

            string email = HttpContext.User.FindFirstValue("Email");


            //function, to GET a schedule from DataBase
            allScheduleOfUser = dbService.GetAllSchedule(email); //CHANGE

            //

            return allScheduleOfUser;
        }

        //Post request MISSING (tomorrow, Wednesday)

        [HttpPost("[action]")]
        public void CreateSchedule([FromForm] string name)
        {
            string email = HttpContext.User.FindFirstValue("Email");
            // name = schedule's name
            dbService.AddNew1Schedule(email, name);
            //response ID back maybe

        }



        [HttpDelete]
        public void Delete1Schedule([FromForm] string userId, [FromForm] string scheduleId)
        {
            dbService.DeleteSchedule(userId, scheduleId);
        }





    }
}
