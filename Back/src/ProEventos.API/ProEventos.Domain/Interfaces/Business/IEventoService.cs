using ProEventos.Domain.Dtos;
using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces.Business
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEventos(int eventoId, EventoDto model);
        Task<bool> DeleteEvento(int eventoId);
        Task<IEnumerable<EventoDto>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<IEnumerable<EventoDto>> GetAllEventosAsync(bool includePalestrantes);
        Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
    }
}
