using System;
using System.Collections.Generic; // Necesario para usar List<T>
using System.Globalization; // Necesario para CultureInfo para Parseo de double

// Definición de la clase Asignatura
// Ahora incluye una propiedad para la nota.
public class Asignatura
{
    // Propiedad para almacenar el nombre de la asignatura.
    public string Nombre { get; set; }
    
    // Propiedad para almacenar la nota de la asignatura (tipo double para permitir decimales).
    public double Nota { get; set; }

    // Constructor de la clase Asignatura.
    public Asignatura(string nombre)
    {
        Nombre = nombre;
        Nota = 0.0; // Inicializar la nota a 0.0 por defecto
    }

    // Método para representar la asignatura como una cadena de texto.
    public override string ToString()
    {
        return $"Asignatura: {Nombre}, Nota: {Nota}";
    }
}

// Definición de la clase Curso
public class Curso
{
    private List<Asignatura> asignaturas;
    public string NombreCurso { get; private set; }

    // Constructor de la clase Curso.
    public Curso(string nombreCurso)
    {
        NombreCurso = nombreCurso;
        asignaturas = new List<Asignatura>();
    }

    // Método para añadir una nueva asignatura al curso.
    public void AgregarAsignatura(Asignatura asignatura)
    {
        if (asignatura != null)
        {
            asignaturas.Add(asignatura);
            Console.WriteLine($"'{asignatura.Nombre}' ha sido añadida al curso '{NombreCurso}'.");
        }
        else
        {
            Console.WriteLine("No se puede agregar una asignatura nula.");
        }
    }

    // Nuevo método para solicitar al usuario la nota de cada asignatura.
    public void SolicitarNotas()
    {
        Console.WriteLine($"\n--- Introducción de Notas para el curso '{NombreCurso}' ---");
        if (asignaturas.Count == 0)
        {
            Console.WriteLine("No hay asignaturas para registrar notas.");
            return;
        }

        // Se usa CultureInfo.InvariantCulture para asegurar que el punto decimal se interprete consistentemente
        // independientemente de la configuración regional del sistema (ej. 4.5 en lugar de 4,5).
        CultureInfo culture = CultureInfo.InvariantCulture;

        foreach (var asignatura in asignaturas)
        {
            double notaIngresada;
            bool entradaValida = false;

            // Bucle para asegurar que se introduce una nota válida (numérica y entre 0 y 10).
            while (!entradaValida)
            {
                Console.Write($"Introduce la nota para '{asignatura.Nombre}' (0-10): ");
                string? input = Console.ReadLine(); // Se usa '?' para indicar que puede ser nulo

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("La nota no puede estar vacía. Inténtalo de nuevo.");
                    continue;
                }

                // Intenta convertir la entrada del usuario a un double.
                // NumberStyles.Any permite parsear números con diferentes formatos (ej. miles, decimales).
                if (double.TryParse(input, NumberStyles.Any, culture, out notaIngresada))
                {
                    // Valida que la nota esté en el rango esperado.
                    if (notaIngresada >= 0.0 && notaIngresada <= 10.0)
                    {
                        asignatura.Nota = notaIngresada;
                        entradaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Nota fuera del rango (0-10). Inténtalo de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número para la nota.");
                }
            }
        }
        Console.WriteLine("--- Notas registradas con éxito. ---\n");
    }

    // Método modificado para mostrar las asignaturas con sus notas.
    public void MostrarAsignaturasConNotas()
    {
        Console.WriteLine($"\n--- Resumen de Notas del curso '{NombreCurso}' ---");

        if (asignaturas.Count == 0)
        {
            Console.WriteLine("No hay asignaturas registradas en este curso.");
        }
        else
        {
            // Itera sobre cada asignatura y muestra el mensaje solicitado.
            foreach (var asignatura in asignaturas)
            {
                // Formato con dos decimales para la nota.
                Console.WriteLine($"En {asignatura.Nombre} has sacado {asignatura.Nota.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
        Console.WriteLine("--------------------------------------\n");
    }

    // Método para obtener el número actual de asignaturas en el curso.
    public int ContarAsignaturas()
    {
        return asignaturas.Count;
    }
}

// Clase principal del programa.
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("***** Programa de Gestión de Asignaturas y Notas *****\n");

        Curso miCurso = new Curso("Ingeniería de Software - 2025");

        miCurso.AgregarAsignatura(new Asignatura("Matemáticas"));
        miCurso.AgregarAsignatura(new Asignatura("Física"));
        miCurso.AgregarAsignatura(new Asignatura("Química"));
        miCurso.AgregarAsignatura(new Asignatura("Historia"));
        miCurso.AgregarAsignatura(new Asignatura("Lengua"));
        miCurso.AgregarAsignatura(new Asignatura("Programación Orientada a Objetos"));

        // Nuevo paso: Solicitar las notas al usuario.
        miCurso.SolicitarNotas();

        // Nuevo paso: Mostrar las asignaturas junto con las notas introducidas.
        miCurso.MostrarAsignaturasConNotas();

        Console.WriteLine($"Total de asignaturas en el curso: {miCurso.ContarAsignaturas()}");

        Console.WriteLine("\n***** Fin del Programa *****");

        // Console.ReadKey(); // Descomentar para pausar la consola si es necesario.
    }
}
