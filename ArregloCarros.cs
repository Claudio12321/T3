using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3
{
    internal class ArregloCarros
    {
        private Carro[] carros;
        private int cantidad;

        public ArregloCarros(int capacidad)
        {
            carros = new Carro[capacidad];
            cantidad = 0;
        }

        public void Agregar(Carro carro)
        {
            carros[cantidad] = carro;
            cantidad++;
        }

        public int Cantidad()
        {
            return cantidad;
        }

        public Carro Obtener(int i)
        {
            return carros[i];
        }

        public void MostrarTodos()
        {
            for (int i = 0; i < cantidad; i++)
            {
                carros[i].Mostrar();
            }
        }
    }
}
