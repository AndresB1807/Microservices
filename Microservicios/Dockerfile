#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservicios/Microservicios.csproj", "Microservicios/"]
RUN dotnet restore "Microservicios/Microservicios.csproj"
COPY . .
WORKDIR "/src/Microservicios"
RUN dotnet build "Microservicios.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservicios.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservicios.dll"]