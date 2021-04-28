using System;

namespace MobEye.Requests
{
    class AuthorizationRequest
    { 
        public String PhoneID { get; set; }
        public String PrivateKey { get; set; }

        public AuthorizationRequest(String phoneId, String privateKey)
        {
            this.PhoneID = phoneId;
            this.PrivateKey = privateKey;
        }

        public override string ToString()
        {
            return "Phone id " + PhoneID + "Private Key " + PrivateKey;
        }
    }
}
