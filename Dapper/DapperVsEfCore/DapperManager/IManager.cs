using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperVsEfCore.DapperManager
{
    public interface IManager<T>
    {
        List<T> GetAll();
        T? GetById(long id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(long id);
    }
}
