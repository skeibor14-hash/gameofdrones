using _sistema_;
using System.IO;
using System.Text;

namespace modelos{

	/*Item Lista*/
	public class Entidad : modelo_manager {}

	/*Item DB*/
	public class Entidades : Db_manager {

		/*Propiedades*/
		public static string ruta		= "";
		public static string formato	= "|[nombre]|";

		/*Inicializar items*/
		public Entidades main(){
			/**/
			/*Ruta de accion*/
				modelos.Entidades.ruta = _sistema_.Db_manager.db_local + "/entidades";
			/**/
			/*Verificar si carpeta*/
				if( !Directory.Exists( modelos.Entidades.ruta ) ){
					Directory.CreateDirectory(  modelos.Entidades.ruta  );
				}
			/**/
			/*Verificar si migrado*/
				if( !File.Exists( modelos.Entidades.ruta + "/" + modelos.Entidades.activo + "1" ) ){
					/**/
					/*Crear Item*/
						string item = "";
					/**/
					/*ITEM*/
						item = modelos.Entidades.formato.Replace("[nombre]", "Piedra"  );
						File.WriteAllText( modelos.Entidades.ruta + "/" + modelos.Entidades.activo + "1", item, Encoding.UTF8 );
					/**/
					/*ITEM*/
						item = modelos.Entidades.formato.Replace("[nombre]", "Papel"  );
						File.WriteAllText( modelos.Entidades.ruta + "/" + modelos.Entidades.activo + "2", item, Encoding.UTF8 );
					/**/
					/*ITEM*/
						item = modelos.Entidades.formato.Replace("[nombre]", "Tijera"  );
						File.WriteAllText( modelos.Entidades.ruta + "/" + modelos.Entidades.activo + "3", item, Encoding.UTF8 );
					/**/
				}
			/**/
			/*FIN*/
				return this;
			/**/
		}

		/*Seleccionar todo*/
		public Entidad all(){
			/**/
			/*Iniciar tabla*/
				this.main();
			/**/
			/*Obtener nueva lista*/
				modelos.Entidad nueva_lista = new modelos.Entidad();
			/**/
			/*Iterar directorio*/
				foreach( string ruta_archivo in Directory.GetFiles( modelos.Entidades.ruta, _sistema_.Db_manager.activo + "*" ) ){
					/**/
					/*Obtener Contenido*/
						string contenido	= File.ReadAllText( ruta_archivo, Encoding.UTF8 );
					/**/
					/**/
					/*Remover del contenido los seperadores de inicio y fin*/
						contenido			= contenido.Substring( 1, contenido.Length - 2 );
					/**/
					/*Separar contenido en piezas*/
						string[] n_contenido = contenido.Split("|");
					/**/
					/*Agregar contenido a lista*/
						nueva_lista.Add( n_contenido );
					/**/
				}
			/**/
			/*FIN*/
				return nueva_lista;
			/**/
		}
	}
}