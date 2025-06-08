# Caps Quest

## Grupo Gama Alta

Caps Quest es un juego educativo diseñado para ayudar a estudiantes de cuarto grado a aprender el uso correcto de las letras mayúsculas en nombres propios (antropónimos) a través de ejercicios interactivos y divertidos.

---

## Descripción del Proyecto

Caps Quest presenta una aventura en la que un malvado mago ha lanzado un hechizo sobre el reino, haciendo que sus habitantes olviden las reglas gramaticales para el uso de las mayúsculas. El jugador debe completar diferentes tipos de ejercicios para romper el hechizo y restaurar el conocimiento.

---

## Características Principales

- Tres tipos de ejercicios: Verdadero y Falso, Selección Múltiple y Completar.
- Interacción con NPCs que activan paneles de ejercicios al colisionar.
- Control de movimiento 2D con joystick virtual o teclado.
- Sistema para mostrar texto de actividades dinámicamente desde archivos.
- Control de animaciones basado en el movimiento del jugador.
- Interfaz que oculta y muestra paneles según la actividad en curso.

---

## Estructura de Scripts

### NPC.cs

Controla la interacción con NPCs que activan los paneles de ejercicios y deshabilita el movimiento del jugador mientras se realiza una actividad.

### TextoActividadIndividual.cs

Carga y muestra el texto de las actividades desde archivos de texto ubicados en la carpeta Resources.

### Movimiento.cs

Gestiona el movimiento del personaje usando Rigidbody2D y entradas del joystick o teclado, además de controlar las animaciones.

### CambioIntro.cs

Se encarga de hacer el cambio de escena cronometrado despues que se muestra el logo de los desarrolladores.

### CambioOutro.cs

Igual que el anterior este se encarga de hacer el cambio de escena en la escena final del juego para que vuelva a empezar al Menu Principal.

### Salida.cs

Un script basico que permite salir de la ejecucion del juego presionando ESC en PC o el boton Atras en Android.

### SceneManager.cs

Esta clase se encarga de manejar los cambios de escenas que ocurre durante todo el trancurso del juego.

---

## Requisitos

- Unity (versión compatible con tu proyecto)
- Paquete de joystick virtual de Fenerax Studios (o equivalente)
- Carpeta `Resources` con los archivos de texto para las actividades
- Paquete Cinemachine de la Assets Store de Unity

---

## Instrucciones para Ejecutar

1. Abre el proyecto en Unity.
2. Asegúrate de que los scripts estén asignados a los GameObjects correspondientes.
3. Configura los paneles de ejercicios en los NPCs.
4. Ejecuta la escena principal y prueba los movimientos y ejercicios.
5. Usa el joystick o teclado para moverte y colisiona con los NPCs para activar los ejercicios.

---

## Autores

- Grupo Gama Alta

---

## Contacto

Para soporte o sugerencias, contactar con el equipo de desarrollo del Grupo Gama Alta.
Correo: jaron.aviles@gmail.com
