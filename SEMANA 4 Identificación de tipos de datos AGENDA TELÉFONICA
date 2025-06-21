using System;
using System.Collections.Generic;
using System.Linq; // Necesario para LINQ (ordenamiento, filtrado)

// ==============================================================================
// 1. Definición de la Clase Contacto (Representa un "Registro" o "Estructura")
// ==============================================================================
public class Contacto
{
    // Propiedades de la clase (equivalente a los campos de un registro/estructura)
    public string Id { get; private set; } // Identificador único, generado automáticamente
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NumeroTelefono { get; set; } // Será la clave principal en el diccionario
    public string Email { get; set; }
    public string Direccion { get; set; }

    /// <summary>
    /// Constructor de la clase Contacto.
    /// </summary>
    /// <param name="nombre">Nombre(s) del contacto.</param>
    /// <param name="apellido">Apellido(s) del contacto.</param>
    /// <param name="numeroTelefono">Número de teléfono del contacto (obligatorio y único).</param>
    /// <param name="email">Correo electrónico del contacto (opcional).</param>
    /// <param name="direccion">Dirección física del contacto (opcional).</param>
    public Contacto(string nombre, string apellido, string numeroTelefono, string email = "", string direccion = "")
    {
        Id = Guid.NewGuid().ToString(); // Genera un ID único global
        Nombre = nombre;
        Apellido = apellido;
        NumeroTelefono = numeroTelefono;
        Email = email;
        Direccion = direccion;
    }

    /// <summary>
    /// Retorna el nombre completo del contacto en formato "Apellido(s) Nombre(s)".
    /// </summary>
    /// <returns>Nombre completo formateado.</returns>
    public string GetNombreCompleto()
    {
        return $"{Apellido} {Nombre}".Trim(); // .Trim() para eliminar espacios extra si uno de los campos está vacío
    }

    /// <summary>
    /// Muestra la información detallada del contacto en la consola.
    /// </summary>
    public void MostrarInfo()
    {
        Console.WriteLine($"--- Contacto ID: {Id.Substring(0, 8)}... ---"); // Mostrar solo los primeros 8 caracteres del ID
        Console.WriteLine($"  Nombre Completo: {GetNombreCompleto()}");
        Console.WriteLine($"  Teléfono: {NumeroTelefono}");
        if (!string.IsNullOrEmpty(Email))
        {
            Console.WriteLine($"  Email: {Email}");
        }
        if (!string.IsNullOrEmpty(Direccion))
        {
            Console.WriteLine($"  Dirección: {Direccion}");
        }
        Console.WriteLine("---------------------------");
    }
}

// ==============================================================================
// 2. Definición de la Clase AgendaTelefonica
//    (Utiliza List<Contacto> y Dictionary<string, Contacto> internamente)
// ==============================================================================
public class AgendaTelefonica
{
    // Miembros privados para almacenar los contactos
    private List<Contacto> _contactosLista;
    private Dictionary<string, Contacto> _contactosDiccionario;
    private string _tipoEstructura; // Para saber qué estructura se está usando

    /// <summary>
    /// Constructor de la AgendaTelefonica.
    /// Inicializa la estructura de datos para almacenar los contactos.
    /// </summary>
    /// <param name="tipoEstructura">"lista" para usar List<Contacto>,
    ///                                "diccionario" para usar Dictionary<string, Contacto>.</param>
    public AgendaTelefonica(string tipoEstructura = "lista")
    {
        _tipoEstructura = tipoEstructura.ToLower(); // Normalizar a minúsculas
        if (_tipoEstructura == "lista")
        {
            _contactosLista = new List<Contacto>();
            Console.WriteLine($"Agenda inicializada con una {_tipoEstructura} (vector dinámico).");
        }
        else if (_tipoEstructura == "diccionario")
        {
            // La clave será el número de teléfono del contacto
            _contactosDiccionario = new Dictionary<string, Contacto>();
            Console.WriteLine($"Agenda inicializada con un {_tipoEstructura} (mapa asociativo).");
        }
        else
        {
            throw new ArgumentException("Tipo de estructura no soportado. Use 'lista' o 'diccionario'.");
        }
    }

