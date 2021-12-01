FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Notifications/Source/Articlib.Notifications.Api/Articlib.Notifications.Api.csproj", "Notifications/Source/Articlib.Notifications.Api/"]
RUN dotnet restore "Notifications/Source/Articlib.Notifications.Api/Articlib.Notifications.Api.csproj"
COPY . .
WORKDIR "/src/Notifications/Source/Articlib.Notifications.Api"
RUN dotnet build "Articlib.Notifications.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Articlib.Notifications.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Notifications.Api.dll"]