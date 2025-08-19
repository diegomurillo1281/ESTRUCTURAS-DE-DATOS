using System;
using System.Collections.Generic;
using System.Linq;

public class Vacunación
{
    public HashSet<string> Todos { get; set; } = new();
    public HashSet<string> Pfizer { get; set; } = new();
    public HashSet<string> AstraZeneca { get; set; } = new();

    private List<string> nombres = new() {
        "Luis", "Ana", "Carlos", "María", "José", "Lucía", "Pedro", "Sofía", "Miguel", "Valentina",
        "Jorge", "Camila", "Andrés", "Paola", "Diego", "Fernanda", "Ricardo", "Isabela", "David", "Gabriela"
    };

    private List<string> apellidos = new() {
        "García", "Rodríguez", "Martínez", "López", "Gómez", "Pérez", "Sánchez", "Ramírez", "Torres", "Flores",
        "Castillo", "Morales", "Vargas", "Ramos", "Ortega", "Cruz", "Mendoza", "Silva", "Herrera", "Jiménez"
    };

    public Vacunación()
    {
        var rnd = new Random();

        // Generar 500 nombres únicos
        while (Todos.Count < 500)
        {
            string nombreCompleto = $"{nombres[rnd.Next(nombres.Count)]} {apellidos[rnd.Next(apellidos.Count)]}";
            Todos.Add(nombreCompleto);
        }

        var listaTodos = Todos.ToList();

        // Seleccionar 75 ciudadanos para Pfizer
        while (Pfizer.Count < 75)
        {
            Pfizer.Add(listaTodos[rnd.Next(listaTodos.Count)]);
        }

        // Seleccionar 75 ciudadanos para AstraZeneca
        while (AstraZeneca.Count < 75)
        {
            AstraZeneca.Add(listaTodos[rnd.Next(listaTodos.Count)]);
        }
    }

    public HashSet<string> NoVacunados() =>
        Todos.Except(Pfizer.Union(AstraZeneca)).ToHashSet();

    public HashSet<string> AmbasDosis() =>
        Pfizer.Intersect(AstraZeneca).ToHashSet();

    public HashSet<string> SoloPfizer() =>
        Pfizer.Except(AstraZeneca).ToHashSet();

    public HashSet<string> SoloAstraZeneca() =>
        AstraZeneca.Except(Pfizer).ToHashSet();
}
