using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Security.Cryptography;
using VotacaoAlterData.Domain;
using VotacaoAlterData.Domain.Entity;
using VotacaoAlterData.WebAPI.Dtos;

namespace VotacaoAlterData.WebAPI.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.UserName, opt =>
                {
                    opt.MapFrom(src => src.Email);
                });


            CreateMap<User, UserLoginDto>()
                .ReverseMap();

            CreateMap<Recurso, RecursoDto>()
                .ReverseMap();

            CreateMap<RecursoUser, RecursoUserDto>()
             .ReverseMap();

            CreateMap<ItemRecursoDto, ItemRecurso>();

            CreateMap<ItemRecurso, ItemRecursoDto>()
                .AfterMap((src, dest) =>
                {
                    if (dest.Votado)
                    {
                        dest.Active = !dest.Votado;
                    }

                });

            CreateMap<ItemRecurso, ItemRecursoVotoDto>()
                .ForMember(dest => dest.Active, opt =>
                {
                    opt.MapFrom(src => true);
                })
                .ForMember(dest => dest.Votado, opt =>
                {
                    opt.MapFrom(src => true);
                });


            CreateMap<Voto, VotoDto>()
                   .ReverseMap();

        }
    }
}
