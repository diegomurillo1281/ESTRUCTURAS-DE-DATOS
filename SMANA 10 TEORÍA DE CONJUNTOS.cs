using System;
using System.Collections.Generic;
using System.Linq;

namespace CampanaVacunacionCOVID
{
    public class Ciudadano
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool VacunadoPfizer { get; set; }
        public bool VacunadoAstraZeneca { get; set; }
        public bool PrimeraDosisPfizer { get; set; }
        public bool SegundaDosisPfizer { get; set; }
        public bool PrimeraDosisAstraZeneca { get; set; }
        public bool SegundaDosisAstraZeneca { get; set; }

        public Ciudadano(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public string EstadoVacunacion()
        {
            if (!VacunadoPfizer && !VacunadoAstraZeneca)
                return "No vacunado";
            
            if (VacunadoPfizer && VacunadoAstraZeneca)
                return "Ambas vacunas";
            
            if (VacunadoPfizer && SegundaDosisPfizer)
                return "Pfizer (ambas dosis)";
            
            if (VacunadoAstraZeneca && SegundaDosisAstraZeneca)
                return "AstraZeneca (ambas dosis)";
            
            if (VacunadoPfizer)
                return "Pfizer (solo primera dosis)";
            
            return "AstraZeneca (solo primera dosis)";
        }

        public override string ToString()
        {
            return $"{Id}: {Nombre} - {EstadoVacunacion()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE VACUNACIÓN COVID-19 ===");
            Console.WriteLine("Generando datos ficticios...\n");

            // 1. Crear conjunto de 500 ciudadanos
            List<Ciudadano> todosLosCiudadanos = GenerarCiudadanos(500);

            // 2. Vacunar ciudadanos
            VacunarCiudadanos(todosLosCiudadanos, 75, "Pfizer");
            VacunarCiudadanos(todosLosCiudadanos, 75, "AstraZeneca");

            // Aplicar operaciones de teoría de conjuntos
            Console.WriteLine("=== RESULTADOS DE LA CAMPAÑA DE VACUNACIÓN ===\n");

            // a. Ciudadanos que no se han vacunado
            var noVacunados = todosLosCiudadanos.Where(c => !c.VacunadoPfizer && !c.VacunadoAstraZeneca);
            MostrarResultado("CIUDADANOS NO VACUNADOS", noVacunados);

            // b. Ciudadanos que han recibido ambas dosis (de cualquier vacuna)
            var ambasDosis = todosLosCiudadanos.Where(c => 
                (c.VacunadoPfizer && c.SegundaDosisPfizer) || 
                (c.VacunadoAstraZeneca && c.SegundaDosisAstraZeneca));
            MostrarResultado("CIUDADANOS CON AMBAS DOSIS", ambasDosis);

            // c. Ciudadanos que solo han recibido la vacuna de Pfizer (al menos una dosis)
            var soloPfizer = todosLosCiudadanos.Where(c => c.VacunadoPfizer && !c.VacunadoAstraZeneca);
            MostrarResultado("CIUDADANOS SOLO CON PFIZER", soloPfizer);

            // d. Ciudadanos que solo han recibido la vacuna de AstraZeneca (al menos una dosis)
            var soloAstraZeneca = todosLosCiudadanos.Where(c => c.VacunadoAstraZeneca && !c.VacunadoPfizer);
            MostrarResultado("CIUDADANOS SOLO CON ASTRAZENECA", soloAstraZeneca);

            // e. Ciudadanos que han recibido ambas vacunas
            var ambasVacunas = todosLosCiudadanos.Where(c => c.VacunadoPfizer && c.VacunadoAstraZeneca);
            MostrarResultado("CIUDADANOS CON AMBAS VACUNAS", ambasVacunas);

            // Estadísticas
            MostrarEstadisticas(todosLosCiudadanos, noVacunados, ambasDosis, 
                               soloPfizer, soloAstraZeneca, ambasVacunas);

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static List<Ciudadano> GenerarCiudadanos(int cantidad)
        {
            var ciudadanos = new List<Ciudadano>();
            for (int i = 1; i <= cantidad; i++)
            {
                ciudadanos.Add(new Ciudadano(i, $"Ciudadano {i}"));
            }
            return ciudadanos;
        }

        static void VacunarCiudadanos(List<Ciudadano> ciudadanos, int cantidad, string tipoVacuna)
        {
            var random = new Random();
            var noVacunados = ciudadanos.Where(c => !c.VacunadoPfizer && !c.VacunadoAstraZeneca).ToList();
            
            // Asegurar que no intentamos vacunar más de los disponibles
            cantidad = Math.Min(cantidad, noVacunados.Count);
            
            for (int i = 0; i < cantidad; i++)
            {
                int index = random.Next(noVacunados.Count);
                var ciudadano = noVacunados[index];
                
                if (tipoVacuna == "Pfizer")
                {
                    ciudadano.VacunadoPfizer = true;
                    ciudadano.PrimeraDosisPfizer = true;
                    // 60% de probabilidad de tener segunda dosis
                    ciudadano.SegundaDosisPfizer = random.Next(100) < 60;
                }
                else
                {
                    ciudadano.VacunadoAstraZeneca = true;
                    ciudadano.PrimeraDosisAstraZeneca = true;
                    // 60% de probabilidad de tener segunda dosis
                    ciudadano.SegundaDosisAstraZeneca = random.Next(100) < 60;
                }
                
                noVacunados.RemoveAt(index);
            }
        }

        static void MostrarResultado(string titulo, IEnumerable<Ciudadano> conjunto)
        {
            Console.WriteLine($"=== {titulo} ===");
            Console.WriteLine($"Cantidad: {conjunto.Count()}");
            
            if (conjunto.Any())
            {
                Console.WriteLine("Ejemplos:");
                foreach (var ciudadano in conjunto.Take(5))
                {
                    Console.WriteLine($"  {ciudadano}");
                }
                if (conjunto.Count() > 5)
                {
                    Console.WriteLine($"  ... y {conjunto.Count() - 5} más");
                }
            }
            Console.WriteLine();
        }

        static void MostrarEstadisticas(List<Ciudadano> todos, 
                                       IEnumerable<Ciudadano> noVacunados,
                                       IEnumerable<Ciudadano> ambasDosis,
                                       IEnumerable<Ciudadano> soloPfizer,
                                       IEnumerable<Ciudadano> soloAstraZeneca,
                                       IEnumerable<Ciudadano> ambasVacunas)
        {
            Console.WriteLine("=== ESTADÍSTICAS GENERALES ===");
            Console.WriteLine($"Total de ciudadanos: {todos.Count}");
            Console.WriteLine($"No vacunados: {noVacunados.Count()} ({(noVacunados.Count() * 100.0 / todos.Count):F1}%)");
            Console.WriteLine($"Con ambas dosis: {ambasDosis.Count()} ({(ambasDosis.Count() * 100.0 / todos.Count):F1}%)");
            Console.WriteLine($"Solo Pfizer: {soloPfizer.Count()} ({(soloPfizer.Count() * 100.0 / todos.Count):F1}%)");
            Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count()} ({(soloAstraZeneca.Count() * 100.0 / todos.Count):F1}%)");
            Console.WriteLine($"Ambas vacunas: {ambasVacunas.Count()} ({(ambasVacunas.Count() * 100.0 / todos.Count):F1}%)");

            // Verificación de consistencia
            int totalReportado = noVacunados.Count() + soloPfizer.Count() + soloAstraZeneca.Count() + ambasVacunas.Count();
            Console.WriteLine($"Total reportado: {totalReportado} (debe ser {todos.Count})");
            Console.WriteLine($"Consistencia: {(totalReportado == todos.Count ? "✓ CORRECTA" : "✗ INCORRECTA")}");
        }
    }
}
