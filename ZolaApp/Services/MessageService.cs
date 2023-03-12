using ZolaApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using ModelShared;

namespace ZolaApp.Services
{
    public class MessageService
    {
        static MessageService _instance;

        public static MessageService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageService();

                return _instance;
            }
        }

        public async Task<string> GetMutual(User user)
        {
            string URL = "http://14.161.9.203:45500/api/MutualFriends/" + user.Id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetMessage(int ID_Conversation)
        {
            string URL = "http://14.161.9.203:45500/api/Messages/" + ID_Conversation;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}