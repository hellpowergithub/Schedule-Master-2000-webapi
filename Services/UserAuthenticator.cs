using ScheduleMaster;
using ScheduleMaster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule_Master_2000_webapi.Services
{
    public class UserAuthenticator
    {

        //checks if user exists in DataBase
        private static DataBaseService dbService = new DataBaseService();
        private static List<User> allUsers = dbService.GetAllUser();

        public bool IsAdmin(string email, string password)
        {
            foreach (var user in allUsers)
            {
                if ("admin@admin.com" == user.Email && "admin" == user.Password)
                {
                    return true;
                }
            }
            return false; 
        }

    }
}
