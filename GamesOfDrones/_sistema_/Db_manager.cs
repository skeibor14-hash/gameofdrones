using Microsoft.Data.Sqlite;

namespace _sistema_{

	/*Modelo base*/
	public abstract class Modelo_base{

		/*FUncion de crear tabla*/
		public abstract void verificar_tabla( string tabla );

		/*Ver Filas*/
		public string filas( string tabla ){
			/**/
			/*Asegurar existencia de tabla*/
				this.verificar_tabla( tabla );
			/**/
			/*Iniciar seleccion*/
				Microsoft.Data.Sqlite.SqliteCommand? comando = DB_Starter.iniciar(@$"
					SELECT	*
					FROM	{tabla}
					WHERE	eliminado IS NULL
				");
			/**/
			/*Fin*/
				return DB_Starter.ejecutar_lector( comando );
			/**/
		}

		/*Ver Lista*/
		public string opciones( string tabla ){
			/**/
			/*Asegurar existencia de tabla*/
				this.verificar_tabla( tabla );
			/**/
			/*Iniciar seleccion*/
				Microsoft.Data.Sqlite.SqliteCommand? comando = DB_Starter.iniciar(@$"
					SELECT	id,nombre
					FROM	{tabla}
					WHERE	eliminado IS NULL
				");
			/**/
			/*Crear coleccion*/
				string opciones = "";
			/**/
			/*Iterar resultado*/
				foreach( string filas in _sistema_.DB_Starter.ejecutar_lector( comando ).Split("$") ){

					/*Obtener ID y valor*/
					string[] filas_sp = filas.Split("|");
					if( filas_sp.Length == 2 ){

						/*Obtener ID y valor*/
						string id		= filas_sp[0];
						string valor	= filas_sp[1];

						/*Separar columnas*/
						id		= id	.Split(":")[1];
						valor	= valor	.Split(":")[1];

						/*Sanitizar columnas*/
						id		= _sistema_.Sanitizador.escapar( id		);
						valor	= _sistema_.Sanitizador.escapar( valor	);

						/*Crear objeto*/
						opciones += $"<option value=\"{id}\"data-descapar=\"{valor}\">{valor}</option>";
					}
				}
			/**/
			/*Devolver*/
				return opciones;
			/**/
		}
	}

	/*Item de DB*/
	public static class DB_Starter{

		/*Conector*/
		static Microsoft.Data.Sqlite.SqliteConnection? conector = null;

		/*Conectar*/
		public static void conectar(){
			using(
				DB_Starter.conector = new SqliteConnection("Data Source=" + _sistema_.Lector_ENV.obtener("db_sqlite_ubicacion") )
			){
				DB_Starter.conector.Open();
			}
		}

		/*Ejecutar*/
		public static void ejecutar( string sql_query ){

			/*Verificar conexion*/
			if(
				DB_Starter.conector == null
			)
				throw new InvalidOperationException("La conexión no está inicializada.");

			/*Iniciar COnexion*/
			if(
				DB_Starter.conector.State != System.Data.ConnectionState.Open
			){
				DB_Starter.conector.Open();
			}

			/*Conectar*/
			using( Microsoft.Data.Sqlite.SqliteCommand comando = DB_Starter.conector.CreateCommand() ){
				comando.CommandText = sql_query;
				comando.ExecuteNonQuery();
			}
		}

		/*Iniciar SQL que use parametros*/
		public static Microsoft.Data.Sqlite.SqliteCommand? iniciar( string sql_query ){
			using(
				Microsoft.Data.Sqlite.SqliteCommand? comando = DB_Starter.conector?.CreateCommand()
			){
				comando?.CommandText = sql_query;
				return comando;
			}
		}

		/*Agregar a SQL parametros*/
		public static void ejecutar_cmd( Microsoft.Data.Sqlite.SqliteCommand? comando ){
			comando?.ExecuteNonQuery();
		}

		/*Seleccionar SQL*/
		public static string seleccionar( string sql_query ){

			/*Iniciar seleccion*/
			Microsoft.Data.Sqlite.SqliteCommand? comando = DB_Starter.iniciar( sql_query );

			/*Leer*/
			return DB_Starter.ejecutar_lector( comando );
		}

		/*Agregar a SQL parametros*/
		public static void agregar( Microsoft.Data.Sqlite.SqliteCommand? comando, string columna, string valor ){
			comando?.Parameters.AddWithValue( columna, Sanitizador.escapar( valor ) );
		}

		/*Seleccionar SQL con parametros*/
		public static string ejecutar_lector( Microsoft.Data.Sqlite.SqliteCommand? comando ){

			/*String*/
			string sql_query = "";

			/*Ejecutar lector*/
			using(
				Microsoft.Data.Sqlite.SqliteDataReader? lector = comando?.ExecuteReader()
			){
				/*Verificar Existencia*/
				if( lector != null ){

					/*Lector de lineas*/
					string linea = "";

					/*Leer lineas*/
					while( lector.Read() ){

						/*Lector de columnas*/
						string columnas = "";

						/*Items internos*/
						for( int i = 0; i < lector.FieldCount; ++i ){

							/*Columna*/
							string? columna = lector.GetName(i);

							/*Valor*/
							var valor = lector.GetValue(i);

							/*Linea*/
							columnas += $"|{columna}:{valor}";
						}

						/*Remover Primer item*/
						if( columnas.Length > 0 ){
							columnas = columnas.Substring( 1, columnas.Length - 1 );
						}

						/*Fila*/
						linea += $"${columnas}";
					}

					/*Remover Primer item*/
					if( linea.Length > 0 ){
						linea = linea.Substring( 1, linea.Length - 1 );
					}

					/*Unir*/
					sql_query += linea;
				}
			}

			/*FIN*/
			return sql_query;
		}
	}
}