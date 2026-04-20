using Microsoft.Data.Sqlite;

namespace _sistema_{
	public static class DB_Starter{

		/*Conector y conectar*/
		/**
		 * Permite mantener un conector en ejecucion para evitar sobrecargar
		 * la base de datos de conexiones constantes.
		 *
		 * 		- Mediante el uso de [conectar()] se evita el spam constante de conecciones a DB
		 * 		- Este elemento usualmente es utilizado una sola ves en todo el sistema y mantiene una conexion directa con DB
		 *
		 * @requires:
		 * 		Configuracion en env para:		db_sqlite_ubicacion
		 * 		Manejador de env para:			_sistema_.Lector_ENV.obtener
		*/
		static SqliteConnection? conector = null;
		public static void conectar( string debug = "" ){
			if(
				_sistema_.DB_Starter.conector == null
			){
				_sistema_.DB_Starter.conector = new SqliteConnection("Data Source=" + _sistema_.Lector_ENV.obtener("db_sqlite_ubicacion") );
			}
		}

		/*Ejecutar*/
		/**
		 * - Dado un query
		 * - Y habiendo previamente llamado [conectar()]
		 * - Si no se ha llamado [conectar()]; Intentara conectar o arrojar error
		 * - Intenta ejecutar dicho query; O enviar error de solicitud
		*/
		public static void ejecutar( string debug, string sql_query ){

			/*Verificar*/
			if(
				_sistema_.DB_Starter.conector == null
			){
				throw new ArgumentNullException( @"Error de conexión. No se pudo conectar a la DB");
			}

			/*Verificar*/
			if(
				_sistema_.DB_Starter.conector.State != System.Data.ConnectionState.Open
			){
				_sistema_.DB_Starter.conector.Open();
			}

			/*Ejecutar query*/
			using(
				Microsoft.Data.Sqlite.SqliteCommand comando = DB_Starter.conector.CreateCommand()
			){
				/*Asignar Query*/
				comando.CommandText = sql_query;

				/*Ejecucion de comando*/
				comando.ExecuteNonQuery();
			}
		}

		/*Seleccionar SQL*/
		public static string seleccionar( string debug, string sql_query ){

			/*Verificar*/
			if(
				_sistema_.DB_Starter.conector == null
			){
				throw new ArgumentNullException( @"Error de conexión", "No se pudo conectar a la DB");
			}

			/*Verificar*/
			if(
				_sistema_.DB_Starter.conector.State != System.Data.ConnectionState.Open
			){
				_sistema_.DB_Starter.conector.Open();
			}

			/*Ejecutar query*/
			using(
				Microsoft.Data.Sqlite.SqliteCommand comando = DB_Starter.conector.CreateCommand()
			){
				/*Asignar Query*/
				comando.CommandText = sql_query;

				/*String de retorono*/
				string resultado_retorno = "";

				/*Ejecutar lector*/
				using(
					Microsoft.Data.Sqlite.SqliteDataReader lector = comando.ExecuteReader()
				){
					/*Lector de lineas contenedor*/
					string lector_filas = "";

					/*Contador de lineas*/
					int		k		= 0;
					string	k_str	= "0";

					/*Leer Filas*/
					while( lector.Read() ){

						/*Lector de columnas contenedor*/
						string columnas = "";

						/*Iterar Columnas en filas*/
						for(
							int i = 0; i < lector.FieldCount; ++i
						){
							/*Crear STR de lectura*/
							string i_str	= i.ToString();

							/*Nombre de la columna*/
							string? columna = lector.GetName(i);

							/*Valor de la columna*/
							var valor = lector.GetValue(i);

							/*Adjuntar Linea*/
							columnas += $"|{columna}:{valor}";
						}

						/*Remover Primer item*/
						if( columnas.Length > 0 ){
							columnas = columnas.Substring( 1 );
						}

						/*Fila*/
						lector_filas += $"${columnas}";

						/*Iterador de filas*/
						++k;

						/*Crear STR de lectura*/
						k_str = k.ToString();
					}

					/*Remover Primer item*/
					if( lector_filas.Length > 0 ){
						lector_filas = lector_filas.Substring( 1 );
					}

					/*Unir*/
					resultado_retorno += lector_filas;
				}

				/*FIN*/
				return resultado_retorno;
			}
		}
	}
}