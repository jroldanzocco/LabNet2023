using LINQ.Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Practica.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> GetOutStock()
        {
            return _context.Products.Where(p => p.UnitsInStock == 0)
                    .OrderBy(p => p.ProductName)
                    .ToList();
        }   
        public List<Products> GetPlusThree()
        {
            return _context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)
                .OrderBy(p => p.UnitPrice)
                .ToList();
        }
        public Products getBySpecificId(int id)
        {
            var producto = _context.Products.Where(p => p.ProductID == id).FirstOrDefault();
            if(producto == null)
                throw new Exception($"El producto con el ID {id} no existe");

            return producto;
        }
    }
}
