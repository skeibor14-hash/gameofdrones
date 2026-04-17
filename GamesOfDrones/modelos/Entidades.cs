namespace modelos{
	public class Entidades : _sistema_.Modelo_base {

		/*Nombre de la tabla*/
		public static string Nombre = "entidades";

		/*FUncion de crear tabla*/
		override public void verificar_tabla( string tabla ){
			/**/
			/*Crear Tabla*/
				_sistema_.DB_Starter.ejecutar(@$"
					CREATE TABLE IF NOT EXISTS {tabla}(
						id				integer		PRIMARY KEY
						,nombre			text		NULL
						,eliminado		float		NULL
					);
				");
			/**/
			/*Prueba de insercion*/
				string? comando = _sistema_.DB_Starter.seleccionar($"SELECT 1 FROM {tabla} LIMIT 1");
				if( comando == "" ){

					Microsoft.Data.Sqlite.SqliteCommand? ejecutor = _sistema_.DB_Starter.iniciar(@$"
						INSERT INTO {tabla}(	nombre		)VALUES(		$nombre		);
					");
					_sistema_.DB_Starter.agregar( ejecutor, "$nombre", "Piedra" );
					_sistema_.DB_Starter.ejecutar_cmd( ejecutor );

					ejecutor = _sistema_.DB_Starter.iniciar(@$"
						INSERT INTO {tabla}(	nombre		)VALUES(		$nombre		);
					");
					_sistema_.DB_Starter.agregar( ejecutor, "$nombre", "Papel" );
					_sistema_.DB_Starter.ejecutar_cmd( ejecutor );

					ejecutor = _sistema_.DB_Starter.iniciar(@$"
						INSERT INTO {tabla}(	nombre		)VALUES(		$nombre		);
					");
					_sistema_.DB_Starter.agregar( ejecutor, "$nombre", "Tijeras" );
					_sistema_.DB_Starter.ejecutar_cmd( ejecutor );
				}
			/**/
		}
	}
}