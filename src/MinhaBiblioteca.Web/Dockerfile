#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MinhaBiblioteca.Web/MinhaBiblioteca.Web.csproj", "MinhaBiblioteca.Web/"]
RUN dotnet restore "MinhaBiblioteca.Web/MinhaBiblioteca.Web.csproj"
COPY . .
WORKDIR "/src/MinhaBiblioteca.Web"
RUN dotnet build "MinhaBiblioteca.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinhaBiblioteca.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinhaBiblioteca.Web.dll"]