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


        //returns all users from DataBase
        public List<User> GetAllUser()
        {
            List<User> allUser = new List<User>();

            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM users", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string userId = reader["user_id"].ToString();
                        string nickname = reader["nickname"].ToString();
                        string password = reader["pw"].ToString();
                        //string salt = reader["salt"].ToString();
                        User user = new User(userId, nickname, password);
                        allUser.Add(user);
                    }

                }
            }

            return allUser;

        }

        //return single user
        public User Get1User(string email)
        {
            User user = new User();
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM users WHERE @userId = user_id", conn))
                {
                    cmd.Parameters.AddWithValue("userId", email);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string userEmail = reader["user_id"].ToString();
                        string password = reader["pw"].ToString();
                        string nickname = reader["nickname"].ToString();
                        //string slat = reader["salt"].ToString();

                         user = new User(userEmail, nickname, password);
                    }
                }
            }

            return user;
        }





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
                using (var cmd = new NpgsqlCommand("SELECT * FROM schedules WHERE @email = user_id", conn))
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

        //POST modify existing schedule
        public void ModifySchedule(string userId, string scheduleId, string scheduleName)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE schedules SET schedule_name = @scheduleName WHERE schedule_id = @scheduleId AND user_id = @userId", conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("scheduleId", scheduleId);
                    cmd.Parameters.AddWithValue("scheduleName", scheduleName);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Deletes 1 schedule if conditions meet
        public void DeleteSchedule(string userId, string scheduleId)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM schedules WHERE user_id = @userId AND schedule_id = @scheduleId", conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("scheduleId", scheduleId);

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



        // returns all Tasks based on who's email it is
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

        //Add new Task based on email or registered user
        public void AddTask(string title, string description, string user_id)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO tasks(task_title, task_description, user_id) VALUES(@title, @description, @userId)", conn))
                {
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("userId", user_id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Modifies existing task of existing user
        public void ModifyTask(string title, string description, string userId, string taskId)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE tasks SET task_title = @title, task_description = @description WHERE user_id = @userId AND task_id = taskId", conn))
                {
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("taskId", taskId);

                    cmd.ExecuteNonQuery();

                }
            }
        }


        //DELETE task
        public void DeleteTask(string userId, string taskId)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM tasks WHERE user_id = @userId AND task_id = @taskId", conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("taskId", taskId);

                    cmd.ExecuteNonQuery();
                }
            }
        }




































































































































        //ok
    }
}
