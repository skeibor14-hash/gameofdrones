using _sistema_;
using System.IO;
using System.Text;

namespace modelos{

	public class Juegos : Db_manager {

		public static string ruta		= "";
		public static string formato	= "|[nombre]|";

		public Juegos main(){
			/**/
			/*Ruta de accion*/
				modelos.Juegos.ruta = _sistema_.Db_manager.db_local + "/juegos";
			/**/
			/*Verificar si carpeta*/
				if( !Directory.Exists( modelos.Juegos.ruta ) ){
					Directory.CreateDirectory(  modelos.Juegos.ruta  );
				}
			/**/
			/*FIN*/
				return this;
			/**/
		}
	}
}