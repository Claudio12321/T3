using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3
{
    internal class NodoAdyacencia
    {
        public int Destino;

        public double DistanciaKm;

        public double TiempoMin;

        public NodoAdyacencia Siguiente;

        public NodoAdyacencia(
            int destino,
            double distancia,
            double tiempo)
        {
            Destino = destino;
            DistanciaKm = distancia;
            TiempoMin = tiempo;

            Siguiente = null;
        }
    }
}
