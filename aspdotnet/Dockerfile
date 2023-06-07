FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /code

COPY src/Workshop.Notes.WebApi.csproj src/Workshop.Notes.WebApi.csproj
WORKDIR /code/src
RUN dotnet restore

COPY ./src .
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "Workshop.Notes.WebApi.dll"]
