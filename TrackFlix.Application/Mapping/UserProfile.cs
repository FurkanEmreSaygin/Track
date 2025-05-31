using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TrackFlix.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.User, DTOs.UserDto>();
            CreateMap<DTOs.CreateUserDto, Domain.User>();
            CreateMap<DTOs.UpdateUserDto, Domain.User>()
                .ForAllMembers(opt => opt.Condition((src, dest, member) => member != null));
        }
    }
}