// See https://aka.ms/new-console-template for more information

using POO;
using System.Collections.Generic;
using System.ComponentModel;

int cantidadTransportes;
int i = 1;

cantidadTransportes = 1;
List<TransportePublico> listaDeTrasportes = new List<TransportePublico>();
Console.WriteLine("El taxi tiene una capacidad maxima de 4 pasajeros\n y el omnibus tiene una capacidad maxima de 100 pasajeros");

while (i <= cantidadTransportes)
{
    Console.WriteLine("Ingrese cantidad de pasajeros para el taxi: ");
    Taxi taxi = new Taxi();
    taxi.setPasajeros(Convert.ToInt16(Console.ReadLine()));

    Console.WriteLine("Ingrese cantidad de pasajeros para el omnibus: ");
    Omnibus omnibus = new Omnibus();
    omnibus.setPasajeros(Convert.ToInt16(Console.ReadLine()));

    listaDeTrasportes.Add(taxi);
    listaDeTrasportes.Add(omnibus);

    i++;
}

foreach (TransportePublico tp in listaDeTrasportes)
{
    Console.WriteLine($"{tp.ToString().Substring(4)}: {tp.getPasajeros()} pasajeros");
}
