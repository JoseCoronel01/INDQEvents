# INDQEvents
Examen técnico backend

Proyecto APIEventos archivo appsettings.json modificar la cadena de conexion a la base de datos. 

Proyecto UI interfaz del usuario archivo web.config appSettings modificar el value de la ruta que conecta a la api una vez en ejecucion y la 
otra variable images el value donde se guardan las imagenes esa no modificarla. 

En la raíz del proyecto archivo de Script de la base de datos con la estrucutara de tablas y la información de prueba. 

Tecnología utilizada:

Visual Studio 2019 community IDE para el desarrollo.
Sql Server 2019 v18.6 Express Edition 
El proyecto de ApiEventos con NETCORE 3.1 
El proyecto de ModeloClases Biblioteca de clases o (PCL) .NetStandard 
El Proyecto de UI interfaz ASP.Net WebForms .NetFramework 4.6.1

Alcance
La API deberá permitir:
• De forma pública:
  o Registrar usuarios. OK
  o Una vez registrado, iniciar sesión. OK
  o Consultar imagenes guardadas. (Solo el metodo en la api)
• Para usuario con sesión: falto usar el token que se genera para validar el error 401.
  o Mostrar un listado con los últimos eventos. OK
  o Permitir confirmar asistencia. 
  o Permitir cancelar asistencia. 
  o Subir imágenes. OK (al registrar un evento)
  o Registrar nuevos eventos. OK
  o Búsqueda de eventos con los siguientes filtros: (Solo el metodo en la api)
    ▪ Por localización 
    ▪ Por título del evento 


En la raíz del proyecto dejo los instaladores para probar la aplicacion. 
