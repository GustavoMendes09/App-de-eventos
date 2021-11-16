using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProEventos.Domain.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio"),
         StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres")]
        public string Tema { get; set; }
        [Display(Name = "Qtd Pessoas"), 
         Range(1,120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]
        public int QtdPessoas { get; set; }
        [RegularExpression(@".*\.(jpg|bmp|png|gif)$", ErrorMessage = "não é uma imagem valida.")]
        public string ImagemUrl { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio"),
         Phone(ErrorMessage = "O campo {0} esta com numero invalido")]
        public string Telefone { get; set; }
        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O campo {0} é obrigatorio"),
         EmailAddress(ErrorMessage = "É necessário ser um {0} válido")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> PalestranteEventos { get; set; }
    }
}
