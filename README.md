# Sistema de Control de Citas Médicas

Este proyecto es una aplicación web en ASP.NET Core MVC que funciona como cliente para una API web creada con ASP.NET Core 8 usando el enfoque Code First con Entity Framework Core. El sistema permite gestionar pacientes, médicos, citas y clínicas.

## Requisitos

- Visual Studio 2022
- .NET 8.0 SDK
- SQL Server

## Configuración del Proyecto

### 1. Clonar el Repositorio

Clona este repositorio en tu máquina local utilizando el siguiente comando:


git clone https://github.com/tu_usuario/SistemaControlCitasMedicasMVC.git

### 2. Configurar la Cadena de Conexión
Abre el archivo appsettings.json y configura la URL base de la API:
{
  "ApiUrl": "https://localhost:7022/api",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

### 3. Restaurar Paquetes NuGet
Restaura los paquetes NuGet necesarios para el proyecto:

dotnet restore

### 4. Ejecutar la API
Asegúrate de que la API Web_Api_Code-first esté en ejecución. Puedes clonar y configurar la API siguiendo las instrucciones en su propio repositorio. Una vez configurada, ejecuta la API desde Visual Studio asegurándote de que esté corriendo en https://localhost:7022.

### 5. Ejecutar la Aplicación MVC
Ejecuta la aplicación MVC desde Visual Studio (Ctrl + F5).

La aplicación estará disponible en https://localhost:7265 o http://localhost:5258.


```bash