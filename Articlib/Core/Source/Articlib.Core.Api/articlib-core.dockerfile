FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS source
WORKDIR /src
COPY Directory.Build.props .
COPY Core/Source/ Core/Source/
COPY Common-DotNet/ Common-DotNet/
WORKDIR /src/Core/Source/Articlib.Core.Api
RUN dotnet restore

FROM source AS test
WORKDIR /src
COPY Core/Test/ Core/Test/
WORKDIR /src/Core/Test/Articlib.Core.Domain.Test
RUN dotnet test -c Debug -o /app/test

FROM source AS publish
WORKDIR /src/Core/Source/Articlib.Core.Api
RUN dotnet publish -c Release -o /app/publish

FROM source AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Core.Api.dll"]
