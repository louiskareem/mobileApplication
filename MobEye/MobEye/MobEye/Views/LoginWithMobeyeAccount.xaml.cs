using MobEye.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithMobeyeAccount : ContentPage
    {
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;

        public LoginWithMobeyeAccount()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Async method to handle the user login with an mobeye account (user 1)
        /// Will send a POST request to api 
        /// Mobeye will authenticate user and response back with a private key to use for every future POST requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void SignIn(object sender, EventArgs e)
        {
            List<Models.Device> devices = new List<Models.Device>();

            // set up the http objects
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (s, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(clientHandler);

            try
            {
                User user = new User(Entry_Username.Text, Entry_Username.Text, Role.Account, devices);

                // send request to api and wait for response
                var url = "";
                var jsonData = new StringContent(JsonConvert.SerializeObject("username" + Entry_Username.Text + "password" + Entry_Password.Text), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, jsonData);

                // if response successful then save private ket locally
                // then show a popup (display alert) with result before goin to homepage
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    await SecureStorage.SetAsync("private_key", result);
                    await DisplayAlert("Successful", result, "Close");
                    await Navigation.PushAsync(new AlarmPage());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}