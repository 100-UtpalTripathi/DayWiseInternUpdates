using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApplicationModelLibrary;

namespace QuizApplicationDALLibrary
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        T Add(T item);
        T Update(int id, T item);
        T Delete(int id);
    }
}
