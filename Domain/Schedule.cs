﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster.Domain
{
    public class Schedule
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserEmail { get; set; }

        public Schedule(int id, string name, string userEmail)
        {
            Id = id;
            Name = name;
            UserEmail = userEmail;
        }

        public Schedule()
        {
        }
    }
}
