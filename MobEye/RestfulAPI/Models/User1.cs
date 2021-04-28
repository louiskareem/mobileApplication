using System;

namespace RestfulAPI.Models
{
    public class User1 : User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int[] DoorID { get; set; }

        public User1(int[] doors, String username, String password, int userPhoneNumber, string deviceImei, string privateKey) : base(userPhoneNumber, deviceImei, privateKey)
        {
            this.Username = username;
            this.Password = password;
            this.DoorID = doors;
        }
    }
}
