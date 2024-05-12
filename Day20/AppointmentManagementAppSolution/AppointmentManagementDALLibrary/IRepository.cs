using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        List<T> GetAll();
        T GetByID(K key);
        T Add(T item);
        T Update(T item);
        T DeleteByID(K key);
    }
}
