using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.Controllers
{
  public class ProdutosController : Controller
  {
    private readonly IMapper _mapper;
    private readonly IProdutoAppService _produtoAppService;
    private readonly IClienteAppService _clienteAppService;

    public ProdutosController(IMapper mapper, IProdutoAppService produtoAppService, IClienteAppService clienteAppService)
    {
      _mapper = mapper;
      _produtoAppService = produtoAppService;
      _clienteAppService = clienteAppService;
    }

    // GET: ProdutoController1
    public ActionResult Index()
    {
      var produtoModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(_produtoAppService.GetAll());
      return View(produtoModel);
    }

    // GET: ProdutoController1/Details/5
    public ActionResult Details(int id)
    {
      var produto = _produtoAppService.GetById(id);
      var produtoModel = _mapper.Map<Produto, ProdutoModel>(produto);
      return View(produtoModel);
    }

    // GET: ProdutoController1/Create
    public ActionResult Create()
    {
      ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome");
      return View();
    }

    // POST: ProdutoController1/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ProdutoModel model)
    {
      if (ModelState.IsValid)
      {
        var produto = _mapper.Map<ProdutoModel, Produto>(model);
        _produtoAppService.Add(produto);
        return RedirectToAction("Index");
      }
      ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome", model.ClienteId);
      return View(model);
    }

    // GET: ProdutoController1/Edit/5
    public ActionResult Edit(int id)
    {
      var produto = _produtoAppService.GetById(id);
      var produtoModel = _mapper.Map<Produto, ProdutoModel>(produto);

      ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome", produtoModel.ClienteId);
      return View(produtoModel);
    }

    // POST: ProdutoController1/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ProdutoModel model)
    {
      if (ModelState.IsValid)
      {
        var produto = _mapper.Map<ProdutoModel, Produto>(model);
        _produtoAppService.Update(produto);
        return RedirectToAction("Index");
      }
      ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome", model.ClienteId);
      return View(model);
    }

    // GET: ProdutoController1/Delete/5
    public ActionResult Delete(int id)
    {
      var produto = _produtoAppService.GetById(id);
      var produtoModel = _mapper.Map<Produto, ProdutoModel>(produto);
      return View(produtoModel);
    }

    // POST: ProdutoController1/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      var produto = _produtoAppService.GetById(id);
      _produtoAppService.Remove(produto);
      return RedirectToAction("Index");
    }
  }
}
