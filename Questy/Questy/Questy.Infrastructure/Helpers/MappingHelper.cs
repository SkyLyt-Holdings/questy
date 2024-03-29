﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Questy.Domain.Entities;
using Questy.Infrastructure.DTOs.Quest;
using Questy.Infrastructure.DTOs.User;
using Questy.Infrastructure.DTOs.Tag;
using Questy.Infrastructure.DTOs.Archetype;

namespace Questy.Infrastructure.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<User, UserResponseDTO>()
            .ForMember(d => d.UserType, m => m.MapFrom(s => s.UserType.Description));
            CreateMap<Quest, QuestDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Archetype, ArchetypeDTO>().ReverseMap();
        }
    }
}