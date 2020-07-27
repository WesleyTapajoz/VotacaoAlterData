using AutoMapper;
using System;
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

            CreateMap<Recurso, RecursoDto>().ReverseMap();

            //CreateMap<RecursoDto, Recurso> ()
            //    .ForMember(dest => dest.DataCadastro, opt =>
            //    {
            //        opt.MapFrom(src => DateTime.Now);
            //    });

            CreateMap<ItemRecurso, ItemRecursoDto>().ReverseMap();


            //CreateMap<ItemRecursoDto, ItemRecurso>()
            // .ForMember(dest => dest.DataCadastro, opt =>
            // {
            //     opt.MapFrom(src => DateTime.Now);
            // });


            CreateMap<Voto, VotoDto>()
           .ReverseMap();

        }
    }
}
