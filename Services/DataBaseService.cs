using Npgsql;
using ScheduleMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster.Services
{
    public class DataBaseService : IDataBaseService
    {
        private static readonly string _conn = Program.ConnectionString;
        private static NpgsqlConnection conn = new NpgsqlConnection(_conn);

        public string GetScheduleName(string email)
        {
            string scheduleName = "";
            using (var conn = new NpgsqlConnection(_conn)) 
            {
                conn.Open();
               
                using (var cmd = new NpgsqlCommand("SELECT schedule_name FROM schedules WHERE @email = user_email", conn))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        scheduleName = reader["schedule_name"].ToString();
                    }
                }

                return scheduleName;
            }
        }

        public List<Schedule> GetSchedules(string email)
        {
            var allSchedules = new List<Schedule>();

            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("", conn))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //scheduleName = reader["schedule_name"].ToString();
                    }
                }
                
            }

            return allSchedules;
        }
    }
}
