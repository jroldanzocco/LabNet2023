using Northwind.To.EF.Logic;
using Northwind.To.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.To.EF.MVC.Models;

namespace Northwind.To.EF.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeesLogic logic = new EmployeesLogic();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> empleados = logic.GetAll();
            List<EmployeeView> empleadosView = empleados.Select(e => new EmployeeView()
            {
                Id = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title
            }).ToList();
            return View(empleadosView);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(EmployeeViewInsert model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employeeEntity = new Employees
                    {
                        FirstName = model.Nombre,
                        LastName = model.Apellido,
                        Title = model.Rol
                    };
                    logic.Add(employeeEntity);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public ActionResult Update(int id)
        {
            EmployeeView model = new EmployeeView();
            var employee = logic.GetById(id);

            model.Id = employee.EmployeeID;
            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.Title = employee.Title;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(EmployeeView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = logic.GetById(model.Id);
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Title = model.Title;

                    logic.Update(employee);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult Delete(int id)
        {
            logic = new EmployeesLogic();
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }

        }
    }
}