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
            try
            {
                _context.Employees.Remove(empleadoABorrar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
                 
        }

        public List<Employees> GetAll()
        {
            return _context.Employees.OrderByDescending(e => e.EmployeeID).ToList();
        }

        public Employees GetById(int id)
        {
            try
            {
                var empleado = _context.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();

                return empleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Update(Employees entity)
        {
            var empleadoAModificar = _context.Employees.Where(e => e.EmployeeID == entity.EmployeeID).FirstOrDefault();
            if (empleadoAModificar != null)
            {
                    empleadoAModificar.FirstName = entity.FirstName;
                    empleadoAModificar.LastName = entity.LastName;
                    empleadoAModificar.Title = entity.Title;
                    _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
