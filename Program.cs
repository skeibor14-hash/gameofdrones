using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MiServidorWeb{

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

			/*Iniciar DB*/
			_sistema_.Db_manager.main("db_local");

			/*Pagina de error 404*/
			app.UseStatusCodePages(async context => {
				if( context.HttpContext.Response.StatusCode == 404 ){
					context.HttpContext.Response.ContentType = "text/html; charset=UTF-8";
					await context.HttpContext.Response.WriteAsync("¡Ups! La página que buscas no existe.");
				}
			});

			/*Configuracion de la URL + Puerto*/
			app.Urls.Add("http://localhost:5002");

			/*llamado de Rutas.cs*/
			Rutas.main( app );

			/*Enviar*/
			app.Run();
		}
	}
}