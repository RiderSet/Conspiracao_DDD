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
    public class ProdutoController : Controller
    {
        private readonly IProdutoRep repository;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoRep _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<IEnumerable<ProdutoViewModel>>(await repository.Get_All()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var ProdutoViewModel = await ObterProdutosPorCliente(id);
            if (ProdutoViewModel == null)
            {
                return NotFound();
            }
            return View(ProdutoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel ProdutoViewModel)
        {
            if (!ModelState.IsValid) return View(ProdutoViewModel);

            var Produto = mapper.Map<Produto>(ProdutoViewModel);
            await repository.Add(Produto);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ProdutoViewModel = await ObterProdutoPorId(id);
            if (ProdutoViewModel == null)
            {
                return NotFound();
            }
            return View(ProdutoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel ProdutoViewModel)
        {
            if (id != ProdutoViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(ProdutoViewModel);

            var Produto = mapper.Map<Produto>(ProdutoViewModel);
            await repository.UpDate(Produto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var ProdutoViewModel = await ObterProdutoPorId(id);
            if (ProdutoViewModel == null)
            {
                return NotFound();
            }
            return View(ProdutoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ProdutoViewModel = await ObterProdutoPorId(id);
            if (ProdutoViewModel == null)
            {
                return NotFound();
            }
            await repository.Remove(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProdutoPorId(Guid id)
        {
            return mapper.Map<ProdutoViewModel>(await repository.Get_ById(id));
        }

        private async Task<ProdutoViewModel> ObterProdutosPorCliente(Guid id)
        {
            return mapper.Map<ProdutoViewModel>(await repository.ObterPorCliente(id));
        }
    }
}
