using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class StatusPost
    {
        public User User { get; set; }
        public Alarm Alarm { get; set; }

        public StatusPost(User user, Alarm alarm)
        {
            this.User = user;
            this.Alarm = alarm;
        }


    }
}
