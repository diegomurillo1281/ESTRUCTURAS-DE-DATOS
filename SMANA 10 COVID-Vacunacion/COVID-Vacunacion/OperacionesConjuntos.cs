using System;
using System.Collections.Generic;
using System.Linq;

namespace COVID_Vacunacion
{
    public class OperacionesConjuntos
    {
        public List<Ciudadano> TodosCiudadanos { get; }
        public List<Ciudadano> VacunadosPfizer { get; }
        public List<Ciudadano> VacunadosAstraZeneca { get; }
        public List<Ciudadano> AmbasDosis { get; }
        public List<Ciudadano> NoVacunados { get; }
        public List<Ciudadano> SoloPfizer { get; }
        public List<Ciudadano> SoloAstraZeneca { get; }

        public OperacionesConjuntos(List<Ciudadano> todosCiudadanos, List<Ciudadano> vacunadosPfizer,
                                  List<Ciudadano> vacunadosAstraZeneca, List<Ciudadano> ambasDosis)
        {
            TodosCiudadanos = todosCiudadanos;
            VacunadosPfizer = vacunadosPfizer;
            VacunadosAstraZeneca = vacunadosAstraZeneca;
            AmbasDosis = ambasDosis;

            NoVacunados = CalcularNoVacunados();
            SoloPfizer = CalcularSoloPfizer();
            SoloAstraZeneca = CalcularSoloAstraZeneca();
        }

        private List<Ciudadano> CalcularNoVacunados()
            => TodosCiudadanos.Except(VacunadosPfizer.Union(VacunadosAstraZeneca)).Take(100).ToList();

        private List<Ciudadano> CalcularSoloPfizer()
            => VacunadosPfizer.Except(VacunadosAstraZeneca).Take(75).ToList();

        private List<Ciudadano> CalcularSoloAstraZeneca()
            => VacunadosAstraZeneca.Except(VacunadosPfizer).Take(75).ToList();

        public void MostrarEstadisticas()
        {
            Console.WriteLine("=== ESTADÍSTICAS DE VACUNACIÓN ===");
            Console.WriteLine($"Total de ciudadanos: {TodosCiudadanos.Count}");
            Console.WriteLine($"No vacunados: {NoVacunados.Count}");
            Console.WriteLine($"Ambas dosis: {AmbasDosis.Count}");
            Console.WriteLine($"Solo Pfizer: {SoloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca: {SoloAstraZeneca.Count}");
            Console.WriteLine($"Total vacunados: {VacunadosPfizer.Union(VacunadosAstraZeneca).Count()}\n");
        }
    }
}
