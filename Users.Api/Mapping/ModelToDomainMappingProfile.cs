using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Api.Models.RegisterUser;
using Users.Domain.Commands.User;

namespace Users.Api.Mapping
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            CreateMap<NewUserModel, CreateUserCommand>();
        }
    }
}
