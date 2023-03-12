using Xamarin.Forms;

namespace ZolaApp.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Bio { get; set; }
        public int NumOfConvs { get; set; }
        public int NumOfMess { get; set; }
        public string ProfilePic { get; set; }
        public int? IsOnline { get; set; }
    }
}