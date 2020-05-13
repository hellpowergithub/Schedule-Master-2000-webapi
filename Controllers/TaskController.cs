using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Nancy.Json;
using ScheduleMaster.Services;
using ScheduleMaster.Domain;

namespace Schedule_Master_2000_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static DataBaseService dbService = new DataBaseService();



        [HttpGet]
        public string Get()
        {
            List<ScheduleMaster.Domain.Task> allTask = dbService.GetAllTasks(2);

            var json = new JavaScriptSerializer().Serialize(allTask);

            return json;

        }










    }
}