    /// <summary>
    /// Añade un nuevo objeto Contacto a la agenda.
    /// </summary>
    /// <param name="contacto">Objeto de tipo Contacto a agregar.</param>
    /// <returns>True si el contacto fue agregado, False en caso contrario (ej. duplicado).</returns>
    public bool AgregarContacto(Contacto contacto)
    {
        if (contacto == null)
        {
            Console.WriteLine("Error: El contacto a agregar es nulo.");
            return false;
        }

        if (_tipoEstructura == "lista")
        {
            _contactosLista.Add(contacto);
            Console.WriteLine($"Contacto '{contacto.GetNombreCompleto()}' agregado a la agenda.");
        }
        else if (_tipoEstructura == "diccionario")
        {
            // Usamos el número de teléfono como clave. Verificamos duplicidad.
            if (_contactosDiccionario.ContainsKey(contacto.NumeroTelefono))
            {
                Console.WriteLine($"Advertencia: Ya existe un contacto con el número {contacto.NumeroTelefono}. No se agregó.");
                return false;
            }
            _contactosDiccionario.Add(contacto.NumeroTelefono, contacto);
            Console.WriteLine($"Contacto '{contacto.GetNombreCompleto()}' agregado al diccionario.");
        }
        return true;
    }

    /// <summary>
    /// Elimina un contacto de la agenda por su número de teléfono o por nombre/apellido parcial.
    /// </summary>
    /// <param name="criterioBusqueda">String (número de teléfono, o parte de nombre/apellido).</param>
    /// <returns>True si el contacto fue eliminado, False en caso contrario.</returns>
    public bool EliminarContacto(string criterioBusqueda)
    {
        if (string.IsNullOrEmpty(criterioBusqueda))
        {
            Console.WriteLine("Criterio de búsqueda para eliminar no puede ser vacío.");
            return false;
        }

        bool eliminado = false;
        if (_tipoEstructura == "lista")
        {
            // Usamos RemoveAll para eliminar todos los contactos que coincidan
            int countBefore = _contactosLista.Count;
            _contactosLista.RemoveAll(c => criterioBusqueda.Equals(c.NumeroTelefono, StringComparison.OrdinalIgnoreCase) ||
                                           c.GetNombreCompleto().IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);
            if (_contactosLista.Count < countBefore)
            {
                Console.WriteLine($"Contacto(s) con criterio '{criterioBusqueda}' eliminado(s) de la lista.");
                eliminado = true;
            }
        }
        else if (_tipoEstructura == "diccionario")
        {
            // Intentar eliminar directamente por número de teléfono (clave)
            if (_contactosDiccionario.Remove(criterioBusqueda))
            {
                Console.WriteLine($"Contacto con número '{criterioBusqueda}' eliminado del diccionario.");
                eliminado = true;
            }
            else
            {
                // Si no es el número, buscar por nombre/apellido (requiere iterar sobre los valores)
                List<string> clavesAEliminar = new List<string>();
                foreach (var kvp in _contactosDiccionario) // kvp = KeyValuePair
                {
                    if (kvp.Value.GetNombreCompleto().IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        clavesAEliminar.Add(kvp.Key);
                    }
                }
                
                if (clavesAEliminar.Any())
                {
                    foreach (var key in clavesAEliminar)
                    {
                        Contacto c = _contactosDiccionario[key]; // Obtener el contacto antes de eliminar
                        _contactosDiccionario.Remove(key);
                        Console.WriteLine($"Contacto '{c.GetNombreCompleto()}' eliminado del diccionario por nombre/apellido.");
                    }
                    eliminado = true;
                }
            }
        }
        
        if (!eliminado)
        {
            Console.WriteLine($"Contacto con criterio '{criterioBusqueda}' no encontrado para eliminar.");
        }
        return eliminado;
    }

