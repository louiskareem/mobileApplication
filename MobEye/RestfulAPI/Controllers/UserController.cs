using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestfulAPI.Database;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Context is used here to mock a database
        private readonly UserContext userContext;
        private readonly NotificationHubClient notifications;

        public UserController(UserContext userContext)
        {
            this.userContext = userContext;
            this.notifications = new Notifications(userContext).Hub;
        }


        /// <summary>
        /// //https://localhost:/api/users/
        /// This GET method returns all the users from the 'database'
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return userContext.Users.ToList();
        }

        //https://localhost:/api/users/1/
        /// <summary>
        /// This GET method returns a user based on their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            User user = userContext.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        //https://localhost:/api/users/
        /// <summary>
        /// This POST method creates and saves user in the 'database' then return user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<User> PostUser(User user)
        {
            var newRegistrationId = await notifications.CreateRegistrationIdAsync();
            user.PrivateKey = newRegistrationId;
            userContext.Users.Add(user);
            userContext.SaveChanges();
            return user;
        }

        //https://localhost:/api/users/registration
        /// <summary>
        /// This POST method is used to confirm user's registration, 
        /// POST request from the mobile (xamarin), it will return a random string of 5 digits to be used as a private key
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("registration")]
        public JValue PostRegisterUser([FromBody] JValue data)
        {
            var random = new Random();
            string privateKey = string.Empty;
            int length = 5;

            for (int i = 0; i < length; i++)
            {
                privateKey = String.Concat(privateKey, random.Next(10).ToString());
            }
            //return (JValue)privateKey;
            return (JValue)"success";
        }


        //https://localhost:/api/users/door
        /// <summary>
        /// This POST is request is used only for testing purposes.
        /// POST request from mobile to open a door, returns success string 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("door")]
        public JValue PostDoorUser([FromBody] JValue data)
        {

            return (JValue)"success";
            //return (JValue)Request.Headers["Authorization"].ToString();
        }
    }
}
