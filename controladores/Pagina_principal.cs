namespace controladores{

	public static class Pagina_principal{

		/*Inicio de la url*/
		public static void main( WebApplication app ){
			app.MapGet( _sistema_.Lector_ENV.obtener("ruta_pagina_principal"), ( HttpContext context ) => {
				return vistas.Index.main( context );
			});
		}
	}
}