#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS source
WORKDIR /src
COPY Directory.Build.props .
COPY Services/ Services/
COPY Articles/Source/ Articles/Source/
COPY Common-DotNet/LittleByte.Core/ Common-DotNet/LittleByte.Core/
COPY Common-DotNet/LittleByte.Domain/ Common-DotNet/LittleByte.Domain/
COPY Common-DotNet/LittleByte.Logging/ Common-DotNet/LittleByte.Logging/
COPY Common-DotNet/LittleByte.Validation/ Common-DotNet/LittleByte.Validation/
WORKDIR /src/Articles/Source/Articlib.Articles.Api
RUN dotnet restore

FROM source AS test
WORKDIR /src
COPY Articles/Test/ Articles/Test/
WORKDIR /src/Articles/Test/Articlib.Articles.Domain.Test
RUN dotnet test -c Debug -o /app/test

FROM source AS publish
WORKDIR /src/Articles/Source/Articlib.Articles.Api
RUN dotnet publish -c Release -o /app/publish

FROM source AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Articles.Api.dll"]
