using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Data.Interface
{
    public interface ICrudRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<bool> Save(T t);
        bool Update(T t);
        bool Delete(int id);
    }
}