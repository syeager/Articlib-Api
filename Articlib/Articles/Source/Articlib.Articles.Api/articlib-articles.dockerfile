FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS source
WORKDIR /src
COPY Directory.Build.props .
COPY Articles/Source/ Articles/Source/
COPY Common-DotNet/ Common-DotNet/
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
