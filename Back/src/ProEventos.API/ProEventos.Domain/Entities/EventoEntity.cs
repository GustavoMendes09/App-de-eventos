using System;
using System.Collections.Generic;

namespace ProEventos.Domain.Entities
{
    public class EventoEntity : BaseEntity
    {
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<LoteEntity> Lotes { get; set; }
        public IEnumerable<RedeSocialEntity> RedesSociais { get; set; }
        public IEnumerable<PalestranteEventoEntity> PalestranteEventos { get; set; }

    }
}
