using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Dtos
{
    public class RedeSocialDto
    {
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public EventoDto Evento { get; set; }
        public int? PalestranteId { get; set; }
        public PalestranteDto Palestrante { get; set; }
    }
}
