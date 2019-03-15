using AutoMapper;
using DMGM.Api.Dtos;
using DMGM.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMGM.Api.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForLoginListDto>();
            CreateMap<User, UserForDetailedDto>();

            CreateMap<UserForRegisterDto, User>();
        }
    }
}
