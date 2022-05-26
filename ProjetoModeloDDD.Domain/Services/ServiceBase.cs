﻿using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Services
{
  public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
  {
    private readonly IRepositoryBase<TEntity> _repositoryBase;

    public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
    {
      _repositoryBase = repositoryBase;
    }

    public void Add(TEntity obj)
    {
      _repositoryBase.Add(obj);
    }

    public void Dispose()
    {
      _repositoryBase.Dispose();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _repositoryBase.GetAll();
    }

    public TEntity GetById(int id)
    {
      return _repositoryBase.GetById(id);
    }

    public void Remove(TEntity obj)
    {
      _repositoryBase.Remove(obj);
    }

    public void Update(TEntity obj)
    {
      _repositoryBase.Update(obj);
    }
  }
}
