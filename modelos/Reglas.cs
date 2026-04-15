using _sistema_;
using System.IO;
using System.Text;

namespace modelos{

	public class Reglas : Db_manager {

		public static string ruta		= "";
		public static string formato	= "|[formato]|";

		public Reglas main(){
			/**/
			/*Ruta de accion*/
				modelos.Reglas.ruta = _sistema_.Db_manager.db_local + "/reglas";
			/**/
			/*Verificar si carpeta*/
				if( !Directory.Exists( modelos.Reglas.ruta ) ){
					Directory.CreateDirectory(  modelos.Reglas.ruta  );
				}
			/**/
			/*Verificar si migrado*/
				if( !File.Exists( modelos.Reglas.ruta + "/" + modelos.Reglas.activo + "1" ) ){
					/**/
					/*Crear Item*/
						string fila = "";
					/**/
					/*ITEM*/
						fila = modelos.Reglas.formato.Replace("[formato]", "1:3;2:1;3:2"  );
						File.WriteAllText( modelos.Reglas.ruta + "/" + modelos.Reglas.activo + "1", fila, Encoding.UTF8 );
					/**/
				}
			/**/
			/*FIN*/
				return this;
			/**/
		}
	}
}