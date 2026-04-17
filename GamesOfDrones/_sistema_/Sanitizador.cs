namespace _sistema_{

	/*Sanitizador de objetos recibidos*/
	public class Sanitizador{

		/*Convierte caracteres especiales en secuencia de datos seguros para DB y el sitema en general*/
		public static string escapar( string valor ){
			/**/
			/*Sostenedor*/
				string caracter = "";
				string remplazo = "";
			/**/
			/*Revision*/
				caracter = "+";		remplazo = "[A]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = ",";		remplazo = "[B]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "-";		remplazo = "[C]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = ".";		remplazo = "[D]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "/";		remplazo = "[E]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = ":";		remplazo = "[F]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = ";";		remplazo = "[G]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "<";		remplazo = "[H]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "=";		remplazo = "[I]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = ">";		remplazo = "[J]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "?";		remplazo = "[K]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "@";		remplazo = "[M]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = @"\";	remplazo = "[N]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "^";		remplazo = "[L]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "`";		remplazo = "[O]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "{";		remplazo = "[P]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "}";		remplazo = "[Q]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "~";		remplazo = "[R]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "_";		remplazo = "[S]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "|";		remplazo = "[T]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "'";		remplazo = "[U]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "!";		remplazo = "[V]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = @"""";	remplazo = "[W]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "#";		remplazo = "[X]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "$";		remplazo = "[Y]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "%";		remplazo = "[Z]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "&";		remplazo = "[0]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "(";		remplazo = "[1]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = ")";		remplazo = "[2]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
				caracter = "*";		remplazo = "[3]"; if( valor.Contains( caracter ) ){ valor = valor.Replace( caracter, remplazo ); }
			/**/
			/*FIN*/
				return valor;
			/**/
		}

		/*Revierte caracteres especiales a secuencias inseguras*/
		public static string descapar( string valor ){
			/**/
			/*Sostenedor*/
				string caracter = "";
				string remplazo = "";
			/**/
			/*Revision*/
				caracter = "+";		remplazo = "[A]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = ",";		remplazo = "[B]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "-";		remplazo = "[C]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = ".";		remplazo = "[D]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "/";		remplazo = "[E]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = ":";		remplazo = "[F]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = ";";		remplazo = "[G]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "<";		remplazo = "[H]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "=";		remplazo = "[I]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = ">";		remplazo = "[J]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "?";		remplazo = "[K]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "@";		remplazo = "[M]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = @"\";	remplazo = "[N]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "^";		remplazo = "[L]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "`";		remplazo = "[O]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "{";		remplazo = "[P]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "}";		remplazo = "[Q]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "~";		remplazo = "[R]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "_";		remplazo = "[S]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "|";		remplazo = "[T]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "'";		remplazo = "[U]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "!";		remplazo = "[V]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = @"""";	remplazo = "[W]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "#";		remplazo = "[X]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "$";		remplazo = "[Y]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "%";		remplazo = "[Z]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "&";		remplazo = "[0]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "(";		remplazo = "[1]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = ")";		remplazo = "[2]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
				caracter = "*";		remplazo = "[3]"; if( valor.Contains( remplazo ) ){ valor = valor.Replace( remplazo, caracter ); }
			/**/
			/*FIN*/
				return valor;
			/**/
		}
	}
}