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

        public Schedule Get1Schedule(string email)
        {
            var schedule = new Schedule();

            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM schedules WHERE @email = user_email", conn))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int Id = Convert.ToInt32(reader["schedule_id"]);
                        var Name = reader["schedule_name"].ToString();
                        string UserEmail = reader["user_email"].ToString();
                        schedule = new Schedule(Id, Name, UserEmail);
                    }
                }

            }

            return schedule;
        }


        //returns ALL schedules from the user
        public List<Schedule> GetAllSchedule(string email)
        {
            var schedules = new List<Schedule>();

            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM schedules WHERE @email = user_email", conn))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int Id = Convert.ToInt32(reader["schedule_id"]);
                        var Name = reader["schedule_name"].ToString();
                        string UserEmail = reader["user_email"].ToString();
                        var schedule = new Schedule(Id, Name, UserEmail);
                        schedules.Add(schedule);
                    }
                }

            }

            return schedules;
        }

        //POST
        public void AddNew1Schedule(string email, string name)
        {
            // name = schedule's Name
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO schedules(schedule_name, user_email) VALUES(@name, @email); ", conn))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
