using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Dividir
    {
        public void DividirPorCero(int num)
        {
                try
            {
                Console.WriteLine(num / 0);
            } catch(DivideByZeroException e)
            {
                Console.WriteLine(e);
            } finally
            {
                Console.WriteLine("La operación a finalizado ");
            }
        }

        public void DividirNumeros(String a, String b)
        {
            try
            {
                int num1 = Convert.ToInt16(a);
                int num2 = Convert.ToInt16(b);
                Console.WriteLine("\nEl resultado de la division es: " + num1 / num2);
            } catch (DivideByZeroException e)
            {
                Console.WriteLine("\nSolo John Nash puede dividir por 0!\n\n" + e);
            } catch (Exception e)
            {
                Console.WriteLine("\nSeguro Ingreso una letra o no ingreso nada!\n\n" + e);
            } 
        }
    }
}
