<h1 align="center">Estructura de base de datos</h1>

- Tabla `[entidades]`:
	*   Entidades que se pueden usar en el juego; Iniciales: Piedra, papel o tijeras.
	*   Posee: ID, Nombre

- Tabla `[juegos_estados]`:
	*   Estado actual de un juego: En proceso, Finalizado o Abandonado.
	*   Posee: ID, Nombre

- Tabla `[Jugadores]`:
	*   Posee los nombre de los jugadores registrados.
	*   Posee: ID, Nombre

- Tabla `[Reglas]`:
	*   Regla del juego, inicialmente posee la formula de como un item permite ganar sobre otro.
	*   Al cabo de finalizar el primer juego te permite agregar tus propias reglas.
	*   La formula es guardado en texto plano para permitir al sistema reconocer como usar los elementos.
	*   Posee: ID, Formula
	*	Depende de: entidades

- Tabla `[Juegos]`:
	*   Posee los jugadores jugando actualmente.
	*   Posee el turno actual, que jugador le toca, cual entidad ha sido seleccionada.
	*   Posee si el juego ha finalizado o no, quien va ganando o perdiendo.
	*   Posee: ID, Jugador1, Jugador2, Turno, SeleccionActual, TurnoJugador, Ganador, Perdedor, PuntajeJ1, PuntajeJ2, Estado, Regla
	*	Depende de: Jugadores, juegos_estados, reglas
