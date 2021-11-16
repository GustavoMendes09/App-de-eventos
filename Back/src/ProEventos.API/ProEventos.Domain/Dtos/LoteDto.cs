using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public EventoDto Evento { get; set; }
    }
}
