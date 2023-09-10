using Northwind.To.EF.CommonComponents;
using Northwind.To.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var empleadoABorrar = _context.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            
                 _context.Employees.Remove(empleadoABorrar);
                 _context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return _context.Employees.OrderBy(e => e.LastName).ToList();
        }

        public Employees GetById(int id)
        {
            var empleado = _context.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();

            return empleado;
        }

        public void Update(Employees entity)
        {
            var empleadoAModificar = _context.Employees.Where(e => e.EmployeeID == entity.EmployeeID).FirstOrDefault();
            if (empleadoAModificar != null)
            {
                if (entity.LastName.Length <= 20 && entity.FirstName.Length <= 10)
                {
                    empleadoAModificar.FirstName = entity.FirstName;
                    empleadoAModificar.LastName = entity.LastName;
                    _context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException();
                }

            }
        }
    }
}
