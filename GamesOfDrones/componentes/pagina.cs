using System.IO;
using System.Text;

namespace componentes{

	/*Sanitizador de objetos recibidos*/
	public class Pagina{

		/*Codigo superior*/
		public static string superior( HttpContext context, string titulo ){
			/**/
			/*Ubicacion*/
				string ubicacion	= _sistema_.Lector_ENV.ubicacion_archivos("pagina_superior.html");
			/**/
			/*Contenido*/
				string contenido	= File.ReadAllText( ubicacion, Encoding.UTF8 );
			/**/
			/*Obtener Valores base*/
				string titulo_pagina	= _sistema_.Lector_ENV.obtener("vista_pagina_titulo");
				string color			= _sistema_.Lector_ENV.obtener("vista_pagina_color");
				string url_sistema		= _sistema_.Lector_ENV.url_sistema();
				string nonce			= _sistema_.Lector_ENV.generar_nonce();
			/**/
			/*Realizar remplazos*/
				contenido = contenido.Replace("{$_titulo_$}",					$"{titulo_pagina} | {titulo}"			);
				contenido = contenido.Replace("{$_vista_pagina_color_$}",		color									);
				contenido = contenido.Replace("{$_url_sistema_$}",				url_sistema								);
				contenido = contenido.Replace("{$_nonce_$}",					nonce									);
			/**/
			/*Cabezeras*/
				context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
			/**/
			/*FIN*/
				return contenido;
			/**/
		}

		/*Codigo inferior*/
		public static string inferior(){
			/**/
			/*Ubicacion*/
				string ubicacion	= _sistema_.Lector_ENV.ubicacion_archivos("pagina_inferior.html");
			/**/
			/*Contenido*/
				string contenido	= File.ReadAllText( ubicacion, Encoding.UTF8 );
			/**/
			/*FIN*/
				return contenido;
			/**/
		}
	}
}