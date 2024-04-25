using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepository<K, T>
    {
        T Add(T item);
        ICollection<T> GetAll();
        T GetByKey(K key);
        T Update(T item);
        T Delete(K key);
    }
}
