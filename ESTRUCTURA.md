<h1 align="center">Estructura de proyecto</h1>

<p align="center">Este archivo complementa la estructura de carpetas y archivos asi como la funcionalidad de las carpetas y sus contenidos</p>

<hr>

1. ./controladores
	*   Carpeta que mantiene la lógica de cada solicitud del sistema, maneja la URL, ruta y lógica de un grupo de solicitudes en especifico.

2. ./modelos
	*   Carpeta que contiene la lógica de cada tabla de la base de datos `[SQLite]` incluida.
	*   Dichos archivos internos actuan como intermediarios para ingresar y obtener valores de la base de datos.
	*   Utilizan un `[modelo base]` incluido en el archivo en la carpeta `_sistema_`.

3. ./vistas
	*   Contiene la interfáz gráfica del usuario, el cual se comprende de: HTML, CSS y JS (Angular).

4. ./framentos
	*   Contienen una estructura parcial el cual se integra con los `[componentes]` del sistema.
	*   Permiten el envio de `[componentes]` parciales via `[GET HTTPS]`.

5. ./componentes
	*   Son fragmentos que utilizamos constantemente en las vistas y podemos reciclar entre fragmentos y llarmalos sin requerir reconstruir la interfaz.
	*   Permiten mantener una interfaz estandar.

6. ./Properties
	*   Es una carpeta utilizada por `[Visual Code]` para poder ejecutar el proyecto en su consola interna.

7. ./`[_sistema_]`
	*   Archivos de lógica que se reutilizarán durante todo el sistema como sanitizadores, código núcleo, manejo de sesiónes o (en caso de necesitar) manejo de usuarios y roles.

8. ./Program.cs
	*   El inxed principal que compila toda la lógica incial del sistema.

9. ./rutas.cs
	*   El archivo que maneja la enrutación del sistema.