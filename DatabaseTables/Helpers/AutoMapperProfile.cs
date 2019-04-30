using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTables.Dtos;
using DatabaseTables.Models;
using DatabaseTables.Helpers;
using DatabaseTables.Services;
using AutoMapper;

namespace DatabaseTables.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}