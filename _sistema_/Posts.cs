using System.Text.RegularExpressions;

namespace _sistema_{

	public static class Posts{

		/*Cabezeras para post*/
		public static string csrf_actual	= "";

		/*Cabezeras para post*/
		public static string cabezera		= "application/json; charset=UTF-8";

		/*Cabezera CSRF*/
		public static void cabezera_csrf( HttpContext context ){
			/**/
			/*Generar Cookie*/
				string nombre	=_sistema_.Lector_ENV.obtener("cookie_csrf");
				string hash 	= _sistema_.MD5_HASH.hazar();
				context.Response.Headers.Append("Set-Cookie", $"{nombre}={hash}; Path=/; HttpOnly; SameSite=Lax; Expires={DateTime.UtcNow.AddDays(1):R}");
			/**/
			/*Guardar en la sesion actual*/
				_sistema_.Sesiones.guardar( context, "csrf", hash );
			/**/
		}

		/*Obtener CSRF*/
		public static string obtener_csrf( HttpContext context ){
			return _sistema_.Sesiones.obtener( context, "csrf" );
		}

		/*Validar CSRF*/
		public static string validar_csrf( HttpContext context, string campo_csrf ){
			/**/
			/*Obtener datos*/
				string valor_cookie		= _sistema_.Posts.obtener_csrf( context );
			/**/
			/*Verificar valor*/
				if(
					valor_cookie == ""
				){
					context.Response.Headers["Content-Type"] = _sistema_.Posts.cabezera;
					return _sistema_.Posts.respuesta_post( 403, "no_admitido", "CSRF de usuario vacía" );
				}
			/**/
			/*Verificar valor*/
				if(
					campo_csrf == ""
				){
					context.Response.Headers["Content-Type"] = _sistema_.Posts.cabezera;
					return _sistema_.Posts.respuesta_post( 403, "no_admitido", "Campo CSRF vacío" );
				}
			/**/
			/*Verificar valor*/
				if(
					valor_cookie != campo_csrf
				){
					context.Response.Headers["Content-Type"] = _sistema_.Posts.cabezera;
					return _sistema_.Posts.respuesta_post( 403, "no_admitido", "CSRF de usuario no coincide" );
				}
			/**/
			/*Valor correcto*/
				return "";
			/**/
		}

		/*Respuestas para post*/
		public static string respuesta_post( int codigo, string resultado, string mensaje ){

			/*Crear Texto*/
			string text = "";

			/*Crear respuesta*/
			text += "{";
			text += @"""codigo"":"		+ $"{codigo.ToString()}";
			text += @",""resultado"":"	+ @$"""{resultado}""";
			text += @",""mensaje"":"	+ @$"""{mensaje}""";
			text += "}";

			/*Fin*/
			return text;
		}

		/*Lector de post*/
		async public static Task<string> leer_post( HttpContext context ){
			using(
				System.IO.StreamReader reader = new StreamReader( context.Request.Body )
			){
				/**/
				/*Obtener Body*/
					string post = await reader.ReadToEndAsync();
				/**/
				/*Transformar post body*/
					post		= _sistema_.Posts.post_parser( post );
				/**/
				/*FIN*/
					return post;
				/**/
			}
		}

		/*Lector de post*/
		public static string post_parser( string post ){
			/**/
			/*Colector*/
				string colector = "";
			/**/
			/*Leer form boundary*/
				Match capturador = Regex.Match( post, @"^(------geckoformboundary[a-z0-9]{32})" );
				if(
					!capturador.Success
				)
					return colector;
			/**/
			/*Obtener form boundary*/
				string form_boundary = capturador.Groups[1].Value;
			/**/
			/*Difivir mi post usando el form boundary*/
				foreach(
					string filas in post.Split( form_boundary )
				){
					/**/
					/*Leer nombre campo*/
						Match campo_capturador = Regex.Match( filas, @"Content-Disposition: form-data; name=""(.*?)""" );
						if(
							!campo_capturador.Success
						)
							continue;
					/**/
					/*Campo nombre*/
						string campo_nombre	= _sistema_.Sanitizador.escapar( campo_capturador.Groups[1].Value );
					/**/
					/*Leer valor campo*/
						string campo_valor	= filas.Replace( @$"Content-Disposition: form-data; name=""{campo_nombre}""", "" );
					/**/
					/*Limpiar valor*/
						campo_valor			= _sistema_.Sanitizador.escapar( campo_valor.Trim() );
					/**/
					/*Coleccionar*/
						colector += $"|{campo_nombre}:{campo_valor}";
					/**/
				}
			/**/
			/*Remover trailing*/
				colector = colector.Substring( 1 );
			/**/
			/*FIN*/
				return colector;
			/**/
		}

		/*Lector de post*/
		public static string obtener_post( string post_parsed, string nombre ){
			/**/
			/*Leer form boundary*/
				Match capturador = Regex.Match( $"|{post_parsed}|", @$"\|{nombre}\:(.*?)\|" );
				if(
					!capturador.Success
				)
					return "";
			/**/
			/*Obtener form boundary*/
				return capturador.Groups[1].Value;
			/**/
		}
	}
}