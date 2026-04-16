using Microsoft.Data.Sqlite;

namespace controladores{

	public static class db_test{

		/*Inicio de la url*/
		public static void main(WebApplication app){

			/*Generar enrutacion*/
			app.MapGet("/db_test", (HttpContext context) => {
				/**/
				/*Crear texto*/
					string text = "";
				/**/
				/*Crear Conector*/
					using var connection = new SqliteConnection("Data Source=database.db");
					connection.Open();
				/**/
				/*Crear Tabla*/
					using (var createCmd = connection.CreateCommand()){
						createCmd.CommandText = @"
							CREATE TABLE IF NOT EXISTS

							blogs(
								id				integer		PRIMARY KEY
								,title			text		NULL
								,content		text		NULL
								,author			text		NULL
								,created_at		DATETIME	DEFAULT CURRENT_TIMESTAMP
							)";
						createCmd.ExecuteNonQuery();
						text = "DB Creada<br>";
					}
				/**/
				/*Prueba de insercion*/
					using (var insertCmd = connection.CreateCommand()){
						insertCmd.CommandText = @"
							INSERT INTO

							blogs(
								 title
								,content
								,author
							)VALUES(
								$title
								,$content
								,$author
							)";
						insertCmd.Parameters.AddWithValue("$title", "Blog 1");
						insertCmd.Parameters.AddWithValue("$content", "Primer blog.");
						insertCmd.Parameters.AddWithValue("$author", "John Doe");
						insertCmd.ExecuteNonQuery();
					}
					using (var insertCmd = connection.CreateCommand()){
						insertCmd.CommandText = @"
							INSERT INTO
							blogs(
								 title
								,content
								,author
							)
							VALUES(
								$title
								,$content
								,$author
							)";
						insertCmd.Parameters.AddWithValue("$title", "El Peluka");
						insertCmd.Parameters.AddWithValue("$content", "Historia sobre el peluka.");
						insertCmd.Parameters.AddWithValue("$author", "Paulo Cohelo");
						insertCmd.ExecuteNonQuery();
					}
					text = "Autores agregados<br>";
				/**/
				/*Crear ccomando*/
					using var command = connection.CreateCommand();
					command.CommandText = "SELECT * FROM Blogs";

					using var reader = command.ExecuteReader();
					while (reader.Read()){

						/*Items internos*/
						for(
							int i = 0; i < reader.FieldCount; ++i
						){
							/*Columna*/
							string columna = reader.GetName(i);

							/*Valor*/
							var valor = reader.GetValue(i);

							/*Linea*/
							Console.WriteLine( columna + ": " + valor );
						}

						/*Rows Separador*/
						Console.WriteLine("----");
					}
					text = "Datos seleccionados, revise su consola<br>";
				/**/
				/*Fin*/
					context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
					return text;
				/**/
			});
		}
	}
}