using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZolaApp.Models;
using ZolaApp.Services;
using ZolaApp.Views;

namespace ZolaApp.ViewModels
{
    public class LoginViewModel : MvvmHelpers.BaseViewModel
    {
        public User User { get; set; }


        public AsyncCommand LoginCommand { get; set; }

        UserService _service = new UserService();

        public LoginViewModel()
        {
            Title = "Login Page";
            User = new User();

            LoginCommand = new AsyncCommand(Login);
        }

        async Task Login()
        {
            User.Username = "tien";
            User.Password = "123";
            var response = await _service.LoginAsync(User.Username, User.Password);
            if (!string.IsNullOrEmpty(response))
            {
                Response re = JsonConvert.DeserializeObject<Response>(response);
                if (re.StatusCode == "200")
                {
                    var userLogin = JsonConvert.DeserializeObject<User>(re.Message);

                    App.myUserLogin = userLogin;

                    await Shell.Current.GoToAsync("Chats");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", re.Message, "OK");
                }
            }
        }

    }
}
