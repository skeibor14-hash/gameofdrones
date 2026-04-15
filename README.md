<p align="center"><img src="https://avatars.githubusercontent.com/u/276023818?v=4" alt="Alex Logo"></p>

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

3.   `[Compilamos]` el proyecto entrando en su carpeta, ejecutamos un CMD con (permisos administrativos en caso de ser necesario) con `[CD]` en la carpeta actual ejecutando el siguiente código:
	 ```
	dotnet run
	 ```
4. Del comando anterior si obtenemos un anuncio que indica que el proyecto esta siendo ejecutado en el puerto deseado (`[5002]` por defecto y configurable) significa que poseemos ya un binario dentro de la carpeta `[bin/debug]`
5. Una ves compilado el proyecto, podemos utilizar el `[exe]` encontrado dentro de la carpeta `[bin]` mencionada anteriormente y el cual nos servirá para ejecutar la aplicación sin requerir compilar de nuevo.

---

> [!NOTE]
>
> - Se realizó el proyecto con una `[plantilla]` ensamblada manualmente por el desarrollador de este repositorio.
> - Se aplicó todos los conocimientos necesarios para que sea compatible con la mayor cantidad de `[versiones de ASP.NET]` y `[navegadores]`.
> - Se utilizó `[angular.js]` nivel cliente para realizar la movilidad y dinámica del sistema según lo solicitado por el evaluador.
> - Se construyó un archivo tipo `[env]` para poder configurar elementos dentro del sistema y evitar que estos sean `[HARD-CODE]`.

---

Version: 0.1.0
Fecha de lanzamiento: 15-abr-2026

---

### Por hacer

Para que esta versión cumpla con todos los elementos deseados para la versión final de evaluación se desea completar los siguientes puntos
*   Realizar modelos que puedan hacer solicitudes a la base de datos (La base de datos utilizada es un archivo `[SQLite]`).
*   Programar el sanitizador interno que evite ingresar caracteres especiales a la base de datos y pueda causar problemas futuros.
*   Programar el modelo base interno que se convetirá en la plantilla principal para los modelos.
*   Programar mecanismos que ayuden al navegador poseer cierto grado de seguridad y compatibilidad (Ejemplo: manejo de cache, manejo de sesión).
*   Programar el manejo de sesión de los datos de los jugadores actuales.
*   Programar la vista para la visual de ingresar jugador 1 y jugador 2.
*   Programar la vista para reanudar un juego en caso de ser abandonado.
*   Programar lógica interna para manejar cookies: La sesión del usuario con los jugadores actuales, el turno actual, puntaje, estado del juego, el usuario que le toca jugar actualmente y cualquier otro elemento que no desee perder al recargar la página.
*   Programar lógica interna para iniciar un juego.
*   Programar lógica interna para manejar los turnos.
*   Programar lógica interna para reaunidar un juego.
*   Programar lógica interna para abandonar un juego e iniciar uno nuevo.
*   Programar lógica interna para finalizar un juego y automáticamente poder configurar nuevas reglas.
*   Programar lógica interna para definifir cuando un jugador gana y cuando un jugador pierde.
*   Programar lógica interna para la definición de las variables `[ENV]` en un archivo que pueda modificar el usuario a futuro.
*   Programar lógica del cliente y del servidor para sanitizar datos a la hora de leer `[POST]` y guardar datos a `[DB]` .
*   Programar la vista para estadística interna.
*   Programar vista leader board que muestre los puntajes de los usuarios, cuanto han ganado, cuanto han perdido y cuantas partidas han abandonado.
*   Programar lógica interna de manejo de CACHE SQL para uso constante de DB SQlite.
*   ¿Posible mejora de la interfáz?.
	-   En caso de poseer tiempo extra, estudiar la posibilidad de realizar una interfaz amigable y agradable para el usuario con visuales modernas.