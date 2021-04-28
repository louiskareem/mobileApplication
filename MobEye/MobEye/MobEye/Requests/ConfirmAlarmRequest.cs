using System;

namespace MobEye.Requests
{
    public class ConfirmAlarmRequest
    {
        public String PhoneID { get; set; }
        public String PrivateKey { get; set; }

        public int UniqueMessageID { get; set; }

        public String Response { get; set; }

        public ConfirmAlarmRequest(String phoneId, int uniqueMessageID, String response, String privateKey)
        {
            this.PhoneID = phoneId;
            this.UniqueMessageID = uniqueMessageID;
            this.Response = response;
            this.PrivateKey = privateKey;
        }

        public override string ToString()
        {
            return "Phone id " + PhoneID + "Private Key " + PrivateKey;
        }
    }
}
