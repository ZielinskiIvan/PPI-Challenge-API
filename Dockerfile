# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-windowsservercore-ltsc2019 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0-windowsservercore-ltsc2019 AS build
WORKDIR /src
COPY ["PPI Challenge API.csproj", "."]
RUN dotnet restore "./PPI Challenge API.csproj"
COPY . .

# Instalar sqlcmd
RUN powershell -Command \
    Invoke-WebRequest -Uri https://go.microsoft.com/fwlink/?linkid=2155310 -OutFile sqlcmd.msi; \
    Start-Process msiexec.exe -ArgumentList '/i', 'sqlcmd.msi', '/quiet', '/norestart' -NoNewWindow -Wait; \
    Remove-Item -Force sqlcmd.msi

# Agregar sqlcmd al PATH
RUN setx PATH "$env:PATH;C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn"

RUN dotnet build "./PPI Challenge API.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "./PPI Challenge API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (imagen de producción)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PPI Challenge API.dll"]
