/*Sanitizador de objetos recibidos*/
window['Sanitizador'] = {

	/*Convierte caracteres especiales en secuencia de datos seguros para DB y el sitema en general*/
	'escapar': ( valor ) => {
		/**/
		/*Sostenedor*/
			let origen		= "";
			let conversion	= "";
		/**/
		/*Revision*/
			origen = "+";	conversion = "[A]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = ",";	conversion = "[B]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "-";	conversion = "[C]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = ".";	conversion = "[D]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "/";	conversion = "[E]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = ":";	conversion = "[F]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = ";";	conversion = "[G]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "<";	conversion = "[H]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "=";	conversion = "[I]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = ">";	conversion = "[J]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "?";	conversion = "[K]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "@";	conversion = "[M]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "\\";	conversion = "[N]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "^";	conversion = "[L]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "`";	conversion = "[O]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "{";	conversion = "[P]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "}";	conversion = "[Q]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "~";	conversion = "[R]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "_";	conversion = "[S]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "|";	conversion = "[T]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "'";	conversion = "[U]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "!";	conversion = "[V]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "\"";	conversion = "[W]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "#";	conversion = "[X]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "$";	conversion = "[Y]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "%";	conversion = "[Z]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "&";	conversion = "[0]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "(";	conversion = "[1]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = ")";	conversion = "[2]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
			origen = "*";	conversion = "[3]"; if( valor.indexOf( origen ) !== -1 ){ valor = valor.split( origen ).join( conversion ); }
		/**/
		/*FIN*/
			return valor;
		/**/

	},

	/*Revierte origenes especiales a secuencias inseguras*/
	'descapar': ( valor ) => {
		/**/
		/*Sostenedor*/
			let origen		= "";
			let conversion	= "";
		/**/
		/*Revision*/
			origen = "+";	conversion = "[A]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = ",";	conversion = "[B]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "-";	conversion = "[C]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = ".";	conversion = "[D]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "/";	conversion = "[E]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = ":";	conversion = "[F]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = ";";	conversion = "[G]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "<";	conversion = "[H]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "=";	conversion = "[I]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = ">";	conversion = "[J]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "?";	conversion = "[K]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "@";	conversion = "[M]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "\\";	conversion = "[N]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "^";	conversion = "[L]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "`";	conversion = "[O]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "{";	conversion = "[P]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "}";	conversion = "[Q]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "~";	conversion = "[R]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "_";	conversion = "[S]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "|";	conversion = "[T]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "'";	conversion = "[U]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "!";	conversion = "[V]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "\"";	conversion = "[W]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "#";	conversion = "[X]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "$";	conversion = "[Y]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "%";	conversion = "[Z]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "&";	conversion = "[0]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "(";	conversion = "[1]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = ")";	conversion = "[2]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
			origen = "*";	conversion = "[3]"; if( valor.indexOf( conversion ) !== -1 ){ valor = valor.split( conversion ).join( origen ); }
		/**/
		/*FIN*/
			return valor;
		/**/
	},
}