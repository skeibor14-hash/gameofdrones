namespace controladores{

	/*Sanitizador de objetos recibidos*/
	public class Comenzar_juego{

		/*Archivos permitidos*/
		public static void main( WebApplication app ){
			app.MapPost( _sistema_.Lector_ENV.obtener("ruta_comenzar_juego"), async ( HttpContext context ) => {
				/**/
				/*Mensaje*/
				/**/
				/*Obtener POST*/
					string post		= await _sistema_.Posts.leer_post( context );
				/**/
				/*Obtener CSRF*/
					string csrf		= _sistema_.Posts.obtener_post( post, "csrf" );
				/**/
				/*Validar CSRF*/
					string mensaje	= _sistema_.Posts.validar_csrf( context, csrf );
					if(
						mensaje != ""
					){
						return mensaje;
					}
				/**/
				/*Obtener campos*/
					string prueba1	= _sistema_.Posts.obtener_post( post, "prueba1" );
					string prueba2	= _sistema_.Posts.obtener_post( post, "prueba2" );
				/**/


				Console.WriteLine( $"CSRF es 1: {csrf}" );
				Console.WriteLine( $"prueba1 es 1: {prueba1}" );
				Console.WriteLine( $"prueba2 es 2: {prueba2}" );


				context.Response.Headers["Content-Type"] = _sistema_.Posts.cabezera;
				return _sistema_.Posts.respuesta_post( 200, "sin_problemas", "FUNCIONA" );
			});
		}
	}
}