using ScheduleMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster.Services
{
    public interface IDataBaseService
    {


        //Schedule
        List<Schedule> GetSchedules(string email);

        string GetScheduleName(string email);







    }
}
