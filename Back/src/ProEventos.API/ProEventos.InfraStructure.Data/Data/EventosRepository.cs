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
    public class EventosRepository : BaseRepository<EventoEntity>, IEventosRepository
    {
        private DbSet<EventoEntity> dataset;
        public EventosRepository(DataContext context) : base(context)
        {
            this.dataset = context.Set<EventoEntity>();
            // para não travar a tabela quando fazer o get
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<EventoEntity>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<EventoEntity> query = dataset
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();

        }

        public async Task<EventoEntity> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<EventoEntity> query = dataset
                 .Include(e => e.Lotes)
                 .Include(e => e.RedesSociais);

            if (includePalestrantes)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EventoEntity>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<EventoEntity> query = dataset
                 .Include(e => e.Lotes)
                 .Include(e => e.RedesSociais);

            if (includePalestrantes)
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToListAsync();
        }
    }
}
