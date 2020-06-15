using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GBastos.Conspiracao.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "Este campo precisa de ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
