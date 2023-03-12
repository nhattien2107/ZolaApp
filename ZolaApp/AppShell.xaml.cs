using System;
using Xamarin.Forms;
using ZolaApp.Views;

namespace ZolaApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Login",
                typeof(LoginPage));
            Routing.RegisterRoute("Register",
                typeof(RegisterPage));
            Routing.RegisterRoute("Chats", 
                typeof(ChatsPage)); 
            Routing.RegisterRoute("Message", 
                typeof(MessagePage));
        }

    }
}
