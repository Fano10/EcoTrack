# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS Build
WORKDIR /source
COPY . .
RUN dotnet restore "./EcoTrack.Authentification.API/EcoTrack.Authentification.API.csproj" --disable-parallel
# Installer dotnet-ef globalement
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet publish "./EcoTrack.Authentification.API/EcoTrack.Authentification.API.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=Build /app ./

EXPOSE 5005

# Appliquer les migrations au démarrage
ENTRYPOINT ["sh", "-c", "dotnet ef database update --project ./EcoTrack.Authentification.API/EcoTrack.Authentification.API.csproj && dotnet EcoTrack.Authentification.API.dll"]
