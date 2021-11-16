using AutoMapper;
using ProEventos.Domain.Dtos;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Business;
using ProEventos.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Business
{
    public class EventoService : IEventoService
    {
        private readonly IEventosRepository eventoRepository;
        private readonly IMapper mapper;
        public EventoService(IEventosRepository eventoRepository, IMapper mapper)
        {
            this.eventoRepository = eventoRepository;
            this.mapper = mapper;
        }

        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = mapper.Map<EventoEntity>(model);

                eventoRepository.Add(evento);

                if (await eventoRepository.SaveChangesAsync())
                    return mapper.Map<EventoDto>(await eventoRepository.GetEventoByIdAsync(evento.Id, false));

                return null;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEventos(int eventoId, EventoDto model)
        {
            try
            {
                var eventoById = await eventoRepository.GetEventoByIdAsync(eventoId, false);
                if (eventoById == null)
                    return null;

                var evento = mapper.Map<EventoEntity>(model);

                evento.AttId(eventoId);

                eventoRepository.Update(evento);

                if (await eventoRepository.SaveChangesAsync())
                    return mapper.Map<EventoDto>(await eventoRepository.GetEventoByIdAsync(evento.Id, false));

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await eventoRepository.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                    throw new Exception("Evento para delete não foi encontrado");

                eventoRepository.Delete(evento);

                return await eventoRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventoDto>> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                var eventos = await eventoRepository.GetAllEventosAsync(includePalestrantes);
                if (eventos == null)
                    return null;

                var result = mapper.Map<List<EventoDto>>(eventos);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventoDto>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null)
                    return null;

                var result = mapper.Map<List<EventoDto>>(eventos);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            try
            {
                var evento = await eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null)
                    return null;

                var result = mapper.Map<EventoDto>(evento);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
