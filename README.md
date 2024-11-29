Prueba Tecnica Daniel Flores.

Este repositorio este compuesto por dos proyectos, un backend con NetCore 8 y un frontend con React. 

Instrucciones para levantar el proyecto

Base de datos:
  - El backend está configurado para conectarse a una base de datos PostgreSQL online.
  - No necesitas configurar nada adicional para que la API se conecte automáticamente al levantarla.
  - Nota: Si quieres usar otra base de datos, modifica la cadena de conexión en el archivo appsettings.Development.json del backend. Luego sigue los pasos adicionales indicados en el backend para actualizar la base de datos.

Backend (API en .NET Core 8):
  1. Ingresa al directorio del backend
  2. Restaura las dependencias:
     dotnet restore
  3. Levanta la API:
     dotnet run
  4. (Opcional) Si cambias la base de datos
     -  Instala la herramienta de Entity Framework: "dotnet tool install --global dotnet-ef"
     -  Aplica las migraciones: "dotnet ef database update"
     
Frontend (Aplicación en React):
  1. Ingresa al directorio del frontend
  2. Instala las dependencias:
     npm install
  3. Levanta la aplicación:
    npm run dev
  4. Abre el sitio web en tu navegador en: http://localhost:5173/

Ya una vez ingreses en el sitio en la parte superior en el header, ingresa a la opcion de "Usuarios" y luego la de "Crear Usuario", completa la infomacion y guarda. 
regresa al home e inicia sesion, con el correo y contraseña antes creada. esto permitira almacenar tus preferencias del sitio.
