using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
namespace SignLanguage
{
    public class AutoMapping :Profile
    {
        public AutoMapping()
        {
            CreateMap<Word, WordDto>();
            CreateMap<User, UserDto>();

        }
    }
}
