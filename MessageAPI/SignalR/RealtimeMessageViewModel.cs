using MessageAPI.Interfaces;
using MessageAPI.Models;
using System;

namespace MessageAPI.SignalR
{
    /// <summary>
    /// Message for SignalR
    /// </summary>
    public class RealtimeMessageViewModel : IRealTimeMessage
    {
        public string Text { get; }
        public object Data { get; }
        public RealtimeMessageViewModel(Message message)
        {
            Text = "created";
            Data = new MessageEventViewModel
            {
                Date = message.SendOn,
                Text = message.Text,
                Number = message.Number
            };
        }

        private class MessageEventViewModel
        {
            public DateTime Date { get; set; }
            public string Text { get; set; }
            public int Number { get; set; }
        }
    }
}
