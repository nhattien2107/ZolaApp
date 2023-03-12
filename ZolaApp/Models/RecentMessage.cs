using ModelShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZolaApp.Models
{
    public class RecentMessage
    {
        public UserShare Sender { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
        public int ConversationID { get; set; }
    }
}
