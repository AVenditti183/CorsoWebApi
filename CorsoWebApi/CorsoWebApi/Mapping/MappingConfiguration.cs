using AutoMapper;
using CorsoWebApi.DTO;
using CorsoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoWebApi.Mapping
{
    public static class MappingConfiguration
    {
        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
                { 
                    cfg.CreateMap<Biglietto, BigliettoDto>()
                        .ForMember(dst => dst.Evento,
                            opt => opt.MapFrom(src =>
                                src.Evento == null
                                    ? null
                                    : new EventoBigliettoDto
                                    {
                                        Id = src.Evento.Id,
                                        Nome = src.Evento.Nome,
                                        Data = src.Evento.Data
                                    }));

                    cfg.CreateMap<BigliettoDto, Biglietto>()
                        .ForMember(dst => dst.Evento,
                            opt => opt.MapFrom(src =>
                                src.Evento == null
                                    ? null
                                    : new Evento
                                    {
                                        Id = src.Evento.Id,
                                        Nome = src.Evento.Nome,
                                        Data = src.Evento.Data
                                    }));

                    cfg.CreateMap<Evento,EventoDto>();
                    cfg.CreateMap<EventoDto,Evento>();
                        });
                return configuration.CreateMapper();
        }
    }
}
