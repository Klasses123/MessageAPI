using AutoMapper;
using MessageAPI.Interfaces;
using MessageAPI.Models;
using MessageAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController
    {
        private IMessageService MessageService { get; }
        private IMapper Mapper { get; }
        public MessageController(IMapper mapper,
            IMessageService messageService)
        {
            MessageService = messageService;
            Mapper = mapper;
        }

        [HttpGet("allForLastTenMin")]
        public async Task<ActionResult<string>> GetAllForLastTenMin()
        {
            return new JsonResult(
                Mapper.Map<IEnumerable<Message>>(
                    await MessageService.GetAllForLastTenMin()));
        }

        [HttpPost("sendMessage")]
        public async Task<ActionResult<string>> Send([FromBody] MessageViewModel msg)
        {
            return new JsonResult(
                Mapper.Map<MessageViewModel>(
                    await MessageService.CreateMessage(
                        Mapper.Map<Message>(msg))));
        }
    }
}
