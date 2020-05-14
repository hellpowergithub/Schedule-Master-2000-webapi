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
using Microsoft.AspNetCore.Authorization;

namespace Schedule_Master_2000_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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


        [HttpPost]
        public void ModifyTask([FromForm] string title, [FromForm] string description, [FromForm] string userId, [FromForm] string taskId)
        {
            //check user here?
            dbService.ModifyTask(title, description, userId, taskId);
        }


        [HttpDelete] // or [HttpPost]
        public void DeleteTask([FromForm] string userId, [FromForm] string taskId)
        {
            dbService.DeleteTask(userId, taskId);
        }




    }
}