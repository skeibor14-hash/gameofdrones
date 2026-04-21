using Microsoft.Data.Sqlite;

namespace controladores{

	public static class Db_test{

		/*Inicio de la url*/
		public static void main(WebApplication app){
			/**/
			/*Obtener Variable*/
				string ruta = _sistema_.Lector_ENV.obtener("ruta_db_test");
			/**/
			/*Verificar si ruta no borrada*/
				if( ruta != "[borrar]" ){
					app.MapGet( ruta, (HttpContext context) => {
						/**/
						/*Crear texto*/
							string text = "";
						/**/
						/*Generar Texto*/
							text += $"<h2>Prueba de tabla</h2><br>";
							text += modelos.Entidades.opciones();
						/**/
						/*Fin*/
							context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
							return text;
						/**/
					});
				}
			/**/
		}
	}
}