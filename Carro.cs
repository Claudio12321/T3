using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3
{
    internal class Carro
    {
        public string Placa;
        public string Color;
        public string Tipo;

        public double SolesPorMinuto;

        public int VerticeActual;

        public void Mostrar()
        {
            Console.WriteLine(
                $"Placa: {Placa} | Color: {Color} | Tipo: {Tipo} | Vértice: {VerticeActual}");
        }
    }
}
