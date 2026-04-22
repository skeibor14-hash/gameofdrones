using System.IO;
using System.Text;

namespace controladores{

	/*Sanitizador de objetos recibidos*/
	public class Archivos{

		/*Archivos permitidos*/
		public static void main( WebApplication app ){

			/*Mapa de ruta para angular*/
			app.MapGet( _sistema_.Lector_ENV.obtener("archivo_angular"),( HttpContext context ) => {
				return controladores.Archivos.responder_cabezera( context, "application/javascript", "inline; filename=angular.min.js", true, false, false, "angular.min.js" );
			});

			/*Mapa de ruta para favicon*/
			app.MapGet( _sistema_.Lector_ENV.obtener("archivo_favicon"),( HttpContext context ) => {
				return controladores.Archivos.responder_imagen( context, "image/ico", true, false, false, "favicon.ico" );
			});

			/*Mapa de ruta para scripts*/
			app.MapGet( _sistema_.Lector_ENV.obtener("archivo_scripts"),( HttpContext context ) => {
				return controladores.Archivos.responder_cabezera( context, "application/javascript", "inline; filename=scripts.js", true, false, false, "scripts.js" );
			});

			/*Mapa de ruta para estilos*/
			app.MapGet( _sistema_.Lector_ENV.obtener("archivo_estilos"),( HttpContext context ) => {
				return controladores.Archivos.responder_cabezera( context, "text/css", "inline; filename=estilos.css", true, false, false, "estilos.css" );
			});

			/*Mapa de ruta para sanitizador*/
			app.MapGet( _sistema_.Lector_ENV.obtener("archivo_sanitizador"),( HttpContext context ) => {
				return controladores.Archivos.responder_cabezera( context, "application/javascript", "inline; filename=sanitizador.js", true, false, false, "sanitizador.js" );
			});

			/*Mapa de ruta para xhr*/
			app.MapGet( _sistema_.Lector_ENV.obtener("archivo_xhr"),( HttpContext context ) => {
				return controladores.Archivos.responder_cabezera( context, "application/javascript", "inline; filename=manejador_xhr.js", true, false, false, "manejador_xhr.js" );
			});
		}

		/*responder_cabezera*/
		public static Microsoft.AspNetCore.Http.IResult responder_imagen( HttpContext context, string mime, bool cache, bool robots, bool csp, string archivo ){
			/**/
			/*Obtener Archivo*/
				string ruta_archivo = _sistema_.Lector_ENV.ubicar_archivos( archivo );
			/**/
			/*Cabezeras*/
				controladores.Archivos.cabezeras_constantes( context );
				controladores.Archivos.cabezeras_cache( context, cache );
				controladores.Archivos.cabezeras_robots( context, robots );
				controladores.Archivos.cabezeras_csp( context, csp );
			/**/
			/*Aplicar cabezeras*/
				context.Response.Headers["Content-Type"] = mime;
			/**/
			/*Enviar archivo*/
				byte[] bytes = File.ReadAllBytes( ruta_archivo );
				return Results.File( bytes, mime );
			/**/
		}

		/*responder_cabezera*/
		public static string responder_cabezera( HttpContext context, string mime, string disposicion, bool cache, bool robots, bool csp, string archivo ){
			/**/
			/*Cabezeras*/
				controladores.Archivos.cabezeras_constantes( context );
				controladores.Archivos.cabezeras_cache( context, cache );
				controladores.Archivos.cabezeras_robots( context, robots );
				controladores.Archivos.cabezeras_csp( context, csp );
			/**/
			/*Obtener Archivo*/
				string ruta_archivo = _sistema_.Lector_ENV.Sys_files_path + "/" + archivo;
			/**/
			/*Verificar existencia O 404*/
				if( !File.Exists( ruta_archivo ) ){
					context.Response.Headers["Content-Type"] = _sistema_.Posts.cabezera;
					return _sistema_.Posts.respuesta_post( 404, "no_encontrado", "Archivo no encontrado" );
				}
			/**/
			/*Enviar archivo*/
				context.Response.Headers["Content-Type"]			= mime;
				context.Response.Headers["Content-Disposition"]		= disposicion;
				return File.ReadAllText( $"{_sistema_.Lector_ENV.Sys_files_path}/{archivo}", Encoding.UTF8 );
			/**/
		}

		/*Cabezeras compartidas*/
		public static void cabezeras_constantes( HttpContext context ){
			context.Response.Headers["Referrer-Policy"]			= "no-referrer";
			context.Response.Headers["X-Content-Type-Options"]	= "nosniff";
			context.Response.Headers["X-Frame-Options"]			= "DENY";
			context.Response.Headers["X-XSS-Protection"]		= "1;mode=block";
		}

