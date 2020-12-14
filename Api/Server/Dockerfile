#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Api/Server/NotatnikMechanika.Server.csproj", "Api/Server/"]
COPY ["Clients/Client/NotatnikMechanika.Client.csproj", "Clients/Client/"]
COPY ["Api/Shared/NotatnikMechanika.Shared.csproj", "Api/Shared/"]
COPY ["MVVMPackage/Blazor/MVVMPackage.Blazor.csproj", "MVVMPackage/Blazor/"]
COPY ["MVVMPackage/Core/MvvmPackage.Core.csproj", "MVVMPackage/Core/"]
COPY ["Clients/Core/NotatnikMechanika.Core.csproj", "Clients/Core/"]
COPY ["Api/Service/NotatnikMechanika.Service.csproj", "Api/Service/"]
COPY ["Api/Repository/NotatnikMechanika.Repository.csproj", "Api/Repository/"]
COPY ["Api/Data/NotatnikMechanika.Data.csproj", "Api/Data/"]
RUN dotnet restore "Api/Server/NotatnikMechanika.Server.csproj"
COPY . .
WORKDIR "/src/Api/Server"
RUN dotnet build "NotatnikMechanika.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotatnikMechanika.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotatnikMechanika.Server.dll"]