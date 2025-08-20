using System;

namespace COVID_Vacunacion
{
    public class Ciudadano : IEquatable<Ciudadano>
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }

        public Ciudadano(string cedula, string nombre, string apellido, int edad, string ciudad)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Ciudad = ciudad;
        }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public bool Equals(Ciudadano other) => other != null && Cedula == other.Cedula;
        public override bool Equals(object obj) => Equals(obj as Ciudadano);
        public override int GetHashCode() => Cedula.GetHashCode();
        public override string ToString() => $"{NombreCompleto} - {Cedula} - {Edad} años - {Ciudad}";
    }
}
