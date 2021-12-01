#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Articles/Source/Articlib.Users.Api/Articlib.Users.Api.csproj", "Articles/Source/Articlib.Users.Api/"]
RUN dotnet restore "Articles/Source/Articlib.Users.Api/Articlib.Users.Api.csproj"
COPY . .
WORKDIR "/src/Articles/Source/Articlib.Users.Api"
RUN dotnet build "Articlib.Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Articlib.Users.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Users.Api.dll"]