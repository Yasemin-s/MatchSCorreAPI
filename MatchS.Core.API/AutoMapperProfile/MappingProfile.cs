using AutoMapper;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.AdvertDTO;
using MatchS.Core.Entity.DTO.CategoryDTO;
using MatchS.Core.Entity.DTO.CommentDTO;
using MatchS.Core.Entity.DTO.MessageDTO;
using MatchS.Core.Entity.DTO.ParticipantDTO;
using MatchS.Core.Entity.DTO.UserDTO;

namespace MatchS.Core.API.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AddUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<Advert, AddAdvertDTO>().ReverseMap();
            CreateMap<Advert, GetAdvertDTO>().ReverseMap();
            CreateMap<Advert, UpdateAdvertDTO>().ReverseMap();
            CreateMap<Advert, ListAdvertDTO>().ReverseMap();
            CreateMap<Category, AddCategoryDTO>().ReverseMap();
            CreateMap<Comment, AddCommentDTO>().ReverseMap();
            CreateMap<Comment, ListCommentDTO>().ReverseMap();
            CreateMap<Message, ListMessageDTO>().ReverseMap();
            CreateMap<Message, AddMessageDTO>().ReverseMap();
            CreateMap<Participant, ListParticipantDTO>().ReverseMap();
        }
    }
}