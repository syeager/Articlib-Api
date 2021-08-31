FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "Articlib/Articles/Source/Articlib.Articles.Api/Articlib.Articles.Api.csproj"
#COPY . .
WORKDIR "/src/Articlib/Articles/Source/Articlib.Articles.Api"
RUN dotnet build "Articlib.Articles.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Articlib.Articles.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articlib.Articles.Api.dll"]