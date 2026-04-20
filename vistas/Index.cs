using System.IO;
using System.Text;

namespace vistas{

	/*Sanitizador de objetos recibidos*/
	public class Index{

		/*Union de elementos*/
		public static string main( HttpContext context ){
			/**/
			/*Crear string*/
				string html = "";
			/**/
			/*Conectar elementos*/
				html += componentes.Pagina.superior( context, "Inicio", false, true, true );
				html += vistas.Index.css();
				html += vistas.Index.codigo();
				html += vistas.Index.script();
				html += componentes.Pagina.inferior();
			/**/
			/*FIN*/
				return html;
			/**/
		}

		/*css del index*/
		public static string css(){
			return @"";
		}

		/*Codigo del index*/
		public static string codigo(){
			return  File.ReadAllText( _sistema_.Lector_ENV.ubicar_archivos("vista_index.html"), Encoding.UTF8 );
		}

		/*scripts del index*/
		public static string script(){
			return @"";
		}
	}
}