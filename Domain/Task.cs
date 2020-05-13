using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaster.Domain
{
    public class Task
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public Task(int id, string title, string description, string imgUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
        }

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Task()
        {

        }
    }
}
