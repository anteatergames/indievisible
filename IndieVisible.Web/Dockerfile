#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IndieVisible.Web/IndieVisible.Web.csproj", "IndieVisible.Web/"]
COPY ["IndieVisible.Application/IndieVisible.Application.csproj", "IndieVisible.Application/"]
COPY ["IndieVisible.Domain/IndieVisible.Domain.csproj", "IndieVisible.Domain/"]
COPY ["IndieVisible.Domain.Core/IndieVisible.Domain.Core.csproj", "IndieVisible.Domain.Core/"]
COPY ["IndieVisible.Infra.Data/IndieVisible.Infra.Data.csproj", "IndieVisible.Infra.Data/"]
COPY ["IndieVisible.Infra.CrossCutting.Identity/IndieVisible.Infra.CrossCutting.Identity.csproj", "IndieVisible.Infra.CrossCutting.Identity/"]
COPY ["IndieVisible.Infra.CrossCutting.Abstractions/IndieVisible.Infra.CrossCutting.Abstractions.csproj", "IndieVisible.Infra.CrossCutting.Abstractions/"]
COPY ["IndieVisible.Infra.Data.MongoDb/IndieVisible.Infra.Data.MongoDb.csproj", "IndieVisible.Infra.Data.MongoDb/"]
COPY ["IndieVisible.Infra.CrossCutting.IoC/IndieVisible.Infra.CrossCutting.IoC.csproj", "IndieVisible.Infra.CrossCutting.IoC/"]
COPY ["IndieVisible.Infra.CrossCutting.Notifications/IndieVisible.Infra.CrossCutting.Notifications.csproj", "IndieVisible.Infra.CrossCutting.Notifications/"]
COPY ["IndieVisible.Infra.Data.Cache/IndieVisible.Infra.Data.Cache.csproj", "IndieVisible.Infra.Data.Cache/"]
RUN dotnet restore "IndieVisible.Web/IndieVisible.Web.csproj"
COPY . .
WORKDIR "/src/IndieVisible.Web"
RUN dotnet build "IndieVisible.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IndieVisible.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IndieVisible.Web.dll"]
