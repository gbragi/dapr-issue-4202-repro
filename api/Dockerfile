FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY api/. ./api/
COPY protos/. ./protos/
WORKDIR /source/api
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "api.dll"]
