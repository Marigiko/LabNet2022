using EntityFrameworkProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProjectLogic
{
    public class CustomersLogic : BaseLogic, ICRUDLogic<Customers>
    {
        public void Add(Customers campo)
        {
            context.Customers.Add(campo);
            context.SaveChanges();
        }
        public IQueryable<Customers> Get()
        {
            var query = from customers in context.Customers
                        select customers;
            return query;
            //Method Syntax
            //return context.Customers;
        }
        public List<String> GetNames()
        {
            var query = from customers in context.Customers
                        select customers.ContactName;
            return query.ToList();
            //Method Syntax
            //return context.Customers.ToList();
        }
        public IQueryable<Customers> GetAllInRegionWA()
        {
            var query = from customers in context.Customers
                        where customers.Region == "WA"
                        select customers;
            return query;
            //Method Syntax
            //return context.Customers.Where(c => c.Region == "WA");
        }

        public IQueryable<Customers> CustomerAndOrders()
        {
            var query = from customers in context.Customers
                        join orders in context.Orders
                        on new { customers.CustomerID }
                        equals new { orders.CustomerID }
                        where customers.Region == "WA" && orders.OrderDate > new DateTime(1997, 1, 1)
                        select customers;

            return query;
            //Method Syntax
            //return context.Customers.Where(c => c.Region == "WA");
        }

        public void Delete(int id)
        {
            var customerAEliminar = context.Customers.Find(id);

            context.Customers.Remove(customerAEliminar);

            context.SaveChanges();
        }

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Update(Customers campo)
        {
            var customerAActualizar = context.Customers.Find(campo.CustomerID);

            customerAActualizar.CompanyName = campo.CompanyName;

            context.SaveChanges();
        }
    }
}
