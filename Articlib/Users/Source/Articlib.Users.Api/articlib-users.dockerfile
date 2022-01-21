FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS source
WORKDIR /src
COPY Directory.Build.props .
COPY Users/Source/ Users/Source/
COPY Common-DotNet/ Common-DotNet/
WORKDIR /src/Users/Source/Articlib.Users.Api
RUN dotnet restore

FROM source AS test
WORKDIR /src
COPY Users/Test/ Users/Test/
WORKDIR /src/Users/Test/Articlib.Users.Domain.Test
RUN dotnet test -c Debug -o /app/test

FROM source AS publish
WORKDIR /src/Users/Source/Articlib.Users.Api
RUN dotnet publish -c Debug -o /app/publish

FROM source AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Users.Api.dll"]
