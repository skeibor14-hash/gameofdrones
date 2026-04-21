namespace modelos{

	public static class Juegos {

		/*Nombre de la tabla*/
		public static string Tabla_nombre		= "juegos";

		/*Estructura de la tabla y creacion*/
		public static string Tabla_estructura	= @"
			 id							integer		PRIMARY KEY
			,juego_estado_id			integer		NULL
			,regla_id					integer		NULL
			,jugador_actual				integer		NULL
			,turno_actual				integer		NULL
			,puntaje_jugador_1			integer		NULL
			,puntaje_jugador_2			integer		NULL
			,jugador_id_1				integer		NULL
			,jugador_id_2				integer		NULL
			,entidad_jugador_1_id		integer		NULL
			,entidad_jugador_2_id		integer		NULL
			,jugador_ganador_id			integer		NULL
			,jugador_perdedor_id		integer		NULL
			,creado						float		NULL
			,actualizado				float		NULL
			,eliminado					float		NULL
		";

		/*Llave primaria*/
		public static string Campo_id				= "id";

		/*Campos buscables*/
		public static string Campos_buscables		= "id|jugador_id_1|jugador_id_2|puntaje_jugador_1|puntaje_jugador_2|juego_estado_id";

		/*Campos insertables*/
		public static string Campos_insertables		= "juego_estado_id|regla_id|jugador_actual|turno_actual|puntaje_jugador_1|puntaje_jugador_2|jugador_id_1|jugador_id_2|entidad_jugador_1_id|entidad_jugador_2_id|jugador_ganador_id|jugador_perdedor_id";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "juego_estado_id|jugador_actual|turno_actual|puntaje_jugador_1|puntaje_jugador_2|entidad_jugador_1_id|entidad_jugador_2_id|jugador_ganador_id|jugador_perdedor_id";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "eliminado";


		/*Campos Migrables*/
		public static string Datos_migrables		= "";

		/*Depende de*/
		public static void tabla_dependencias(){}
	}
}