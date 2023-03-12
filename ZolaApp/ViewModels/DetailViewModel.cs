using ZolaApp.Models;
using ZolaApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ModelShared;
using MvvmHelpers;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ZolaApp.ViewModels
{
    [QueryProperty("Name", "Name")]
    public class DetailViewModel : MvvmHelpers.BaseViewModel
    {
        string name;      
        public string Name { get => name; set => SetProperty(ref name, value); }

        string avatar;
        public string AvatarSender { get => avatar; set => SetProperty(ref avatar, value); }
        public ObservableRangeCollection<UserShare> Users { get; set; }
        public ObservableRangeCollection<MessageShare> Messages { get; set; }

        public DetailViewModel()
        {
           
            Users = new ObservableRangeCollection<UserShare>();
            Messages = new ObservableRangeCollection<MessageShare>();

            LoadMessage();
        }
        public async void LoadMessage()
        {
            MessageService _msg = new MessageService();

            var listMessage = await _msg.GetMessage(App.ConversationID);

            var lstMessage = JsonConvert.DeserializeObject<List<Message>>(listMessage);

            if(lstMessage.Count > 0)
            {
                foreach (var item in lstMessage)
                {
                    string time = "";
                    if (item.SentTime.Subtract(DateTime.Now).TotalDays == 0)
                    {
                        time = item.SentTime.TimeOfDay.ToString("HH:mm");
                    }
                    else if (item.SentTime.Subtract(DateTime.Now).TotalDays > 365)
                    {
                        time = item.SentTime.Date.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        time = item.SentTime.Date.ToString("dd/MM");
                    }
                    MessageShare msg = new MessageShare()
                    {
                        Id = item.Id,
                        Message1 = item.Message1,
                        SenderId = item.SenderId,
                        SentTime = time,
                        ConversationId = item.ConversationId
                    };
                    if(item.SenderId != App.myUserLogin.Id)
                    {
                        msg.SenderAvatar = App.Sender.ProfilePic;
                    }
                    Messages.Add(msg);  
                }
            }

        }

        public ICommand BackCommand => new Command(OnBack);

        async void OnBack()
        {
            await NavigationService.Instance.NavigateBackAsync();
        }
    }
}