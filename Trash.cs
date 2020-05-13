using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using ScheduleMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Schedule_Master_2000_webapi.Model
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }

        //MISSING users, tasks, days, slots

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=localhost:5001;Database=Schedule Master 2000;Username=postgres;Password=admin");


    }
}
