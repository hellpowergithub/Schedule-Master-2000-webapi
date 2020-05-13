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

namespace Schedule_Master_2000_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private static DataBaseService dbService = new DataBaseService();
        //private readonly ScheduleContext _context;

        //public ScheduleController(ScheduleContext context)
        //{
        //    _context = context;
        //}


        
        //-------------------------------------------------

        //[HttpGet]
        //public async Task<ActionResult<Schedule>> GetSchedule(string email)
        //{
        //    Schedule UserSchedule = await _context.Schedules.FindAsync(email);

        //    if (UserSchedule == null)
        //    {
        //        Console.WriteLine("User Schedule == null");
        //    }

        //    return UserSchedule;


        //}





        [HttpGet("{email}")]

        public string Get(string email)
        
        {

            //function, to GET a schedule from DataBase
            var schedule = dbService.GetAllSchedule(email); //CHANGE

            //
            Console.WriteLine(schedule.ToString());

            var json = new JavaScriptSerializer().Serialize(schedule);
            Console.WriteLine(json);
            return json;
        }

        //Post request MISSING (tomorrow, Wednesday)

        [Authorize] //only if you have the permission to do it
        [HttpPost]
        public void PostNew1Schedule(string email, string name)
        {
            // name = schedule's name
            dbService.AddNew1Schedule("erik@erik.com", "new Schedule");
            //response ID back maybe

        }
    }
}
