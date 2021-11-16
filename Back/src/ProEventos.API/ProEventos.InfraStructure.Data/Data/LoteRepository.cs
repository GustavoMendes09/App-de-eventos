using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.InfraStructure.Data.Data
{
    public class LoteRepository : BaseRepository<LoteEntity>, ILoteRepository
    {
        private DbSet<LoteEntity> dataset;
        public LoteRepository(DataContext context) : base(context)
        {
            this.dataset = context.Set<LoteEntity>();
            // para não travar a tabela quando fazer o get
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<LoteEntity> GetLoteByIdsAsync(int eventoId, int id)
        {
            IQueryable<LoteEntity> query = dataset
                .AsNoTracking()
                .Where(l => l.EventoId == eventoId && l.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LoteEntity>> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<LoteEntity> query = dataset
                .AsNoTracking()
                .Where(l => l.EventoId == eventoId);

            return await query.ToListAsync();
        }
    }
}
