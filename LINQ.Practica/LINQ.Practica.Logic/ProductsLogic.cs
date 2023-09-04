using LINQ.Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Products GetBySpecificId(int id)
        {
            var producto = _context.Products.Where(p => p.ProductID == id).ToList().FirstOrDefault();
            if(producto == null)
                throw new Exception($"El producto con el ID {id} no existe");

            return producto;
        }
        public List<Products> GetProductByName()
        {
            return _context.Products.Where(p => p.UnitsInStock > 0)
                    .OrderBy(p => p.ProductName)
                    .ToList();
        }
        public List<Products> GetProductByStock()
        {
            return _context.Products.Where(p => p.UnitsInStock > 0)
                    .OrderByDescending(p => p.UnitsInStock)
                    .ToList();
        }
        public List<ProductPerCategorie> GetProductByCategorie()
        {
            return _context.Products.Join(_context.Categories, p => p.CategoryID, c => c.CategoryID,
                                            (Products, Categories) => new ProductPerCategorie
                                            {
                                                Id = Products.ProductID,
                                                Producto = Products.ProductName,
                                                Categoria = Categories.CategoryName
                                            }).OrderBy(p => p.Categoria).ToList();
        }
        public Products GetfirstProduct()
        {
            var producto = (from p in _context.Products
                            where p.UnitsInStock > 0
                            select p)
                           .FirstOrDefault();

            if (producto == null)
                throw new Exception("No existen productos");

            return producto;
        }
    }
}
