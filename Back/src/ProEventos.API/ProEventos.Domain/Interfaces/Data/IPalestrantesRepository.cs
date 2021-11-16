using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces.Data
{
    public interface IPalestrantesRepository : IBaseRepository<PalestranteEntity>
    {
        Task<IEnumerable<PalestranteEntity>> GetAllPalestrantesByNameAsync(string name, bool includeEventos);
        Task<IEnumerable<PalestranteEntity>> GetAllPalestrantesAsync(bool includeEventos);
        Task<PalestranteEntity> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}
