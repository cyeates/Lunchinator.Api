﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunchinator.Data.Contracts;
using System.Data.Entity;
using System.Data;

namespace Lunchinator.Data
{
  public class EFRepository<T> : IRepository<T> where T : class
  {
    private readonly DbContext _context;
    private DbSet<T> _set;
    public EFRepository(DbContext context)
    {
      _context = context;
      _set = context.Set<T>();
    }

    public T GetById(int id)
    {
      return _set.Find(id);
    }

    public IQueryable<T> GetAll()
    {
      return _set;
    }

    public void Add(T entity)
    {
      var entry = _context.Entry(entity);
      if (entry.State == EntityState.Detached)
      {
        _set.Add(entity);
      }
      else
      {
        entry.State = EntityState.Added;
      }

    }

    public void Update(T entity)
    {
      var entry = _context.Entry(entity);
      if (entry.State == EntityState.Detached)
      {
        _set.Attach(entity);
      }
      
      entry.State = EntityState.Modified;
      
    }

    public void Delete(T entity)
    {
      var entry = _context.Entry(entity);
      if (entry.State != EntityState.Deleted)
      {
        entry.State = EntityState.Deleted;
      }
      else
      {
        _set.Attach(entity);
        _set.Remove(entity);
      }
    }
  }
}
