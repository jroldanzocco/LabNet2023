using Northwind.To.EF.CommonComponents;
using Northwind.To.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLLogic<Employees, int>
    {
        public void Add(Employees newEntity)
        {
            var existente = _context.Employees.Where(c => c.EmployeeID == newEntity.EmployeeID).FirstOrDefault();
            if (existente == null)
            {
                _context.Employees.Add(newEntity);
                _context.SaveChanges();
            }
            else
            {
                throw new ExistentRegException();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employees> GetAll()
        {
            return _context.Employees.AsQueryable()
                .OrderBy(e => e.LastName);
        }

        public Employees GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employees entity)
        {
            throw new NotImplementedException();
        }
    }
}