    /// <summary>
    /// Busca contactos por nombre, apellido o número de teléfono.
    /// </summary>
    /// <param name="criterioBusqueda">String con el nombre, apellido o número a buscar.</param>
    /// <returns>Una lista de objetos Contacto que coinciden con el criterio.</returns>
    public List<Contacto> BuscarContacto(string criterioBusqueda)
    {
        List<Contacto> resultados = new List<Contacto>();
        if (string.IsNullOrEmpty(criterioBusqueda))
        {
            Console.WriteLine("Criterio de búsqueda no puede ser vacío.");
            return resultados;
        }

        string criterioLower = criterioBusqueda.ToLower(); // Normalizar para búsqueda insensible a mayúsculas/minúsculas

        if (_tipoEstructura == "lista")
        {
            foreach (var contacto in _contactosLista)
            {
                if (criterioBusqueda.Equals(contacto.NumeroTelefono, StringComparison.OrdinalIgnoreCase) || // Búsqueda por número exacto
                    contacto.GetNombreCompleto().ToLower().Contains(criterioLower)) // Búsqueda por subcadena en nombre completo
                {
                    resultados.Add(contacto);
                }
            }
        }
        else if (_tipoEstructura == "diccionario")
        {
            // 1. Intentar búsqueda directa por número de teléfono (clave)
            if (_contactosDiccionario.TryGetValue(criterioBusqueda, out Contacto foundContactByNumber))
            {
                resultados.Add(foundContactByNumber);
            }
            // 2. Si no se encontró por clave, buscar por nombre/apellido (iterando sobre valores)
            // Asegurarse de no añadir duplicados si ya se encontró por número y coincide el nombre
            foreach (var contacto in _contactosDiccionario.Values)
            {
                if (!resultados.Contains(contacto) && // Evitar duplicados si ya se encontró por número
                    contacto.GetNombreCompleto().ToLower().Contains(criterioLower))
                {
                    resultados.Add(contacto);
                }
            }
        }
        return resultados;
    }

    /// <summary>
    /// Visualiza todos los contactos en la agenda (Reportería).
    /// </summary>
    public void MostrarTodosContactos()
    {
        Console.WriteLine("\n=== REPORTE: AGENDA TELEFÓNICA COMPLETA ===");
        
        // Obtener la colección de contactos de la estructura actual
        IEnumerable<Contacto> contactosAMostrar = null;
        if (_tipoEstructura == "lista")
        {
            contactosAMostrar = _contactosLista;
        }
        else if (_tipoEstructura == "diccionario")
        {
            contactosAMostrar = _contactosDiccionario.Values;
        }

        if (contactosAMostrar == null || !contactosAMostrar.Any()) // Verificar si la agenda está vacía
        {
            Console.WriteLine("La agenda está vacía.");
            Console.WriteLine("==========================================");
            return;
        }
        
        // Opcional: Ordenar los contactos para la visualización (por apellido, luego por nombre)
        var contactosOrdenados = contactosAMostrar.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre);

        int i = 1;
        foreach (var contacto in contactosOrdenados)
        {
            Console.WriteLine($"--- Contacto #{i} ---");
            contacto.MostrarInfo();
            i++;
        }
        
        Console.WriteLine($"Total de contactos: {(contactosAMostrar as ICollection<Contacto>)?.Count ?? contactosAMostrar.Count()}");
        Console.WriteLine("==========================================");
    }
}

