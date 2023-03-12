using System;
using System.Collections.Generic;
using System.Text;

namespace ModelShared
{
    public class MessageShare
    {
        public int Id { get; set; }
        public string Message1 { get; set; }
        public int SenderId { get; set; }
        public string SentTime { get; set; }
        public int ConversationId { get; set; }

        public string SenderAvatar { get; set; }
    }
}
