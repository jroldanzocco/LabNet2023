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
    }
}
