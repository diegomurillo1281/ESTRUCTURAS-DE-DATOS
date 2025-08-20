using System;
using System.Collections.Generic;
using System.Linq;

namespace COVID_Vacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE VACUNACIÓN COVID-19 ===");
            Console.WriteLine("Generando datos ficticios...\n");
            
            var ciudadanos = GeneradorDatos.CrearCiudadanos(500);
            var vacunadosPfizer = GeneradorDatos.SeleccionarCiudadanosAleatorios(ciudadanos, 150);
            var vacunadosAstraZeneca = GeneradorDatos.SeleccionarCiudadanosAleatorios(ciudadanos, 150);
            
            vacunadosAstraZeneca = GeneradorDatos.EvitarSolapamiento(vacunadosAstraZeneca, vacunadosPfizer, ciudadanos);
            
            var ambasDosis = GeneradorDatos.SeleccionarCiudadanosAleatorios(
                vacunadosPfizer.Union(vacunadosAstraZeneca).ToList(), 250);
            
            var operaciones = new OperacionesConjuntos(ciudadanos, vacunadosPfizer, vacunadosAstraZeneca, ambasDosis);
            
            var reporte = new GeneradorReportes();
            reporte.GenerarReporteCompleto(operaciones);
            
            Console.WriteLine("Reporte generado exitosamente: 'Reporte_Vacunacion_COVID.pdf'");
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
