#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TWT.API/TWT.API.csproj", "src/TWT.API/"]
COPY ["src/TWT.Core/TWT.Core.csproj", "src/TWT.Core/"]
COPY ["src/TWT.Data/TWT.Data.csproj", "src/TWT.Data/"]
RUN dotnet restore "src/TWT.API/TWT.API.csproj"
COPY . .
WORKDIR "/src/src/TWT.API"
RUN dotnet build "TWT.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TWT.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TWT.API.dll"]