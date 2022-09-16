using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    abstract class TransportePublico
    {
        private int pasajeros;
        protected int capacidadMaxima;

        public int getPasajeros()
        {
            return this.pasajeros;
        }
        public void setPasajeros(int pasajeros)
        {
            if(pasajeros <= this.capacidadMaxima)
            {
                this.pasajeros = pasajeros;
            }
        }
        public int getCapacidadMaxima()
        {
            return this.capacidadMaxima;
        }

        public void Avanzar(){}
        public void Detenerse(){}
    }
}
