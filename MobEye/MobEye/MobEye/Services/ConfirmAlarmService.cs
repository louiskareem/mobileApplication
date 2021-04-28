using MobEye.Requests;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobEye.Services
{
    public class ConfirmAlarmService
    {
        private HttpClient client;

        public ConfirmAlarmService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }

        /// <summary>
        /// Method to send post request to mobeye
        /// POST request to confirm an alarm and remove alarm after confirmed
        /// </summary>
        /// <param name="phoneID"></param>
        /// <param name="messageID"></param>
        /// <param name="responseText"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public async Task<String> ConfirmAlarm(String phoneID, int messageID, String responseText, String privateKey)
        {
            Uri uri = new Uri(String.Format(""));

            try
            {
                ConfirmAlarmRequest registrationRequest = new ConfirmAlarmRequest(phoneID, messageID, responseText, privateKey);

                string json = JsonConvert.SerializeObject(registrationRequest);

                StringContent registrationContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, registrationContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    string jsonString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                    String postResponse = JsonConvert.DeserializeObject<String>(jsonString);

                    return postResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }
    }
}
