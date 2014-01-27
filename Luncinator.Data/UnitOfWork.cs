using Lunchinator.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunchinator.Data.Entities;

namespace Lunchinator.Data
{
  public class UnitOfWork : IUnitOfWork
  {

    private readonly LunchinatorContext _context;

    public UnitOfWork(LunchinatorContext context)
    {
      this._context = context;
    }

    public IRepository<Lunch> Lunches
    {
      get
      {
        return new EFRepository<Lunch>(_context);
      }
    }

    public IRepository<User> Users
    {
      get
      {
        return new EFRepository<User>(_context);
      }
    }

    public void Commit()
    {
      _context.SaveChanges();
    }
  }
}
