using MobEye.Models;
using System;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobEye.Services;
using MobEye.Resources;
using System.Globalization;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithCode : ContentPage
    {
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;
        private RegistrationAndAuthorizationService registrationAndAuthorizationService;

        public LoginWithCode()
        {
            InitializeComponent();
            registrationAndAuthorizationService = new RegistrationAndAuthorizationService();
        }

        /// <summary>
        /// Async method to handle the user login (user 2 and user 3)
        /// Will send a POST request to api
        /// Mobeye will authenticate user and response back with a private key to use for every future POST requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SignIn(object sender, EventArgs e)
        {
            SecureStorage.Remove("role");
            String code = Entry_Code.Text;

            if(code == "")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID..ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID..ToString());
                Application.Current.Properties["phoneCode"] = code;
                Application.Current.Properties["phoneId"] = "";
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));
                
                if(await SecureStorage.GetAsync("role") == "Account")
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else if (code == "")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID..ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID..ToString());
                Application.Current.Properties["phoneCode"] = code;
                Application.Current.Properties["phoneId"] = "";
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                if (await SecureStorage.GetAsync("role") == "Account")
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else if (code == "")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID..ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID..ToString());
                Application.Current.Properties["phoneCode"] = code;
                Application.Current.Properties["phoneId"] = "";
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                if (await SecureStorage.GetAsync("role") == "Standard")
                {
                    await Navigation.PushAsync(new AlarmPage());
                }
            }
            else if (code == "")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID..ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID..ToString());
                Application.Current.Properties["phoneCode"] = code;
                Application.Current.Properties["phoneId"] = "";
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                if (await SecureStorage.GetAsync("role") == "Standard")
                {
                    await Navigation.PushAsync(new DoorPage());
                }
            }
            else if (code == "")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID..ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID..ToString());
                Application.Current.Properties["phoneCode"] = code;
                Application.Current.Properties["phoneId"] = "";
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));

                if (await SecureStorage.GetAsync("role") == "Standard")
                {
                    await Navigation.PushAsync(new AlarmPage());
                }
            }
            else
            {
                await DisplayAlert("Error", "Please enter the correct code", "Close");
            }
        }

        /// <summary>
        /// Method to get a new code?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResendCode(object sender, EventArgs e)
        {
            DisplayAlert("Code resent", "Your code has been resend, it could take up to 5 minutes to arrive!", "Close");
        }


        /// <summary>
        /// Method to open login page (with an mobeye account)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginMobeye(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginWithMobeyeAccount());
        }

        /// <summary>
        /// Method to change language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ChangeLanguage(object sender, EventArgs args)
        {
            Picker languageSelect = (Picker)sender;

            int language = languageSelect.SelectedIndex;

            switch (language)
            {
                case 0:
                    AppResources.Culture = new CultureInfo("en");
                    Navigation.PushAsync(new LoginWithCode());
                    break;
                case 1:
                    AppResources.Culture = new CultureInfo("fr");
                    Navigation.PushAsync(new LoginWithCode());
                    break;
                case 2:
                    AppResources.Culture = new CultureInfo("nl");
                    Navigation.PushAsync(new LoginWithCode());
                    break;
                case 3:
                    AppResources.Culture = new CultureInfo("de");
                    Navigation.PushAsync(new LoginWithCode());
                    break;

            }
        }
    }
}