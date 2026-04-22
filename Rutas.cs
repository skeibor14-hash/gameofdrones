namespace BaseFolder{

	public static class Rutas{

		/*Rutas Generales*/
		public static void main( WebApplication app ){

			/*Unir controladores.archivos.cs*/
			controladores.Archivos.main( app );

			/*Unir controladores.pagina_principal.cs*/
			controladores.Pagina_principal.main( app );

			/*Unir controladores.db_test.cs*/
			controladores.Db_test.main( app );

			/*Unir controladores.controladores.cs*/
			controladores.Comenzar_juego.main( app );
		}

		/*Paginas 400*/
		public static void p404( WebApplication app ){
			app.UseStatusCodePages(async context => {

				/*GET*/
				if(
					context.HttpContext.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase )
				){
					if( context.HttpContext.Response.StatusCode == 404 ){
						context.HttpContext.Response.ContentType = "text/html; charset=UTF-8";
						await context.HttpContext.Response.WriteAsync("Página no encontrada.");
					}
				}

				/*POST y OTROS*/
				else{
					if( context.HttpContext.Response.StatusCode == 404 ){
						context.HttpContext.Response.ContentType = _sistema_.Posts.cabezera;
						await context.HttpContext.Response.WriteAsync( _sistema_.Posts.respuesta_post( 404, "no_encontrado", "Página no encontrada" ) );
					}
				}
			});
		}
	}
}