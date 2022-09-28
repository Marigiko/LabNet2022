using EntityFrameworkProjectEntities;
using EntityFrameworkProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeesLogic employeesLogic = new EmployeesLogic();
            CustomersLogic customersLogic = new CustomersLogic();

            Console.WriteLine("ESTA ES UNA DEMO EN LA CUAL SE MUESTRA EL FUNCIONAMIENTO DE LOS METODOS: INSERT, UPDATE, DELETE, Y SELECT ALL\n");

            Console.WriteLine("\nESTOS SON TODOS LOS REGISTROS DE LA TABLA EMPLOYEES\n");
            foreach (Employees employee in employeesLogic.GetAll())
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} es un empleado y su ID es: {employee.EmployeeID}");
            }
            Console.WriteLine("\nESTOS SON TODOS LOS REGISTROS DE LA TABLA CUSTOMERS\n");
            foreach (Customers customer in customersLogic.GetAll())
            {
                Console.WriteLine($"La empresa es: {customer.CompanyName} \n Codigo Postal es: {customer.PostalCode}");
            }

            bool continuar = true;

            while(continuar)
            {
                try
                {
                    Console.WriteLine("\nIngrese el Nombre del empleado a agregar: ");
                    string FirstName = Console.ReadLine();

                    Console.WriteLine("\nIngrese el Apellido del empleado a agregar: ");
                    string LastName = Console.ReadLine();

                    employeesLogic.Add(new Employees
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                    });

                    Console.WriteLine("\nIngrese el ID del empleado a actualizar: ");
                    int employeeID = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("\nIngrese el nuevo Apellido: ");
                    LastName = Console.ReadLine();

                    employeesLogic.Update(new Employees
                    {
                        LastName = LastName,
                        EmployeeID = employeeID,
                    });

                    Console.WriteLine("\nIngrese el ID del empleado a eliminar: ");
                    int idAEliminar = Convert.ToInt16(Console.ReadLine());
                    employeesLogic.Delete(idAEliminar);
                    /* NOTA: Por cuestiones de relaciones de tablas en la bd entre FK y PK 
                     * al intentar eliminar un empleado que tenga asisganada una orden el programa crashea,
                       si se intenta eliminar un registro de un empleado nuevo que no tiene ninguna relacion
                       el programa funciona de la manera esperada*/

                    Console.WriteLine("\npara continuar ingrese: True \nen caso contrario ingrese: False");
                    continuar = Convert.ToBoolean(Console.ReadLine());
                } catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                /* NOTA: Por falta de tiempo se evito un manejo mas detallado de errores */

            }

            Console.WriteLine("\nEsta es la Tabla EMPLOYEES despues de las modificaciones: \n");
            foreach (Employees employee in employeesLogic.GetAll())
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} es un empleado y su ID es: {employee.EmployeeID}");
            }

            Console.ReadLine();
        }
    }
}
