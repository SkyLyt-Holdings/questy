using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Questy.Domain.Entities;
using Questy.Infrastructure.DTOs.User;

namespace Questy.Infrastructure.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<User, UserResponseDTO>()
            .ForMember(d => d.UserType, m => m.MapFrom(s => s.UserType.Description));
        }
    }
}
