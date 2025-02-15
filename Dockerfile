# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PPI Challenge API.csproj", "."]
RUN dotnet restore "./PPI Challenge API.csproj"
COPY . .

RUN dotnet build "./PPI Challenge API.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "./PPI Challenge API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (imagen de producción)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PPI Challenge API.dll"]
