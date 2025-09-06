using System;
using System.Collections.Generic; // Para usar List<T>
using System.Linq; // Para usar LINQ (OrderBy, Distinct, Any)

// Definición de la clase Loteria
// Esta clase se encarga de gestionar los números ganadores.
public class Loteria
{
    // Una lista privada para almacenar los números ganadores.
    private List<int> numerosGanadores;

    // Propiedad pública de solo lectura para el nombre del juego (opcional, para claridad).
    public string NombreJuego { get; private set; }

    // Constructor de la clase Loteria.
    // Inicializa la lista de números y el nombre del juego.
    public Loteria(string nombreJuego = "Lotería Primitiva")
    {
        NombreJuego = nombreJuego;
        numerosGanadores = new List<int>();
    }

    /// <summary>
    /// Solicita al usuario que introduzca los números ganadores de la lotería.
    /// Valida que sean números válidos, en el rango correcto y sin repeticiones.
    /// </summary>
    /// <param name="cantidadNumeros">La cantidad de números que se deben introducir (ej. 6).</param>
    /// <param name="minValor">El valor mínimo permitido para un número (ej. 1).</param>
    /// <param name="maxValor">El valor máximo permitido para un número (ej. 49).</param>
    public void PedirNumerosGanadores(int cantidadNumeros, int minValor, int maxValor)
    {
        Console.WriteLine($"\n--- Introducción de los {cantidadNumeros} números ganadores de la {NombreJuego} ---");
        Console.WriteLine($"(Números deben estar entre {minValor} y {maxValor}, y no repetidos)");

        numerosGanadores.Clear(); // Asegura que la lista esté vacía antes de empezar

        for (int i = 0; i < cantidadNumeros; i++)
        {
            int numeroIngresado;
            bool entradaValida = false;

            // Bucle para asegurar que el usuario introduce un número válido, en rango y no repetido.
            while (!entradaValida)
            {
                Console.Write($"Introduce el número {i + 1}: ");
                string? input = Console.ReadLine(); // Lee la entrada del usuario

                // 1. Validar que la entrada no esté vacía.
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("La entrada no puede estar vacía. Inténtalo de nuevo.");
                    continue; // Vuelve a pedir el número
                }

                // 2. Intentar convertir la entrada a un número entero.
                if (int.TryParse(input, out numeroIngresado))
                {
                    // 3. Validar que el número esté dentro del rango permitido.
                    if (numeroIngresado >= minValor && numeroIngresado <= maxValor)
                    {
                        // 4. Validar que el número no haya sido introducido previamente.
                        if (!numerosGanadores.Contains(numeroIngresado))
                        {
                            numerosGanadores.Add(numeroIngresado); // Añade el número a la lista
                            entradaValida = true; // La entrada es válida, sale del bucle interno
                        }
                        else
                        {
                            Console.WriteLine($"El número {numeroIngresado} ya ha sido introducido. Inténtalo de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"El número {numeroIngresado} está fuera del rango permitido ({minValor}-{maxValor}). Inténtalo de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número entero.");
                }
            }
        }
        Console.WriteLine("--- Números registrados con éxito. ---\n");
    }

    /// <summary>
    /// Muestra los números ganadores almacenados por pantalla, ordenados de menor a mayor.
    /// </summary>
    public void MostrarNumerosOrdenados()
    {
        Console.WriteLine($"\n--- Números Ganadores de la {NombreJuego} (Ordenados) ---");

        // Verifica si la lista de números está vacía.
        if (!numerosGanadores.Any()) // Utiliza LINQ para verificar si hay elementos
        {
            Console.WriteLine("No se han registrado números ganadores.");
        }
        else
        {
            // Ordena la lista de números de menor a mayor.
            // List<int>.Sort() ordena la lista en su lugar (modifica la lista original).
            numerosGanadores.Sort(); 

            // Muestra cada número de la lista ordenada.
            Console.Write("Números: ");
            for (int i = 0; i < numerosGanadores.Count; i++)
            {
                Console.Write(numerosGanadores[i]);
                if (i < numerosGanadores.Count - 1)
                {
                    Console.Write(", "); // Añade coma y espacio entre números, pero no al final
                }
            }
            Console.WriteLine("\n"); // Nueva línea al final para formateo
        }
        Console.WriteLine("----------------------------------------------------\n");
    }

    /// <summary>
    /// Retorna una copia de la lista de números ganadores.
    /// </summary>
    public List<int> GetNumerosGanadores()
    {
        return new List<int>(numerosGanadores); // Retorna una nueva lista para no exponer la interna
    }
}

// Clase principal del programa donde se ejecuta la aplicación.
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("***** Programa de Lotería Primitiva *****\n");

        // 1. Crear una instancia de la clase Loteria.
        // Se crea un objeto 'miLoteria' que gestionará los números.
        Loteria miLoteria = new Loteria("Lotería Primitiva");

        // Definir las reglas de la lotería (cantidad de números y rango)
        const int CantidadDeNumeros = 6;
        const int MinimoValor = 1;
        const int MaximoValor = 49;

        // 2. Solicitar al usuario los números ganadores.
        // Se llama al método PedirNumerosGanadores con los parámetros de la lotería.
        miLoteria.PedirNumerosGanadores(CantidadDeNumeros, MinimoValor, MaximoValor);

        // 3. Mostrar los números ganadores por pantalla, ordenados.
        // Se llama al método MostrarNumerosOrdenados del objeto 'miLoteria'.
        miLoteria.MostrarNumerosOrdenados();

        Console.WriteLine("\n***** Fin del Programa *****");

        // Opcional: Esperar a que el usuario presione una tecla antes de cerrar la consola
        // Console.ReadKey();
    }
}
