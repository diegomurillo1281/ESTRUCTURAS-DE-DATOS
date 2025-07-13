using System;
using System.Collections.Generic; // Necesario para usar la clase Stack

public class ParenthesisChecker
{
    // El método Main es el punto de entrada de la aplicación.
    public static void Main(string[] args)
    {
        // Ejemplos de expresiones para probar la función IsBalanced.
        string expression1 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string expression2 = "{[()]()}";
        string expression3 = "({[})"; // Desbalanceada
        string expression4 = "((()))";
        string expression5 = "(()"; // Desbalanceada
        string expression6 = ""; // Cadena vacía, considerada balanceada
        string expression7 = "([{}])"; // Balanceada
        string expression8 = "({[<]})"; // Desbalanceada (caracteres no reconocidos)
        string expression9 = "[(])"; // Desbalanceada (orden incorrecto)

        // Imprimir el resultado para cada expresión de prueba.
        Console.WriteLine($"Expresión: {expression1}");
        Console.WriteLine($"Resultado: {IsBalanced(expression1)}\n");

        Console.WriteLine($"Expresión: {expression2}");
        Console.WriteLine($"Resultado: {IsBalanced(expression2)}\n");

        Console.WriteLine($"Expresión: {expression3}");
        Console.WriteLine($"Resultado: {IsBalanced(expression3)}\n");

        Console.WriteLine($"Expresión: {expression4}");
        Console.WriteLine($"Resultado: {IsBalanced(expression4)}\n");

        Console.WriteLine($"Expresión: {expression5}");
        Console.WriteLine($"Resultado: {IsBalanced(expression5)}\n");

        Console.WriteLine($"Expresión: {expression6}");
        Console.WriteLine($"Resultado: {IsBalanced(expression6)}\n");

        Console.WriteLine($"Expresión: {expression7}");
        Console.WriteLine($"Resultado: {IsBalanced(expression7)}\n");

        Console.WriteLine($"Expresión: {expression8}");
        Console.WriteLine($"Resultado: {IsBalanced(expression8)}\n");

        Console.WriteLine($"Expresión: {expression9}");
        Console.WriteLine($"Resultado: {IsBalanced(expression9)}\n");

        // Mantener la consola abierta hasta que el usuario presione una tecla.
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    /// <summary>
    /// Determina si los paréntesis, llaves y corchetes en una expresión están correctamente balanceados.
    /// Utiliza una pila para almacenar los caracteres de apertura y verificar las coincidencias.
    /// </summary>
    /// <param name="expression">La cadena de expresión a verificar.</param>
    /// <returns>Una cadena indicando si la fórmula está balanceada o no, con un mensaje descriptivo.</returns>
    public static string IsBalanced(string expression)
    {
        // Se utiliza una pila (Stack<char>) para almacenar los caracteres de apertura
        // encontrados durante el recorrido de la expresión.
        Stack<char> stack = new Stack<char>();

        // Se itera sobre cada caracter de la expresión de entrada.
        foreach (char c in expression)
        {
            // Si el caracter actual es un paréntesis, llave o corchete de apertura,
            // se empuja (Push) a la pila.
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            // Si el caracter actual es un paréntesis, llave o corchete de cierre.
            else if (c == ')' || c == '}' || c == ']')
            {
                // Antes de intentar sacar un elemento de la pila, se verifica si está vacía.
                // Si la pila está vacía y encontramos un caracter de cierre, significa
                // que no hay un caracter de apertura correspondiente, por lo tanto, la expresión no está balanceada.
                if (stack.Count == 0)
                {
                    return "Fórmula no balanceada: Caracter de cierre sin apertura correspondiente.";
                }

                // Se saca (Pop) el último caracter de apertura de la pila.
                char openChar = stack.Pop();

                // Se verifica si el caracter de cierre actual coincide con el caracter de apertura que se acaba de sacar.
                // Si no coinciden (ej. se cierra un ')' pero se esperaba un '{'), la expresión no está balanceada.
                if (c == ')' && openChar != '(')
                {
                    return "Fórmula no balanceada: Paréntesis desbalanceado (cierre incorrecto).";
                }
                else if (c == '}' && openChar != '{')
                {
                    return "Fórmula no balanceada: Llaves desbalanceadas (cierre incorrecto).";
                }
                else if (c == ']' && openChar != '[')
                {
                    return "Fórmula no balanceada: Corchetes desbalanceados (cierre incorrecto).";
                }
            }
            // Otros caracteres (números, operadores, espacios) son ignorados, ya que no afectan el balanceo de los delimitadores.
        }

        // Después de iterar sobre toda la expresión, si la pila está vacía,
        // significa que cada caracter de apertura tuvo su caracter de cierre correspondiente.
        if (stack.Count == 0)
        {
            return "Fórmula balanceada.";
        }
        else
        {
            // Si la pila no está vacía, significa que quedaron caracteres de apertura
            // sin su correspondiente caracter de cierre, por lo tanto, la expresión no está balanceada.
            return "Fórmula no balanceada: Quedan caracteres de apertura sin cerrar.";
        }
    }
}
