#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Client/ElectricWebApp/ElectricWebApp.csproj", "src/Client/ElectricWebApp/"]
COPY ["src/Share/CommonShare/CommonShare.csproj", "src/Share/CommonShare/"]
RUN dotnet restore "src/Client/ElectricWebApp/ElectricWebApp.csproj"
COPY . .
WORKDIR "/src/src/Client/ElectricWebApp"
RUN dotnet build "ElectricWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElectricWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectricWebApp.dll"]