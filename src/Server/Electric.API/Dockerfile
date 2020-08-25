#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Server/Electric.API/Electric.API.csproj", "src/Server/Electric.API/"]
COPY ["src/Server/Electric.Application/Electric.Application.csproj", "src/Server/Electric.Application/"]
COPY ["src/Server/Electric.Core/Electric.Core.csproj", "src/Server/Electric.Core/"]
COPY ["src/Share/CommonShare/CommonShare.csproj", "src/Share/CommonShare/"]
COPY ["src/Server/Electric.Infrastructure/Electric.Infrastructure.csproj", "src/Server/Electric.Infrastructure/"]
RUN dotnet restore "src/Server/Electric.API/Electric.API.csproj"
COPY . .
WORKDIR "/src/src/Server/Electric.API"
RUN dotnet build "Electric.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Electric.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Electric.API.dll"]