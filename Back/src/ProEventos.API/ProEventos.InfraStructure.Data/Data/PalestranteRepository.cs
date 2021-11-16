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
    public class PalestranteRepository : BaseRepository<PalestranteEntity>, IPalestrantesRepository
    {
        private DbSet<PalestranteEntity> dataset;
        public PalestranteRepository(DataContext context) : base(context)
        {
            this.dataset = context.Set<PalestranteEntity>();
            // para não travar a tabela quando fazer o get
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<PalestranteEntity>> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<PalestranteEntity> query = dataset
                .Include(p => p.RedesSociais);

            if (includeEventos)
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);


            query = query.OrderBy(p => p.Id);

            return await query.ToListAsync();

        }

        public async Task<PalestranteEntity> GetAllPalestranteByIdAsync(int palestranteId, bool includePalestrantes = false)
        {
            IQueryable<PalestranteEntity> query = dataset
                 .Include(p => p.RedesSociais);

            if (includePalestrantes)
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.OrderBy(e => e.Id).Where(e => e.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PalestranteEntity>> GetAllPalestrantesByNameAsync(string nome, bool includePalestrantes = false)
        {
            IQueryable<PalestranteEntity> query = dataset
                 .Include(p => p.RedesSociais);

            if (includePalestrantes)
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query
                .OrderBy(p => p.Id)
                .Where(p => p.Nome.ToLower()
                .Contains(nome.ToLower()));

            return await query.ToListAsync();
        }
    }
}
