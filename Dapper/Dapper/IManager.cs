using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Demo
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
