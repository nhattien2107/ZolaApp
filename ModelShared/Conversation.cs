using System;
using System.Collections.Generic;
using System.Text;

namespace ModelShared
{
    public class Conversation
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int[] UserIds { get; set; }
        public MessageShare LastMessage { get; set; }
        public UserShare Peer { get; set; }

    }
}
