using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using System;

namespace ProEventos.InfraStructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<LoteEntity> Lotes { get; set; }
        public DbSet<PalestranteEntity> Palestrantes { get; set; }
        public DbSet<PalestranteEventoEntity> PalestranteEventos { get; set; }
        public DbSet<RedeSocialEntity> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEventoEntity>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<EventoEntity>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PalestranteEntity>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
