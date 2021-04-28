using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobEye.Views;
using Xamarin.Essentials;
using System.Windows.Input;

namespace MobEye
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BindingContext = this;

            MainPage = new NavigationPage(new LoginWithCode());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
