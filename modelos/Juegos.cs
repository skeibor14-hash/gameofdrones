namespace modelos{

	public static class Juegos {

		/*Nombre de la tabla*/
		public static string Tabla_nombre		= "juegos";

		/*Estructura de la tabla y creacion*/
		public static string Tabla_estructura	= @"
			 id						integer		PRIMARY KEY
			,jugador_id_1			integer		NULL
			,jugador_id_2			integer		NULL
			,puntaje_jugador_1		integer		NULL
			,puntaje_jugador_2		integer		NULL
			,regla_id				integer		NULL
			,juego_estado_id		integer		NULL
			,jugador_actual			integer		NULL
			,ganador_id				integer		NULL
			,perdedor_id			integer		NULL
			,creado					float		NULL
			,actualizado			float		NULL
			,eliminado				float		NULL
		";

		/*Llave primaria*/
		public static string Campo_id				= "id";

		/*Campos buscables*/
		public static string Campos_buscables		= "id|jugador_id_1|jugador_id_2|puntaje_jugador_1|puntaje_jugador_2|regla_id|juego_estado_id|jugador_actual|ganador_id|perdedor_id|creado|actualizado|eliminado";

		/*Campos insertables*/
		public static string Campos_insertables		= "nombre";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "nombre,jugador_id_1,jugador_id_2,puntaje_jugador_1,puntaje_jugador_2,regla_id,juego_estado_id,jugador_actual,ganador_id,perdedor_id";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "eliminado";

		/*Depende de*/
		public static string Tabla_dependencia	= "";

		/*Campos Migrables*/
		public static string Datos_migrables	= ""
			+ "$jugador_id_1"
			+ "$jugador_id_2"
			+ "$puntaje_jugador_1"
			+ "$puntaje_jugador_2"
			+ "$regla_id"
			+ "$juego_estado_id"
			+ "$jugador_actual"
			+ "$ganador_id"
			+ "$ganador_id"
			+ "$perdedor_id"
		;

		/*Listado de opciones ofrecida por modelos*/
		/**
		 *	Verificar tabla genera los siguiente posibles debugs:
		 * 		"creat_tabla"					-> Para ver codigo de creacion
		 * 		"seleccionar_tabla_query" 		-> Para ver chequeo si necesita migracion
		 * 		"seleccionar_tabla_resultado" 	-> Para ver chequeo de resultado
		 * 		"insertar_item" 				-> Para ver codigo de migracion en caso de ejecutarse
		 *
		 *	Opciones genera los siguiente posibles debugs:X
		 * 		"seleccionar_tabla_query" 		-> Para ver chequeo si necesita migracion
		 * 		"seleccionar_tabla_resultado" 	-> Para ver chequeo de resultado
		 * 		"opciones" 						-> Para ver tags de opciones
		*/
		public static string opciones(){
			/**/
			/*Verificar*/
				_sistema_.Modelos.verificar_tabla(
					""
					,modelos.Juegos.Tabla_nombre
					,modelos.Juegos.Tabla_estructura
					,modelos.Juegos.Campos_insertables
					,modelos.Juegos.Campo_creado
					,modelos.Juegos.Datos_migrables
				);
			/**/
			/*Envio*/
				return _sistema_.Modelos.opciones( "", modelos.Juegos.Tabla_nombre );
			/**/
		}
	}
}