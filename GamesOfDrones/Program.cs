using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MiSistema{

	class Program{

		static void Main( string[] args ){

			/*Llamado del constructor*/
			var builder = WebApplication.CreateBuilder( args );

			/*Llamado del constructor de aplicacion*/
			var app = builder.Build();

			/*Logica de inicio de sesión*/
			/*app.UseSession(new SessionOptions{
				Cookie.Name = "MiCookieDeSesion",
				IdleTimeout = TimeSpan.FromMinutes(30),
				Cookie.HttpOnly = true,
				Cookie.IsEssential = true
			});*/

			/*Iniciar lectura de ENV desde Lector_ENV.cs*/
			_sistema_.Lector_ENV.cargar_env();

			/*Carga de archivos necesarios*/
			_sistema_.Lector_ENV.ubicacion_archivos();

			/*Iniciar DB desde Db_Manager.cs*/
			_sistema_.DB_Starter.conectar();

			/*Pagina de error 404*/
			Rutas.p404( app );

			/*Configuracion de la URL + Puerto*/
			app.Urls.Add( _sistema_.Lector_ENV.url_sistema() );

			/*llamado de Rutas.cs*/
			Rutas.main( app );

			/*Enviar*/
			app.Run();
		}
	}
}