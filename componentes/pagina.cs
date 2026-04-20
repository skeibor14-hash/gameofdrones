using System.IO;
using System.Text;

namespace componentes{

	/*Sanitizador de objetos recibidos*/
	public class Pagina{

		/*Codigo superior*/
		public static string superior( HttpContext context, string titulo, bool cache, bool robots, bool csp ){
			/**/
			/*Contenido*/
				string contenido		= File.ReadAllText( _sistema_.Lector_ENV.ubicar_archivos("pagina_superior.html"), Encoding.UTF8 );
			/**/
			/*Obtener Valores base*/
				string titulo_pagina	= _sistema_.Lector_ENV.obtener("vista_pagina_titulo");
				string color			= _sistema_.Lector_ENV.obtener("vista_pagina_color");
				string url_sistema		= _sistema_.Lector_ENV.url_sistema();
				string nonce			= _sistema_.Lector_ENV.generar_nonce();
				string scripts			= _sistema_.Lector_ENV.obtener("archivo_scripts");
				string favicon			= _sistema_.Lector_ENV.obtener("archivo_favicon");
				string estilos_css		= _sistema_.Lector_ENV.obtener("archivo_estilos");
				string angular_js		= _sistema_.Lector_ENV.obtener("archivo_angular");
			/**/
			/*Realizar remplazos*/
				contenido = contenido.Replace("{$_scripts_js_$}",				scripts									);
				contenido = contenido.Replace("{$_favicon_$}",					favicon									);
				contenido = contenido.Replace("{$_estilos_css_$}",				estilos_css								);
				contenido = contenido.Replace("{$_angular_js_$}",				angular_js								);
				contenido = contenido.Replace("{$_nonce_$}",					nonce									);
				contenido = contenido.Replace("{$_titulo_$}",					$"{titulo_pagina} | {titulo}"			);
				contenido = contenido.Replace("{$_url_sistema_$}",				url_sistema								);
				contenido = contenido.Replace("{$_vista_pagina_color_$}",		color									);
			/**/
			/*Cabezeras*/
				controladores.Archivos.cabezeras_constantes( context );
				controladores.Archivos.cabezeras_cache( context, cache );
				controladores.Archivos.cabezeras_robots( context, robots );
				controladores.Archivos.cabezeras_csp( context, csp );
			/**/
			/*Aplicar cabezeras*/
				context.Response.Headers["Content-Type"]			= "text/html; charset=UTF-8";
				context.Response.Headers["Content-Disposition"]		= $@"inline; filename=""{titulo}.html""";
			/**/
			/*FIN*/
				return contenido;
			/**/
		}

		/*Codigo inferior*/
		public static string inferior(){
			return  File.ReadAllText( _sistema_.Lector_ENV.ubicar_archivos("pagina_inferior.html"), Encoding.UTF8 );
		}
	}
}