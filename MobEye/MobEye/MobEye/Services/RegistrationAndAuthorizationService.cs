using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MobEye.Requests;
using MobEye.Responses;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using MobEye.Models;

namespace MobEye.Services
{
    class RegistrationAndAuthorizationService
    {
        private HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public RegistrationAndAuthorizationService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }

        /// <summary>
        /// Post method to register device 
        /// </summary>
        /// <param name="phoneID"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<String> Register(String phoneID, String code)
        {
            Uri uri = new Uri(String.Format(""));

            try
            {
                RegistrationRequest registrationRequest = new RegistrationRequest(phoneID, code);

                string json = JsonConvert.SerializeObject(registrationRequest);

                StringContent registrationContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, registrationContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    string jsonString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                    String privateKey = JsonConvert.DeserializeObject<RegistrationResponse>(jsonString).PrivateKey;

                    await SecureStorage.SetAsync("private_key", privateKey);

                    return privateKey;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return ex.ToString();
            }
        }

        /// <summary>
        /// Post method to get authorizations
        /// </summary>
        /// <param name="phoneId"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public async Task<String> Authorization(String phoneId, String privateKey)
        {
            Uri uri = new Uri(String.Format(""));
            await SecureStorage.SetAsync("device", "");

            try
            {
                AuthorizationRequest authorizationRequest = new AuthorizationRequest(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                string json = JsonConvert.SerializeObject(authorizationRequest);

                StringContent authContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, authContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    var jsonString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                    List<Device> devices = new List<Device>();

                    JObject jObject = JObject.Parse(jsonString);

                    String responseUserRole = (string)jObject["UserRole"];

                    await SecureStorage.SetAsync("role", responseUserRole);

                    String responsePrivateKey = (string)jObject["PrivateKey"];

                    Device device = new Device();

                    if (jObject["Devices"].First["DeviceId"] != null)
                    {
                        
                        device.ID = (int)jObject["Devices"].First["DeviceId"];

                        device.DeviceName = (string)jObject["Devices"].First["DeviceName"];

                        device.CommandText = (string)jObject["Devices"].First["CommandText"];

                        if ((String)jObject["Devices"].First["Command"] == Command.DO1.ToString())
                        {
                            device.Command = Command.DO1;
                        }

                        await SecureStorage.SetAsync("device", device.ID.ToString());
                        await SecureStorage.SetAsync("door_status", "Opened");
                        devices.Add(device);
                    }
                   
                    AuthorizationResponse response1 = new AuthorizationResponse(responseUserRole, responsePrivateKey, devices);
                    return response1.ToString();
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
