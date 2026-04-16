namespace _sistema_{

	/*Manejador de items y listas*/
	public static class Lista{
		/**/
		/*Manejador de Creadores*/
			public static Lista_nodo crear(){
				return new Lista_nodo();
			}
		/**/
		/*Manejador de agregar*/
			public static void agregar<T>( Lista_nodo lista, T item, string llave = "" ){
				lista.agregar_nodo( ( item?.ToString() ?? string.Empty ), llave );
			}
		/**/
		/*Manejador de Iterar*/
			public static void iterar( Lista_nodo lista, Action<string,string?,string?> iterador ){
				/**/
				/*Obtener cursor*/
					_sistema_.Lista_item? cursor = lista.cursor();
				/**/
				/*Obtener valores iniciales*/
					string? llave = cursor?.obtener_llave();
					string? valor = cursor?.obtener_valor();
				/**/
				/*Verificar Llave*/
					if( llave == "" ){
						llave = "1";
					}
				/**/
				/*Enviar*/
					iterador( "1", llave, valor );
				/**/
				/*Crear iteradores*/
					int		i_int =  2 ;
					string	i_str = "2";
				/**/
				/*Verificar*/
					while(
						( cursor = cursor?.item_siguiente() ) != null
					){
						/**/
						/*Obtener valores*/
							llave = cursor?.obtener_llave();
							valor = cursor?.obtener_valor();
						/**/
						/*Verificar Llave*/
							if( llave == "" ){
								llave = i_str;
							}
						/**/
						/*Enviar*/
							iterador( i_str, llave, valor );
						/**/
						/*Iterar*/
							++i_int;
						/**/
						/*Stringify*/
							i_str = i_int.ToString();
						/**/
					}
				/**/
			}
		/**/
	}

	/*Lista de nodos*/
	public class Lista_nodo{

		/*Nodos*/
	    public int?			Total		= 0;
	    public Lista_item?	Primero		= null;
	    public Lista_item?	Ultimo		= null;

		/*Constructor*/
		public void agregar_nodo( string valor, string llave = "" ){
			/**/
			/*Crear Nodo*/
				Lista_item nuevo_nodo = new Lista_item();
			/**/
			/*Agregamos valores*/
				nuevo_nodo.agregar_item( valor, llave );
			/**/
			/*Verificar Vacio*/
				if(
					this.Ultimo == null
				){
					this.Primero = this.Ultimo = nuevo_nodo;
				}
			/**/
			/*Llenar*/
				else{
					/**/
					/*Obtener Ultimo nodo agregado*/
						Lista_item? primer_nodo		= this.Primero;
					/**/
					/*Unir con nodo actual*/
						primer_nodo?.Siguiente		= nuevo_nodo;
					/**/
					/*Agregar a la pila*/
						this.Primero				= nuevo_nodo;
					/**/
				}
			/**/
			/*Sumar*/
				++this.Total;
			/**/
		}

		/*Finalizacion de registro; Iterar por el primer item*/
		/**
		 * Si se usa [lista.fin()] -> [cursor.siguiente()]
		*/
		public Lista_item? cursor(){
			return this.Ultimo;
		}

		/*Cantidad de items encontrados*/
		public int? total(){
			return this.Total;
		}
	}

	/*Item del nodo*/
	public class Lista_item{

		/*Concepto del nodo*/
		public string?			Llave		= null;
		public string?			Valor		= null;
		public Lista_item?		Siguiente	= null;

		/*Constructor*/
		public void agregar_item( string? valor = "", string? llave = "" ){

			/*Llave y Valor*/
			this.Llave		= llave;
			this.Valor		= valor;

			/*Iterador siguiente*/
			this.Siguiente	= null;
		}

		/*Mostrar llave actual*/
		public string? obtener_llave(){
			return this.Llave;
		}

		/*Mostrar valor actual*/
		public string? obtener_valor(){
			return this.Valor;
		}

		/*siguiente nodo*/
		public Lista_item? item_siguiente(){
			return this.Siguiente;
		}
	}
}