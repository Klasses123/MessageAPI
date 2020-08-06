using MessageAPI.Interfaces;
using MessageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Services
{
    /// <summary>
    /// Service for interaction with messages
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IBaseRepository<Message> _messageRepo;
        public MessageService(IBaseRepository<Message> messageRepo)
        {
            _messageRepo = messageRepo;
        }
        public Task<IEnumerable<Message>> GetAllForLastTenMin()
        {
            return Task.FromResult(
                _messageRepo.Get(m => m.SendOn <= DateTime.UtcNow 
                    && m.SendOn >= DateTime.UtcNow.AddMinutes(-10))
                .AsEnumerable());
        }

        public Task<Message> CreateMessage(Message msg)
        {
            msg.SendOn = DateTime.UtcNow;
            var res = _messageRepo.Create(msg);
            _messageRepo.Save();
            return Task.FromResult(res);
        }
    }
}
