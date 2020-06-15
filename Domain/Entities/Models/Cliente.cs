using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public class Cliente : Entity
    {
        public string Nome  { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
