using AutoMapper;
using CommanderMine.Dtos;
using CommanderMine.Models;

namespace CommanderMine.Profiles
{
    public class ReadProfile : Profile
    {
        public ReadProfile()
        {
            CreateMap<Command, CommandRead>();
             CreateMap<CommandCreate,Command>();
             CreateMap<CommandUpdate,Command>();
             CreateMap<Command,CommandUpdate>();
        }

    }
}