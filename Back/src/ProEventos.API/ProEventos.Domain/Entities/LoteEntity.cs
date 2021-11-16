using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Entities
{
    public class LoteEntity : BaseEntity
    {
        public string Name { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public EventoEntity Evento { get; set; }
    }
}
