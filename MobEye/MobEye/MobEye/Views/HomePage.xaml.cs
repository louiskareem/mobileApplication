using MobEye.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        AlarmService alarmService = new AlarmService();

        public HomePage()
        {
            InitializeComponent();

            //alarmService.CheckForAlarms();
        }

        /// <summary>
        /// When app loaded
        /// </summary>
        protected override void OnAppearing() 
        {
            //Lbl_Device_Info.Text = "";
            //Lbl_Alarm_Info.Text = "";
        }


        /// <summary>
        /// Method to direct user to Mobeye's portal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPortal(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.mymobeye.eu/"));
        }

        /// <summary>
        /// Method to open alarm page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAlarmPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlarmPage());
        }

        /// <summary>
        /// Method to go to door page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoteControlPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DoorPage());
        }
    }
}
