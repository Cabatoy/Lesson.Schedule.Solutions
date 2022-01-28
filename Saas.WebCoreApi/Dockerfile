#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Saas.WebCoreApi/Saas.WebCoreApi.csproj", "Saas.WebCoreApi/"]
COPY ["Saas.Business/Saas.Business.csproj", "Saas.Business/"]
COPY ["Saas.Core/Saas.Core.csproj", "Saas.Core/"]
COPY ["Saas.Entities/Saas.Entities.csproj", "Saas.Entities/"]
COPY ["Saas.DataAccess/Saas.DataAccess.csproj", "Saas.DataAccess/"]
RUN dotnet restore "Saas.WebCoreApi/Saas.WebCoreApi.csproj"
COPY . .
WORKDIR "/src/Saas.WebCoreApi"
RUN dotnet build "Saas.WebCoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Saas.WebCoreApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Saas.WebCoreApi.dll"]