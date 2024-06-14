using DataAcessLayer.Abstract;
using DataAcessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {  
        MailAppContext context=new MailAppContext();
        public void Delete(int id)
        {
            var values = context.Set<T>().Find(id); 
            context.Set<T>().Remove(values); 
            context.SaveChanges();
        }

        public T GetbyId(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetlistAll()
        { 
            return  context.Set<T>().ToList();
        }

        public void Insert(T entity)
        { 
            var values=context.Set<T>().Add(entity); 
            context.SaveChanges();
        }

        public void Update(T entity)
        { 
            var values=context.Set<T>().Update(entity); 
            context.SaveChanges();
        }
    }
}
