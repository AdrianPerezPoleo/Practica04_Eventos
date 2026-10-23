# Práctica 04. Eventos
- **Autor:** Adrián Pérez Poleo
- **Correo:** alu0101635224@ull.edu.es

## Índice
- [Ejercicio 01](#ejercicio-01)
- [Ejercicio 02](#ejercicio-02) 
- [Ejercicio 03](#ejercicio-03)
- [Ejercicio 04](#ejercicio-04)
- [Ejercicio 05](#ejercicio-05)
- [Ejercicio 06](#ejercicio-06)
- [Ejercicio 08](#ejercicio-08)
- [Ejercicio 09](#ejercicio-09)


## Introducción
En esta práctica se han utilizado delegados y eventos en Unity. Gracias a estas herramientas se ha podido desacoplar código, permitiendo que diferentes objetos y sistemas reaccionen a eventos concretos (como colisiones o recolecciones de objetos) sin necesidad de estar referenciados entre sí. A lo largo de los ejercicios se han construído mecánicas donde las respuestas a los eventos han sido cambios de color, movimientos, etc.

## Ejercicio 01
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio01_MovimientoCubo.cs](Assets/Scripts/Ejercicio01_MovimientoCubo.cs)
[Assets/Scripts/Ejercicio01_Notificador.cs](Assets/Scripts/Ejercicio01_Notificador.cs)
[Assets/Scripts/Ejercicio01_Tipo01.cs](Assets/Scripts/Ejercicio01_Tipo01.cs)
[Assets/Scripts/Ejercicio01_Tipo02.cs](Assets/Scripts/Ejercicio01_Tipo02.cs)

### Descripción
El primer ejercicio pide la creación de una escena inicial con 5 esferas rojas (tipo 1) y verdes (tipo 2), un cubo y un cilindro. El objetivo es crear una mecánica en la que cuando el cubo colisione con el cilindro, las esferas de tipo 1 persigan a un objetivo predefinido y las esferas de tipo 2 sigan al cilindro.

### Implementación
En primer lugar, se implementó el movimiento del jugador en el script `Ejercicio01_MovimientoCubo`, utilizando `FixedUpdate`, `MovePosition` y `MoveRotation` para desplazar el cubo según la entrada del usuario. Por otro lado, se configuró el cilindro con el script `Ejercicio01_Notificador`. Este script declara un delegado y un evento `OnFollow` que se dispara tras detectar una colisión con el jugador.

Finalmente, para que las esferas reaccionaran, los scripts `Ejercicio01_Tipo01` y `Ejercicio01_Tipo02` se suscriben al evento `OnFollow` en su función `Start`. Puesto que en un inicio se encuentran a la espera, al ser notificados cambian una variable booleana que habilita su movimiento.

### Ejecución
![](GIFs/Ejercicio01.gif)

## Ejercicio 02
Este ejercicio no tiene ficheros de código.

### Descripción
El objetivo de este ejercicio consiste en sustituir los objetos geométricos básicos de la escena anterior (esferas, cubo y cilindro) por modelos de humanoides descargados desde los enlaces proporcionados en el enunciado.

### Implementación
Este ejercicio no requiere de nuevos scripts. La implementación consistió en importar los *prefabs* de los humanoides al proyecto y agregarlos a la escena, sustituyendo visualmente a los primitivos geométricos. Se pudo comprobar la versatilidad del sistema de eventos, pues los nuevos modelos reaccionaron exactamente igual sin necesidad de tocar una sola línea de código.

### Ejecución
![](GIFs/Ejercicio02.gif)

## Ejercicio 03
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio03_EscudoTipo02.cs](Assets/Scripts/Ejercicio03_EscudoTipo02.cs)

[Assets/Scripts/Ejercicio03_MovimientoCubo.cs](Assets/Scripts/Ejercicio03_MovimientoCubo.cs)

[Assets/Scripts/Ejercicio03_Notificador.cs](Assets/Scripts/Ejercicio03_Notificador.cs)

[Assets/Scripts/Ejercicio03_Tipo01Escudo01.cs](Assets/Scripts/Ejercicio03_Tipo01Escudo01.cs)

[Assets/Scripts/Ejercicio03_Tipo01Escudo02.cs](Assets/Scripts/Ejercicio03_Tipo01Escudo02.cs)


### Descripción
Para esta fase, se adapta la escena incorporando distintos tipos de escudos (tipo 1 y tipo 2). Si el cubo choca con un humanoide de tipo 2, los humanoides del grupo 1 deben acercarse a un escudo. Si el cubo choca con un humanoide del grupo 1, estos se dirigen a los escudos del grupo 2; y si logran colisionar con ellos, los humanoides deben cambiar de color.

### Implementación
Para lograr estas resolver este problema, el script `Ejercicio03_Notificador` (asociado al jugador) se encargó de gestionar dos eventos distintos: `OnFollowFirst` y `OnFollowSecond`. Mediante `OnTriggerEnter`, el jugador detecta con qué tipo de humanoide ha chocado basándose en sus etiquetas y lanza el evento correspondiente.

Los humanoides cuentan con los scripts `Ejercicio03_Tipo01Escudo01` y `Ejercicio03_Tipo01Escudo02`, los cuales se suscriben a estos eventos y activan su persecución hacia los escudos asignados. Por otro lado, para realizar el cambio de color, se asoció el script `Ejercicio03_EscudoTipo02` a los escudos físicos. Al detectar la colisión de un objeto "Tipo 1", accede al componente Renderer de dicho objeto y sustituye el color de su material por un tono dorado.

### Ejecución
![](GIFs/Ejercicio03.gif)

## Ejercicio 04
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio04_Movimiento.cs](Assets/Scripts/Ejercicio04_Movimiento.cs)

[Assets/Scripts/Ejercicio04_Notifier.cs](Assets/Scripts/Ejercicio04_Notifier.cs)

[Assets/Scripts/Ejercicio04_Tipo01.cs](Assets/Scripts/Ejercicio04_Tipo01.cs)

[Assets/Scripts/Ejercicio04_Tipo02.cs](Assets/Scripts/Ejercicio04_Tipo02.cs)


### Descripción
En este ejercicio, cuando el cubo se aproxima a un objeto de referencia, los humanoides del grupo 1 deben teletransportarse hacia un escudo objetivo fijado de antemano. Al mismo tiempo, los humanoides del grupo 2 deben rotar para mirar hacia un objeto ubicado en la escena con ese propósito.

### Implementación
Para resolver este ejercicio se tuvo que crear una zona de detección (un cubo con *trigger* y transparente) y añadir al jugador el script `Ejercicio04_Notifier`. Este script aprovecha el *trigger* para lanzar el evento *OntargetApproached*.

La respuesta al evento se dividió en dos scripts. El script `Ejercicio04_Tipo01`, asignado al grupo 1, responde al evento moviendo su posición (`rb.MovePosition`) a la ubicación del escudo objetivo. Para evitar que todos los humanoides se solapen en el mismo punto exacto, se le sumó un vector aleatorio (`GenerateRandomVector`) al destino. Por su parte, el script `Ejercicio04_Tipo02`, asignado al grupo 2, fuerza su orientación mediante `rb.MoveRotation` combinada con `Quaternion.LookRotation`, logrando que fijen su vista en el edificio designado.

### Ejecución
![](GIFs/Ejercicio04.gif)

## Ejercicio 05
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio05_EscudoRecolectable.cs](Assets/Scripts/Ejercicio05_EscudoRecolectable.cs)

[Assets/Scripts/Ejercicio05_Movimiento.cs](Assets/Scripts/Ejercicio05_Movimiento.cs)

[Assets/Scripts/Ejercicio05_PointManager.cs](Assets/Scripts/Ejercicio05_PointManager.cs)

### Descripción
El objetivo de este ejercicio es implementar una mecánica de recolección de escudos que recompense al jugador actualizando su puntuación. Según el enunciado, los escudos de tipo 1 suman 5 puntos, mientras que los de tipo 2 suman 10 puntos. Esta puntuación debe ser registrada y mostrada a través de la consola de Unity.

### Implementación
En primer lugar, se crearon los objetos coleccionables en la escena, a los que se les añadió el script `Ejercicio05_EscudoRecolectable`. Este fichero declara un evento estático (`OnShieldCollected`) que envía un parámetro entero indicando la cantidad de puntos. Puesto que los escudos contaban con distintas configuraciones de físicas, la recolección se contempló tanto por `OnTriggerEnter` (para Tipo 1) como por `OnCollisionEnter` (para Tipo 2).

Por otro lado, se el jugador tuvo el script `Ejercicio05_PointManager`. Este componente se suscribe al evento estático de los escudos. Cada vez que se detecta una recolección, se acumulan los puntos recibidos en la variable local `totalPoints` y automáticamente se imprime un mensaje para mantener un registro del progreso durante la simulación.

### Ejecución
![](GIFs/Ejercicio05.gif)

## Ejercicio 06
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio06_PointView.cs](Assets/Scripts/Ejercicio06_PointView.cs)

### Descripción
Partiendo del sistema de recolección anterior, se solicita la creación de una interfaz de usuario (UI) que muestre visualmente en la pantalla la puntuación que va obteniendo el cubo en tiempo real.

### Implementación
Para la parte visual, se integró en la escena un objeto *Canvas* que contenía una etiqueta de texto generada con *TextMeshPro*. El script `Ejercicio06_PointView` recupera la referencia del componente de texto y del mánager de puntos del jugador. Para no actualizar la interfaz innecesariamente en cada frame (`Update`), el script se suscribe al mismo evento de recolección (`OnShieldCollected`). Así, solo cuando se recoge un escudo, el script solicita la puntuación actual al mánager y formatea la cadena de texto de la pantalla.

### Ejecución
![](GIFs/Ejercicio06.gif)

## Ejercicio 08
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio08_CoinCollector.cs](Assets/Scripts/Ejercicio08_CoinCollector.cs)

[Assets/Scripts/Ejercicio08_DirectionalLight.cs](Assets/Scripts/Ejercicio08_DirectionalLight.cs)

[Assets/Scripts/Ejercicio08_EndgameNotifier.cs](Assets/Scripts/Ejercicio08_EndgameNotifier.cs)

[Assets/Scripts/Ejercicio08_Enemigo.cs](Assets/Scripts/Ejercicio08_Enemigo.cs)

[Assets/Scripts/Ejercicio08_Limon.cs](Assets/Scripts/Ejercicio08_Limon.cs)

[Assets/Scripts/Ejercicio08_MonedaRecolectable.cs](Assets/Scripts/Ejercicio08_MonedaRecolectable.cs)

[Assets/Scripts/Ejercicio08_Movimiento.cs](Assets/Scripts/Ejercicio08_Movimiento.cs)

[Assets/Scripts/Ejercicio08_PlayerEndgame.cs](Assets/Scripts/Ejercicio08_PlayerEndgame.cs)

### Descripción
El ejercicio requiere el diseño y generación de una escena personalizada que incluya elementos acordes a un prototipo propio, implementando además algunas de las mecánicas basadas en eventos desarrolladas en los apartados anteriores.

### Implementación
Se construyó un minijuego integrando múltiples eventos que serán explicados a continuación. La recolección principal se hace mediante monedas (`Ejercicio08_MonedaRecolectable`), donde cada captura notifica al `Ejercicio08_CoinCollector`. Como efecto secundario para aumentar la dificultad, cada moneda recolectada ralentiza levemente al jugador.

Al mismo tiempo, los enemigos (`Ejercicio08_Enemigo`) se suscriben a la recolección de monedas para que, al recoger la primera, los enemigos "despierten" y comiencen a seguir al jugador. Para contrarrestalos, se coloca un objeto defensivo en la escena (un limón con `Ejercicio08_Limon`) que emite un evento de pausa temporal para que los enemigos dejen de perseguir al jugador.

Por último, se definió una condición de victoria en `Ejercicio08_EndgameNotifier`. Si el jugador supera los 50 puntos y entra en la zona final, se lanza el evento `OnEndgame`. Diversos componentes de la escena están suscritos a este fin de juego: la luz direccional del entorno (`Ejercicio08_DirectionalLight`) baja su intensidad para simular el anochecer, los enemigos se detienen permanentemente, y el jugador (`Ejercicio08_PlayerEndgame`) es teletransportado a la azotea de una de las casas.

### Ejecución
![](GIFs/Ejercicio08_01.gif)
![](GIFs/Ejercicio08_02.gif)

## Ejercicio 09
Los ficheros de código se encuentran en: 
[Assets/Scripts/Ejercicio09_EscudoTipo02.cs](Assets/Scripts/Ejercicio09_EscudoTipo02.cs)

[Assets/Scripts/Ejercicio09_MovimientoCubo.cs](Assets/Scripts/Ejercicio09_MovimientoCubo.cs)

[Assets/Scripts/Ejercicio09_Notificador.cs](Assets/Scripts/Ejercicio09_Notificador.cs)

[Assets/Scripts/Ejercicio09_Tipo01Escudo01.cs](Assets/Scripts/Ejercicio09_Tipo01Escudo01.cs)

[Assets/Scripts/Ejercicio09_Tipo01Escudo02.cs](Assets/Scripts/Ejercicio09_Tipo01Escudo02.cs)


### Descripción
Este ejercicio pide reimplementar la mecánica exacta descrita en el ejercicio 3, pero esta vez el cubo del jugador debe comportarse como un objeto físico movido por fuerzas dinámicas.

### Implementación
Para resolver este ejercicio, se modificó lo implementado en el ejercicio 3. El script `Ejercicio09_MovimientoCubo` dejó de usar `MovePosition` y `MoveRotation` para aplicar fuerzas mediante `rb.AddForce()`, delegando el desplazamiento al motor de físicas de Unity.

Debido a esto, el detector de impactos (`Ejercicio09_Notificador`) tuvo que ser adaptado. Se sustituyó el método `OnTriggerEnter` por `OnCollisionEnter`, para que el sistema evalúe colisiones y lance los eventos `OnFollowFirst` y `OnFollowSecond`. Las respuestas a los eventos siguieron la misma lógica de los scripts del ejercicio 3, viendo que los eventos permiten que se altere como es un objeto sin que el resto del sistema falle o requiera recodificarse.

### Ejecución
![](GIFs/Ejercicio09.gif)