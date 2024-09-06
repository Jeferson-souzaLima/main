using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAulas.App.Data;
using ProjetoAulas.App.ViewModels;
using ProjetoAulas.Business.Interfaces;
using ProjetoAulas.Business.Models;

namespace ProjetoAulas.App.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IFornecedorRepository fornecedorRepository,
                                  ICategoriaRepository categoriaRepository,
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        [Route("dados-de-produto/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularCategoriasFornecedores(new ProdutoViewModel());

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularCategoriasFornecedores(produtoViewModel);
            if (!ModelState.IsValid) return View(produtoViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";

            if (!await UploadArquivo(produtoViewModel.ImageUpload, imgPrefixo))
            {
                return View(produtoViewModel);
            }

            produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImageUpload.FileName;

            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction("Index");

        }

        [Route("editar-produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            produtoViewModel = await PopularCategoriasFornecedores(produtoViewModel);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizacao = await ObterProdutoFornecedor(id);

            produtoViewModel = await PopularCategoriasFornecedores(produtoViewModel);

            produtoViewModel.Imagem = produtoAtualizacao.Imagem;


            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImageUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadArquivo(produtoViewModel.ImageUpload, imgPrefixo)) return View(produtoViewModel);

                produtoAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImageUpload.FileName;
            }

            produtoAtualizacao.Fornecedor = produtoViewModel.Fornecedor;
            produtoAtualizacao.FornecedorId = produtoViewModel.FornecedorId;
            produtoAtualizacao.Categoria = produtoViewModel.Categoria;
            produtoAtualizacao.CategoriaId = produtoViewModel.CategoriaId;

            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.Valor = produtoViewModel.Valor;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoRepository.Alterar(_mapper.Map<Produto>(produtoAtualizacao));

            return RedirectToAction("Index");
        }

        [Route("excluir-produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            await _produtoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProdutoFornecedor(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutosFornecedor(id));
        }

        private async Task<ProdutoViewModel> PopularCategoriasFornecedores(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produtoViewModel;
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length <= 0) return false;

            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(caminho))
            {
                ModelState.AddModelError(String.Empty, "Já existe um arquivo com este nome");
            }

            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
