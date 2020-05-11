using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster.Domain
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ScheduleId { get; set; }

        public int DayNumber { get; set; }

        public Day(int id, string name, int scheduleId, int dayNumber)
        {
            Id = id;
            Name = name;
            ScheduleId = scheduleId;
            DayNumber = dayNumber;
        }
    }
}
