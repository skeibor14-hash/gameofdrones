using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BaseFolder{

	class Program{

		static void Main( string[] args ){

			/*consturctor de APP*/
			var builder = WebApplication.CreateBuilder( args );

			/*Iniciar lectura de ENV desde Lector_ENV.cs*/
			_sistema_.Lector_ENV.cargar_env();

			/*Carga de archivos necesarios*/
			_sistema_.Lector_ENV.ubicar_archivos();

			/*Iniciar DB desde Db_Manager.cs*/
			_sistema_.DB_Starter.conectar();

			/*Llamado del constructor de aplicacion*/
			Microsoft.AspNetCore.Builder.WebApplication app = builder.Build();

			/*Pagina de error 404*/
			BaseFolder.Rutas.p404( app );

			/*Configuracion de la URL + Puerto*/
			app.Urls.Add( _sistema_.Lector_ENV.url_sistema() );

			/*llamado de Rutas.cs*/
			BaseFolder.Rutas.main( app );

			/*Enviar*/
			app.Run();
		}
	}
}