// ==============================================================================
// 3. Clase Program: Contiene la lógica principal de la aplicación y los datos
// ==============================================================================
public class Program
{
    // Función auxiliar para parsear el nombre completo (Apellido(s) y Nombre(s))
    // Simplificación: asume que las últimas dos palabras son el nombre y el resto los apellidos.
    public static (string Apellido, string Nombre) ParsearNombreCompleto(string full_name_str)
    {
        string[] parts = full_name_str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 2)
        {
            string nombre = string.Join(" ", parts.Skip(parts.Length - 2));
            string apellido = string.Join(" ", parts.Take(parts.Length - 2));
            return (apellido.Trim(), nombre.Trim());
        }
        else if (parts.Length == 1)
        {
            return ("", parts[0].Trim()); // Si solo hay una palabra, asumimos que es nombre
        }
        else
        {
            return ("", "");
        }
    }

    // Listado de contactos proporcionado
    public static readonly List<(string Telefono, string NombreCompleto)> ContactosData = new List<(string, string)>
    {
        ("0941433526", "FRANCO COELLO KLEBER EDUARDO"),
        ("1720816386", "RODRIGUEZ HURTADO CARLOS VINICIO"),
        ("1718358987", "ALBAN CARVAJAL CRISTIAN EDUARDO"),
        ("0941313025", "CABANILLA CANDO JOSEPH ESTUARDO"),
        ("1207528173", "CUESTA GARCIA EDER ENRIQUE"),
        ("0956637300", "BORJA TROYA STALIN ALDAHIR"),
        ("0928268754", "DAVID ROMERO GABRIELA TABITA"),
        ("0850275116", "VERA GARCÍA DAYANA MONCERRATTE"),
        ("0503234395", "RAMIREZ OCHOA KEVIN VINICIO"),
        ("1314584358", "INTRIAGO VELEZ XIMENA KATHERINE"),
        ("0940168099", "CARRERA FLORES ALEJANDRA BRIGGITTE"),
        ("0931052732", "PARRALES LOZANO ALEXANDRA MADELAYNE"),
        ("0920079670", "CASTRO SUAREZ DIXON ANDRÉS"),
        ("0803660422", "VELASCO PEÑAFIEL ANDERSON IVÁN"),
        ("0930855432", "LOPEZ ASENCIO GABRIELA STEPHANIE"),
        ("0929383016", "CORNEJO MENDOZA ÁNGEL EDUARDO"),
        ("0941142051", "ALEAGA OCHOA JUAN SEBASTIÁN"),
        ("1724342728", "RECALDE ESPINOZA JHON BRAYAN"),
        ("1750103598", "CASTRO GUANOQUIZA WILLIAM RODRIGO"),
        ("0940299704", "CRIOLLO HERAS JOSELYN ISABEL"),
        ("0955886940", "MERCHAN SANCHEZ MICHAEL ESTIVEN"),
        ("1723276042", "RUANO TUAREZ JONATHAN MESÍAS"),
        ("0920323292", "ZAMBRANO MOREIRA JOSÉ ROBERTO"),
        ("1206447219", "SOBENIS SALDAÑA BYRON OMAR"),
        ("0919945857", "FIGUEROA ALMEIDA JOSSELINE MARÍA"),
        ("0925366858", "JURADO RON CARLOS ALBERTO"),
        ("2400170763", "GONZALEZ DESIDERIO CARLOS MANUEL"),
        ("1719123166", "DUMANCELA ORTIZ JENNY MARGOTH"),
        ("1755110705", "CEVALLOS MALDONADO HENRY BRAYAN"),
        ("1726879784", "CABRERA CABRERA JUAN CARLOS"),
        ("0603587130", "PAGUAY MONTALEZA MIRSHAN JAVIER"),
        ("0605180421", "TENEMAZA CARANQUI DENNYS ELICEO"),
        ("0952871143", "SOLEDISPA TANDAZO JESSICA SOLANGE"),
        ("0604129296", "VARGAS LÓPEZ JOHNNY PAÚL"),
        ("0603980095", "CABRERA MACHADO BLADIMIR ANTONIO"),
        ("0201891728", "CHASI SISA SERGIO ENRIQUE"),
        ("0550012421", "CAYANCELA IZA HENRY DANIEL")
    };

    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// </summary>
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Para manejar caracteres especiales como Ñ o acentos

        // =====================================================================
        // DEMOSTRACIÓN DE AGENDA CON LIST<CONTACTO> (VECTOR DINÁMICO)
        // =====================================================================
        Console.WriteLine("=".PadRight(80, '='));
        Console.WriteLine("DEMOSTRACIÓN DE AGENDA TELEFÓNICA CON LISTA (VECTOR DE OBJETOS)");
        Console.WriteLine("=".PadRight(80, '='));
        AgendaTelefonica agendaLista = new AgendaTelefonica("lista");

        Console.WriteLine("\n--- Agregando contactos a la Agenda (Lista) ---");
        foreach (var data in ContactosData)
        {
            (string apellido, string nombre) = ParsearNombreCompleto(data.NombreCompleto);
            Contacto contacto = new Contacto(nombre, apellido, data.Telefono);
            agendaLista.AgregarContacto(contacto);
        }

        // Reportería: Visualizar todos los contactos
        agendaLista.MostrarTodosContactos();

        // Reportería: Consultar/Buscar contactos en la Lista
        Console.WriteLine("\n".PadRight(30, '-') + " CONSULTAS EN AGENDA (LISTA) " + "".PadLeft(30, '-'));
        
        Console.WriteLine("\n--- Buscando 'EDUARDO' (en nombre/apellido) ---");
        List<Contacto> resultadosBusquedaLista = agendaLista.BuscarContacto("EDUARDO");
        if (resultadosBusquedaLista.Any())
        {
            foreach (var res in resultadosBusquedaLista)
