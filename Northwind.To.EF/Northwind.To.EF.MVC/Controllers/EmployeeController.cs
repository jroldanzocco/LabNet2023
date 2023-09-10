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
        private readonly EmployeesLogic logic = new EmployeesLogic();
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
        public ActionResult Insert(EmployeeViewModel empView)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employeeEntity = new Employees
                    {
                        FirstName = empView.Nombre,
                        LastName = empView.Apellido,
                        Title = empView.Rol
                    };
                    logic.Add(employeeEntity);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }
                
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index","Error");
            }
            
        }
    }
}