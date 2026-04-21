using Microsoft.Data.Sqlite;

namespace _sistema_{

	/*Modelo base*/
	public static class Modelos{



		/*Escape para la DB Actual*/
		public static string Escape_sqlite			= @"""";

		/*Codigo de manipulacion de tablas; Solo se ejecuta si la tabla no existe*/
		public static string Creacion				= "CREATE TABLE IF NOT EXISTS [TABLE]( [ESTRUCTURA] );";

		/*Insersion estandar inicial*/
		public static string Insersion_inicio		= "INSERT INTO [TABLE]( [CREADO_COL],[COLS_1] )VALUES";

		/*N Objetos insertables*/
		public static string Insersion_fin			= ",( strftime('%s', 'now'),[COLS_2] )";

		/*Actualizacion estandar; Solo se actualizará por ID*/
		public static string Actualizacion			= "UPDATE [TABLE] SET [ACTUALIZADO_COL]=strftime('%s', 'now'),[COLS_1] WHERE [ID]";

		/*Selección estandar; Solo se utilizara estos queries*/
		public static string Busqueda				= "SELECT [COLS_1] [FROM] [WHERE] [OFFSET] [LIMIT] [ORDER]";


		/*Funcion de verificar integridad de tabla; crea si no existe; migra si debe migrar*/
		/**
		 * Debug permite uso de:
		 * 		"creat_tabla"					-> Para ver codigo de creacion
		 * 		"seleccionar_tabla_query" 		-> Para ver chequeo si necesita migracion
		 * 		"seleccionar_tabla_resultado" 	-> Para ver chequeo de resultado
		 * 		"insertar_item" 				-> Para ver codigo de migracion en caso de ejecutarse
		*/
		static public void verificar_tabla(
			string debug
			,string nombre_tabla
			,string estructura_tabla
			,string campos_insertables
			,string campo_creado
			,string datos_migrables
		){

			/*Crear tabla si no existe*/
			_sistema_.Modelos.crear_tabla( debug, nombre_tabla, estructura_tabla );

			/*Migrar tabla si migrable*/
			_sistema_.Modelos.migrar_tabla( debug, nombre_tabla, campos_insertables, campo_creado, datos_migrables );
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
				creacion = creacion.Replace("[TABLE]",			nombre_tabla	);
				creacion = creacion.Replace("[ESTRUCTURA]",	estructura_tabla	);
			/**/
			/*DEBUG de creacion*/
				if(
					debug == "creat_tabla"
				){
					throw new ArgumentNullException( @$"[TESTING DE SQL en ""creat_tabla""] -> {creacion}" );
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
		static public void migrar_tabla( string debug, string nombre_tabla, string campos_insertables, string campo_creado, string datos_migrables ){
			if(
				"" != datos_migrables
				&&
				"" == _sistema_.Modelos.seleccionar_tabla( debug, nombre_tabla, "1", "", "", "1" )
			){
				insertar_item( debug, nombre_tabla, campos_insertables, campo_creado, datos_migrables );
			}
		}

		/*Funcion de insertar*/
		static public void insertar_item( string debug, string nombre_tabla, string campos_insertables, string campo_creado, string datos_insertables ){
			/**/
			/*Obtener Generar variables*/
				string insersion_inicio		= "";
				string insersion_fin		= "";
			/**/
			/*Obtener Codigo de insersion_inicio*/
				insersion_inicio = _sistema_.Modelos.Insersion_inicio;
			/**/
			/*Remplazar valores*/
				insersion_inicio = insersion_inicio.Replace("[TABLE]",			nombre_tabla							);
				insersion_inicio = insersion_inicio.Replace("[CREADO_COL]",		campo_creado							);
				insersion_inicio = insersion_inicio.Replace("[COLS_1]",			campos_insertables.Replace("|",",")		);
			/**/
			/*Insertar Item; insertar o fallar en el intento*/
				foreach( string filas in datos_insertables.Substring( 1 ).Split("$") ){

					/*Colector*/
					string items_saneado = "";

					/*Configurar Filas*/
					foreach( string item in filas.Split("|") ){

						/*Sanitizar Item*/
						string item_saneado = _sistema_.Sanitizador.escapar( item );

						/*Escapar ITEM*/
						item_saneado = $"{_sistema_.Modelos.Escape_sqlite}{item_saneado}{_sistema_.Modelos.Escape_sqlite}";

						/*Incluir en lista*/
						items_saneado += $",{item_saneado}";
					}

					/*Remover Trail*/
					items_saneado = items_saneado.Substring( 1 );

					/*Incluir Valores*/
					insersion_fin += _sistema_.Modelos.Insersion_fin.Replace("[COLS_2]", items_saneado );
				}
			/**/
			/*Remocion de trail*/
				insersion_fin = insersion_fin.Substring( 1 );
			/**/
			/*Union de elementos*/
				string insersion_final = $"{insersion_inicio}{insersion_fin};";
			/**/
			/*DEBUG de Insersion*/
				if(
					debug == $"insertar_item"
				){
					throw new ArgumentNullException( $@"[TESTING DE SQL en ""insertar_item""] -> {insersion_final}" );
				}
			/**/
			/*Ejecutar SQL*/
				_sistema_.DB_Starter.ejecutar( debug, insersion_final );
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
				query_seleccion = query_seleccion.Replace("[COLS_1]",				columnas				);
			/**/
			/*FROM*/
				/*Inexistencia de FROM*/
					if( nombre_tabla == "" ){
						query_seleccion = query_seleccion.Replace("[FROM]",			""						);
					}
					else{
						query_seleccion = query_seleccion.Replace("[FROM]",			$"FROM {nombre_tabla}"	);
					}
				/**/
			/**/
			/*WHERE*/
				/*Inexistencia de WHERE*/
					if( wheres == "" ){
						query_seleccion = query_seleccion.Replace("[WHERE]",		""						);
					}
				/**/
				/*Existencia de WHERE*/
					else{
						query_seleccion = query_seleccion.Replace("[WHERE]",		$"WHERE {wheres}"		);
					}
				/**/
			/**/
			/*OFFSET*/
				/*Inexistencia de OFFSET*/
					if( offsets == "" ){
						query_seleccion = query_seleccion.Replace("[OFFSET]",		""						);
					}
				/**/
				/*Existencia de OFFSET*/
					else{
						query_seleccion = query_seleccion.Replace("[OFFSET]",		$"OFFSET {offsets}"		);
					}
				/**/
			/**/
			/*LIMIT*/
				/*Inexistencia de LIMIT*/
					if( limits == "" ){
						query_seleccion = query_seleccion.Replace("[LIMIT]",		""						);
					}
				/**/
				/*Existencia de LIMIT*/
					else{
						query_seleccion = query_seleccion.Replace("[LIMIT]",		$"LIMIT {limits}"		);
					}
				/**/
			/**/
			/*ORDER*/
				/*Inexistencia de ORDER*/
					if( orders == "" ){
						query_seleccion = query_seleccion.Replace("[ORDER]",		""						);
					}
				/**/
				/*Existencia de ORDER*/
					else{
						query_seleccion = query_seleccion.Replace("[ORDER]",		$"ORDER BY {limits}"	);
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