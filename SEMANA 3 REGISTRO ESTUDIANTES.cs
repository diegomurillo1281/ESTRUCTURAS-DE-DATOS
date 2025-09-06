using System;
using System.Collections.Generic;

namespace RegistroEstudiantes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Sistema de Registro de Estudiantes ---");
            Console.WriteLine("");

            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            // Datos de Diego Bermudez
            string[] telefonosDiego = { "0963578952", "0912345879", "0999852147" };
            Estudiante diego = new Estudiante(
                3578941256,
                "Diego",
                "Bermudez",
                "GUAYAQUIL, CDLA 9 DE OCTUBRE MZ 5 V6",
                telefonosDiego
            );
            listaEstudiantes.Add(diego);

            // Datos de Luis Rivera
            string[] telefonosLuis = { "0952365894", "0967894563", "0958965412" };
            Estudiante luis = new Estudiante(
                7689451323,
                "Luis",
                "Rivera",
                "MANTA, CDLA EL PALMAR MZ 17 V3",
                telefonosLuis
            );
            listaEstudiantes.Add(luis);

            // Datos de Maria Rosas
            string[] telefonosMaria = { "0985412396", "0967854123", "0992147856" };
            Estudiante maria = new Estudiante(
                5698741256,
                "Maria",
                "Rosas",
                "GUAYAQUIL, CDLA LAS ACACIAS MZ 3 V2",
                telefonosMaria
            );
            listaEstudiantes.Add(maria);

            // Datos de Juana Lamas
            string[] telefonosJuana = { "0995236417", "0963585412", "0998521478" };
            Estudiante juana = new Estudiante(
                2358964781,
                "Juana",
                "Lamas",
                "MACHALA, CDLA 3 DE ABRIL MZ 117 V8",
                telefonosJuana
            );
            listaEstudiantes.Add(juana);

            Console.WriteLine("--- Registros de Estudiantes Creados ---");
            Console.WriteLine("");

            foreach (Estudiante est in listaEstudiantes)
            {
                est.MostrarInformacion();
                Console.WriteLine("\n-----------------------------------------------------\n");
            }

            Console.WriteLine("--- Fin de la Demostración de Registro de Estudiantes ---");
        }
    }
}
