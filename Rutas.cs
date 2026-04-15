using controladores;

namespace MiServidorWeb{

	public static class Rutas{

		public static void main(WebApplication app){

			/*Unir controladores.iniciar_juego.cs*/
			iniciar_juego.main( app );

			/*Unir controladores.mover_turno.cs*/
			mover_turno.main( app );
		}
	}
}