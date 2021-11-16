using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Entities
{
    public class RedeSocialEntity : BaseEntity
    {
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public EventoEntity Evento { get; set; }
        public int? PalestranteId { get; set; }
        public PalestranteEntity Palestrante { get; set; }
    }
}
