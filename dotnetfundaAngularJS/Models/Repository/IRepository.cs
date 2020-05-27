using System.Collections.Generic;

namespace dotnetfundaAngularJS.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        bool Save();
    }
}
