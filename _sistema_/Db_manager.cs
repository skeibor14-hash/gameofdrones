using System.IO;

namespace _sistema_{

	/*Manejador de Modelo individual*/
	public class modelo_manager : IEnumerable<string[]> {

		/*Listado de listas*/
		private List<string[]> filas = new List<string[]>();

		/*Agregar Fila*/
		public void Add( string[] fila ){
		    filas.Add( fila );
		}

		/*Indexacion de filas*/
		public string[] this[ int index ]{
			get{
				return filas[ index ];
			}
			set{
				filas[ index ] = value;
			}
		}

		/*Conteo*/
		public int Count{
			get{
				return filas.Count;
			}
		}

		/*Ennumeradores*/
		public IEnumerator<string[]> GetEnumerator(){
			return filas.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
			return this.GetEnumerator();
		}
	}

	/*Manejador de Modelos*/
	public class Db_manager{

		/*Ubicacion de DB*/
		public static string db_local	= "";

		/*Estado de item*/
		public static string activo		= "activo_";
		public static string inactivo	= "inactivo_";

		/*Inicio de la url*/
		public static void main( string db_local ){

			/*Verificar Debug*/
			if( Directory.Exists( "bin/debug/net10.0" ) ){
				db_local = "bin/debug/net10.0/" + db_local;
			}

			/*Crear carpeta*/
			if( !Directory.Exists( db_local ) ){
				Directory.CreateDirectory(  db_local  );
			}

			/*Asignar ubicacion*/
			_sistema_.Db_manager.db_local = db_local;
		}
	}
}