using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZolaApp.Views
{
    [QueryProperty("Conversation_ID", "ConversationID")]
    public partial class MessagePage : ContentPage
    {
        public string Conversation_ID { get; set; }
        public MessagePage()
        {
            InitializeComponent();
        }
    }
}