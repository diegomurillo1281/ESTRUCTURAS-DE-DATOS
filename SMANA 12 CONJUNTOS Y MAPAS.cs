# Módulo principal para el sistema de gestión de torneos

def main():
    """
    Función principal para la gestión de un torneo de fútbol.
    """
    torneo = {}  # Mapa para almacenar equipos y jugadores
    jugadores_registrados = set()  # Conjunto para asegurar la unicidad de jugadores

    while True:
        print("\n--- MENÚ PRINCIPAL ---")
        print("1. Registrar equipo y jugador")
        print("2. Visualizar equipos y jugadores")
        print("3. Salir")

        opcion = input("Seleccione una opción: ")

        if opcion == '1':
            registrar_jugador(torneo, jugadores_registrados)
        elif opcion == '2':
            reporteria(torneo, jugadores_registrados)
        elif opcion == '3':
            print("Saliendo del sistema...")
            break
        else:
            print("Opción no válida. Intente de nuevo.")

def registrar_jugador(torneo, jugadores_registrados):
    """
    Registra un jugador en un equipo.
    """
    nombre_equipo = input("Ingrese el nombre del equipo: ").strip().capitalize()
    nombre_jugador = input("Ingrese el nombre del jugador: ").strip().capitalize()

    if nombre_jugador in jugadores_registrados:
        print(f"Error: El jugador '{nombre_jugador}' ya está registrado en el torneo.")
        return

    if nombre_equipo not in torneo:
        torneo[nombre_equipo] = set()
        print(f"Se ha creado el equipo '{nombre_equipo}'.")
    
    torneo[nombre_equipo].add(nombre_jugador)
    jugadores_registrados.add(nombre_jugador)
    print(f"El jugador '{nombre_jugador}' ha sido registrado en el equipo '{nombre_equipo}'.")


def reporteria(torneo, jugadores_registrados):
    """
    Muestra los reportes de equipos y jugadores.
    """
    print("\n--- REPORTE ---")
    print("1. Ver todos los equipos")
    print("2. Ver jugadores de un equipo")
    print("3. Ver todos los jugadores del torneo")
    print("4. Volver al menú principal")

    opcion_reporte = input("Seleccione una opción de reporte: ")

    if opcion_reporte == '1':
        print("\n--- EQUIPOS REGISTRADOS ---")
        if not torneo:
            print("No hay equipos registrados.")
        else:
            for equipo in torneo.keys():
                print(f"- {equipo}")

    elif opcion_reporte == '2':
        nombre_equipo = input("Ingrese el nombre del equipo para ver sus jugadores: ").strip().capitalize()
        if nombre_equipo in torneo:
            print(f"\n--- JUGADORES DE {nombre_equipo.upper()} ---")
            if not torneo[nombre_equipo]:
                print(f"El equipo '{nombre_equipo}' no tiene jugadores registrados.")
            else:
                for jugador in sorted(list(torneo[nombre_equipo])):
                    print(f"- {jugador}")
        else:
            print(f"El equipo '{nombre_equipo}' no está registrado.")

    elif opcion_reporte == '3':
        print("\n--- TODOS LOS JUGADORES DEL TORNEO ---")
        if not jugadores_registrados:
            print("No hay jugadores registrados en el torneo.")
        else:
            for jugador in sorted(list(jugadores_registrados)):
                print(f"- {jugador}")
    
    elif opcion_reporte == '4':
        return
    else:
        print("Opción no válida. Volviendo al menú de reportes.")

if __name__ == "__main__":
    main()
