using MessageAPI.Interfaces;
using System;

namespace MessageAPI.Models
{
    public class Message : IDataModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime SendOn { get; set; }
        public string Text { get; set; }
    }
}
