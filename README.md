# Esta es una aplicación de consola en C#

### Función
Selecciona dos personas aleatoriamente, la primera persona será el **desarrollador** y la segunda persona será el **facilitador**. El facilitador debe tener un problema/reto para el desarrollador. El desarrollador programará en vivo el problema/reto del facilitador.

### Reglas de la 'Console App'
* Las personas seleccionadas no se pueden repetir mientras el programa esté en ejecución.
* Debe permitir decidir cuándo deseas que la ejecución del programa termine.

### Cosas interesantes que hace la app
* Animaciones por fotogramas.
* Permite al desarrollador crear y personalizar su propia carpeta.
* Permite al facilitador establecer reglas: límite de líneas para programar (opcional), límite de intentos (opcional) y un límite de tiempo (requerido).
* Abre el Reloj, selecciona el cronómetro automáticamente y dependiendo del límite de tiempo establecido por el facilitador, comienza la cuenta regresiva (esto se hace a través de los servicios de Windows y el manejo de teclas por PowerShell).
* Permite al desarrollador programar desde la consola. En caso de que el desarrollador termine el programa antes del tiempo y las líneas establecidas por el facilitador, puede avisarle al programa que terminó con el siguiente comando: **//Ok.**
* Guarda los datos detalladamente en un archivo JSON.
* Establece y actuliza los datos en un Excel.

**Nota:** para ver los datos en Excel necesitas una clave. Es la suma de 1601 de los valores/caracteres numéricos del ASCII. 

### Requisitos de funcionamiento
* Sistema Windows.
* Reloj de Windows actulizado.
* Ejecutar el programa en PowerShell.
* El Reloj debe tener los 'Timer' creados antes de ejecutar el programa. Los Timer son: 01:00, 03:00 y 05:00 (Todo esto en minutos).
* Tenet .NET 7.0