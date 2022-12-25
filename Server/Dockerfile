#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/BlazorWebAssemblyPrometheus.Server.csproj", "Server/"]
COPY ["Client/BlazorWebAssemblyPrometheus.Client.csproj", "Client/"]
COPY ["Shared/BlazorWebAssemblyPrometheus.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/BlazorWebAssemblyPrometheus.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "BlazorWebAssemblyPrometheus.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorWebAssemblyPrometheus.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorWebAssemblyPrometheus.Server.dll"]