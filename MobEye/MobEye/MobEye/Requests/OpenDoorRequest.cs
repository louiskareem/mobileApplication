using System;

namespace MobEye.Requests
{
    public class OpenDoorRequest
    {
        public String PhoneId { get; set; }
        public String DeviceId { get; set; }
        public String PrivateKey { get; set; }
        public String Command { get; set; }

        public OpenDoorRequest(String PhoneId,String DeviceId, String PrivateKey, String Command)
        {
            this.PhoneId = PhoneId;
            this.DeviceId = DeviceId;
            this.PrivateKey = PrivateKey;
            this.Command = Command;
        }
    }
}
