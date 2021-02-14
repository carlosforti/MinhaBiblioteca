#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MinhaBiblioteca.Api/MinhaBiblioteca.Api.csproj", "MinhaBiblioteca.Api/"]
RUN dotnet restore "MinhaBiblioteca.Api/MinhaBiblioteca.Api.csproj"
COPY . .
WORKDIR "/src/MinhaBiblioteca.Api"
RUN dotnet build "MinhaBiblioteca.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinhaBiblioteca.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinhaBiblioteca.Api.dll"]