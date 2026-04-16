namespace controladores{

	public static class pagina_principal{

		/*Inicio de la url*/
		public static void main(WebApplication app){

			/*Generar enrutacion*/
			app.MapGet("/", (HttpContext context) => {
				context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
				return "Pagina principal.";
			});
		}
	}
}