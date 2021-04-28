using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class AlarmPostModel
    {
        public AlarmPostModel(int messageID, string deviceName, string location, string alarmText, string setReset, int priority, DateTime dateTime, List<string> recipients, bool escalation, string value = "none")
        {
            MessageID = messageID;
            DeviceName = deviceName;
            Location = location;
            AlarmText = alarmText;
            SetReset = setReset;
            Priority = priority;
            DateTime = dateTime;
            Recipients = recipients;
            Escalation = escalation;
            Value = value;
        }

        public int MessageID { get; set; }
        public string DeviceName { get; set; }
        public string Location { get; set; }
        public string AlarmText { get; set; }
        public string SetReset { get; set; }
        public int Priority { get; set; }
        public DateTime DateTime { get; set; }
        public List<string> Recipients { get; set; }
        public bool Escalation { get; set; }
        public string Value { get; set; }
        public Status Status { get; set; }

        public static implicit operator Alarm(AlarmPostModel alarm)
        {
            List<User> users = new List<User>(alarm.Recipients.Count);

            for (int i = 0; i < alarm.Recipients.Count; i++)
            {
                //users.Add(new User(alarm.Recipients.ElementAt(i), "deviceImei", "key123"));
            }
            return new Alarm
            {
                MessageID = alarm.MessageID,
                DeviceName=alarm.DeviceName,
                Location=alarm.Location,
                AlarmText=alarm.AlarmText,
                SetReset=alarm.SetReset,
                Priority=alarm.Priority,
                DateTime=alarm.DateTime,
                Recipients= users,
                Escalation=alarm.Escalation,
                Status=Status.received,
                Value=alarm.Value
            };
        }

        public AlarmPostModel()
        {
        }
    }
}
