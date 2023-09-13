using Northwind.To.EF.Logic;
using Northwind.To.EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.To.EF.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public IEnumerable<Customer> GetAllEmployees()
        {
            CustomersLogic logic = new CustomersLogic();

            List<Customer> clientes = logic.GetAll().Select(e => new Customer
            {
                CustomerID = e.CustomerID,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName
            }).ToList();
            return clientes;
        }
        [HttpGet]
        public IHttpActionResult GetCustomer(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound(); 
            CustomersLogic logic = new CustomersLogic();
            var cliente = logic.GetById(id);
            if (cliente != null)
            {
                Customer clienteModelo = new Customer
                {
                    CustomerID = cliente.CustomerID,
                    CompanyName = cliente.CompanyName,
                    ContactName = cliente.ContactName
                };
                return Ok(clienteModelo);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
                try
                {
                    CustomersLogic logic = new CustomersLogic();
                    var cliente = logic.GetById(id);
                    if (cliente == null) return BadRequest($"El cliente {id} no existe");
                    logic.Delete(id);
                    return Ok($"Se elimino el cliente {id}");
                }
                catch (Exception)
                {
                    return BadRequest("No se puede eliminar el cliente por conflicto de referencias");
                }

            
        }
        [HttpPut]
        public IHttpActionResult PutCustomer(Customer clienteModel)
        {
            try
            {
                if (clienteModel == null) return BadRequest();

                CustomersLogic logic = new CustomersLogic();

                logic.Update(new Entities.Customers
                {
                    CustomerID = clienteModel.CustomerID,
                    CompanyName = clienteModel.CompanyName,
                    ContactName = clienteModel.ContactName
                });
                return Ok($"El cliente {clienteModel.CustomerID} fue modificado con exito");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IHttpActionResult PostCustomer(Customer clienteModel)
        {
            try
            {
                if (clienteModel == null) return BadRequest();

                CustomersLogic logic = new CustomersLogic();
                logic.Add(new Entities.Customers
                {
                    CustomerID = clienteModel.CustomerID,
                    CompanyName = clienteModel.CompanyName,
                    ContactName = clienteModel.ContactName
                });
                return Ok($"Se incorporo un nuevo cliente correctamente");
            }
            catch (Exception)
            {
                return BadRequest("Formato de ingreso incorrecto");
            }
        }
    }
}


