using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces.Data
{
    public interface IEventosRepository : IBaseRepository<EventoEntity>
    {
        Task<IEnumerable<EventoEntity>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<IEnumerable<EventoEntity>> GetAllEventosAsync(bool includePalestrantes);
        Task<EventoEntity> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
    }
}
