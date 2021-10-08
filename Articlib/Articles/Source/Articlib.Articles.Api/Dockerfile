#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Articlib/Directory.Build.props", "."]
COPY ["Articlib/Articles/Source/Articlib.Articles.Api/Articlib.Articles.Api.csproj", "Articlib/Articles/Source/Articlib.Articles.Api/"]
COPY ["Articlib/Articles/Source/Articlib.Articles.Domain/Articlib.Articles.Domain.csproj", "Articlib/Articles/Source/Articlib.Articles.Domain/"]
COPY ["Articlib/Articles/Source/Articlib.Articles.Infra/Articlib.Articles.Infra.csproj", "Articlib/Articles/Source/Articlib.Articles.Infra/"]

COPY ["Common-DotNet/LittleByte.Core/LittleByte.Core.csproj", "Common-DotNet/LittleByte.Core/"]
COPY ["Common-DotNet/LittleByte.Domain/LittleByte.Domain.csproj", "Common-DotNet/LittleByte.Domain/"]
COPY ["Common-DotNet/LittleByte.Logging/LittleByte.Logging.csproj", "Common-DotNet/LittleByte.Logging/"]
COPY ["Common-DotNet/LittleByte.Validation/LittleByte.Validation.csproj", "Common-DotNet/LittleByte.Validation/"]

WORKDIR "/src/Articlib/Articles/Source/Articlib.Articles.Api"

RUN dotnet restore "Articlib/Articles/Source/Articlib.Articles.Api/Articlib.Articles.Api.csproj"
COPY . .

RUN dotnet build "Articlib.Articles.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Articlib.Articles.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Articles.Api.dll"]
