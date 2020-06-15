using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GBastos.Conspiracao.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo precisa de ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public ClienteViewModel Cliente { get; set; }

        [HiddenInput]
        public Guid ClienteId { get; set; }
    }
}
