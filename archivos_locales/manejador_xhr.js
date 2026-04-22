/*Sanitizador de objetos recibidos*/
window['mxhr'] = {

	/*Abre el uso de la URL*/
	'crear': ( $metodo, $url, $data, $onload ) =>{
		/**/
		/*Crear XHR*/
			let $xhr = new XMLHttpRequest();
		/**/
		/*Abrir URL*/
			$xhr.open( $metodo, $url, true );
		/**/
		/*Cargar URL*/
			$xhr.onload = _ => {
				if(
					mxhr.respuesta_200( $xhr )
				){
					$onload( $xhr );
				}
			}
		/**/
		/*Cargar formdata*/
			let $formulario = new FormData();
		/**/
		/*Foreach*/
			for( $key in $data )
				$formulario.append( $key, $data[ $key ] );
		/**/
		/*Enviar*/
			$xhr.send( $formulario )
		/**/
	},

	'respuesta_200': ( $xhr ) => {
		if(
			$xhr.readyState === 4
		){
			/**/
			/*Manejo de envio*/
				if(
					$xhr.status === 200
				)
					return true;
			/**/
			/*ERROR*/
				window.angular_set('mensaje_servidor_titulo', `Error ${ $xhr.status }:`		);
				window.angular_set('mensaje_servidor_contenido', $xhr.statusText			);
				console.log( $xhr );
			/**/
			/*FIN*/
				return false;
			/**/
		}
	},

	'onload_200': ( $xhr ) => {
		if(
			$xhr.response
		){
			/**/
			/*Definir JSON*/
				let $json = "";
			/**/
			/*Intentar resolver JSON*/
				try{
					$json = JSON.parse( $xhr.response );
				}catch( $e ){
					/**/
					/*ERROR*/
						window.angular_set('mensaje_servidor_titulo',		`Error al decodificar JSON:`		);
						window.angular_set('mensaje_servidor_contenido',	'JSON no posee formato correcto'	);
						console.log( $xhr );
					/**/
					/*FALSE*/
						return false;
					/**/
				}
			/**/
			/*Verficiar codigo 200*/
				if(
					!$json.codigo
				){
					/**/
					/*ERROR*/
						window.angular_set('mensaje_servidor_titulo',		`Error al leer código JSON:`		);
						window.angular_set('mensaje_servidor_contenido',	'JSON no posee formato correcto'	);
						console.log( $xhr );
					/**/
					/*FALSE*/
						return false;
					/**/
				}
			/**/
			/*Verficiar codigo 200*/
				if(
					$json.codigo !== 200
				){
					/**/
					/*ERROR*/
						window.angular_set('mensaje_servidor_titulo',		'Solicitud denegada'													);
						window.angular_set('mensaje_servidor_contenido',	`${ $json.mensaje }. De ser posible, corriga los errores indicados`		);
						console.log( $xhr );
					/**/
					/*FALSE*/
						return false;
					/**/
				}
			/**/
			/*Todo en orden*/
				return $json;
			/**/
		}
	},
};