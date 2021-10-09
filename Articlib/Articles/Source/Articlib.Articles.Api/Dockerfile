FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY Directory.Build.props .
COPY Services/ Services/

COPY Articles/Source/ Articles/Source/

COPY Common-DotNet/LittleByte.Core/ Common-DotNet/LittleByte.Core/
COPY Common-DotNet/LittleByte.Domain/ Common-DotNet/LittleByte.Domain/
COPY Common-DotNet/LittleByte.Logging/ Common-DotNet/LittleByte.Logging/
COPY Common-DotNet/LittleByte.Validation/ Common-DotNet/LittleByte.Validation/

WORKDIR ./Articles/Source/Articlib.Articles.Api

RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Articles.Api.dll"]
