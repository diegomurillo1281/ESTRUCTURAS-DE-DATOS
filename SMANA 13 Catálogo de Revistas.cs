using System;
using System.Collections.Generic;

/// <summary>
/// Clase principal que gestiona el catálogo de revistas y las operaciones de búsqueda.
/// </summary>
public class CatalogoRevistas
{
    // Catálogo de revistas, utilizando una lista para almacenar los títulos.
    // Se inicializa con al menos 10 títulos como lo solicita la tarea.
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

    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// Contiene el menú interactivo para el usuario.
    /// </summary>
    public static void Main(string[] args)
    {
        // Para usar la búsqueda recursiva (binaria), el catálogo debe estar ordenado.
        catalogo.Sort();
        Console.WriteLine("El catálogo ha sido ordenado para una búsqueda eficiente.");

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título específico");
            Console.WriteLine("2. Salir");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingresa el título de la revista a buscar: ");
                    string tituloBuscado = Console.ReadLine();
                    
                    // Elegir entre los métodos de búsqueda.
                    // Descomenta uno de los dos para usarlo.
                    
                    // bool encontrado = BusquedaIterativa(tituloBuscado);
                    bool encontrado = BusquedaRecursiva(tituloBuscado, 0, catalogo.Count - 1);
                    
                    MostrarResultado(encontrado, tituloBuscado);
                    break;
                case "2":
                    continuar = false;
                    Console.WriteLine("Saliendo de la aplicación...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                    break;
            }
        }
    }

    /// <summary>
    /// Realiza una búsqueda iterativa de un título en el catálogo.
    /// Este método recorre todos los elementos de la lista.
    /// </summary>
    /// <param name="tituloBuscado">El título que se desea encontrar.</param>
    /// <returns>True si el título se encuentra, de lo contrario, False.</returns>
    public static bool BusquedaIterativa(string tituloBuscado)
    {
        foreach (string titulo in catalogo)
        {
            if (titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Realiza una búsqueda recursiva utilizando el algoritmo de búsqueda binaria.
    /// Este método es más eficiente pero requiere que la lista esté ordenada.
    /// </summary>
    /// <param name="tituloBuscado">El título que se desea encontrar.</param>
    /// <param name="inicio">El índice de inicio de la búsqueda.</param>
    /// <param name="fin">El índice de fin de la búsqueda.</param>
    /// <returns>True si el título se encuentra, de lo contrario, False.</returns>
    public static bool BusquedaRecursiva(string tituloBuscado, int inicio, int fin)
    {
        // Caso base: El rango de búsqueda es inválido, el título no se encontró.
        if (inicio > fin)
        {
            return false;
        }

        // Se calcula el índice del elemento medio del rango de búsqueda.
        int medio = (inicio + fin) / 2;
        string tituloMedio = catalogo[medio];

        // Se compara el título del medio con el título que se busca.
        int comparacion = string.Compare(tituloMedio, tituloBuscado, StringComparison.OrdinalIgnoreCase);

        if (comparacion == 0)
        {
            // El título se encontró en el medio.
            return true;
        }
        else if (comparacion > 0)
        {
            // El título buscado es alfabéticamente menor, por lo que se busca en la mitad izquierda.
            return BusquedaRecursiva(tituloBuscado, inicio, medio - 1);
        }
        else
        {
            // El título buscado es alfabéticamente mayor, por lo que se busca en la mitad derecha.
            return BusquedaRecursiva(tituloBuscado, medio + 1, fin);
        }
    }

    /// <summary>
    /// Muestra el resultado de la búsqueda en la consola.
    /// </summary>
    /// <param name="encontrado">Indicador booleano del resultado de la búsqueda.</param>
    /// <param name="titulo">El título que se buscó.</param>
    private static void MostrarResultado(bool encontrado, string titulo)
    {
        Console.WriteLine($"\nBuscando '{titulo}'...");
        if (encontrado)
        {
            Console.WriteLine("Resultado: Encontrado");
        }
        else
        {
            Console.WriteLine("Resultado: No encontrado");
        }
    }
}
