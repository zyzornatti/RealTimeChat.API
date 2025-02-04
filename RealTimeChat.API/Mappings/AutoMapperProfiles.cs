using AutoMapper;
using RealTimeChat.API.Models.Domain;
using RealTimeChat.API.Models.DTO;

namespace RealTimeChat.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //Auth
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<LoginDto, ApplicationUser>().ReverseMap();
            //Chat Room
            CreateMap<ChatRoomDto, ChatRoom>().ReverseMap();
            CreateMap<AddChatRoomRequestDto, ChatRoom>().ReverseMap();
        }
    }
}
