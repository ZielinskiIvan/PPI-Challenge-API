# PPI Challenge API

*Docker*

1- Para ejecutar el proyecto con docker debemos tener docker desktop instalado: 
https://www.docker.com/

*NOTA* Ejecutar "wsl --update" despues de instalar nos puede ahorrar errores
*NOTA* Recomiendo tener el docker desktop apuntando a Linux containers

2- Luego para obtener las imagenes que necesitamos debemos ejecutar en el CMD de nuesto equipo estos comandos

docker pull ivanzielinski/mi-imagen-sqlserver
docker pull ivanzielinski/ppi_entregable

3- Para este paso podemos obtener y usar el repositorio de git con https://github.com/ZielinskiIvan/PPI-Challenge-API.git O BIEN van a tener un zip con el proyecto
llamado : PPI-Challenge-API-master

4- abriremos el cmd nuevamente

5- Nos dirijiremos con el comando cd /Rutadenuestroproyecto/

*Nota* La ruta de nuestro proyecto a la que me refiero debe contener el archivo "dockerfile" y "docker-compose.yml"

6- Ejecutaremos a continuacion el comando

docker compose up -d

7- Si no tiro ningun error, deberias tener en tu docker desktop la imagen montada

8- Para ver si el proyect ejecuta podemos ponen en el navegador http://localhost:8080/swagger/index.html y el proyecto estará abierto en swagger

*Ejacutar localmente*

1- descargar el proyecto de git

2- Tendremos que cambiar nuestro app.settings.Development *ATENCION* *SOLO CAMBIAR EL DEVELOPMENT, NUNCA CAMBIEN EL APPSETTINGS.JSON* 
y apuntar a algun endpoint valido para correr en sql server por ejemplo

3- Si no tenemos base de datos en sql server, en la carpeta de nuestro proyecto debemos ejectuar:

dotnet ef database update

Esto nos creara una base de datos con la logica del proyecto y con inserts hechos. (Para poder usar debe leer el manual PPI_Challenge_Api_casos_de_uso)

*NOTA* el proyecto esta hecho en NET 9, deberan descargarse el runtime y sus caracteristicas

*Paquetes utilizados(No necesarios ejecutar pero pueden de ser de ayuda)*

dotnet add package AutoMapper
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package FluentValidation.AspNetCore


Gracias por leer si tienen algun problema de version o cualquier cosa que pueda ayuda contactar a ivanezielinski@gmail.com