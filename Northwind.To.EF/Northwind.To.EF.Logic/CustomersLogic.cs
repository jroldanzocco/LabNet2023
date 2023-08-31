using Northwind.To.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLLogic<Customers>
    {
        public void Add(Customers newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Update(Customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
