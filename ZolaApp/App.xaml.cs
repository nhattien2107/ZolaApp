using ModelShared;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using ZolaApp.Models;

namespace ZolaApp
{
    public partial class App : Application
    {
        public static User myUserLogin { get; set; }
        public static UserShare Sender { get; set; }
        public static int ConversationID { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
