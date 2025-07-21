# Sistema de Gestión de Ventas

Este proyecto es una aplicación de escritorio desarrollada en C# (.NET Framework 4.7.2) para la gestión de ventas, compras, productos, clientes, proveedores y reportes. Incluye funcionalidades de administración, reportes y exportación a Excel.

## Requisitos

- Windows 7/8/10/11
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- SQL Server (Express o superior)
- Permisos de administrador para instalar dependencias si es necesario

## Instalación

1. **Clona o descarga este repositorio.**
2. **Ejecuta el archivo SQL**  
   - Ubicado en la raíz o carpeta `database` del proyecto (por ejemplo: `DB_SISTEMA_VENTAS.sql`).
   - Ábrelo con SQL Server Management Studio y ejecútalo para crear la base de datos y las tablas necesarias.

3. **Configura la cadena de conexión**  
   - Abre el archivo `App.config` en el proyecto `CapaPresentacion`.
   - Modifica el valor de `Data Source` y otros parámetros si tu instancia de SQL Server es diferente.

4. **Compila el proyecto en Visual Studio 2022**  
- Abre la solución `.sln`.
- Restaura los paquetes NuGet si es necesario.
- Compila en modo Release o Debug.

5. **Ejecuta la aplicación**  
- El ejecutable estará en la carpeta `bin\Release` o `bin\Debug` de `CapaPresentacion`.

## Publicación e Instalación

Si deseas distribuir la aplicación a otros equipos:

- Usa la opción de **Publicar** en Visual Studio (ClickOnce o instalador MSI).
- Asegúrate de incluir el requisito previo de **.NET Framework 4.7.2** en el instalador.
- Si usas ClickOnce y quieres que el instalador incluya el framework, sigue las instrucciones de Microsoft para agregar los prerequisitos.

## Funcionalidades principales

- Gestión de productos, categorías, clientes y proveedores.
- Registro y consulta de ventas y compras.
- Reportes filtrados por fecha y exportación a Excel.
- Control de stock y usuarios con roles y permisos.
- Interfaz moderna y adaptable a pantalla completa.

## Notas

- Si no existen categorías, deberás registrar al menos una antes de agregar productos.
- El sistema requiere que la base de datos esté correctamente creada y accesible.
- Para exportar a Excel, se utiliza la librería [ClosedXML](https://github.com/ClosedXML/ClosedXML).

**Recuerda:**  
Antes de ejecutar la aplicación por primera vez, asegúrate de que la base de datos esté creada y la cadena de conexión sea correcta.
