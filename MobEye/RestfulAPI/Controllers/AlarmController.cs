using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestfulAPI.Database;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    [Route("api/messages/")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly AlarmContext alarmContext;
        private readonly Notifications notifications;
        // Context is used here to mock a database
        private readonly UserContext userContext;

        /// <summary>
        /// Method to reference database context (temporary save data)
        /// </summary>
        /// <param name="alarmContext"></param>
        public AlarmController(AlarmContext alarmContext)
        {
            this.alarmContext = alarmContext;
            this.userContext = userContext;
            this.notifications = new Notifications(userContext);
        }

        /// <summary>
        /// //https://localhost:44349/api/messages/
        /// Method to return alarms in a list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Alarm> GetAlarms()
        {
            return alarmContext.Alarms.Include(alarm => alarm.Recipients).ToList();
        }

        /// <summary>
        /// //https://localhost:44349/api/messages/
        /// Post request for alarms
        /// Method to "create" and add alarms
        /// </summary>
        /// <param name="alarm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> PostAlarm(AlarmPostModel alarm)
        {
            alarmContext.Alarms.Add(alarm);
            alarmContext.SaveChanges();
            var result = await this.notifications.sendToAll();
            //var result = await this.notifications.sendAlarm(alarm);
            Console.WriteLine("result is " + result.ToString());
            return new HttpResponseMessage(result);
        }

        /// <summary>
        /// Method to get status
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [HttpPost("status")]
        public JObject PostStatus(JObject items)
        {
            return (JObject)items;
        }
    }
}
