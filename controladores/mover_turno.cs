namespace controladores
{
	public static class mover_turno{

		/*Inicio de la url*/
		public static void main(WebApplication app){

			/*Generar enrutacion*/
			app.MapGet("/mover_turno", (HttpContext context) => {
				context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
				return "mover_turno";
			});
		}
	}
}