		/*Cabezeras Cache*/
		public static void cabezeras_cache( HttpContext context, bool aplicar ){
			/**/
			/*Modo cache*/
				if(
					aplicar
				){
					context.Response.Headers["Pragma"]			= "public";
					context.Response.Headers["Expires"]			= "31 Dec 9999 23:59:59 UTC";
					context.Response.Headers["Cache-Control"]	= "max-age=31536000, public";
					context.Response.Headers["Last-Modified"]	= "01 Jan 2001 00:00:00 UTC";
				}
			/**/
			/*Modo no cache*/
				else{
					context.Response.Headers["Pragma"]			= "no-cache";
					context.Response.Headers["Expires"]			= "01 Jan 2001 00:00:00 UTC";
					context.Response.Headers["Cache-Control"]	= "max-age=0, public";
					context.Response.Headers["Last-Modified"]	= "31 Dec 9999 23:59:59 UTC";
				}
			/**/
		}

		/*Cabezeras compartidas*/
		public static void cabezeras_robots( HttpContext context, bool aplicar ){
			/**/
			/*Modo Robots*/
				if(
					aplicar
				){
					context.Response.Headers["X-Robots-Tag"]	= "all";
				}
			/**/
			/*Modo no Robots*/
				else{

					/*Breve explicacion:*/
						/*	noindex			# Prevents the page from being indexed.*/
						/*	nofollow		# Prevents search engines from following links on the page.*/
						/*	noarchive		# Prevents search engines from storing a cached copy of the page.*/
						/*	nosnippet		# Prevents search engines from showing a snippet or video preview in search results.*/
						/*	noimageindex	# Prevents images on the page from being indexed.*/
						/*	nocache			# Similar to noarchive, though less commonly used.*/
						/*	notranslate		# Prevents translation options from being offered in search results.*/
						/*	noodp			# Prevents the use of Open Directory Project (DMOZ) description for the page.*/
						/*	noydir			# Prevents Yahoo Directory descriptions from being used.*/
					/**/

					context.Response.Headers["X-Robots-Tag"]	= "noindex, nofollow, noarchive, nosnippet, noimageindex, nocache, notranslate, noodp, noydir";
				}
			/**/
		}

