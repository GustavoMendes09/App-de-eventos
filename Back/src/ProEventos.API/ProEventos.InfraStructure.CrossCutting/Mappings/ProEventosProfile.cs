using AutoMapper;
using ProEventos.Domain.Dtos;
using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.CrossCutting.Mappings
{
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<EventoEntity, EventoDto>().ReverseMap();
            CreateMap<LoteEntity, LoteDto>().ReverseMap();
            CreateMap<RedeSocialEntity, RedeSocialDto>().ReverseMap();
            CreateMap<PalestranteEntity, PalestranteDto>().ReverseMap();
        }
    }
}
