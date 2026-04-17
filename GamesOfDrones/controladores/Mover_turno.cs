namespace controladores{

	public static class Mover_turno{

		/*Inicio de la url*/
		public static void main(WebApplication app){
			app.MapGet( _sistema_.Lector_ENV.obtener("ruta_mover_turno"), (HttpContext context) => {
				context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
				return "Moviendo juego";
			});
		}
	}
}