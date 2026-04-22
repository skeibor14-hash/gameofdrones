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
				html += vistas.Index.codigo( context );
				html += componentes.Pagina.inferior();
			/**/
			/*FIN*/
				return html;
			/**/
		}

		/*Codigo del index*/
		public static string codigo( HttpContext context ){
			/**/
			/*Obtener codigo*/
				string codigo = File.ReadAllText( _sistema_.Lector_ENV.ubicar_archivos("vista_index.html"), Encoding.UTF8 );
			/**/
			/*Remplazar*/
				codigo = codigo.Replace("{$_token_csrf_$}", _sistema_.Posts.obtener_csrf( context ) );
			/**/
			/*FIN*/
				return codigo;
			/**/
		}
	}
}