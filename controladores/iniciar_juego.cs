namespace controladores
{
	public static class iniciar_juego{

		/*Inicio de la url*/
		public static void main(WebApplication app){

			/*Generar enrutacion*/
			app.MapGet("/iniciar_juego", (HttpContext context) => {
				context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
				return "iniciar_juego.";
			});
		}
	}
}