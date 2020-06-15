using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GBastos.Conspiracao.ViewModels;
using Domain.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Models;

namespace GBastos.Conspiracao.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRep repository;
        private readonly IMapper mapper;

        public ClienteController(IClienteRep _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<IEnumerable<ClienteViewModel>>(await repository.Get_All()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = await ObterClientesPorProduto(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = mapper.Map<Cliente>(clienteViewModel);
            await repository.Add(cliente);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await ObterClientePorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = mapper.Map<Cliente>(clienteViewModel);
            await repository.UpDate(cliente);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await ObterClientePorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clienteViewModel = await ObterClientePorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            await repository.Remove(id);

            return RedirectToAction("Index");
        }

        //private bool ClienteViewModelExists(Guid id)
        //{
        //    return repository.ClienteViewModel.Any(e => e.Id == id);
        //}

        private async Task<ClienteViewModel> ObterClientePorId(Guid id)
        {
            return mapper.Map<ClienteViewModel>(await repository.Get_ById(id));
        }

        private async Task<ClienteViewModel> ObterClientesPorProduto(Guid id)
        {
            return mapper.Map<ClienteViewModel>(await repository.ObterPorProduto(id));
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProduto(Guid id)
        {
            return (IEnumerable<ProdutoViewModel>)mapper.Map<ProdutoViewModel>(await repository.ObterProdutos(id));
        }
    }
}
