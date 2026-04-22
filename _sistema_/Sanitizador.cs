using System.Text.RegularExpressions;

namespace _sistema_{

	/*Sanitizador de objetos recibidos*/
	public class Sanitizador{

		/*Convierte caracteres especiales en secuencia de datos seguros para DB y el sitema en general*/
		public static string escapar( string valor ){
			/**/
			/*Sostenedor*/
				string origen		= "";
				string conversion	= "";
			/**/
			/*Revision*/
				origen = "+";	conversion = "[A]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = ",";	conversion = "[B]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "-";	conversion = "[C]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = ".";	conversion = "[D]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "/";	conversion = "[E]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = ":";	conversion = "[F]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = ";";	conversion = "[G]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "<";	conversion = "[H]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "=";	conversion = "[I]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = ">";	conversion = "[J]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "?";	conversion = "[K]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "@";	conversion = "[M]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = @"\";	conversion = "[N]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "^";	conversion = "[L]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "`";	conversion = "[O]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "{";	conversion = "[P]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "}";	conversion = "[Q]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "~";	conversion = "[R]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "_";	conversion = "[S]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "|";	conversion = "[T]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "'";	conversion = "[U]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "!";	conversion = "[V]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = @"""";	conversion = "[W]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "#";	conversion = "[X]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "$";	conversion = "[Y]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "%";	conversion = "[Z]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "&";	conversion = "[0]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "(";	conversion = "[1]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = ")";	conversion = "[2]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
				origen = "*";	conversion = "[3]"; if( valor.Contains( origen ) ){ valor = valor.Replace( origen, conversion ); }
			/**/
			/*FIN*/
				return valor;
			/**/
		}

		/*Revierte origenes especiales a secuencias inseguras*/
		public static string descapar( string valor ){
			/**/
			/*Sostenedor*/
				string origen		= "";
				string conversion	= "";
			/**/
			/*Revision*/
				origen = "+";	conversion = "[A]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = ",";	conversion = "[B]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "-";	conversion = "[C]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = ".";	conversion = "[D]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "/";	conversion = "[E]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = ":";	conversion = "[F]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = ";";	conversion = "[G]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "<";	conversion = "[H]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "=";	conversion = "[I]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = ">";	conversion = "[J]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "?";	conversion = "[K]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "@";	conversion = "[M]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = @"\";	conversion = "[N]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "^";	conversion = "[L]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "`";	conversion = "[O]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "{";	conversion = "[P]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "}";	conversion = "[Q]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "~";	conversion = "[R]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "_";	conversion = "[S]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "|";	conversion = "[T]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "'";	conversion = "[U]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "!";	conversion = "[V]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = @"""";	conversion = "[W]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "#";	conversion = "[X]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "$";	conversion = "[Y]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "%";	conversion = "[Z]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "&";	conversion = "[0]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "(";	conversion = "[1]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = ")";	conversion = "[2]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
				origen = "*";	conversion = "[3]"; if( valor.Contains( conversion ) ){ valor = valor.Replace( conversion, origen ); }
			/**/
			/*FIN*/
				return valor;
			/**/
		}

		/*Obtener una cookie*/
		public static string obtener_cookie( HttpContext context, string nombre ){
			/**/
			/*Verificar si existe*/
				if(
					context.Request.Cookies[ nombre ] == null
				){
					return "";
				}
			/**/
			/*Verificar si es una cookie valida*/
				if(
					context.Request.Cookies[ nombre ] is not string
				){
					return "";
				}
			/**/
			/*Obtener objeto*/
				string cookie = context.Request.Cookies[ nombre ] ?? "";
			/**/
			/*Verificar que solo posea caracteres de una COOKIE*/
				Match capturador = Regex.Match( cookie, @"^[a-z0-9]{32}$" );
				if(
					!capturador.Success
				){
					return "";
				}
			/**/
			/*FIN*/
				return cookie;
			/**/
		}
	}
}