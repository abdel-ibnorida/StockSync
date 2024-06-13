# Usa l'immagine base ufficiale di ASP.NET Core per .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usa l'immagine base ufficiale del SDK .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StockSync/StockSync.csproj", "./"]
RUN dotnet restore "StockSync.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "StockSync/StockSync.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockSync/StockSync.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockSync.dll"]
