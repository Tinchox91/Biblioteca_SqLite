# Biblioteca_SqLite
# Biblioteca DB

## Descripción

**Biblioteca DB** es una aplicación de consola desarrollada en C# (.NET 8) que permite gestionar una biblioteca digital. Ofrece funcionalidades para administrar libros, usuarios y préstamos, facilitando el registro, consulta, actualización y eliminación de información de manera sencilla e interactiva.

## Características

- **Gestión de Libros:**  
  - Agregar, eliminar, actualizar y buscar libros por autor o ISBN.
  - Listar todos los libros disponibles.

- **Gestión de Usuarios:**  
  - Registrar nuevos usuarios.
  - Consultar, actualizar y eliminar usuarios.
  - Buscar usuarios por nombre o correo.

- **Gestión de Préstamos:**  
  - Registrar nuevos préstamos de libros a usuarios.
  - Consultar, actualizar y eliminar préstamos.
  - Buscar préstamos por usuario o libro.

## Instalación

1. Clona el repositorio:
   2. Abre la solución en Visual Studio.
3. Restaura los paquetes NuGet necesarios.
4. Compila la solución.

## Uso

1. Ejecuta la aplicación desde Visual Studio (__F5__ o __Ctrl+F5__).
2. Navega por el menú principal usando el teclado:
- Selecciona la opción deseada (Libros, Usuarios, Préstamos o Salir).
- Sigue las instrucciones en pantalla para cada operación.

## Estructura del Proyecto

- **Controllers:** Lógica de negocio para cada entidad.
- **Views:** Interfaz de usuario en consola.
- **Contexto:** Configuración y acceso a la base de datos.
- **Models:** Definición de las entidades (Libro, Usuario, Prestamo).

## Requisitos

- .NET 8 SDK
- Visual Studio 2022 o superior

## Notas

- La base de datos se crea automáticamente en la carpeta `Data` al ejecutar la aplicación.
- El proyecto utiliza Entity Framework Core con SQLite.

---

Desarrollado para fines educativos.
