using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZolaApp.Services
{
    public class UserService
    {
        public async Task<string> LoginAsync(string username, string password)
        {
            string URL = "http://14.161.9.203:45500/api/Users/Login/" + username + "," + password + "";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
