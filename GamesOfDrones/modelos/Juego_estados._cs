using _sistema_;
using System.IO;
using System.Text;

namespace modelos{

	public class Juego_estados : Db_manager {

		public static string ruta		= "";
		public static string formato	= "|[nombre]|";

		public Juego_estados main(){
			/**/
			/*Ruta de accion*/
				modelos.Juego_estados.ruta = _sistema_.Db_manager.db_local + "/juego_estados";
			/**/
			/*Verificar si carpeta*/
				if( !Directory.Exists( modelos.Juego_estados.ruta ) ){
					Directory.CreateDirectory(  modelos.Juego_estados.ruta  );
				}
			/**/
			/*Verificar si migrado*/
				if( !File.Exists( modelos.Juego_estados.ruta + "/" + modelos.Juego_estados.activo + "1" ) ){
					/**/
					/*Crear Item*/
						string item = "";
					/**/
					/*ITEM*/
						item = modelos.Juego_estados.formato.Replace("[nombre]", "En proceso"  );
						File.WriteAllText( modelos.Juego_estados.ruta + "/" + modelos.Juego_estados.activo + "1", item, Encoding.UTF8 );
					/**/
					/*ITEM*/
						item = modelos.Juego_estados.formato.Replace("[nombre]", "Finalizado"  );
						File.WriteAllText( modelos.Juego_estados.ruta + "/" + modelos.Juego_estados.activo + "2", item, Encoding.UTF8 );
					/**/
					/*ITEM*/
						item = modelos.Juego_estados.formato.Replace("[nombre]", "Abandonado"  );
						File.WriteAllText( modelos.Juego_estados.ruta + "/" + modelos.Juego_estados.activo + "3", item, Encoding.UTF8 );
					/**/
				}
			/**/
			/*FIN*/
				return this;
			/**/
		}
	}
}