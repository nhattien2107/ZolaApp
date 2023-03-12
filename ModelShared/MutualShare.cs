using System;
using System.Collections.Generic;
using System.Text;

namespace ModelShared
{
    public class MutualShare
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MutualId { get; set; }
        public string LastMsg { get; set; }
        public int SenderId { get; set; }
        public DateTime SentTime { get; set; }
    }
}
