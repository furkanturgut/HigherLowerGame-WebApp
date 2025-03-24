using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CountryDtos;
using api.Dtos.LeagueDto;
using api.Dtos.PlayerDtos;
using api.Dtos.TeamDtos;
using api.Models;
using AutoMapper;

namespace api.Helpers
{
   public class MappingProfiles : Profile
   {
        public MappingProfiles() 
        {
           CreateMap<Player, GetPlayerDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName));
            CreateMap<CreatePlayerDto, Player>().ReverseMap();
            CreateMap<UpdatePlayerDto, Player>()
            .ForMember(dest=> dest.Country , opt=> opt.Ignore())
            .ForMember(dest=> dest.Team, opt => opt.Ignore());
            CreateMap<GetCountryDto, Country>().ReverseMap();
            CreateMap<CreateCountryDto, Country>().ReverseMap();
            CreateMap<UpdateCountryDto, Country>().ReverseMap();
            CreateMap<League, GetLeagueDto>().ForMember(dest=> dest.CountryName, opt=> opt.MapFrom(src=> src.country.CountryName)).ForMember(dest => dest.Teams, opt => opt.MapFrom(src=> src.Teams));
            CreateMap<League, CreateLeagueDto>().ReverseMap();
            CreateMap<League, UpdateLeagueDto>().ReverseMap();
            CreateMap<Team, GetTeamDto>()
            .ForMember(dest=> dest.LeagueName, opt=> opt.MapFrom(opt=> opt.League.LeagueName))
            .ForMember(dest=> dest.players ,opt => opt.MapFrom(opt=> opt.Players));
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();
         }
   }
}