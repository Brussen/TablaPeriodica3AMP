# TablaPeriodica3AMP
Tabla periódica de los elementos, con información detallada, buscador y un juego de cuestionario de tres dificultades y una tabla de clasificación de la puntiación del mismo.
(PRIMERA VERSIÓN; FALTA TODO lmao)

# COMO FUNCIONA, PASO POR PASO:
**1.- IdleMsg;**
    IdleMsg es una variable que almacena el texto a mostrar mientras el buscador está en desuso. Puedes ingresar en el cualquier string, o simplemenete escribir "" para no mostrar nada.

**2.- Ciclo For Each para obtener los controles.**
    Primero, se guarda lo escrito en el buscador en la variable "text", que se utiliza después.
    El ciclo For Each es similar a un ciclo For regular, solo que éste busca itera en elementos dentro de un Array (lista o contenedor de valores). El Array en el que busca es 
    " Me.Controls "; Me se refiere a si mismo (el form) y .Controls especifica la busqueda a solo los controles dentro del form.
    La Instrucción TypeOf se usa para comparar el tipo de objeto que es algo, en este caso, se buscan controles de tipo Button.

**3.- Limpiado y normalizado de la búsqueda.**
    La Función .Normalize transforma un texto en distintas formas, la forma "D" (FormD) separa a los caracteres de manera modular ( Ej.- Á -> A + ´ ).
    Esto es utilizado para segmentar el texto. La Clase de objeto StringBuilder crea un String editable de una longitud especificada. Se utiliza el largo del texto actual.
    Se inicializa otro ciclo, un ciclo For regular que itera en los caracteres que componen al texto. En Visual Basic, los Strings se leen como Arrays de Caracteres, por lo que se 
    puede seleccionar una letra en específico de la misma forma que seleccionarías un elemento en un Array. Utilizando ésto, se itera en todos los caracteres que componen al 
    texto descompuesto; Se guarda el caracter actual en una variable temporal llamada "c". Luego, se compara que la categoría del Unicode de "c" No sea igual (<>) a la categoría
    "NonSpacingMark", en la cual se almacenan todas las marcas de acento (como ´ ó ^ en las letras á y â). Si el caracter no pertenece a esta categoría, se añade mediante la
    Función .Append() al StringBuilder, utilizando también la Funcion .ToLowerInvariant para pasar el caracter a su versión en minúscula.

**4.- Comparado del texto normalizado con los elementos.**
    Se Compara el texto normalizado con los nombres y el texto de todos los elementos encontrados. Se Utiliza la Función .ToLower para convertir el nombre o texto del elemento en
    minúsculas y luego se corrobora si el texto normalizado se encuentra dentro del nombre o texto (Ej.- "hidró" se encuentra dentro de "hidrógeno"). Si la comparación resulta 
    verdadera, el boton iterado se muestra (Activa) y, de lo contrario, se esconde (Desactiva).
    Finalmente, si el cuadro de búsqueda está vacio, o está mostrando el mensaje de inactividad, muestra todos los elementos.

**5.- Añadido nuevos elementos.**
    En el diseñador, agrega una nuevo Button. En la propiedad de Name ingresa el nombre del elemento a añadir, y en la propiedad Text, inserta el símbolo. El cuadro de búsqueda
    lo considerará automaticamente gracias al ciclo For Each.

**6.- Eventos Miscelaneos.**
    Los Eventos search_Enter y search_Exit son simple calidad de vida, se utilizan para el funcionamiento de IdleMsg. search_Enter limpia la caja de búsqueda para que el mensaje no
    interfiera con lo que vaya a escribi el usuario, y search_Exit lo regresa cuando se deja de utilizar el cuadro de búsqueda.

**7.- Problemas a considerar y cambios a futuro.**
    Primero, es importante resaltar que el cuadro de búsqueda modifica TODOS los botones dentro del formulario. Para contrarrestar esto, tengo pensado utilizar la propieda de etiquetas
    dentro de los botones de los elementos, o de lo contrario, añadir algún prefijo al nombre de los elementos (actualmente utilizan "btn", pero no sirve de mucho.)
    El Evento search_Exit debe ser reinventado, pues actualmente puede molestar al usuario si deselecciona el cuadro de búsqueda por accidente.
