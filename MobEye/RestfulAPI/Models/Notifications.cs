using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;
using RestfulAPI.Database;

namespace RestfulAPI.Models
{
    public class Notifications
    {
        public NotificationHubClient Hub { get; set; }
        private UserContext userContext;

        public Notifications(UserContext userContext)
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://mobeyeapp.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=QQRATZQhKXCCm5LuHgZLC8BBIBsyzFYlNqvx1Guq5OM=",
                                                                            "MobeyeApp");
            this.userContext = userContext;
        }

        public async Task<HttpStatusCode> sendToAll()
        {
            var notif = " { \"notification\":{ \"title\":\"Alarm\", \"body\":\"test message\" }, \"data\":{ \"property1\":\"value1\", \"property2\":42 } }";

            NotificationOutcome outcome = await Hub.SendFcmNativeNotificationAsync(notif);
            HttpStatusCode ret = HttpStatusCode.InternalServerError;
            if (outcome != null)
            {
                if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
                    (outcome.State == NotificationOutcomeState.Unknown)))
                {
                    ret = HttpStatusCode.OK;
                }
            }
            return ret;

        }

        //public async Task<HttpStatusCode> sendAlarm(AlarmPostModel alarm)
        //{
        //    var notif = " { \"notification\":{ \"title\":\"ALARM\", \"body\": \"" + alarm.AlarmText + "\" }, \"data\":{ \"property1\":\"value1\", \"property2\":42 } }";
        //    var privateKeys = from u in userContext.Users
        //                      where alarm.Recipients.Contains(u.DeviceImei)
        //                      select u.PrivateKey;

        //    var tag = "$InstallationId:{joe93developer}";

        //    NotificationOutcome outcome = await Hub.SendFcmNativeNotificationAsync(notif, tag);
        //    HttpStatusCode ret = HttpStatusCode.InternalServerError;
        //    if (outcome != null)
        //    {
        //        if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
        //            (outcome.State == NotificationOutcomeState.Unknown)))
        //        {
        //            ret = HttpStatusCode.OK;
        //        }
        //    }
        //    return ret;
        //}
    }
}
