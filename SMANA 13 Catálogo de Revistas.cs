using System;
using System.Collections.Generic;

/*
==============================================
   UNIVERSIDAD ESTATAL AMAZÓNICA
   Estudiante: DIEGO JAIME MURILLO ORDEÑANA
   Proyecto: Catálogo de Revistas en C#
==============================================
*/

public class CatalogoRevistas
{
    private static List<string> catalogo = new List<string>
    {
        "Revista de Ciencia",
        "Tecnología Hoy",
        "Historia del Mundo",
        "Arte Moderno",
        "Naturaleza Viva",
        "Viajes y Aventura",
        "Cultura Popular",
        "Gastronomía Creativa",
        "Deportes Extremos",
        "Revista de Negocios",
        "Fotografía Digital"
    };

    public static void Main()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("   UNIVERSIDAD ESTATAL AMAZÓNICA");
        Console.WriteLine("   Estudiante: DIEGO JAIME MURILLO ORDEÑANA");
        Console.WriteLine("   Proyecto: Catálogo de Revistas en C#");
        Console.WriteLine("==============================================\n");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Título a buscar: ");
                string titulo = Console.ReadLine();

                bool encontrado = BusquedaIterativa(titulo);
                Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
            }
            else if (opcion == "2")
            {
                continuar = false;
                Console.WriteLine("Adiós...");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
    }

    // Método de búsqueda simple (iterativa)
    public static bool BusquedaIterativa(string titulo)
    {
        foreach (string t in catalogo)
            if (t.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;
        return false;
    }
}

