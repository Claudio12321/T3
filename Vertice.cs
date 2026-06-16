using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3
{
    internal class Vertice
    {
        public int Id;

        public NodoAdyacencia InicioAdyacentes;

        public Vertice(int id)
        {
            Id = id;
            InicioAdyacentes = null;
        }
    }
}
