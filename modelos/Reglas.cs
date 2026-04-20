namespace modelos{

	public static class Reglas {

		/*Nombre de la tabla*/
		public static string Tabla_nombre		= "reglas";

		/*Estructura de la tabla y creacion*/
		public static string Tabla_estructura	= @"
			 id				integer		PRIMARY KEY
			,formato		text		NULL
			,creado			float		NULL
			,actualizado	float		NULL
			,eliminado		float		NULL
		";

		/*Llave primaria*/
		public static string Campo_id				= "id";

		/*Campos buscables*/
		public static string Campos_buscables		= "id|formato|creado|actualizado|eliminado";

		/*Campos insertables*/
		public static string Campos_insertables		= "formato";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "formato";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "eliminado";

		/*Depende de*/
		public static string Tabla_dependencia	= "";

		/*Campos Migrables*/
		public static string Datos_migrables	= ""
			+ "$[w]1[w]:3"
			+ "$[w]2[w]:1"
			+ "$[w]3[w]:2"
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
					,modelos.Reglas.Tabla_nombre
					,modelos.Reglas.Tabla_estructura
					,modelos.Reglas.Campos_insertables
					,modelos.Reglas.Campo_creado
					,modelos.Reglas.Datos_migrables
				);
			/**/
			/*Envio*/
				return _sistema_.Modelos.opciones( "", modelos.Reglas.Tabla_nombre );
			/**/
		}
	}
}