using EntityFrameworkProjectData;
using EntityFrameworkProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProjectLogic
{
    public class EmployeesLogic : BaseLogic, ICRUDLogic<Employees>
    {
        public void Add(Employees campo)
        {
            context.Employees.Add(campo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeAEliminar = context.Employees.Find(id);

            context.Employees.Remove(employeeAEliminar);

            context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees campo)
        {
            var empoyeeAActualizar = context.Employees.Find(campo.EmployeeID);

            empoyeeAActualizar.LastName = campo.LastName;

            context.SaveChanges();
        }
    }
}
