using Domain.Entities.Models;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Services
{
    public class ClienteService : IServiceBase<Cliente>, IClienteServ
    {
        public void Add(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void UpDate(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
