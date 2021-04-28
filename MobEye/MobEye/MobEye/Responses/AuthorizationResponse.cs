using MobEye.Models;
using System;
using System.Collections.Generic;

namespace MobEye.Responses
{
    public class AuthorizationResponse
    {
        public String userRole { get; set; }

        public String privateKey { get; set; }

        public List<Device> devices { get; set; }

        public AuthorizationResponse() {  }

        public AuthorizationResponse(String role, String pk, List<Device> devices)
        {
            this.userRole = role;
            this.privateKey = pk;
            this.devices = devices;
        }

        public override string ToString()
        {
            return "user role " + userRole + "private key " + privateKey + "devices" + devices.ToString();
        }
    }
}
