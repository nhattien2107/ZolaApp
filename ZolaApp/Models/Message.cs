using System;

namespace ZolaApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Message1 { get; set; }
        public int SenderId { get; set; }
        public DateTime SentTime { get; set; }
        public int ConversationId { get; set; }
    }
}