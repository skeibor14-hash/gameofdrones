using _sistema_;
using System.IO;
using System.Text;

namespace modelos{

	public class Jugadores : Db_manager {

		public static string ruta		= "";
		public static string formato	= "|[nombre]|";

		public Jugadores main(){
			/**/
			/*Ruta de accion*/
				modelos.Jugadores.ruta = _sistema_.Db_manager.db_local + "/jugadores";
			/**/
			/*Verificar si carpeta*/
				if( !Directory.Exists( modelos.Jugadores.ruta ) ){
					Directory.CreateDirectory(  modelos.Jugadores.ruta  );
				}
			/**/
			/*FIN*/
				return this;
			/**/
		}
	}
}