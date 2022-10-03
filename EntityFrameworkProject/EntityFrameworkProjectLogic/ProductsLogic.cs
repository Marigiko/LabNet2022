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
        public IQueryable<Products> GetAllOrderByName()
        {
            var query = from products in context.Products
                        orderby products.ProductName
                        select products;
            return query;
            //Method Syntax
            //return context.Products.OrderBy(p => p.ProductName);
        }
        public IQueryable<Products> GetAllOrderByUnitInStock()
        {
            var query = from products in context.Products
                        orderby products.ProductName
                        descending
                        select products;
            return query;
            //Method Syntax
            //return context.Products.OrderByDescending(p => p.ProductName);
        }
        public IQueryable<IGrouping<Categories,Products>> GetDistinctCategories()
        {
            var query = (from products in context.Products
                        group products by products.Categories into newGroup
                        select newGroup).Distinct();
            return query;
            //Method Syntax
            //return context.Products.GroupBy(p => p.Categories).Distinct();
        }
        public IQueryable<Products> GetFirstElement()
        {
            var query = (from products in context.Products
                         select products).Take(1);
            return query;
            //Method Syntax
            //return context.Products.Take(1);
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
