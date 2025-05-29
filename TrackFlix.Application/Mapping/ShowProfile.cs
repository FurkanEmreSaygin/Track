using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackFlix.Domain;
using AutoMapper;
using TrackFlix.Application.DTOs;
using AutoMapper.Execution;

namespace TrackFlix.Application.Mapping
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<Show, ShowDto>();
            CreateMap<CreateShowDto, Show>();
            CreateMap<UpdateShowDto, Show>().ForAllMembers(opt => opt.Condition((src, dest, member) => member != null));
        }
    }
}