using ZolaApp.Models;
using ZolaApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using ModelShared;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Linq;

namespace ZolaApp.ViewModels
{
    public class HomeViewModel : MvvmHelpers.BaseViewModel
    {
        public ObservableRangeCollection<UserShare> Users { get; set; }
        public ObservableRangeCollection<RecentMessage> RecentChat { get; set; }

        public AsyncCommand<RecentMessage> DetailCommand { get; set; }
        public HomeViewModel()
        {
            User userLogin = App.myUserLogin;
            Users = new ObservableRangeCollection<UserShare>();
            RecentChat = new ObservableRangeCollection<RecentMessage>();
            LoadData(userLogin);

            DetailCommand = new AsyncCommand<RecentMessage>(OnNavigate);
        }

        public async void LoadData(User user)
        {
            MessageService _msg = new MessageService();

            var listFriend = await _msg.GetMutual(user);

            var lstFriend = JsonConvert.DeserializeObject<List<MutualFriend>>(listFriend);

            if(lstFriend.Count > 0)
            {                
                foreach (var item in lstFriend)
                {
                    Users.Add(item.UserInfo);
                    string time = "";
                    if(item.SentTime.Subtract(DateTime.Now).TotalDays == 0)
                    {
                        time = item.SentTime.TimeOfDay.ToString("HH:mm");
                    }
                    else if(item.SentTime.Subtract(DateTime.Now).TotalDays > 365)
                    {
                        time = item.SentTime.Date.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        time = item.SentTime.Date.ToString("dd/MM");
                    }
                    RecentMessage msg = new RecentMessage()
                    {
                        Sender = item.UserInfo,
                        Text = item.LastMsg,
                        Time = time,
                        ConversationID = item.Id
                    };
                    RecentChat.Add(msg);
                }
            }
        }

        async Task OnNavigate(RecentMessage recent)
        {
            if (recent == null)
                return;

            App.ConversationID = recent.ConversationID;
            App.Sender = recent.Sender;

            var route = $"Message?Name={recent.Sender.Lastname + " " + recent.Sender.Firstname}";
            await Shell.Current.GoToAsync(route);
        }
    }
}