using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Api.Models.GetUser;
using Users.Domain.Entities;

namespace Users.Api.Mapping
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<User, UserDetailsModel>();
        }
    }
}
