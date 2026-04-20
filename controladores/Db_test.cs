using Microsoft.Data.Sqlite;

namespace controladores{

	public static class Db_test{

		/*Inicio de la url*/
		public static void main(WebApplication app){
			/**/
			/*Obtener Variable*/
				string ruta = _sistema_.Lector_ENV.obtener("ruta_db_test");
			/**/
			/*Verificar si ruta no borrada*/
				if( ruta != "[borrar]" ){
					app.MapGet( ruta, (HttpContext context) => {
						/**/
						/*Crear texto*/
							string text = "";
						/**/
						/*Generar Texto*/
							text += $"<h2>Prueba de tabla</h2><br>";
							text += modelos.Entidades.opciones();
						/**/
						/*Fin*/
							context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
							return text;
						/**/
					});
				}
            // Obtiener la variable para modelo Juegos_Estados
            string juegoestado = _sistema_.Lector_ENV.obtener("ruta_db_juego_estado");

            if (rutajuegoestado != "[borrar]") {
                app.MapGet(rutajuegoestado, (HttpContext context) => {
                    string text = $"<h2>Listado de Juegos Estados</h2><br>";

						/*Generar Texto*/
                    text += modelos.Juegos_Estados.opciones();

                    context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
                    return text;
                });
            }
             // Obtiener la variable para modelo Reglas
            string regla = _sistema_.Lector_ENV.obtener("ruta_db_regla");

            if (rutaregla != "[borrar]") {
                app.MapGet(rutaregla, (HttpContext context) => {
                    string text = $"<h2>Listado de Reglas</h2><br>";

						/*Generar Texto*/
                    text += modelos.Reglas.opciones();

                    context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
                    return text;
                });
            }
            // Obtiener la variable para modelo Juegos
            string juego = _sistema_.Lector_ENV.obtener("ruta_db_juego");

            if (rutajuego != "[borrar]") {
                app.MapGet(rutajuego, (HttpContext context) => {
                    string text = $"<h2>Juegos</h2><br>";

						/*Generar Texto*/
                    text += modelos.Juegos.opciones();

                    context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
                    return text;
                });
            }
            // Obtiener la variable para modelo Jugadores
            string jugadores = _sistema_.Lector_ENV.obtener("ruta_db_jugadores");

            if (rutajuegadores != "[borrar]") {
                app.MapGet(rutajugadores, (HttpContext context) => {
                    string text = $"<h2>Jugadores</h2><br>";

						/*Generar Texto*/
                    text += modelos.Jugadores.opciones();
                    context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
                    return text;
                });
            }
        }
    }
}
