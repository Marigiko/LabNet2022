using EntityFrameworkProjectData;
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
