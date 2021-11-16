using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces.Data
{
    public interface ILoteRepository : IBaseRepository<LoteEntity>
    {
        Task<IEnumerable<LoteEntity>> GetLotesByEventoIdAsync(int eventoId);
        Task<LoteEntity> GetLoteByIdsAsync(int eventoId, int id);
    }
}
