using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Entities
{
    public class PalestranteEventoEntity
    {
        public string Nome { get; set; }
        public int PalestranteId { get; set; }
        public PalestranteEntity Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoEntity Evento { get; set; }
    }
}
