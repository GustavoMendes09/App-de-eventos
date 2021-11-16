using System;
using System.Collections.Generic;
using System.Text;

namespace ProEventos.Domain.Entities
{
    public class PalestranteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string MinuCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocialEntity> RedesSociais { get; set; }
        public IEnumerable<PalestranteEventoEntity> PalestranteEventos { get; set; }
    }
}
