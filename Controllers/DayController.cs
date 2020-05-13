using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using ScheduleMaster.Services;

namespace Schedule_Master_2000_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private static DataBaseService dbService = new DataBaseService();


        [HttpGet]
        public string Get()
        {
            var allDays = dbService.GetAllDay(2);

            var json = new JavaScriptSerializer().Serialize(allDays);
            Console.WriteLine(json);
            return json;
        }


    }
}