		/**
		 * Instrucciones Content-Security-Policity para navegador
		 * permite agregar una barrera de seguridad adicional a la pagina evitando
		 * ejecucion de scripts de terceros, como extensiones o elementos que quieran
		 * substraer o ejecutar scripts en el navegador del usuario.
		 *
		 * Esta politica solo tomara efecto si el usuario posee un navegador que no ignore
		 * las politicas de seguridad.
		 *
		 * Configurar conforme sea necesario segun los elementos permitidos:
		 *
		 * 	- 'none'			->	Deniega totalmente el uso del objeto
		 *
		 * 	- url_sistema		->	Variable con la URL del sistema que indica que dicho elemento solo sera permitido para la URL del servidor
		 * 							^- Si se intenta usar este elemento y apuntar a una pagina de terceros, el objeto sera denegado
		 *
		 *	- nonce_url			->	Variable con la URL del sistema + codigo de seguridad [nonce] (Mas informacion en el link @source )
		 * 							^- Permite usar elementos de terceros siempre y cuando se incluya el nonce en el objeto.
		 *
		 * Si el navegador presenta elementos bloqueados como [video], [imagenes], [scripts] o [audio] (entre otros), revisar [la consola del navegador]
		 * para mas informacion sobre la restriccion aplicada.
		 *
		 * @source https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Headers/Content-Security-Policy
		*/
		public static void cabezeras_csp( HttpContext context, bool aplicar ){
			/*Crear Header*/
				string header			= "";
			/**/
			/*Elegir metodo*/
				if(
					aplicar
				){
					/**/
					/*Obtener URL del sistema*/
						string url_sistema		= _sistema_.Lector_ENV.url_sistema();
					/**/
					/*Obtener Nonce de seguridad del sistema*/
						string nonce_codigo		= _sistema_.Lector_ENV.generar_nonce();
					/**/
					/*Obtener Nonce URL de seguridad del sistema*/
						string nonce_url		= $"{url_sistema} 'nonce-{nonce_codigo}'";
					/**/
					/*Aplica Datos*/
						header += "child-src "							+ "'none'";																							/*Restringe que URL pueden ser accedidas con <frame> e <iframe> (frame-src posee predecedencia)*/
						header += ", connect-src "						+ url_sistema;																						/*Restringe que URL pueden ser accedidas usando <a> ping, fetch(), fetchLater(), XMLHttpRequest, WebSocket, EventSource, Navigator.sendBeacon()*/
						/*header += ", default-src "					+ nonce_url;*/																						/*Aplica restricciones para todas las directivas existentes*/
						header += ", fenced-frame-src "					+ "'none'";																							/*Restringe que URL pueden ser accedidas con <fencedframe>*/
						header += ", font-src "							+ "'none'";																							/*Restringe que URL pueden ser accedidas con @font-face, desde CSS*/
						header += ", frame-src "						+ "'none'";																							/*Restringe que URL pueden ser accedidas con <frame> e <iframe>*/
						header += ", img-src "							+ nonce_url;																						/*Restringe que URL pueden ser accedidas usando <img> y <link rel="icon"*/
						header += ", manifest-src "						+ "'none'";																							/*Restringe que URL pueden ser accedidas usando <link rel="manifest (Util si se desea hacer una aplicacion movil)*/
						header += ", media-src "						+ "'none'";																							/*Restringe que URL pueden ser accedidas con <audio>, <video>, y <track>*/
						header += ", object-src "						+ "'none'";																							/*Restringe que URL pueden ser accedidas con <object> y <embed>*/
						header += ", prefetch-src "						+ "'none'";																							/*Restringe que URL pueden ser pre-cargadas por otras directivas, complementa connect-src y script-src*/
						/*header += ", script-src "						+ nonce_url;*/																						/*Restringe que URL pueden ser accedidas con <scripts>, que <scripts> puedes ser ejecutados, bloquea uso de eval() y propiedad onlistener=""*/
						/*header += ", script-src-ele "					+ nonce_url;*/																						/*Restringe que tags pueden ejecutarse con <scripts>*/
						/*header += ", script-src-att "					+ "'none'";*/																						/*Restringe que ATRIBUTOS pueden ser accedidos con <scripts>*/
						/*header += ", style-src "						+ nonce_url;*/																						/*Restringe que URL pueden ser accedidas con <link rel="stylesheet", que <styles> puedes ser ejecutados, bloquea uso de propiedad style=""*/
						/*header += ", style-src-elem "					+ nonce_url;*/																						/*Restringe que tags pueden ejecutarse con <link rel="stylesheet" y <style>*/
						/*header += ", style-src-att "					+ "'none'";*/																						/*Restringe que ATRIBUTOS pueden ser accedidos con <scripts>*/
						header += ", worker-src "						+ "'none'";																							/*Restringe que URL pueden ser accedidos con el uso de Worker, SharedWorker, y ServiceWorker en JS*/
						header += ", base-uri "							+ url_sistema;																						/*Restringe que URL pueden ser accedidas usando <base>*/
						header += ", sandbox "							+ "allow-downloads allow-modals allow-popups allow-scripts allow-same-origin allow-forms";			/*Aplica las reglas de seguridad de un <iframe> a la pagina, controla que elementos permitir*/
						header += ", form-action "						+ "'none'";																							/*Restringe que URL pueden ser accedidas usando <form>*/
						header += ", frame-ancestors "					+ "'none'";																							/*Restringe que URL pueden accedider a la pagina padre usando <frame>, <iframe>, <object> o <embed>*/
						header += ", block-all-mixed-content";																												/*Evita uso de http en https*/
					/**/
				}
				else{
					header += "child-src "								+ "'none'";
					header += ", connect-src "							+ "'none'";
					header += ", default-src "							+ "'none'";
					header += ", fenced-frame-src "						+ "'none'";
					header += ", font-src "								+ "'none'";
					header += ", frame-src "							+ "'none'";
					header += ", img-src "								+ "'none'";
					header += ", manifest-src "							+ "'none'";
					header += ", media-src "							+ "'none'";
					header += ", object-src "							+ "'none'";
					header += ", prefetch-src "							+ "'none'";
					header += ", script-src "							+ "'none'";
					header += ", script-src-ele "						+ "'none'";
					header += ", script-src-att "						+ "'none'";
					header += ", style-src "							+ "'none'";
					header += ", style-src-elem "						+ "'none'";
					header += ", style-src-att "						+ "'none'";
					header += ", worker-src "							+ "'none'";
					header += ", base-uri "								+ "'none'";
					header += ", sandbox";
					header += ", form-action "							+ "'none'";
					header += ", frame-ancestors "						+ "'none'";
					header += ", require-trusted-types-for "			+ "'script'";
					header += ", trusted-types "						+ "'none'";
					header += ", block-all-mixed-content";
				}
			/**/
			/*Generar header*/
				context.Response.Headers["Content-Security-Policy"]		= header;
			/**/
		}
	}
}