using EntityFrameworkProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProjectLogic
{
    public class ProductsLogic : BaseLogic
    {
        public IQueryable<Products> GetAllWithoutStock()
        {
            var query = from products in context.Products
                        where products.UnitsInStock == null
                        select products;
            return query;
            //Method Syntax
            //return context.Products.Where(p => p.UnitsInStock == null);
        }
        public IQueryable<Products> GetAllWithtStock()
        {
            var query = from products in context.Products
                        where products.UnitsInStock != null && products.UnitPrice > 3
                        select products;
            return query;
            //Method Syntax
            //return context.Products.Where(p => p.UnitsInStock != null && p.UnitPrice > 3);
        }
        public IQueryable<Products> GetFirst789()
        {
            var query = from products in context.Products
                        where products.ProductID == 789
                        select products;
            return query;
    
            //Method Syntax
            //return context.Products.Where(p => p.ProductID == 789);
        }
    }
}
