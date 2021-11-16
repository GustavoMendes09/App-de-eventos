using ProEventos.Domain.Dtos;
using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces.Business
{
    public interface ILoteService
    {
        Task AddLotes(int eventoId, LoteDto model);
        Task<IEnumerable<LoteDto>> SaveLotes(int eventoId, IEnumerable<LoteDto> model);
        Task<bool> DeleteLote(int eventoId, int loteId);
        Task<IEnumerable<LoteDto>> GetLotesByEventoIdAsync(int eventoId);
        Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId);
    }
}
