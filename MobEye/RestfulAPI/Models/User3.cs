using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class User3 : User
    {
        public int[] DoorID { get; set; }

        public User3(int[] doors, int userPhoneNumber, string deviceImei, string privateKey) : base(userPhoneNumber, deviceImei, privateKey)
        {
            this.DoorID = doors;
        }
    }
}
