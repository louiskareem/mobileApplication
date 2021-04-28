using System;
using System.Collections.Generic;

namespace MobEye.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<Device> Devices { get; set; }

        /// <summary>
        /// Constructor user
        /// </summary>
        public User() { }

        /// <summary>
        /// Constructor for User 1
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="role"></param>
        /// <param name="devices"></param>
        public User(string Username, string Password, Role role, List<Device> devices)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = role;
            this.Devices = devices;
        }

        /// <summary>
        /// Constructor for User 2 & 3
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="role"></param>
        public User(string Username, string Password, Role role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = role;
        }

        /// <summary>
        /// Method to check if username or password fields are empty
        /// </summary>
        /// <returns></returns>
        public bool CheckInformation()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                return false;
            }

            return true;
        }
    }
}
