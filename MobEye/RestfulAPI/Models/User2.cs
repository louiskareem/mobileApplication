using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class User2 : User
    {
        public User2(int userPhoneNumber, string deviceImei, string privateKey) : base(userPhoneNumber, deviceImei, privateKey)
        {
            
        }
    }
}
