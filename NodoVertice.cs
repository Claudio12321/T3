using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3
{
    internal class NodoVertice
    {
        public Vertice Dato;

        public NodoVertice Siguiente;

        public NodoVertice(Vertice dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
