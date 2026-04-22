using System.Text.RegularExpressions;

namespace _sistema_{

	public static class Sesiones {

		/*SESION Vencimiento*/
		public static string Sesion_vencimiento		= "";

		/*Nombre de la tabla*/
		public static string Tabla_nombre		= "sesiones";

		/*Estructura de la tabla y creacion*/
		public static string Tabla_estructura	= @"

			nombre			text		NULL

			,csrf			text		NULL
			,juego_id		integer		NULL
			,vencimiento	float		NULL

			,creado			float		NULL
			,actualizado	float		NULL
		";

		/*Llave primaria*/
		public static string Campo_id				= "";

		/*Campos buscables*/
		public static string Campos_buscables		= "nombre|vencimiento";

		/*Campos insertables*/
		public static string Campos_insertables		= "nombre|vencimiento";

		/*Campos Actualizables*/
		public static string Campos_actualizables	= "juego_id|vencimiento";

		/*Campos Informativos*/
		public static string Campo_creado			= "creado";
		public static string Campo_actualizado		= "actualizado";
		public static string Campo_eliminado		= "";

		/*Campos Migrables*/
		public static string Datos_migrables		= ""
		;

		/*Depende de*/
		public static void tabla_dependencias(){}

		/*Obtener vencimiento*/
		public static string vencimiento(){
			/**/
			/*Cargar vencimiento*/
				if(
					_sistema_.Sesiones.Sesion_vencimiento == ""
				){
					_sistema_.Sesiones.Sesion_vencimiento = _sistema_.Lector_ENV.obtener("sesion_vencimiento");
				}
			/**/
			/*Enviar vencimiento*/
				return _sistema_.Sesiones.Sesion_vencimiento;
			/**/
		}

		/*Obtiene un dato de la sesion; y la genera de no existir*/
		/**
		 *	Seleccion genera los siguiente posibles debugs:
		 * 		"seleccionar_tabla_query" 		-> Para ver chequeo si necesita migracion
		 * 		"seleccionar_tabla_resultado" 	-> Para ver chequeo de resultado
		 * 		"opciones" 						-> Para ver tags de opciones
		 *
		 *	Actualizar genera los siguiente posibles debugs:
		 * 		"actualizar_item" 				-> Chequeo de SQL
		 *
		 *	Borrado genera los siguiente posibles debugs:
		 * 		"borrar_item" 					-> Chequeo de SQL
		*/
		public static string obtener( HttpContext context, string elemento_buscar ){
			/**/
			/*Verificar tabla existente*/
				_sistema_.Modelos.verificar_tabla(
					""
					,_sistema_.Sesiones.Tabla_nombre
					,_sistema_.Sesiones.Campo_creado
					,_sistema_.Sesiones.Tabla_estructura
					,_sistema_.Sesiones.Campos_insertables
					,_sistema_.Sesiones.Datos_migrables
				);
			/**/
			/*Obtener Datos*/
				string nombre_cookie		= _sistema_.Lector_ENV.obtener("cookie_sesion");
				string valor_cookie			= _sistema_.Sanitizador.obtener_cookie( context, nombre_cookie );
				string valor_saneado		= _sistema_.Modelos.escapar( valor_cookie );
			/**/
			/*Datos de la sesion*/
				string datos_sesion			= _sistema_.Modelos.seleccionar_tabla( "", _sistema_.Sesiones.Tabla_nombre, "*", $"nombre={valor_saneado}", "", "1" );
			/**/
			/*Si elemento de sesion es TODO*/
				if(
					elemento_buscar == "*"
				){
					return datos_sesion;
				}
			/**/
			/*Match con valor*/
				Match capturador = Regex.Match( $"|{datos_sesion}|", @$"\|{elemento_buscar}\:(.*?)\|" );
				if( capturador.Success ){
					return capturador.Groups[1].Value;
				}
			/**/
			/*Verificar si match vacio*/
				return "";
			/**/
		}

		/*Obtiene un dato de la sesion; y la genera de no existir*/
		public static void guardar( HttpContext context, string elemento_guardar, string elemento_valor ){
			/**/
			/*Verificar tabla existente*/
				_sistema_.Modelos.verificar_tabla(
					""
					,_sistema_.Sesiones.Tabla_nombre
					,_sistema_.Sesiones.Campo_creado
					,_sistema_.Sesiones.Tabla_estructura
					,_sistema_.Sesiones.Campos_insertables
					,_sistema_.Sesiones.Datos_migrables
				);
			/**/
			/*Datos Principales*/
				string nombre_cookie		= _sistema_.Lector_ENV.obtener("cookie_sesion");
				string valor_cookie			= _sistema_.Sanitizador.obtener_cookie( context, nombre_cookie );
			/**/
			/*Validar*/
				if(
					valor_cookie == ""
				){
					valor_cookie = _sistema_.MD5_HASH.hazar();
				}
			/**/
			/*Datos secundarios*/
				string valor_saneado		= _sistema_.Modelos.escapar( valor_cookie );
				string vencimiento_saneado	= $"{_sistema_.Modelos.UNIX_DB}+{_sistema_.Sesiones.vencimiento()}";
				string elemento_saneado		= _sistema_.Modelos.escapar( elemento_valor );
				string expiracion			= $"{DateTime.UtcNow.AddDays(3):R}";
			/**/
			/*Insertar elemento si no existe*/
				if(
					"" == _sistema_.Modelos.seleccionar_tabla( "", _sistema_.Sesiones.Tabla_nombre, "1", $"nombre={valor_saneado}", "", "1" )
				){
					_sistema_.Modelos.insertar_item(
						""
						,_sistema_.Sesiones.Tabla_nombre
						,_sistema_.Sesiones.Campo_creado
						,$"nombre|vencimiento|{elemento_guardar}"
						,""
							/*"nombre|vencimiento*/
							+ $"${valor_saneado}|{vencimiento_saneado}|{elemento_saneado}"
					);
				}
			/**/
			/*Actualizar sesion actual*/
				else{
					_sistema_.Modelos.actualizar_item(
						""
						,_sistema_.Sesiones.Tabla_nombre
						,_sistema_.Sesiones.Campo_actualizado
						,$"vencimiento|{elemento_guardar}"
						,""
							+ $"${vencimiento_saneado}|{elemento_saneado}"
						,$"nombre={valor_saneado}"
					);
				}
			/**/
			/*Eliminar de DB items con fechas de vencimiento superadas*/
				string hora_actual = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
				_sistema_.Modelos.borrar_item(
					""
					,_sistema_.Sesiones.Tabla_nombre
					,$"{hora_actual} >= vencimiento"
				);
			/**/
			/*Enviar*/
				context.Response.Headers.Append("Set-Cookie", $"{nombre_cookie}={valor_cookie}; Path=/; HttpOnly; SameSite=Lax; Expires={expiracion}");
			/**/
		}
	}
}