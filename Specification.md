# Especificación


## Asociaciones y eventos

La aplicación permite a los asociaciones registrarse. Cuando un usuario se registra, indica el nombre comercial, el nombre completo de la misma (si procede), el logo si lo hubiera, y su ubicación. Al mismo tiempo que se crea el perfil como asociación, se puede crear un evento, del cual el usuario que se registró será nombrado organizador. 

Para que el registro se formalice, y se pueda iniciar sesión, el usuario debe confirmar su correo electrónico, por medio de un email mandado por la aplicación.

El organizador puede crear otros usuarios (hasta 5), que serán organizadores junto a él en ese evento. Los organizadores serán inscritos como participantes en el momento de ser creados.

Para que un evento se cree, debe tener un nombre, una fecha de inicio, de fin, y de comienzo de inscripción. El evento será privado tras crearlo (solo pueden visualizarlo los organizadores), pero lo pueden hacer público. Sin embargo, aunque sea público, la inscripción no será posible hasta que llegue la fecha de inscripción.

Cada evento puede celebrarse en varios lugares distintos. El primer lugar es obligatorio, y se tomará como el lugar principal, o lugar de inscripción. Requiere de un nombre, una descripción opcional, y unas coordenadas. Además del lugar principal, se pueden agregar lugares secundarios. Si el lugar secundario está en las mismas o casi iguales coordenadas que otro de los lugares, se puede indicar al darlo de alta.

### Inscripción en el evento

A partir de la fecha habilitada, cualquier persona podrá inscribirse en el evento, solo necesitará un correo electrónico. Los organizadores pueden hacer que otros campos, como el nombre, los apellidos, dni o teléfono sean obligatorios.

Tanto los organizadores como los asistentes se consideran participantes del evento.

Una vez que la persona se inscribe, el inscrito recibirá en su correo un email, para que haga click y confirme su petición de inscripción. Los organizadores dispondrán una lista con las inscripciones, que deberán confirmar manualmente. Solo podrán confirmar las peticiones de los inscritos que confirmaron el email de confirmación.

Una vez que la organización confirme la petición, el participante se considerará inscrito.

## Gestión de la asociación

La aplicación dispone de una lista de juegos de mesa con datos maestros. Esta lista se tomará preferiblemente de la api de la bgg. 
Los usuarios registrados pueden gestionar su asociación, y añadir juegos de esa lista, para indicar que es propietaria de esos juegos y cuenta con ellos en su inventario.

## Ludoteca

Los organizadores pueden seleccionar juegos de los que su asociación es propietaria, para indicar que son parte de la ludoteca del evento. Otras asociaciones pueden compartir el número de juegos que decidan, para que sean añadidos a la ludoteca del evento.


## Actividades

Los organizadores pueden dar de alta actividades para el evento. Los asistentes pueden hacer peticiones para organizar actividades, que podrán ser aprobadas por los organizadores.

## El evento

Durante el evento, cualquier participante puede coger un juego de la ludoteca. Para ello, hará lo siguiente:
- En la lista de juegos disponibles, filtrará hasta encontrar el que necesite. Una vez escogido, estando autenticado, lo solicita.
Si el juego no está disponible, no se podrá solicitar. Si el participante tiene otro juego en prestamo, tampoco. Si ha solicitado otro juego, la anterior solicitud se eliminará, y prevalecerá la última.
- Pedirá a un organizador que acepte la solicitud. El organizador podrá buscar en la lista de solicitudes que podrá filtrar por nombre de juego o por id de participante, y podrá aprobar la solicitud.
- Para los casos en los que el participante no tenga acceso a internet para realizar la solicitud, un organizador puede cursar la solictud y dar por aceptado el prestamo directamente, solo necesitará el número de inscrito y el juego.

