using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.InfraStructure.Data.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext Context;
        private DbSet<T> dataset;
        public BaseRepository(DataContext context)
        {
            this.Context = context;
            this.dataset = Context.Set<T>();
        }

        
        public void Add(T entity)
        {
            dataset.Add(entity);
        }

        public void Update(T entity)
        {
            dataset.Update(entity);
        }

        public void Delete(T entity)
        {
            dataset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entityArray)
        {
            dataset.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync()) > 0;
        }

        
    }
}
