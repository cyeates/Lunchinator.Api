using Lunchinator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Contracts
{
  public interface IUnitOfWork
  {
    void Commit();

    IRepository<Lunch> Lunches { get; }
    IRepository<User> Users { get; }


  }
}
