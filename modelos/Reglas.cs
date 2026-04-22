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
		public static string Campos_buscables		= "id|formato";

		/*Campos insertables*/
		public static string Campos_insertables		= "formato";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "formato";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "eliminado";

		/*Campos Migrables*/
		public static string Datos_migrables		= ""
			+ "$1>3;2>1;3>2"
		;

		/*Depende de*/
		public static void tabla_dependencias(){}
	}
}