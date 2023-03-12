using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ModelShared
{
    public class UserShare
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Bio { get; set; }       
        public string ProfilePic { get; set; }
        public int IsOnline { get; set; }
    }
}
