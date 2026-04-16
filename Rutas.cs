namespace MiSistema{

	public static class Rutas{

		/*Rutas Generales*/
		public static void main(WebApplication app){

			/*Unir controladores.pagina_principal.cs*/
			controladores.pagina_principal.main( app );

			/*Unir controladores.db_test.cs*/
			controladores.db_test.main( app );

			/*Unir controladores.linked_list.cs*/
			controladores.linked_list.main( app );

			/*Unir controladores.iniciar_juego.cs*/
			controladores.iniciar_juego.main( app );

			/*Unir controladores.mover_turno.cs*/
			controladores.mover_turno.main( app );
		}

		/*400 GET*/
		public static void g404(WebApplication app){
			app.UseStatusCodePages(async context => {
				if( context.HttpContext.Response.StatusCode == 404 ){
					context.HttpContext.Response.ContentType = "text/html; charset=UTF-8";
					await context.HttpContext.Response.WriteAsync("¡Ups! La página que buscas no existe.");
				}
			});
		}

		/*400 POST*/
		public static void p404(WebApplication app){
		}
	}
}