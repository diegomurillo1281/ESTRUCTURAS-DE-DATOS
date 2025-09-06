using System; // Se importa el espacio de nombres 'System' que contiene tipos de datos básicos (como 'double')
              // y la clase 'Math' que es necesaria para usar 'Math.PI' y 'Math.Pow'.

// Define el espacio de nombres para tu aplicación.
// Todas las clases dentro de este archivo pertenecerán a 'FigurasGeometricas'.
namespace FigurasGeometricas
{
    /// <summary>
    /// Clase 'Circulo': Representa un círculo geométrico.
    /// Esta clase encapsula las características (datos) y el comportamiento (métodos) de un círculo.
    /// </summary>
    public class Circulo
    {
        // =======================================================================
        // PROPIEDADES (Atributos o Datos) - Aquí encapsulamos los TIPOS DE DATOS PRIMITIVOS
        // =======================================================================

        /// <summary>
        /// Propiedad 'Radio': Almacena el valor del radio del círculo.
        /// 'public double': Indica que 'Radio' es accesible desde fuera de la clase y su tipo es 'double'.
        ///                  'double' es un tipo de dato primitivo en C# que almacena números de punto flotante
        ///                  de doble precisión (permite decimales, ideal para medidas).
        /// '{ get; private set; }': Define cómo se puede acceder y modificar 'Radio'.
        ///    - 'get;': Permite leer el valor de 'Radio' desde cualquier parte del código.
        ///    - 'private set;': Indica que el valor de 'Radio' SOLO puede ser MODIFICADO o ASIGNADO
        ///                      desde DENTRO de la propia clase 'Circulo'.
        ///                      Esto es fundamental para la ENCAPSULACIÓN: una vez que el círculo es creado
        ///                      con un radio, no se puede cambiar directamente desde fuera, manteniendo su integridad.
        /// </summary>
        public double Radio { get; private set; }

        // =======================================================================
        // CONSTRUCTOR - Método especial para inicializar objetos
        // =======================================================================

        /// <summary>
        /// Constructor de la clase 'Circulo'.
        /// Este método se ejecuta automáticamente CADA VEZ que se crea una nueva instancia (objeto) de 'Circulo'.
        /// Su propósito es inicializar el 'Radio' del círculo cuando se crea.
        /// </summary>
        /// <param name="radio">
        /// Un parámetro de tipo 'double' que representa el radio inicial que tendrá el nuevo círculo.
        /// Este valor será utilizado para establecer el atributo 'Radio' del objeto.
        /// </param>
        public Circulo(double radio)
        {
            // Validación de entrada: Es una buena práctica de encapsulación asegurar que los datos sean válidos.
            // Un radio debe ser siempre un valor positivo.
            if (radio <= 0)
            {
                // Si el radio es inválido (cero o negativo), lanzamos una 'ArgumentException'.
                // Esto detiene la creación del objeto y notifica al programador sobre un uso incorrecto.
                throw new ArgumentException("El radio debe ser un valor positivo para crear un círculo.");
            }

            // Asignamos el valor del parámetro 'radio' al atributo 'Radio' de este objeto 'Circulo'.
            // Esta es la única forma de establecer el 'Radio' desde fuera de la clase,
            // ya que 'Radio' tiene un 'private set'.
            Radio = radio;
        }

        // =======================================================================
        // MÉTODOS - Comportamientos o Funcionalidades de la Clase
        // =======================================================================

        /// <summary>
        /// Método 'CalcularArea': Calcula el área del círculo.
        /// Este método es público ('public') lo que significa que se puede llamar desde fuera de la clase.
        /// Devuelve un valor de tipo 'double' (el área calculada).
        /// No requiere argumentos ya que utiliza el 'Radio' encapsulado del propio objeto.
        /// </summary>
        /// <returns>El área calculada del círculo como un valor 'double'.</returns>
        public double CalcularArea()
        {
            // Fórmula del área del círculo: π * radio^2
            // 'Math.PI' es una constante predefinida para el valor de Pi.
            // 'Math.Pow(base, exponente)' calcula la potencia (radio elevado al cuadrado).
            return Math.PI * Math.Pow(Radio, 2);
        }

        /// <summary>
        /// Método 'CalcularPerimetro': Calcula el perímetro (circunferencia) del círculo.
        /// Es un método público que devuelve un valor de tipo 'double'.
        /// No requiere argumentos ya que utiliza el 'Radio' encapsulado del objeto.
        /// </summary>
        /// <returns>El perímetro calculado del círculo como un valor 'double'.</returns>
        public double CalcularPerimetro()
        {
            // Fórmula del perímetro del círculo: 2 * π * radio
            return 2 * Math.PI * Radio;
        }

        /// <summary>
        /// Método 'MostrarInformacion': Imprime en la consola todos los detalles del círculo.
        /// Es un método público que no devuelve ningún valor ('void').
        /// Utiliza los valores encapsulados (Radio) y los resultados de otros métodos ('CalcularArea', 'CalcularPerimetro').
        /// </summary>
        public void MostrarInformacion()
        {
            Console.WriteLine(<span class="math-inline">"\-\-\- Información del Círculo \-\-\-"\);
