namespace controladores{

	public static class linked_list{

		/*Inicio de la url*/
		public static void main(WebApplication app){

			/*Generar enrutacion*/
			app.MapGet("/linked_list", (HttpContext context) => {
				/**/
				/*Inicio de linked list*/

					/*Iniciar Lista y Nodo*/
					_sistema_.Lista_nodo prueba = _sistema_.Lista.crear();

					/*Agregar items*/
					_sistema_.Lista.agregar<int>( prueba, 1 ); 					/*Item 1*/
					_sistema_.Lista.agregar<string>( prueba, "2", "Carros" ); 	/*Item 2, con llave*/
					_sistema_.Lista.agregar<string>( prueba, "3" ); 			/*Item 3*/

				/**/
				/*Crear Texto*/
					string texto = "";
				/**/
				/*Iteramos lista*/
					_sistema_.Lista.iterar( prueba, ( num, key, val ) => {
						texto += "Item #" + num + "; llave [" + key + "] es => " + val + "<br>";
					});
				/**/
				/*FIN*/
					context.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
					return texto;
				/**/
			});
		}
	}
}
