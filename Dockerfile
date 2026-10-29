# 1. Compiler et préparer l'application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY SupportHub.csproj .
RUN dotnet restore SupportHub.csproj

COPY . .
RUN dotnet publish SupportHub.csproj -c Release -o /app/publish --no-restore

# 2. Préparer l'image d'exécution
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "SupportHub.dll"]