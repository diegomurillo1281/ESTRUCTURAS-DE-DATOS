// ------------------------------------------------------------
// Implementación de teoría de pilas y colas
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;

public class NombreYApellido
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; }

    public NombreYApellido(int id, string nombreCompleto)
    {
        Id = id;
        NombreCompleto = nombreCompleto;
    }

    public override string ToString()
    {
        return $"[ID: {Id}, Nombre y Apellido: {NombreCompleto}]";
    }
}

public class Atraccion
{
    private Queue<NombreYApellido> cola = new Queue<NombreYApellido>();
    private List<NombreYApellido> asientosAsignados = new List<NombreYApellido>();
    private int capacidad;

    public Atraccion(int capacidad)
    {
        this.capacidad = capacidad;
    }

    public void EncolarNombreYApellido(NombreYApellido nombreYApellido)
    {
        cola.Enqueue(nombreYApellido);
    }

    public void AsignarAsientos()
    {
        asientosAsignados.Clear();
        for (int i = 0; i < capacidad && cola.Count > 0; i++)
        {
            asientosAsignados.Add(cola.Dequeue());
        }
    }

    public void VisualizarCola()
    {
        Console.WriteLine("\nNombres y Apellidos en cola:");
        foreach (var nombreYApellido in cola)
        {
            Console.WriteLine(nombreYApellido);
        }
    }

    public NombreYApellido? ConsultarPrimerElemento()
    {
        return cola.Count > 0 ? cola.Peek() : null;
    }

    public void VisualizarAsientosAsignados()
    {
        Console.WriteLine("\nAsientos asignados:");
        foreach (var nombreYApellido in asientosAsignados)
        {
            Console.WriteLine(nombreYApellido);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<string> nombresYApellidos = new List<string>
        {
            "Santiago García", "Valentina Martínez", "Andrés López", "Camila Rodríguez", "Sebastián Pérez",
            "Sofía González", "Mateo Ramírez", "Isabella Fernández", "Nicolás Díaz", "Luciana Torres",
            "Alejandro Gómez", "Victoria Sánchez", "Juan Pablo Mendoza", "Mariana Ruiz", "Diego Herrera",
            "Ana María Castro", "Gabriel Vargas", "Martina Álvarez", "Lucas Ortiz", "Daniela Morales",
            "Facundo López", "Valeria Acosta", "Tomás Medina", "Renata Flores", "Javier Suárez",
            "Paula Navarro", "Matías Romero", "Antonella Benítez", "Franco Silva", "Julieta Ríos"
        };

        Atraccion atraccion = new Atraccion(10); // Capacidad de 10 asientos

        // Simular llegada de 30 nombres y apellidos
        for (int i = 0; i < 30; i++)
        {
            string nombreCompleto = nombresYApellidos[i % nombresYApellidos.Count];
            atraccion.EncolarNombreYApellido(new NombreYApellido(i + 1, nombreCompleto));
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        atraccion.VisualizarCola();
        Console.WriteLine("\nAsignando asientos...");
        atraccion.AsignarAsientos();
        atraccion.VisualizarAsientosAsignados();

        NombreYApellido? primero = atraccion.ConsultarPrimerElemento();
        if (primero != null)
        {
            Console.WriteLine($"\nPrimer nombre y apellido en cola: {primero}");
        }
        else
        {
            Console.WriteLine("\nNo hay nombres y apellidos en la cola.");
        }

        stopwatch.Stop();
        Console.WriteLine($"\n--- Tiempo de Ejecución: {stopwatch.ElapsedMilliseconds} ms ---");

        Console.WriteLine("\nSimulación finalizada. Presiona cualquier tecla para salir.");
        Console.ReadKey();
    }
}
