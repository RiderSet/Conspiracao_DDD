using AutoMapper;
using Domain.Entities.Models;
using GBastos.Conspiracao.ViewModels;

namespace GBastos.Conspiracao.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
