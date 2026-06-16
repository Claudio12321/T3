using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_T3
{
    internal class Grafo
    {
        private NodoVertice inicio;


        public Grafo()
        {
            inicio = null;
        }

        
        public void AgregarVertice(int id)
        {
            if (BuscarVertice(id) != null)
                return;

            NodoVertice nuevo =
                new NodoVertice(new Vertice(id));

            nuevo.Siguiente = inicio;
            inicio = nuevo;
        }

        public Vertice BuscarVertice(int id)
        {
            NodoVertice aux = inicio;

            while (aux != null)
            {
                if (aux.Dato.Id == id)
                    return aux.Dato;

                aux = aux.Siguiente;
            }

            return null;
        }

        
        private bool ExisteConexion(int o, int d)
        {
            Vertice v = BuscarVertice(o);
            if (v == null) return false;

            NodoAdyacencia aux = v.InicioAdyacentes;

            while (aux != null)
            {
                if (aux.Destino == d)
                    return true;

                aux = aux.Siguiente;
            }

            return false;
        }

        public bool AgregarArista(int v1, int v2, double dist, double tiempo)
        {
            if (ExisteConexion(v1, v2))
                return false;

            Vertice a = BuscarVertice(v1);
            Vertice b = BuscarVertice(v2);

            if (a == null || b == null)
                return false;

            NodoAdyacencia n1 =
                new NodoAdyacencia(v2, dist, tiempo);

            n1.Siguiente = a.InicioAdyacentes;
            a.InicioAdyacentes = n1;

            NodoAdyacencia n2 =
                new NodoAdyacencia(v1, dist, tiempo);

            n2.Siguiente = b.InicioAdyacentes;
            b.InicioAdyacentes = n2;

            return true;
        }

        
        public void BuscarTaxisCercanos(ArregloCarros carros, int origen)
        {
            Console.WriteLine("Taxis cercanos:");

            for (int i = 0; i < carros.Cantidad(); i++)
            {
                Carro c = carros.Obtener(i);

                if (c.Tipo.ToUpper() == "TAXI")
                {
                    if (EsCercano(origen, c.VerticeActual, 2))
                    {
                        Console.WriteLine(
                            $"Taxi {c.Placa} en vértice {c.VerticeActual}");
                    }
                }
            }
        }

        private bool EsCercano(int origen, int destino, int maxNivel)
        {
            return BuscarNivel(origen, destino, 0, maxNivel);
        }

        private bool BuscarNivel(int actual, int destino, int nivel, int maxNivel)
        {
            if (nivel > maxNivel)
                return false;

            if (actual == destino)
                return true;

            Vertice v = BuscarVertice(actual);

            NodoAdyacencia aux = v.InicioAdyacentes;

            while (aux != null)
            {
                if (BuscarNivel(aux.Destino, destino, nivel + 1, maxNivel))
                    return true;

                aux = aux.Siguiente;
            }

            return false;
        }

        
        public void DistanciaEntrePuntos(int origen, int destino)
        {
            double dist = 0;
            double tiempo = 0;

            bool ok = BuscarRuta(origen, destino, 0, 3, ref dist, ref tiempo);

            if (ok)
            {
                Console.WriteLine($"Distancia: {dist} km");
                Console.WriteLine($"Tiempo: {tiempo} min");
            }
            else
            {
                Console.WriteLine("No están conectados hasta 3 niveles");
            }
        }

        private bool BuscarRuta(int actual, int destino, int nivel, int maxNivel,
            ref double dist, ref double tiempo)
        {
            if (nivel > maxNivel)
                return false;

            if (actual == destino)
                return true;

            Vertice v = BuscarVertice(actual);

            NodoAdyacencia aux = v.InicioAdyacentes;

            while (aux != null)
            {
                dist += aux.DistanciaKm;
                tiempo += aux.TiempoMin;

                if (BuscarRuta(aux.Destino, destino, nivel + 1, maxNivel, ref dist, ref tiempo))
                    return true;

                aux = aux.Siguiente;
            }

            return false;
        }
    }
}