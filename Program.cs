using System;

class Program
{
    static void Main()
    {
        var campaña = new Vacunación();

        Console.WriteLine("Ciudadanos no vacunados:");
        foreach (var c in campaña.NoVacunados())
            Console.WriteLine(c);

        Console.WriteLine("\nCiudadanos con ambas dosis:");
        foreach (var c in campaña.AmbasDosis())
            Console.WriteLine(c);

        Console.WriteLine("\nCiudadanos solo con Pfizer:");
        foreach (var c in campaña.SoloPfizer())
            Console.WriteLine(c);

        Console.WriteLine("\nCiudadanos solo con AstraZeneca:");
        foreach (var c in campaña.SoloAstraZeneca())
            Console.WriteLine(c);
    }
}
