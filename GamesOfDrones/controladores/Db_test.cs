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
						/*Llamar clase*/
							modelos.Entidades tabla = new modelos.Entidades();
						/**/
						/*Crear Tabla*/
							tabla.verificar_tabla( modelos.Entidades.Nombre );
						/**/
						/*Crear ccomando*/
							text += $"<h2>Contenido de tabla</h2><br>";
							string comando = _sistema_.DB_Starter.seleccionar($@"
								SELECT	*
								FROM	{modelos.Entidades.Nombre}
							");
							foreach( string filas in comando.Split("$") ){
								foreach( string item in filas.Split("|") ){

									/*Extraer objetos*/
									string[] item_spl = item.Split(":");

									/*Obtener String*/
									if( item_spl.Length == 2 ){
										string columna	= item_spl[0];
										string valor	= item_spl[1];
										text += $"{columna}: {valor}<br>";
									}
								}
							}
						/**/
						/*Crear ccomando*/
							text += $"<h2>Lista de tabla</h2><br>";
							text += tabla.opciones( modelos.Entidades.Nombre );
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