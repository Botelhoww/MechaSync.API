FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MechaSync.API/MechaSync.API.csproj", "MechaSync.API/"]
RUN dotnet restore "MechaSync.API/MechaSync.API.csproj"
COPY . .
WORKDIR "/src/MechaSync.API"
RUN dotnet build "MechaSync.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MechaSync.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MechaSync.API.dll"]
