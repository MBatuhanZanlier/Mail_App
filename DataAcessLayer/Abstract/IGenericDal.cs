using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
    public interface IGenericDal <T> where T : class
    {
        void Insert(T entity);
        void Delete(int id);
        T GetbyId(int id);
        void Update(T entity);
        List<T> GetlistAll();
    }
}
