using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApplicationModelLibrary;

namespace QuizApplicationDALLibrary
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T Get(string id);
        List<T> GetAll();
        void Update(string id, T updatedEntity);
        void Delete(string id);
    }
}
