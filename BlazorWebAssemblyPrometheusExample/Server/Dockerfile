#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1234

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorWebAssemblyPrometheusExample/Server/BlazorWebAssemblyPrometheusExample.Server.csproj", "BlazorWebAssemblyPrometheusExample/Server/"]
COPY ["BlazorWebAssemblyPrometheusExample/Client/BlazorWebAssemblyPrometheusExample.Client.csproj", "BlazorWebAssemblyPrometheusExample/Client/"]
COPY ["BlazorWebAssemblyPrometheusExample/Shared/BlazorWebAssemblyPrometheusExample.Shared.csproj", "BlazorWebAssemblyPrometheusExample/Shared/"]
RUN dotnet restore "BlazorWebAssemblyPrometheusExample/Server/BlazorWebAssemblyPrometheusExample.Server.csproj"
COPY . .
WORKDIR "/src/BlazorWebAssemblyPrometheusExample/Server"
RUN dotnet build "BlazorWebAssemblyPrometheusExample.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorWebAssemblyPrometheusExample.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorWebAssemblyPrometheusExample.Server.dll"]