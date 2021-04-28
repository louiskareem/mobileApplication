using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Requests
{
    public class RegistrationRequest
    {
        public String PhoneId { get; set; }
        public String Code { get; set; }

        public RegistrationRequest()
        {

        }

        public RegistrationRequest(String PhoneId, String Code)
        {
            this.PhoneId = PhoneId;
            this.Code = Code;
        }
        public override string ToString()
        {
            return "Phone id " + PhoneId + "Code " + Code;
        }

    }
}
