using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoAulas.App.ViewModels;
using ProjetoAulas.Business.Interfaces;
using ProjetoAulas.Business.Models;

namespace ProjetoAulas.App.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [Route("lista-de-categoria")]

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos()));
        }

        [Route("dados-da-categoria")]

        public async Task<IActionResult> Details(Guid id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        [Route("nova-categoria")]

        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {

            if (!ModelState.IsValid) return View(categoriaViewModel);

            await _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return RedirectToAction("Index");

        }

        [Route("editar-categoria")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var categoriaViewModel = await ObterCategoriaProdutos(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);

        }

        [Route("editar-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaViewModel);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);

            await _categoriaRepository.Alterar(categoria);

            return RedirectToAction("Index");
        }

        [Route("excluir-categoria/{id:guid}")]

        public async Task<IActionResult> Delete(Guid id)
        {

            var categoriaViewModel = await ObterCategoriaProdutos(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);

        }


        [Route("excluir-categoria{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProdutos(id);
            if (categoriaViewModel == null) return NotFound();

            await _categoriaRepository.Remover(id);
            return RedirectToAction("Index");
        }


        private async Task<CategoriaViewModel> ObterCategoria(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));

        }

        private async Task<CategoriaViewModel> ObterCategoriaProdutos(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterCategoriaProdutos(id));

        }


    }
}
