using System;

namespace Domain.Entities.Models
{
    public class Produto : Entity
    {
        public Guid clienteId { get; set; }
        public string Nome  { get; set; }
        public Cliente Cliente { get; set; }
    }
}
