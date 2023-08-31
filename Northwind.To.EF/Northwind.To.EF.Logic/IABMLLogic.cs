using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.Logic
{
    interface IABMLLogic<T>
    {
        void Add(T newEntity);
        void Update(T entity);
        void Delete(string id);
        List<T> GetAll();
    }
}
