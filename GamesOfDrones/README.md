<p align="center"><img src="https://massgrave.dev/img/logo_small.png" alt="MAS Logo"></p>

<h1 align="center">Games of Drones</h1>

<p align="center">Prueba técnica de una aplicación realizada en ASP.NET (Versión v10.0.202) y Angular (Versión cliente v1.8.2)</p>

<hr>

## Descripción Técnica

### ASP.NET (Versión v10.0.002)

1. Para `[instalar]` esta versión se requiere ejecutar el siguiente link que representa la versión utilizada por este proyecto:
	*   [**dotnet-sdk-10.0.202-win-x64.exe**](https://builds.dotnet.microsoft.com/dotnet/Sdk/10.0.202/dotnet-sdk-10.0.202-win-x64.exe) (DOTNET SDK v10.0.202)

2. Procedemos a ejecutar el instalador y una ves finalizado verificas que la version correcta esta instalada usando el siguiente comando:
	 ```
	dotnet --version
	 ```

3. Del comando anterior si obtenemos la versión `[10.0.202]` signficara que poseemos ASP.NET instalado de forma correcta.

---

### Compilación del proyecto

1.   Descargamos la versión actual de este proyecto realizando click en este link:
	*   [**Repositorio actual del proyecto**](https://github.com/[usuario]/[proyecto]/archive/refs/heads/master.zip) (Repositorio ZIP actual del proyecto)

2.   Descomprimimos el `[ZIP]` anterior obtenido de este proyecto.

2.1  (Opcional:) Verificamos que `[SQLIte]` este instalado en nuestos paquetes de `[dotnet]` esto solo para verificar que tenemos todo al:
	```
	dotnet add package Microsoft.Data.Sqlite --version 10.0.6
	dotnet add package SQLitePCLRaw.bundle_e_sqlite3 --version 2.1.11
	dotnet add package SQLitePCLRaw.core --version 2.1.11
	```

4.   `[Compilamos]` el proyecto entrando en su carpeta, ejecutamos un CMD con (permisos administrativos en caso de ser necesario) con `[CD]` en la carpeta actual ejecutando el siguiente código:
	```
	dotnet run
	```

5. Del comando anterior si obtenemos un anuncio que indica que el proyecto esta siendo ejecutado en el puerto deseado (`[5002]` por defecto y configurable) significa que poseemos ya un binario dentro de la carpeta `[bin/debug]`

5.1 En caso de presentar error porque el puerto `[5002]` puede estar BINDED, el sistema automáticamente creará un archivo env.txt el cual podrás editar el puerto.
	*  Dicho archivo solo estará disponible despues de la primera ejecución del programa, sease via `[dotnet run]` o ejecutando los binarios de `[bin/debug/net10.0]`

6. Una ves compilado el proyecto, podemos utilizar el `[exe]` encontrado dentro de la carpeta `[bin/debug/net10.0]` mencionada anteriormente y el cual nos servirá para ejecutar la aplicación sin requerir compilar de nuevo.


---

> [!NOTE]
>
> - LA APLICACIÓN NO REQUIERE MIGRACIÓN: El sistema creará la base de datos según lo configurado en el archivo env.txt y las tablas que requiera el sistema según su uso
> - Se realizó el proyecto con una `[plantilla]` ensamblada manualmente por el desarrollador de este repositorio.
> - Se aplicó todos los conocimientos necesarios para que sea compatible con la mayor cantidad de `[versiones de ASP.NET]` y `[navegadores]`.
> - Se utilizó `[angular.js]` nivel cliente para realizar la movilidad y dinámica del sistema según lo solicitado por el evaluador.
> - Se construyó un archivo tipo `[env]` para poder configurar elementos dentro del sistema y evitar que estos sean `[HARD-CODE]`.
> - En caso que se necesite mayor cantidad de personalización revisar la carpeta `[archivos_locales]` y el archivo `[env.txt]`. Archivos locales permitirá editar el HTML, imagenes y otros objetos. El ENV permitirá editar lógica interna.

---

Version: 0.5.0
Fecha de actualización readmen: 17-abr-2026
Fecha de lanzamiento: 15-abr-2026

---

### Por hacer

Para que esta versión cumpla con todos los elementos deseados para la versión final de evaluación se desea completar los siguientes puntos
*   Realizar modelos que puedan hacer solicitudes a la base de datos (La base de datos utilizada es un archivo `[SQLite]`). [Finalizado]
*   Programar el sanitizador interno que evite ingresar caracteres especiales a la base de datos y pueda causar problemas futuros. [Finalizado]
*   Programar el modelo base interno que se convetirá en la plantilla principal para los modelos. [Parcial, 1 modelo completo, faltan el resto]
*   Programar mecanismos que ayuden al navegador poseer cierto grado de seguridad y compatibilidad (Ejemplo: manejo de cache, manejo de sesión). [Parcial, archivos funcionando, sesió no funcional]
*   Programar el manejo de sesión de los datos de los jugadores actuales. [No Disponible]
*   Programar la vista para la visual de ingresar jugador 1 y jugador 2. [Parcial, no posee funcionalidad]
*   Programar la vista para reanudar un juego en caso de ser abandonado. [No Disponible]
*   Programar lógica interna para manejar cookies: La sesión del usuario con los jugadores actuales, el turno actual, puntaje, estado del juego, el usuario que le toca jugar actualmente y cualquier otro elemento que no desee perder al recargar la página. [No Disponible]
*   Programar lógica interna para iniciar un juego. [No Disponible]
*   Programar lógica interna para manejar los turnos. [No Disponible]
*   Programar lógica interna para reaunidar un juego. [No Disponible]
*   Programar lógica interna para abandonar un juego e iniciar uno nuevo. [No Disponible]
*   Programar lógica interna para finalizar un juego y automáticamente poder configurar nuevas reglas. [No Disponible]
*   Programar lógica interna para definifir cuando un jugador gana y cuando un jugador pierde. [No Disponible]
*   Programar lógica interna para la definición de las variables `[ENV]` en un archivo que pueda modificar el usuario a futuro. [Completo]
*   Programar lógica del cliente y del servidor para sanitizar datos a la hora de leer `[POST]` y guardar datos a `[DB]`. [Completo]
*   Programar la vista para estadística interna. [Completo]
*   Programar vista leader board que muestre los puntajes de los usuarios, cuanto han ganado, cuanto han perdido y cuantas partidas han abandonado. [No disponible]
*   Programar lógica interna de manejo de CACHE SQL para uso constante de DB SQlite. [Completo]
*   ¿Posible mejora de la interfáz?. [Parcial, se posee una interfaz, lógica de archivos CSS no funcional]
	-   En caso de poseer tiempo extra, estudiar la posibilidad de realizar una interfaz amigable y agradable para el usuario con visuales modernas. [Parcial, posee visual para celular]