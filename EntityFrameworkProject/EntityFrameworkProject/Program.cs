using EntityFrameworkProjectEntities;
using EntityFrameworkProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class Program
    {
        static void clearConsole()
        {
            Console.WriteLine("\n\nPresione enter si desea continuar");
            Console.ReadLine();
            Console.Clear();
        }
        static void Main(string[] args)
        {

            EmployeesLogic employeesLogic = new EmployeesLogic();
            CustomersLogic customersLogic = new CustomersLogic();
            ProductsLogic productsLogic = new ProductsLogic();

            IQueryable<Customers> customerLinq = customersLogic.Get();
            List<String> customerNamesLinq = customersLogic.GetNames();
            IQueryable<Customers> customerInRegionWALinq = customersLogic.GetAllInRegionWA();
            IQueryable<Products> productsWithoutLinq = productsLogic.GetAllWithoutStock();
            IQueryable<Products> productsWithLinq = productsLogic.GetAllWithtStock();
            IQueryable<Products> productsFirst789Linq = productsLogic.GetFirst789();
            IQueryable<Customers> customerAndOrdersLinq = customersLogic.CustomerAndOrders();

            Console.WriteLine("Query para devolver objeto customer\n\n");
            foreach (Customers customer in customerLinq)
            {
                Console.WriteLine($"ESTE ES EL NOMBRE DE CONTACTO {customer.ContactName}");
            }
            clearConsole();

            Console.WriteLine("Query para devolver todos los productos sin stock\n\n");
            foreach (Products product in productsWithoutLinq)
            {
                Console.WriteLine($"ESTE ES EL NOMBRE DEL PRODUCTO {product.ProductName} SIN STOCK");
            }
            clearConsole();

            Console.WriteLine("Query para devolver todos los productos que tienen stock y que cuestan más de 3 por\r\nunidad\n\n");
            foreach (Products product in productsWithLinq)
            {
                Console.WriteLine($"ESTE ES EL NOMBRE DEL PRODUCTO {product.ProductName} CON STOCK\n" +
                                  $"Y ESTE ES SU PRECIO UNITARIO {product.UnitPrice}");
            }
            clearConsole();

            Console.WriteLine("Query para devolver todos los customers de la Región WA\n\n");
            foreach (Customers customer in customerInRegionWALinq)
            {
                Console.WriteLine($"ESTE ES EL NOMBRE DE CONTACTO {customer.ContactName}" +
                    $"Y ESTA ES SU REGION {customer.Region}");
            }
            clearConsole();

            Console.WriteLine("Query para devolver el primer elemento o nulo de una lista de productos donde el ID de\r\nproducto sea igual a 789\n\n");
            foreach (Products product in productsFirst789Linq)
            {
                Console.WriteLine($"ESTE ES EL PRODUCTO 789: {product.ProductName}");
            }
            clearConsole();

            Console.WriteLine("Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en\r\nMinuscula\n\n");
            foreach (String customer in customerNamesLinq)
            {
                Console.WriteLine($"ESTE ES EL NOMBRE DE CONTACTO EN MAYUSCULA: {customer.ToUpper()}");
                Console.WriteLine($"este es el nombre de contacto en minuscula: {customer.ToLower()}");
            }
            clearConsole();

            Console.WriteLine("Query para devolver Join entre Customers y Orders donde los customers sean de la \r\nRegión WA y la fecha de orden sea mayor a 1/1/1997\n\n");
            //EN ESTE EJERCICIO TUVE PROBLEMAS CON EL TIPO DE DATO A DEVOLVER "new { customers, orders }"
            foreach (Customers customer in customerAndOrdersLinq)
            {
                Console.WriteLine($"ESTOS SON LOS CUSTOMERS QUE SON DE WA Y SU ORDEN ES MAYOR A 1/1/1997: {customer.ContactName}");
            }
            Console.WriteLine("\n\nFINAL DE LA DEMO");

            Console.ReadLine();
            
        }
    }
}
