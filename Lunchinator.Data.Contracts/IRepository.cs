using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Contracts
{
  public interface IRepository<T> where T: class
  {
    T GetById(int id);
    IQueryable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
  }
}
