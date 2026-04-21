namespace modelos{

	public static class Jugadores {

		/*Nombre de la tabla*/
		public static string Tabla_nombre		= "jugadores";

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
		public static string Campos_buscables		= "id|nombre";

		/*Campos insertables*/
		public static string Campos_insertables		= "nombre";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "nombre";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "eliminado";


		/*Campos Migrables*/
		public static string Datos_migrables		= "";

		/*Depende de*/
		public static void tabla_dependencias(){}

		/*Tabla de puntajes*/
		public static void puntajes(){}
	}
}