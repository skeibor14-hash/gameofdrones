using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _sistema_{

	/*Item de DB*/
	public static class Lector_ENV{

		/*Nonce del sistema*/
		public static string Sys_nonce = "";

		/*URL del sistema*/
		public static string Sys_url = "";

		/*PATH de archivos*/
		public static string Sys_files_path = "";

		/*Version del ENV*/
		public static string ENV_ver = "0.8.0";

		/*Ubicacion del ENV*/
		public static string ENV_path = "env.txt";

		/*Sostenedor de ENVS*/
		public static string ENV = "";

		/*Cargar ENV*/
		public static void cargar_env(){
			/**/
			/*Verificar existencia del ENV*/
				if( !File.Exists( Lector_ENV.ENV_path ) ){
					File.WriteAllText( Lector_ENV.ENV_path, "");
				}
			/**/
			/*Leer ENV*/
				string contenido = File.ReadAllText( Lector_ENV.ENV_path, Encoding.UTF8 );
			/**/
			/*Verificar Contenido del ENV*/
				if( !contenido.Contains($"version={Lector_ENV.ENV_ver}") ){
					contenido = "";
				}
			/**/
			/*Crear objeto env*/
				if( contenido == "" ){
					contenido = Lector_ENV.env_base();
				}
			/**/
			/*Cargar contenido del env*/
				Lector_ENV.env_parser( contenido );
			/**/
		}

		/*Crear ENV base*/
		public static string env_base(){
			/**/
			/*Creador de contenido*/
				string contenido = "";
			/**/
			/*Info*/
				contenido += "###	Archivo de variables configurables del sistema.\n";
				contenido += "###	Tenga en cuenta que si una variable falta o no es declarada apropiadamente, podrá causar problemas en la ejecucion del sistema.\n";
				contenido += "###	Por tanto, si una variable falta o esta mal configurada, el archivo ENV se reiniciará automáticamente.\n";
				contenido += "###	Los comentarios comienzan con: [###] + [tabulador]\n";
				contenido += "###	Los comentarios son tomados en cuenta hasta el final de la linea.\n";
				contenido += "###	Evitar comentar variables.\n";
				contenido += "###	Para programadores: Evitar nombres de variables que posean caracteres especiales mas alla de [_]. Evitar espacios, signos de puntuación, ya que puede afectar el [regexp] interno del sistema.\n";
				contenido += "###	Para usuarios: Evitar nombres de variables que posean caracteres especiales mas alla de [_]. Variables que no esten listadas en este archivo son ignoradas, aún asi será cargadas en memoria, tener en cuenta de no agregar variables adicionales que no se usen en este archivo.\n";
				contenido += "###	El nombre de la variable comienza desde el inicio de la línea hasta el signo [=].\n";
				contenido += "###	El valor de la variable comienza desde el signo [=] hasta el signo [;].\n";
				contenido += "###	Los siguientes signos causaran conflicto con este archivo, evitar su uso fuera de comentarios: [;], [=], [#]\n";
				contenido += "###	Si se desea agregar una nueva línea [\\n] usar el literal [n]; Ejemplo: hola[n]mundo.\n";
				contenido += "###	Si se desea usar dos puntos [;] usar el literal [d]; hola[d]mundo.\n";
				contenido += "###	Si se desea usar igual [=] usar el literal [i]; Ejemplo: hola[i]mundo.\n";
				contenido += "###	Si se desea usar hashtag [#] usar el literal [h]; Ejemplo: hola[h]mundo.\n";
				contenido += "###	Líneas nuevas no seran tomadas encuenta a menos que se escriba el literal: [n]; Ejemplo: Mi[n]nueva[n]linea.\n";
				contenido += "###	Evitar el menor uso posible de signos especiales para prevenir efectos indeseados.\n";
				contenido += "###	Los cambios de este archivo solo tomaran efecto al reinicio de cada ejecucion.\n";
			/**/
			/*Separador*/
				contenido += "\n\n";
			/**/
			/*Crear Contenido de variables*/

				contenido += $"version={Lector_ENV.ENV_ver};											###	Version del enviroment actual. Cambiar este numero si se desea reiniciar el ENV\n";

				contenido += "\n\n";
				contenido += "###	Carpeta de compilacion:\n\n";
				contenido += $"sys_compilacion_folder=bin/debug/net10.0;				###	Esta representa la ruta de compilacion al ejecutar [dotnet run], se usa para colocar [archivos_locales] en su lugar\n";

				contenido += "\n\n";
				contenido += "###	Puerto y url del sistema:\n\n";
				contenido += $"sys_protocolo_sistema=http;								###	Protocolo del sistema, solo acepta [http] y [https] como valores\n";
				contenido += $"sys_host_sistema=localhost;								###	Nombre donde el sistema esta alojado. Recomendado mantener localhost, si se desea hostear se debe usar el nombre del dominio\n";
				contenido += $"sys_puerto_sistema=5002;								###	puerto del sistema, 443 para https, 80 para http, cualquier otro puerto para bind. Si el puerto esta ocupado causara un error en la hora de ejecutar\n";

				contenido += "\n\n";
				contenido += "###	Elementos visuales en vistas:\n\n";
				contenido += $"vista_pagina_titulo=Games of Drones;					###	Titulo de la URL global del sistema\n";
				contenido += $"vista_pagina_color=000000;								###	Color de la pagina para celulares y dispositivos moviles\n";

				contenido += "\n\n";
				contenido += "###	Configuracion de SQLite:\n\n";
				contenido += $"db_sqlite_ubicacion=database.db;						###	Ruta y nombre de la DB a acceder, este archivo será creado automáticamente y migrará las tablas segun su uso. Tener en cuenta que si el archivo es innaccesible podrá causar mal funcionamiento del sistema\n";

				contenido += "\n\n";
				contenido += "###	Configuracion de rutas:\n\n";
				contenido += $"ruta_pagina_principal=/;								###	Pagina de inicio del sistema\n";
				contenido += $"ruta_db_test=/db_test;									###	Ruta de pruebas de DB; escribir como valor [borrar] para desactivar, incluyendo los corchetes\n";
				contenido += $"ruta_comenzar_juego=/comenzar_juego;									###	Ruta de POST para comenzar un juego\n";

				contenido += "\n\n";
				contenido += "###	Configuracion de archivos utilizados:\n\n";
				contenido += $"archivo_angular=/archivos/angular.min.js;				###	Angular del sistema\n";
				contenido += $"archivo_estilos=/archivos/estilos.js;					###	Estilos del sistema\n";
				contenido += $"archivo_favicon=/archivos/favicon.ico;					###	Icono del sistema\n";
				contenido += $"archivo_sanitizador=/archivos/sanitizador.js;			###	Sanitizador de JS\n";
				contenido += $"archivo_xhr=/archivos/manejador_xhr.js;					###	Manejador XHR del sistema\n";
				contenido += $"archivo_scripts=/archivos/scripts.js;					###	Scripts del sistema\n";

				contenido += "\n\n";
				contenido += "###	Elementos de seguridad:\n\n";
				contenido += $"sesion_vencimiento=86400;								###	Tiempo en segundos de vencimiento de sesión; Por defecto máximo es 3 dias; Valor defaul es 24 horas equivalente a: 86400\n";
				contenido += $"cookie_sesion=SESSION_CS;								###	Nombre de la cookie de sesión del sistema\n";
				contenido += $"cookie_csrf=CSRF_CS;									###	Nombre de la cookie de CSRF del sistema\n";
			/*Escribir*/
				File.WriteAllText( Lector_ENV.ENV_path, contenido );
			/**/
			/*Fin*/
				return contenido;
			/**/
		}

		/*Parser de ENV*/
		public static void env_parser( string contenido ){

			/*Remocion de comentarios*/
			contenido = Regex.Replace( contenido, "###\t.*?\n", "\n" );

			/*Remover Lineas*/
			contenido = Regex.Replace( contenido, "\n", "" );

			/*Remocion espacios fuera de valores*/
			contenido = Regex.Replace( contenido, @";\s+", ";" );

			/*Agregar literal [N]*/
			contenido = contenido.Replace( "[n]", "\n" );

			/*Agregar literal [D]*/
			contenido = contenido.Replace( "[d]", ";" );

			/*Agregar literal [i]*/
			contenido = contenido.Replace( "[i]", "=" );

			/*Agregar literal [h]*/
			contenido = contenido.Replace( "[h]", "#" );

			/*Cargar segun lo deseado por el usuario*/
			Lector_ENV.ENV = $";{contenido}";
		}

		/*Ruta base del sistema*/
		public static string obtener( string nombre ){
			/**/
			/*Regexp*/
				string regexp = @$";{nombre}=(.*?);";
			/**/
			/*Verificar objeto deseado; Reiniciar si no existe*/
				Match capturador = Regex.Match( Lector_ENV.ENV, regexp );
				if( !capturador.Success ){
					/**/
					/*Volver a cargar*/
						Lector_ENV.env_parser( Lector_ENV.env_base() );
					/**/
					/*Finalizar con error si no existe*/
						capturador = Regex.Match( Lector_ENV.ENV, regexp );
						if( !capturador.Success ){
							throw new ArgumentNullException(  @$"Error de ENV -> El objeto [Lector_ENV.obtener(""{nombre}"")] no pudo ser obtenido del ENV base. Configure correctamente [Lector_ENV.env_base()].");
						}
					/**/
				}
			/**/
			/*Devolver valor encontrado*/
				return capturador.Groups[1].Value;
			/**/
		}

		/*Ruta base del sistema*/
		public static string url_sistema(){
			/**/
			/*Verificar si no obtenido*/
				if( Lector_ENV.Sys_url == "" ){
					/**/
					/*Obtener Datos*/
						string protocolo	=  Lector_ENV.obtener("sys_protocolo_sistema");
						string host			=  Lector_ENV.obtener("sys_host_sistema");
						string puerto		=  Lector_ENV.obtener("sys_puerto_sistema");
					/**/
					/*Crear*/
						Lector_ENV.Sys_url	=  $"{protocolo}://{host}:{puerto}/";
					/**/
				}
			/**/
			/*Enviar*/
				return Lector_ENV.Sys_url;
			/**/
		}

		/*Alertar existencia o inexistencias*/
		public static void alertar_archivo( string ruta = "" ){
			if( !File.Exists( ruta ) ){
				throw new ArgumentNullException( "Error de carga de archivos", @$"El archivo [{ruta}] no pudo ser obtenido. Configure [Lector_ENV.ubicar_archivos()] para incluir este archivo");
			}
		}

		/*Ruta base de archivos*/
		public static string ubicar_archivos( string extra_path = "" ){
			/**/
			/*Verificar si no obtenido*/
				if( Lector_ENV.Sys_files_path == "" ){

					/*Directorio de origen*/
					string directorio_origen	= "archivos_locales";

					/*Ubicacion de compilacion*/
					string ubicacion_compilacion =  Lector_ENV.obtener("sys_compilacion_folder");

					/*Verificar existencia de compilacion*/
					if( Directory.Exists( ubicacion_compilacion ) ){

						/*Directorio destino*/
						string directorio_destino	= $"{ubicacion_compilacion}/archivos_locales";

						/*Crear Directorio*/
						Directory.CreateDirectory( directorio_destino );

						foreach( string archivo_encontrado in Directory.GetFiles(  directorio_origen, "*.*" )){
						    File.Copy( archivo_encontrado, $"{ubicacion_compilacion}/{archivo_encontrado}", true );
						}

						/*Asignar directorio destino*/
						Lector_ENV.Sys_files_path = directorio_destino;
					}
					else{
						/**/
						/*Asignar directorio destino*/
							Lector_ENV.Sys_files_path = directorio_origen;
						/**/
					}
				}
			/**/
			/*Archivo de salida*/
				string archivo_salida = $"{Lector_ENV.Sys_files_path}/{extra_path}";
			/**/
			/*Verificar*/
				if( !Directory.Exists( archivo_salida ) ){
					Lector_ENV.alertar_archivo( archivo_salida );
				}
			/**/
			/*FIN*/
				return archivo_salida;
			/**/
		}

		/*Nonce Vistas*/
		public static string generar_nonce(){
			/**/
			/*Verificar si no obtenido*/
				if( Lector_ENV.Sys_nonce == "" ){
					Lector_ENV.Sys_nonce = _sistema_.MD5_HASH.hazar();
				}
			/**/
			/*FIN*/
				return Lector_ENV.Sys_nonce;
			/**/
		}
	}
}