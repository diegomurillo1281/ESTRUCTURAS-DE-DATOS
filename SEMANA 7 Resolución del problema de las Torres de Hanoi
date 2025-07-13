using System;
using System.Collections.Generic; // Necesario para usar la clase Stack
using System.Linq; // Necesario para el método Reverse() en la visualización de la pila

public class TowersOfHanoi
{
    // Declaración de las tres torres como pilas de enteros.
    // Un entero representa el tamaño del disco (1 es el más pequeño, N es el más grande).
    private static Stack<int> towerA = new Stack<int>(); // Torre de origen (Source)
    private static Stack<int> towerB = new Stack<int>(); // Torre auxiliar (Auxiliary)
    private static Stack<int> towerC = new Stack<int>(); // Torre de destino (Destination)

    // Contador para llevar la cuenta del número de movimientos realizados.
    private static int moveCount = 0;

    // El método Main es el punto de entrada de la aplicación.
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Resolución del Problema de las Torres de Hanói ---");

        // Define el número de discos para el problema. Puedes cambiar este valor.
        int numberOfDisks = 4; // Por ejemplo, 4 discos.

        // Inicializa la torre de origen (towerA) con los discos.
        // Los discos se apilan del más grande (base) al más pequeño (cima).
        for (int i = numberOfDisks; i >= 1; i--)
        {
            towerA.Push(i);
        }

        Console.WriteLine($"\nEstado inicial con {numberOfDisks} discos:");
        PrintTowers(); // Muestra el estado inicial de las torres.

        Console.WriteLine("\nIniciando la resolución...\n");

        // Llama a la función recursiva principal para resolver las Torres de Hanói.
        // Los parámetros son: número de discos, torre de origen, torre auxiliar, torre de destino,
        // y los nombres de las torres para una mejor visualización.
        SolveHanoi(numberOfDisks, towerA, towerB, towerC, 'A', 'B', 'C');

        Console.WriteLine("\n--- ¡Problema de las Torres de Hanói resuelto! ---");
        Console.WriteLine($"Total de movimientos realizados: {moveCount}");

        // Mantiene la consola abierta hasta que el usuario presione una tecla.
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    /// <summary>
    /// Función recursiva que implementa el algoritmo para resolver las Torres de Hanói.
    /// </summary>
    /// <param name="n">El número de discos a mover en la operación actual.</param>
    /// <param name="source">La pila que representa la torre de origen.</param>
    /// <param name="auxiliary">La pila que representa la torre auxiliar.</param>
    /// <param name="destination">La pila que representa la torre de destino.</param>
    /// <param name="sourceName">El nombre de la torre de origen (para impresión).</param>
    /// <param name="auxiliaryName">El nombre de la torre auxiliar (para impresión).</param>
    /// <param name="destinationName">El nombre de la torre de destino (para impresión).</param>
    private static void SolveHanoi(int n, Stack<int> source, Stack<int> auxiliary, Stack<int> destination, char sourceName, char auxiliaryName, char destinationName)
    {
        // Caso base de la recursión: Si solo hay un disco (n=1), simplemente muévelo de la torre de origen a la de destino.
        if (n == 1)
        {
            MoveDisk(source, destination, sourceName, destinationName);
            return; // Termina la llamada recursiva para este caso.
        }

        // Paso 1: Mover los n-1 discos superiores de la torre de origen a la torre auxiliar.
        // Para esto, la torre de destino actual se convierte en la auxiliar temporal.
        SolveHanoi(n - 1, source, destination, auxiliary, sourceName, destinationName, auxiliaryName);

        // Paso 2: Mover el disco más grande (el n-ésimo disco) de la torre de origen a la torre de destino.
        MoveDisk(source, destination, sourceName, destinationName);

        // Paso 3: Mover los n-1 discos que están en la torre auxiliar a la torre de destino.
        // Para esto, la torre de origen original se convierte en la auxiliar temporal.
        SolveHanoi(n - 1, auxiliary, source, destination, auxiliaryName, sourceName, destinationName);
    }

    /// <summary>
    /// Realiza el movimiento físico de un disco entre dos torres (pilas) y actualiza el contador de movimientos.
    /// También imprime el movimiento realizado y el estado actual de todas las torres.
    /// </summary>
    /// <param name="source">La pila de la torre de donde se sacará el disco.</param>
    /// <param name="destination">La pila de la torre a donde se pondrá el disco.</param>
    /// <param name="sourceName">El nombre de la torre de origen (para impresión).</param>
    /// <param name="destinationName">El nombre de la torre de destino (para impresión).</param>
    private static void MoveDisk(Stack<int> source, Stack<int> destination, char sourceName, char destinationName)
    {
        // Incrementa el contador global de movimientos.
        moveCount++;

        // Saca (Pop) el disco de la cima de la torre de origen.
        int disk = source.Pop();

        // Pone (Push) el disco en la cima de la torre de destino.
        destination.Push(disk);

        // Imprime el movimiento actual.
        Console.WriteLine($"Movimiento {moveCount}: Mover disco {disk} de la Torre {sourceName} a la Torre {destinationName}");
        // Muestra el estado actual de todas las torres después del movimiento.
        PrintTowers();
    }

    /// <summary>
    /// Imprime el estado actual de todos los discos en cada una de las tres torres.
    /// Los discos se muestran de la base a la cima.
    /// </summary>
    private static void PrintTowers()
    {
        Console.Write("  Torre A: ");
        PrintStack(towerA); // Imprime el contenido de la Torre A.
        Console.Write("  Torre B: ");
        PrintStack(towerB); // Imprime el contenido de la Torre B.
        Console.Write("  Torre C: ");
        PrintStack(towerC); // Imprime el contenido de la Torre C.
        Console.WriteLine(); // Añade una línea en blanco para mejor legibilidad entre movimientos.
    }

    /// <summary>
    /// Función auxiliar para imprimir los elementos de una pila de forma legible,
    /// mostrando los discos desde la base hasta la cima.
    /// </summary>
    /// <param name="stack">La pila de enteros a imprimir.</param>
    private static void PrintStack(Stack<int> stack)
    {
        // Si la pila está vacía, imprime un mensaje indicándolo.
        if (stack.Count == 0)
        {
            Console.WriteLine("[Vacía]");
        }
        else
        {
            // Para imprimir los discos de la base a la cima (como se verían en la torre),
            // se convierte la pila a un array y luego se invierte.
            // Esto es porque Stack.ToArray() devuelve los elementos en orden LIFO (cima a base).
            int[] tempArray = stack.ToArray();
            Array.Reverse(tempArray); // Invierte el array para que el disco más grande esté primero.
            Console.WriteLine($"[{string.Join(", ", tempArray)}]"); // Imprime los discos separados por comas.
        }
    }
}
