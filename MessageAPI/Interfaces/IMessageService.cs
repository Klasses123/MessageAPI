using MessageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllForLastTenMin();
        Task<Message> CreateMessage(Message msg);
    }
}
