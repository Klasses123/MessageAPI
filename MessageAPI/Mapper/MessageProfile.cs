using AutoMapper;
using MessageAPI.Models;
using MessageAPI.ViewModels;

namespace MessageAPI.Mapper
{
    /// <summary>
    /// Class for mapping messages
    /// </summary>
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageViewModel, Message>()
                .ForMember(set => set.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(set => set.Text, opt => opt.MapFrom(src => src.Text))
                .IncludeAllDerived();

            CreateMap<Message, MessageViewModel>()
                .ForMember(set => set.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(set => set.Text, opt => opt.MapFrom(src => src.Text))
                .IncludeAllDerived();
        }
    }
}
