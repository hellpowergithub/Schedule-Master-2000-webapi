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
        public void AddNew1Schedule(string userId, string scheduleName)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO schedules(schedule_name, user_email) VALUES(@name, @email); ", conn))
                {
                    cmd.Parameters.AddWithValue("name", scheduleName);
                    cmd.Parameters.AddWithValue("email", userId);
                    cmd.ExecuteNonQuery();

                }
            }
        }






        //return ALL Days, based on schedule_id
        public List<Day> GetAllDay(int scheduleId)
        {

            var allDays = new List<Day>();

            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM days WHERE @schedule_id = schedule_id", conn))
                {
                    cmd.Parameters.AddWithValue("schedule_id", scheduleId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int Id = Convert.ToInt32(reader["day_id"]);
                        string dayName = reader["day_name"].ToString();
                        int dayNumber = Convert.ToInt32(reader["day_number"]);
                        Day day = new Day(Id, dayName, dayNumber);
                        allDays.Add(day);
                    }
                }
            }

            return allDays;
        }


        // returns all Tasks
        public List<Domain.Task> GetAllTasks(int userId)
        {
            List<Domain.Task> allTask = new List<Domain.Task>();
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM tasks WHERE @uid = user_id", conn))
                {
                    cmd.Parameters.AddWithValue("uid", userId);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["task_id"]);
                        string title = reader["task_title"].ToString();
                        string description = reader["task_description"].ToString();
                        //string imgUrl = reader["image_url"].ToString();

                        Domain.Task task = new Domain.Task(id, title, description);
                        allTask.Add(task);
                    }
                }
            }

            return allTask;
        }












































































































































        //ok
    }
}
