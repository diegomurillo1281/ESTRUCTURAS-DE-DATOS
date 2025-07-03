using System;

// 1. Definición de la clase Nodo (Node)
// Representa un elemento individual en la lista enlazada.
public class Nodo
{
    // Valor que almacena el nodo. Puede ser de cualquier tipo (aquí int para simplicidad).
    public int Valor { get; set; }

    // Referencia al siguiente nodo en la lista.
    // Si es null, indica que es el último nodo.
    public Nodo Siguiente { get; set; }

    /// <summary>
    /// Constructor para crear un nuevo nodo.
    /// </summary>
    /// <param name="valor">El valor a almacenar en el nodo.</param>
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null; // Inicialmente, el nuevo nodo no apunta a nada.
    }
}

// 2. Definición de la clase ListaEnlazada (Linked List)
// Gestiona la colección de nodos.
public class ListaEnlazada
{
    // La cabeza de la lista, que apunta al primer nodo.
    // Si es null, la lista está vacía.
    public Nodo Cabeza { get; private set; }

    /// <summary>
    /// Constructor de la ListaEnlazada.
    /// Inicializa la cabeza como null, indicando una lista vacía.
    /// </summary>
    public ListaEnlazada()
    {
        Cabeza = null;
    }

    /// <summary>
    /// Agrega un nuevo nodo al final de la lista enlazada.
    /// </summary>
    /// <param name="valor">El valor del elemento a agregar.</param>
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);

        // Si la lista está vacía, el nuevo nodo se convierte en la cabeza.
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            // Si la lista no está vacía, recorremos hasta el último nodo.
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            // El último nodo ahora apunta al nuevo nodo.
            actual.Siguiente = nuevoNodo;
        }
        Console.WriteLine($"Elemento {valor} agregado a la lista.");
    }

    /// <summary>
    /// Calcula y devuelve el número de elementos en la lista enlazada.
    /// Recorre la lista desde la cabeza hasta el final, contando cada nodo.
    /// </summary>
    /// <returns>El número total de elementos en la lista.</returns>
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = Cabeza; // Empezamos desde la cabeza de la lista.

        // Recorremos la lista mientras el nodo actual no sea null.
        // Cada vez que avanzamos a un nodo, incrementamos el contador.
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente; // Movemos al siguiente nodo.
        }
        return contador;
    }

    /// <summary>
    /// Invierte el orden de los nodos en la lista enlazada.
    /// El primer elemento se convierte en el último y viceversa.
    /// </summary>
    public void InvertirLista()
    {
        if (Cabeza == null || Cabeza.Siguiente == null)
        {
            // Si la lista está vacía o tiene un solo elemento, no hay nada que invertir.
            Console.WriteLine("La lista está vacía o tiene un solo elemento. No se requiere inversión.");
            return;
        }

        Nodo previo = null;     // Nodo que apunta al nodo anterior en el recorrido.
        Nodo actual = Cabeza;   // Nodo que estamos procesando actualmente.
        Nodo siguienteTemp = null; // Nodo temporal para guardar la referencia al siguiente nodo.

        // Recorremos la lista, cambiando la dirección de los punteros 'Siguiente'.
        while (actual != null)
        {
            siguienteTemp = actual.Siguiente; // Guardamos el siguiente nodo antes de cambiar el puntero.
            actual.Siguiente = previo;        // El puntero 'Siguiente' del nodo actual apunta ahora al 'previo'.
            previo = actual;                  // 'Previo' avanza al nodo actual.
            actual = siguienteTemp;           // 'Actual' avanza al nodo que habíamos guardado como 'siguienteTemp'.
        }

        Cabeza = previo; // Una vez que 'actual' es null, 'previo' es la nueva cabeza de la lista invertida.
        Console.WriteLine("La lista ha sido invertida.");
    }

    /// <summary>
    /// Muestra todos los elementos de la lista enlazada por consola.
    /// </summary>
    public void MostrarLista()
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.Write("Elementos en la lista: ");
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.Write($"{actual.Valor} -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("NULL"); // Para indicar el final de la lista.
    }
}

// Clase principal para probar la implementación.
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Demostración de Lista Enlazada y Conteo de Elementos ---");

        // Crear una nueva instancia de la lista enlazada.
        ListaEnlazada miLista = new ListaEnlazada();

        // Mostrar la lista vacía y su conteo.
        miLista.MostrarLista();
        Console.WriteLine($"Número de elementos en la lista: {miLista.ContarElementos()}");

        Console.WriteLine("\n--- Agregando elementos ---");
        miLista.Agregar(10);
        miLista.Agregar(20);
        miLista.Agregar(30);
        miLista.Agregar(40);
        miLista.Agregar(50);

        // Mostrar la lista con elementos y su conteo.
        miLista.MostrarLista();
        Console.WriteLine($"Número de elementos en la lista: {miLista.ContarElementos()}");

        Console.WriteLine("\n--- Invirtiendo la lista ---");
        miLista.InvertirLista();

        // Mostrar la lista después de invertirla.
        miLista.MostrarLista();
        Console.WriteLine($"Número de elementos en la lista (después de invertir): {miLista.ContarElementos()}");

        Console.WriteLine("\n--- Intentando invertir una lista vacía ---");
        ListaEnlazada listaVacia = new ListaEnlazada();
        listaVacia.InvertirLista();
        listaVacia.MostrarLista();

        Console.WriteLine("\n--- Fin de la demostración ---");
        // Console.ReadKey(); // Descomentar para pausar la consola al finalizar.
    }
}
