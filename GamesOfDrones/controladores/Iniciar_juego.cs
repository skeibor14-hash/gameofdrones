namespace controladores{

	public static class Iniciar_juego{

		/*Inicio de la url*/
		public static void main(WebApplication app){
			app.MapGet( _sistema_.Lector_ENV.obtener("ruta_iniciar_juego"), (HttpContext context) => {
				context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
				return "Iniciando juego";
			});
		}
	}
}