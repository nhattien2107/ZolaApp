using ZolaApp.Models;
using Xamarin.Forms;
using ModelShared;

namespace ZolaApp.Views.Templates
{
    internal class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SenderMessageTemplate { get; set; }
        public DataTemplate ReceiverMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = (MessageShare)item;

            if (message.SenderId == App.myUserLogin.Id)
                return ReceiverMessageTemplate;

            return SenderMessageTemplate;
        }
    }
}