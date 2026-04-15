namespace controladores
{
	public static class iniciar_juego{

		/*Inicio de la url*/
		public static void main(WebApplication app){

			/*Generar enrutacion*/
			app.MapGet("/iniciar_juego", (HttpContext context) => {

				/**/
				/*Obtener Modelo Entidad*/
					modelos.Entidad entidades = ( new modelos.Entidades() ).all();
				/**/
				/*Crear Texto*/
					string cadena_texto = "";
				/**/
				/*Iterar*/
					context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
					foreach( string[] fila in entidades )
						cadena_texto += fila[0] + "<br>";
				/**/
				/*Remover espacio extra*/
					cadena_texto = cadena_texto.Substring( 0, cadena_texto.Length - 4 );
				/**/
				/*FIN*/
					return "Felicidades! tus entidades son: <br>" + cadena_texto ;
				/**/
			});
		}
	}
}