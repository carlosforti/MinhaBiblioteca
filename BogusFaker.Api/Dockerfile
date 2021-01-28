#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BogusFaker.Api/BogusFaker.Api.csproj", "BogusFaker.Api/"]
RUN dotnet restore "BogusFaker.Api/BogusFaker.Api.csproj"
COPY . .
WORKDIR "/src/BogusFaker.Api"
RUN dotnet build "BogusFaker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BogusFaker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BogusFaker.Api.dll"]