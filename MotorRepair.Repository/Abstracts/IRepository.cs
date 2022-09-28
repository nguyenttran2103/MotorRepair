using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Repository.Abstracts
{
  public interface IRepository<T>
  {
    public Task<T> Create(T entity);
    public Task<T> Update(T entity);
    public Task<int> Delete(int id);
    public Task<T> GetById(int id);
    public Task<IEnumerable<T>> GetAll();
  }
}
