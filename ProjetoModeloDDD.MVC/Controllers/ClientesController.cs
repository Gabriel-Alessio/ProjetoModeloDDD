using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.Controllers
{
  public class ClientesController : Controller
  {
    private readonly IMapper _mapper;
    private readonly IClienteAppService _clienteAppService;

    public ClientesController(IMapper mapper, IClienteAppService clienteAppService)
    {
      _mapper = mapper;
      _clienteAppService = clienteAppService;
    }

    // GET: ClientesController1
    public ActionResult Index()
    {
      var clienteModel = _mapper.Map<IEnumerable<Cliente> , IEnumerable<ClienteModel>>(_clienteAppService.GetAll());
      return View(clienteModel);
    }

    public ActionResult Especiais()
    {
      var clienteModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(_clienteAppService.ObterClientesEspeciais());
      return View(clienteModel);
    }
  

    // GET: ClientesController1/Details/5
    public ActionResult Details(int id)
    {
      var cliente = _clienteAppService.GetById(id);
      var clienteModel = _mapper.Map<Cliente, ClienteModel>(cliente);
      return View(clienteModel);
    }

    // GET: ClientesController1/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: ClientesController1/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ClienteModel model)
    {
      if (ModelState.IsValid)
      {
        var cliente = _mapper.Map<ClienteModel, Cliente>(model);
        _clienteAppService.Add(cliente);

        return RedirectToAction("Index");
      }

      return View(model);
    }

    // GET: ClientesController1/Edit/5
    public ActionResult Edit(int id)
    {
      var cliente = _clienteAppService.GetById(id);
      var clienteModel = _mapper.Map<Cliente, ClienteModel>(cliente);
      return View(clienteModel);
    }

    // POST: ClientesController1/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ClienteModel model)
    {
      if (ModelState.IsValid)
      {
        var cliente = _mapper.Map<ClienteModel, Cliente>(model);
        _clienteAppService.Update(cliente);

        return RedirectToAction("Index");
      }

      return View(model);
    }

    // GET: ClientesController1/Delete/5
    public ActionResult Delete(int id)
    {
      var cliente = _clienteAppService.GetById(id);
      var clienteModel = _mapper.Map<Cliente, ClienteModel>(cliente);
      return View(clienteModel);
    }

    // POST: ClientesController1/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      var cliente = _clienteAppService.GetById(id);
      _clienteAppService.Remove(cliente);

      return RedirectToAction("Index");
    }
  }
}
