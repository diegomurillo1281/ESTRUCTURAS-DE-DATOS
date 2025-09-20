/*
==============================================
   UNIVERSIDAD ESTATAL AMAZÓNICA
   Estudiante: DIEGO JAIME MURILLO ORDEÑANA
   Proyecto: Catálogo de Revistas en C#
==============================================
*/

public class CatalogoRevistas
{
    private static string[] catalogo =
    {
        "Revista de Ciencia",
        "Tecnología Hoy",
        "Historia del Mundo",
        "Arte Moderno",
        "Naturaleza Viva",
        "Viajes y Aventura",
        "Cultura Popular",
        "Gastronomía Creativa",
        "Deportes Extremos",
        "Revista de Negocios",
        "Fotografía Digital"
    };

    public static void Main()
    {
        System.Console.WriteLine("==============================================");
        System.Console.WriteLine("   UNIVERSIDAD ESTATAL AMAZÓNICA");
        System.Console.WriteLine("   Estudiante: DIEGO JAIME MURILLO ORDEÑANA");
        System.Console.WriteLine("   Proyecto: Catálogo de Revistas en C#");
        System.Console.WriteLine("==============================================\n");

        bool continuar = true;

        while (continuar)
        {
            System.Console.WriteLine("\n--- Catálogo de Revistas ---");
            System.Console.WriteLine("1. Buscar revista");
            System.Console.WriteLine("2. Salir");
            System.Console.Write("Opción: ");
            string opcion = System.Console.ReadLine();

            if (opcion == "1")
            {
                System.Console.Write("Título a buscar: ");
                string titulo = System.Console.ReadLine();

                bool encontrado = BusquedaIterativa(titulo);
                System.Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
            }
            else if (opcion == "2")
            {
                continuar = false;
                System.Console.WriteLine("Adiós...");
            }
            else
            {
                System.Console.WriteLine("Opción no válida.");
            }
        }
    }

    // Búsqueda iterativa en el arreglo
    public static bool BusquedaIterativa(string titulo)
    {
        foreach (string t in catalogo)
            if (t.Equals(titulo, System.StringComparison.OrdinalIgnoreCase))
                return true;
        return false;
    }
}
