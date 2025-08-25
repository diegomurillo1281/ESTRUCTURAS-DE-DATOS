
using System;
using System.Collections.Generic;
using System.Linq;

class Traductor
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto"},
        {"government", "gobierno"},
        {"company", "empresa"}
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese la frase en español: ");
                string frase = Console.ReadLine();
                string[] palabras = frase.Split(' ');
                for (int i = 0; i < palabras.Length; i++)
                {
                    string palabraLimpia = palabras[i].ToLower().Trim(',', '.', ';', ':');
                    string traduccion = diccionario.FirstOrDefault(x => x.Value == palabraLimpia).Key;
                    if (traduccion != null)
                    {
                        palabras[i] = palabras[i].Replace(palabraLimpia, traduccion);
                    }
                }
                Console.WriteLine("Traducción parcial: " + string.Join(" ", palabras));
            }
            else if (opcion == "2")
            {
                Console.Write("Ingrese la palabra en inglés: ");
                string ingles = Console.ReadLine().ToLower();
                Console.Write("Ingrese la traducción en español: ");
                string espanol = Console.ReadLine().ToLower();
                diccionario[ingles] = espanol;
                Console.WriteLine("Palabra agregada correctamente.");
            }
            else if (opcion == "0")
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}
