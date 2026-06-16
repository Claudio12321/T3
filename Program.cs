using Examen_T3;

Grafo grafo = new Grafo();
ArregloCarros carros = new ArregloCarros(100);


for (int i = 1; i <= 10; i++)
    grafo.AgregarVertice(i);


grafo.AgregarArista(1, 2, 2, 3);
grafo.AgregarArista(1, 3, 1, 2);
grafo.AgregarArista(2, 4, 2, 3);
grafo.AgregarArista(3, 5, 4, 5);
grafo.AgregarArista(4, 6, 2, 3);
grafo.AgregarArista(5, 7, 3, 4);
grafo.AgregarArista(6, 8, 1, 2);
grafo.AgregarArista(7, 9, 2, 3);
grafo.AgregarArista(8, 10, 2, 2);
grafo.AgregarArista(3, 4, 1, 1);

int op;

do
{
    Console.WriteLine("\n===== UBER =====");
    Console.WriteLine("1. Agregar Carro");
    Console.WriteLine("5. Taxis cercanos");
    Console.WriteLine("6. Distancia entre puntos");
    Console.WriteLine("7. Tomar taxi");
    Console.WriteLine("9. Salir");

    Console.Write("Opción: ");
    op = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            AgregarCarro(carros);
            break;

        case 5:
            Console.Write("Origen: ");
            int o = int.Parse(Console.ReadLine());
            grafo.BuscarTaxisCercanos(carros, o);
            break;

        case 6:
            Console.Write("Origen: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Destino: ");
            int b = int.Parse(Console.ReadLine());
            grafo.DistanciaEntrePuntos(a, b);
            break;

        case 7:
            TomarTaxi(grafo, carros);
            break;
    }

} while (op != 9);


static void AgregarCarro(ArregloCarros carros)
{
    Carro c = new Carro();

    Console.Write("Placa: ");
    c.Placa = Console.ReadLine();

    Console.Write("Color: ");
    c.Color = Console.ReadLine();

    Console.Write("Tipo (Taxi/Particular): ");
    c.Tipo = Console.ReadLine();

    if (c.Tipo.ToUpper() == "TAXI")
    {
        Console.Write("Soles/min: ");
        c.SolesPorMinuto = double.Parse(Console.ReadLine());

        Random r = new Random();
        c.VerticeActual = r.Next(1, 11);
    }

    carros.Agregar(c);
    Console.WriteLine("Carro agregado");
}


static void TomarTaxi(Grafo grafo, ArregloCarros carros)
{
    Console.Write("Origen: ");
    int origen = int.Parse(Console.ReadLine());

    Console.Write("Destino: ");
    int destino = int.Parse(Console.ReadLine());

    Console.WriteLine("\nTaxis disponibles:");

    for (int i = 0; i < carros.Cantidad(); i++)
    {
        Carro c = carros.Obtener(i);

        if (c.Tipo.ToUpper() == "TAXI")
        {
            Console.WriteLine($"{i}. {c.Placa} - Vértice {c.VerticeActual}");
        }
    }

    Console.Write("Elegir taxi: ");
    int op = int.Parse(Console.ReadLine());

    Carro elegido = carros.Obtener(op);

    double costo = elegido.SolesPorMinuto * 10;

    Console.WriteLine("\n===== YAPE =====");
    Console.WriteLine($"Taxi: {elegido.Placa}");
    Console.WriteLine($"Total: S/ {costo}");
}