// See https://aka.ms/new-console-template for more information
using Exceptions;

Dividir dividirObj = new Dividir();
dividirObj.DividirPorCero(5);

Console.WriteLine("\nIngrese el dividendo: ");
var num1 = Console.ReadLine();
Console.WriteLine("\nIngrese el divisior: ");
var num2 = Console.ReadLine();

dividirObj.DividirNumeros(num1, num2);

Logic logic = new Logic();

try
{
    logic.ExpresionInvalida();
} catch(Exception e)
{
    Console.WriteLine($"MENSAJE DE LA EXCEPCIÓN : {e.Message}\n\n TIPO DE EXCEPCIÓN : {e.GetType()}");
}

try
{
    Console.WriteLine("Ingrese el mensaje de la excepción: \n");
    String mensaje = Console.ReadLine();
    logic.ExcepcionPersonalizada(mensaje);
}
catch (Exception e)
{
    Console.WriteLine($"MENSAJE DE LA EXCEPCIÓN : {e.Message}\n\n TIPO DE EXCEPCIÓN : {e.GetType()}");
}