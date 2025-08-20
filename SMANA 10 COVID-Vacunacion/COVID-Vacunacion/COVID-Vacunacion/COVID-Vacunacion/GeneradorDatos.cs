using System;
using System.Collections.Generic;
using System.Linq;

namespace COVID_Vacunacion
{
    public static class GeneradorDatos
    {
        private static readonly Random random = new Random();
        private static readonly string[] Nombres = {
            "Juan", "María", "Carlos", "Ana", "Luis", "Laura", "Pedro", "Sofía", "José", "Elena",
            "Miguel", "Isabel", "Francisco", "Carmen", "David", "Andrea", "Javier", "Patricia", "Daniel", "Rosa",
            "Antonio", "Lucía", "Manuel", "Teresa", "Pablo", "Marta", "Ángel", "Cristina", "Fernando", "Raquel",
            "Jorge", "Eva", "Sergio", "Nuria", "Alberto", "Silvia", "Raúl", "Inés", "Enrique", "Olga",
            "Diego", "Adriana", "Víctor", "Beatriz", "Rubén", "Clara", "Óscar", "Lorena", "Andrés", "Monica"
        };

        private static readonly string[] Apellidos = {
            "García", "Rodríguez", "González", "Fernández", "López", "Martínez", "Sánchez", "Pérez", "Gómez", "Martín",
            "Jiménez", "Ruiz", "Hernández", "Díaz", "Moreno", "Álvarez", "Muñoz", "Romero", "Alonso", "Gutiérrez",
            "Navarro", "Torres", "Domínguez", "Vázquez", "Ramos", "Gil", "Ramírez", "Serrano", "Blanco", "Molina",
            "Morales", "Suárez", "Ortega", "Delgado", "Castro", "Ortiz", "Rubio", "Marín", "Sanz", "Núñez",
            "Iglesias", "Medina", "Garrido", "Cortés", "Castillo", "Santos", "Lozano", "Guerrero", "Cano", "Prieto"
        };

        private static readonly string[] Ciudades = {
            "Bogotá", "Medellín", "Cali", "Barranquilla", "Cartagena",
            "Bucaramanga", "Pereira", "Manizales", "Cúcuta", "Ibagué",
            "Santa Marta", "Villavicencio", "Pasto", "Montería", "Valledupar"
        };

        public static List<Ciudadano> CrearCiudadanos(int cantidad)
        {
            var ciudadanos = new List<Ciudadano>();
            var cedulasGeneradas = new HashSet<string>();

            for (int i = 0; i < cantidad; i++)
            {
                string cedula;
                do cedula = $"{random.Next(10, 99)}.{random.Next(100, 999)}.{random.Next(100, 999)}-{random.Next(0, 9)}";
                while (cedulasGeneradas.Contains(cedula));

                cedulasGeneradas.Add(cedula);
                string nombre = Nombres[random.Next(Nombres.Length)];
                string apellido = $"{Apellidos[random.Next(Apellidos.Length)]} {Apellidos[random.Next(Apellidos.Length)]}";
                int edad = random.Next(18, 81);
                string ciudad = Ciudades[random.Next(Ciudades.Length)];

                ciudadanos.Add(new Ciudadano(cedula, nombre, apellido, edad, ciudad));
            }
            return ciudadanos;
        }

        public static List<Ciudadano> SeleccionarCiudadanosAleatorios(List<Ciudadano> lista, int cantidad)
            => lista.OrderBy(x => random.Next()).Take(cantidad).ToList();

        public static List<Ciudadano> EvitarSolapamiento(List<Ciudadano> conjunto, List<Ciudadano> exclusion, List<Ciudadano> total)
            => SeleccionarCiudadanosAleatorios(total.Except(exclusion).ToList(), conjunto.Count);
    }
}
