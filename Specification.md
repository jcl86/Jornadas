# Especificación

La aplicación permite registrarse. Un usuario registrado puede crear un evento, del cual será nombrado automáticamente organizador. El organizador puede crear otros usuarios (hasta 5), que serán organizadores junto a él en ese evento.

Para que un evento se cree, debe tener un nombre, una fecha de inicio, de fin, y de comienzo de inscripción. El evento será privado tras crearlo (solo pueden visualizarlo los organizadores), pero lo pueden hacer público. Sin embargo, aunque sea público, la inscripción no será posible hasta que la fecha de inscripción haya pasado.

A partir de la fecha habilitada, cualquier persona podrá inscribirse en el evento, solo necesitará un correo electrónico. Los organizadores pueden hacer que otros campos, como el nombre, los apellidos, dni o teléfono sean obligatorios.

Tanto los organizadores como los asistentes se consideran participantes del evento.

## Ludoteca

La aplicación dispone de una lista de juegos de mesa con datos maestros. Esta lista se tomará preferiblemente de la api de la bgg. Los organizadores pueden seleccionar juegos de esta lista para que sean parte de la ludoteca del evento.

## Actividades
Los organizadores pueden dar de alta actividades para el evento. Los asistentes pueden hacer peticiones para organizar actividades, que podrán ser aprobadas por los organizadores.

## El evento

Durante el evento, cualquier participante puede coger un juego de la ludoteca. Para ello, hará lo siguiente:
- En la lista de juegos disponibles, filtrará hasta encontrar el que necesite. Una vez escogido, estando autenticado, lo solicita.
Si el juego no está disponible, no se podrá solicitar. Si el participante tiene otro juego en prestamo, tampoco. Si ha solicitado otro juego, la anterior solicitud se eliminará, y prevalecerá la última.
- Pedirá a un organizador que acepte la solicitud. El organizador podrá buscar en la lista de solicitudes que podrá filtrar por nombre de juego o por id de participante, y podrá aprobar la solicitud.
- Para los casos en los que el participante no tenga acceso a internet para realizar la solicitud, un organizador puede cursar la solictud y dar por aceptado el prestamo directamente, solo necesitará el número de inscrito y el juego.

