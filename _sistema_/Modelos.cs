using Microsoft.Data.Sqlite;
using System.Text.RegularExpressions;

namespace _sistema_{

	/*Modelo base*/
	public static class Modelos{


		/*Escape para la DB Actual*/
		public static string Escape_db				= @"""";

		/*Elemento UNIX DB*/
		public static string UNIX_DB				= "STRFTIME('%s', 'now')";

		/*Codigo de manipulacion de tablas; Solo se ejecuta si la tabla no existe*/
		public static string Creacion				= "CREATE TABLE IF NOT EXISTS {NOMBRE_TABLA}( {ESTRUCTURA} );";

		/*Insersion estandar inicial*/
		public static string Insersion_inicio		= "INSERT INTO {NOMBRE_TABLA}( {CAMPO_CREADO},{COLUMNAS} )VALUES";

		/*N Objetos insertables*/
		public static string Insersion_fin			= ",( {UNIX_DB},{COLUMNAS_INSERT} )";

		/*Actualizacion estandar; Solo se actualizará por ID*/
		public static string Actualizacion			= "UPDATE {NOMBRE_TABLA} SET {CAMPO_ACTUALIZADO}={UNIX_DB},{COLUMNAS_UPDATE} {WHERES};";

		/*Selección estandar; Solo se utilizara estos queries*/
		public static string Busqueda				= "SELECT {COLUMNAS} {FROM} {WHERES} {OFFSET} {LIMIT} {ORDER};";

		/*Delete estandar; Solo se utilizara en casos especiales, de resto se utilizara el campo ELIMINADO*/
		public static string Borrado				= "DELETE FROM {NOMBRE_TABLA} WHERE {WHERES};";


		/*Escapar campos  para hacerlos seguros a DB; Retornar un campo escapado encerrado por comillas o el separador de turno*/
		static public string escapar( string valor ){
			/**/
			/*Eliminar espacios innecesarios;Crear valor sanitizado*/
				string	valor_saneado	= _sistema_.Sanitizador.escapar( Regex.Replace( valor.Trim(), @"\s+", " ") );
			/**/
			/*Encerrar entre las comillas de DB*/
				valor_saneado			= $"{_sistema_.Modelos.Escape_db}{valor_saneado}{_sistema_.Modelos.Escape_db}";
			/**/
			/*Nullificar*/
				if(
					valor_saneado == ( _sistema_.Modelos.Escape_db + _sistema_.Modelos.Escape_db )
				){
					valor_saneado = "NULL";
				}
			/**/
			/*Encerrar entre las comillas de DB*/
				return valor_saneado;
			/**/
		}


		/*Funcion de verificar integridad de tabla; crea si no existe; migra si debe migrar*/
		/**
		 * Debug permite uso de:
		 * 		"crear_tabla"					-> Para ver codigo de creacion
		 * 		"seleccionar_tabla_query" 		-> Para ver chequeo si necesita migracion
		 * 		"seleccionar_tabla_resultado" 	-> Para ver chequeo de resultado
		 * 		"insertar_item" 				-> Para ver codigo de migracion en caso de ejecutarse
		*/
		static public void verificar_tabla(
			string debug
			,string nombre_tabla
			,string campo_creado
			,string estructura_tabla
			,string campos_insertables
			,string datos_migrables
		){

			/*Crear tabla si no existe*/
			_sistema_.Modelos.crear_tabla( debug, nombre_tabla, estructura_tabla );

			/*Migrar tabla si migrable*/
			_sistema_.Modelos.migrar_tabla( debug, nombre_tabla, campo_creado, campos_insertables, datos_migrables );
		}

		/*Funcion de crear tabla*/
		/**
		 * - Crea la tabla si no existe;
		 * - No realiza mas procesos si la tabla existe
		*/
		static public void crear_tabla( string debug, string nombre_tabla, string estructura_tabla ){
			/**/
			/*Obtener Generar variables*/
				string creacion = "";
			/**/
			/*Obtener Codigo de creacion*/
				creacion = _sistema_.Modelos.Creacion;
			/**/
			/*Remplazar valores*/
				creacion = creacion.Replace("{NOMBRE_TABLA}",	nombre_tabla				);
				creacion = creacion.Replace("{ESTRUCTURA}",		estructura_tabla			);
			/**/
			/*DEBUG de creacion*/
				if(
					debug == "crear_tabla"
				){
					throw new ArgumentNullException( @$"[TESTING DE SQL en ""crear_tabla""] -> {creacion}" );
				}
			/**/
			/*Crear Tabla o fallar en el intento*/
				_sistema_.DB_Starter.ejecutar( debug, creacion );
			/**/
		}

		/*Funcion de migrar tabma*/
		/**
		 * - Si la tabla esta vacia inserta los datos migrables
		 * - No realiza mas procesos si la tabla existe
		 * - Depende de objetos migrables
		*/
		static public void migrar_tabla( string debug, string nombre_tabla, string campo_creado, string campos_insertables, string datos_migrables ){
			if(
				"" != datos_migrables
				&&
				"" == _sistema_.Modelos.seleccionar_tabla( debug, nombre_tabla, "1", "", "", "1" )
			){
				_sistema_.Modelos.insertar_item( debug, nombre_tabla, campo_creado, campos_insertables, datos_migrables );
			}
		}

		/*Funcion de insertar*/
		static public void insertar_item( string debug, string nombre_tabla, string campo_creado, string campos_insertables, string datos_insertables ){
			/**/
			/*Obtener Generar variables*/
				string insersion_inicio		= "";
				string insersion_fin		= "";
			/**/
			/*Obtener Codigo de insersion_inicio*/
				insersion_inicio = _sistema_.Modelos.Insersion_inicio;
			/**/
			/*Remplazar valores*/
				insersion_inicio = insersion_inicio.Replace("{NOMBRE_TABLA}",		nombre_tabla							);
				insersion_inicio = insersion_inicio.Replace("{CAMPO_CREADO}",		campo_creado							);
				insersion_inicio = insersion_inicio.Replace("{COLUMNAS}",			campos_insertables.Replace("|",",")		);
			/**/
			/*Insertar Item; insertar o fallar en el intento*/
				foreach( string filas in datos_insertables.Substring( 1 ).Split("$") ){
					insersion_fin += _sistema_.Modelos.Insersion_fin.Replace("{COLUMNAS_INSERT}", filas.Replace("|",",") );
				}
			/**/
			/*Incluir UNIX DB*/
				insersion_fin	= insersion_fin.Replace("{UNIX_DB}", _sistema_.Modelos.UNIX_DB );
			/**/
			/*Remocion de trail*/
				insersion_fin	= insersion_fin.Substring( 1 );
			/**/
			/*Union de elementos*/
				string insersion_final = $"{insersion_inicio}{insersion_fin};";
			/**/
			/*DEBUG de Insersion*/
				if(
					debug == "insertar_item"
				){
					throw new ArgumentNullException( $@"[TESTING DE SQL en ""insertar_item""] -> {insersion_final}" );
				}
			/**/
			/*Ejecutar SQL*/
				_sistema_.DB_Starter.ejecutar( debug, insersion_final );
			/**/
		}

		/*Funcion de actualizar*/
		static public void actualizar_item( string debug, string nombre_tabla, string campo_actualizado, string campos_actualizables, string datos_actualizables, string wheres ){
			/**/
			/*Generar colector*/
				int i					= 1;
				string i_str			= "1";
				string colector_update	= "";
			/**/
			/*Crear columnas actualizables*/
				foreach( string filas in campos_actualizables.Split("|") ){
					/**/
					/*Coleccionar FILA*/
						colector_update += $",{filas}={{COLUMNA_{i_str}}}";
					/**/
					/*ITERAR*/
						++i;
						i_str = i.ToString();
					/**/
				}
			/**/
			/*Eliminar Trailing*/
				colector_update = colector_update.Substring( 1 );
			/**/
			/*Reomplazar columnas actualizables*/
				i		= 1;
				i_str	= "1";
				foreach( string item in datos_actualizables.Substring( 1 ).Split("|") ){
					/**/
					/*Remplazar FILA*/
						colector_update = colector_update.Replace( $"{{COLUMNA_{i_str}}}", item );
					/**/
					/*ITERAR*/
						++i;
						i_str = i.ToString();
					/**/
				}
			/**/
			/*Existencia de WHERES*/
				string colector_wheres	= "";
				if( wheres != "" ){
					colector_wheres = $"WHERE {wheres}";
				}
			/**/
			/*Generar remplazos*/
				string actualizador		= _sistema_.Modelos.Actualizacion;
				actualizador			= actualizador.Replace("{NOMBRE_TABLA}",		nombre_tabla				);
				actualizador			= actualizador.Replace("{CAMPO_ACTUALIZADO}",	campo_actualizado			);
				actualizador			= actualizador.Replace("{UNIX_DB}",				_sistema_.Modelos.UNIX_DB	);
				actualizador			= actualizador.Replace("{COLUMNAS_UPDATE}",		colector_update				);
				actualizador			= actualizador.Replace("{WHERES}",				colector_wheres				);
			/**/
			/*DEBUG de Insersion*/
				if(
					debug == "actualizar_item"
				){
					throw new ArgumentNullException( $@"[TESTING DE SQL en ""actualizar_item""] -> {actualizador}" );
				}
			/**/
			/*Ejecutar SQL*/
				_sistema_.DB_Starter.ejecutar( debug, actualizador );
			/**/
		}

		/*Funcion de eliminar*/
		static public void borrar_item( string debug, string nombre_tabla, string wheres ){
			/**/
			/*Generar remplazos*/
				string borrado		= _sistema_.Modelos.Borrado;
				borrado				= borrado.Replace("{NOMBRE_TABLA}",			nombre_tabla	);
				borrado				= borrado.Replace("{WHERES}",				wheres			);
			/**/
			/*DEBUG de Insersion*/
				if(
					debug == "borrar_item"
				){
					throw new ArgumentNullException( $@"[TESTING DE SQL en ""borrar_item""] -> {borrado}" );
				}
			/**/
			/*Ejecutar SQL*/
				_sistema_.DB_Starter.ejecutar( debug, borrado );
			/**/
		}

		/*Funcion de seleccionar tabla*/
		static public string seleccionar_tabla(
			string debug		= "",
			string nombre_tabla	= "",
			string columnas		= "",
			string wheres		= "",
			string offsets		= "",
			string limits 		= "",
			string orders		= ""
		){
			/**/
			/*Obtener Generar variables*/
				string query_seleccion = "";
			/**/
			/*Obtener Codigo de seleccion*/
				query_seleccion = _sistema_.Modelos.Busqueda;
			/**/
			/*Remplazar valores*/
				query_seleccion = query_seleccion.Replace("{COLUMNAS}",				columnas				);
			/**/
			/*FROM*/
				/*Inexistencia de FROM*/
					if( nombre_tabla == "" ){
						query_seleccion = query_seleccion.Replace("{FROM}",			""						);
					}
					else{
						query_seleccion = query_seleccion.Replace("{FROM}",			$"FROM {nombre_tabla}"	);
					}
				/**/
			/**/
			/*WHERE*/
				/*Inexistencia de WHERE*/
					if( wheres == "" ){
						query_seleccion = query_seleccion.Replace("{WHERES}",		""						);
					}
				/**/
				/*Existencia de WHERE*/
					else{
						query_seleccion = query_seleccion.Replace("{WHERES}",		$"WHERE {wheres}"		);
					}
				/**/
			/**/
			/*OFFSET*/
				/*Inexistencia de OFFSET*/
					if( offsets == "" ){
						query_seleccion = query_seleccion.Replace("{OFFSET}",		""						);
					}
				/**/
				/*Existencia de OFFSET*/
					else{
						query_seleccion = query_seleccion.Replace("{OFFSET}",		$"OFFSET {offsets}"		);
					}
				/**/
			/**/
			/*LIMIT*/
				/*Inexistencia de LIMIT*/
					if( limits == "" ){
						query_seleccion = query_seleccion.Replace("{LIMIT}",		""						);
					}
				/**/
				/*Existencia de LIMIT*/
					else{
						query_seleccion = query_seleccion.Replace("{LIMIT}",		$"LIMIT {limits}"		);
					}
				/**/
			/**/
			/*ORDER*/
				/*Inexistencia de ORDER*/
					if( orders == "" ){
						query_seleccion = query_seleccion.Replace("{ORDER}",		""						);
					}
				/**/
				/*Existencia de ORDER*/
					else{
						query_seleccion = query_seleccion.Replace("{ORDER}",		$"ORDER BY {limits}"	);
					}
				/**/
			/**/
			/*DEBUG*/
				if(
					debug == "seleccionar_tabla_query"
				){
					throw new ArgumentNullException( @$"[TESTING DE SQL en ""seleccionar_tabla_query""] -> {query_seleccion}" );
				}
			/**/
			/*Obtener resultado*/
				string resultado = _sistema_.DB_Starter.seleccionar( debug, query_seleccion );
			/**/
			/*DEBUG*/
				if(
					debug == "seleccionar_tabla_resultado"
				){
					throw new ArgumentNullException( @$"[TESTING DE SQL en ""seleccionar_tabla_resultado""] -> {resultado}" );
				}
			/**/
			/*FIN*/
				return resultado;
			/**/
		}

		/*Ver Todo*/
		public static string todo( string debug, string nombre_tabla, string campos_buscables ){
			return _sistema_.Modelos.seleccionar_tabla( debug, nombre_tabla, campos_buscables.Replace("|",",") );
		}

		/*Ver Lista*/
		public static string opciones( string debug, string nombre_tabla ){
			/**/
			/*Creador*/
				string opciones = "";
			/**/
			/*Iterar resultado*/
				foreach(
					string filas in _sistema_.Modelos.seleccionar_tabla( debug, nombre_tabla, "id,nombre" ).Split("$")
				 ){

					/*Obtener ID y nombre*/
					string[] filas_sp = filas.Split("|");

					/*Obtener ID y nombre*/
					string id		= filas_sp[0];
					string nombre	= filas_sp[1];

					/*Separar columnas*/
					id		= id		.Split(":")[1];
					nombre	= nombre	.Split(":")[1];

					/*Sanitizar columnas*/
					id		= _sistema_.Sanitizador.escapar( id		);
					nombre	= _sistema_.Sanitizador.escapar( nombre	);

					/*Crear objeto*/
					opciones += $"<option value=\"{id}\"data-descapar=\"{nombre}\">{nombre}</option>";
				}
			/**/
			/*DEBUG de creacion*/
				if(
					debug == "opciones"
				){
					throw new ArgumentNullException( @$"[TESTING DE SQL en ""opciones""] -> {opciones}" );
				}
			/**/
			/*Devolver*/
				return opciones;
			/**/
		}
	}
}