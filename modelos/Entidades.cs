namespace modelos{

	public static class Entidades {

		/*Nombre de la tabla*/
		public static string Tabla_nombre		= "entidades";

		/*Estructura de la tabla y creacion*/
		public static string Tabla_estructura	= @"
			 id				integer		PRIMARY KEY
			,nombre			text		NULL
			,creado			float		NULL
			,actualizado	float		NULL
			,eliminado		float		NULL
		";

		/*Llave primaria*/
		public static string Campo_id				= "id";

		/*Campos buscables*/
		public static string Campos_buscables		= "id|nombre|creado|actualizado|eliminado";

		/*Campos insertables*/
		public static string Campos_insertables		= "nombre";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "nombre";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "eliminado";

		/*Campos Migrables*/
		public static string Datos_migrables	= ""
			+ "$Piedra"
			+ "$Papel"
			+ "$Tijeras"
		;

		/*Depende de*/
		public static void tabla_dependencias(){}

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
					,modelos.Entidades.Tabla_nombre
					,modelos.Entidades.Tabla_estructura
					,modelos.Entidades.Campos_insertables
					,modelos.Entidades.Campo_creado
					,modelos.Entidades.Datos_migrables
				);
			/**/
			/*Envio*/
				return _sistema_.Modelos.opciones( "", modelos.Entidades.Tabla_nombre );
			/**/
		}
	}
}