# =========================================================================
# UNIVERSIDAD ESTATAL AMAZÓNICA
# Estudiante: Diego Jaime Murillo Ordeñana
# =========================================================================

import time
import random
import sys

# Descripción: El agente fue utilizado para la conceptualización de la estructura de datos optimizada (diccionario)
# para la búsqueda por clave de hash, y para generar un esqueleto inicial del código. La lógica de implementación
# y la clase completa fueron escritas manualmente para este reporte.

class VueloFinder:
    """
    Clase para gestionar la base de datos de vuelos y realizar búsquedas eficientes.
    """
    
    def __init__(self, num_vuelos=100000):
        self.num_vuelos = num_vuelos
        self.db = {}
        print(f"✅ Creando base de datos optimizada de {self.num_vuelos} vuelos...")
        self.crear_db_optimizada()
        print(f"✅ Base de datos creada exitosamente.")
        
    def crear_db_optimizada(self):
        """
        Crea una base de datos ficticia de vuelos usando un diccionario para optimizar la búsqueda.
        La estructura de datos es:
        {
          "ORIGEN-DESTINO": [
            { "id": 1, "precio": 150.0, ... },
            { "id": 2, "precio": 120.0, ... }
          ],
          ...
        }
        """
        aeropuertos = ["GYE", "UIO", "BOG", "LIM", "MAD", "JFK"]
        aerolineas = ["Latam", "Avianca", "Iberia", "Delta"]
        
        for i in range(self.num_vuelos):
            origen = random.choice(aeropuertos)
            destino = random.choice(aeropuertos)
            while origen == destino:
                destino = random.choice(aeropuertos)
            
            ruta_clave = f"{origen}-{destino}"
            
            if ruta_clave not in self.db:
                self.db[ruta_clave] = []

            vuelo = {
                "id": i,
                "origen": origen,
                "destino": destino,
                "precio": round(random.uniform(50.0, 500.0), 2),
                "fecha": "2024-10-26",
                "aerolinea": random.choice(aerolineas)
            }
            self.db[ruta_clave].append(vuelo)

    def buscar_vuelos(self, origen, destino):
        """
        Busca vuelos por origen y destino usando la clave de hash optimizada.
        """
        ruta_clave = f"{origen}-{destino}"
        return self.db.get(ruta_clave, [])

    def reporteria(self, origen, destino):
        """
        Realiza la consulta de vuelos y muestra un reporte.
        """
        start_time = time.time()
        vuelos_encontrados = self.buscar_vuelos(origen, destino)
        end_time = time.time()
        
        print(f"\n--- Reportería de vuelos de {origen} a {destino} ---")
        
        if vuelos_encontrados:
            vuelos_encontrados.sort(key=lambda x: x['precio'])
            
            print(f"✅ Resultados encontrados: {len(vuelos_encontrados)}")
            print("Vuelos más baratos:")
            for vuelo in vuelos_encontrados[:5]:
                print(f"   ID: {vuelo['id']} | Precio: ${vuelo['precio']} | Aerolínea: {vuelo['aerolinea']}")
        else:
            print("❌ No se encontraron vuelos con esos criterios.")
            
        print(f"⏳ Tiempo de ejecución de la búsqueda: {end_time - start_time:.6f} segundos")
        
    def mostrar_ejemplo_reporteria(self):
        """
        Muestra un ejemplo de cómo se ven los datos en la estructura interna.
        """
        print("\n--- Ejemplo de estructura de datos (reportería) ---")
        ejemplo_clave = next(iter(self.db))
        print(f"Clave de ejemplo: {ejemplo_clave}")
        print("Primeros 2 vuelos para esta clave:")
        for vuelo in self.db[ejemplo_clave][:2]:
            print(vuelo)
        print("-" * 40)

if __name__ == "__main__":
    if len(sys.argv) < 3:
        print("Uso: python main.py <origen> <destino>")
        sys.exit(1)
        
    origen_busqueda = sys.argv[1].upper()
    destino_busqueda = sys.argv[2].upper()

    vuelos_app = VueloFinder(num_vuelos=100000)
    vuelos_app.mostrar_ejemplo_reporteria()
    vuelos_app.reporteria(origen_busqueda, destino_busqueda)
