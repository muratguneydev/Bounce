FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY Bounce.sln ./
COPY src/Bounce/Bounce.csproj src/Bounce/
COPY tests/Bounce.Testing/Bounce.Testing.csproj tests/Bounce.Testing/
COPY tests/Bounce.UnitTests/Bounce.UnitTests.csproj tests/Bounce.UnitTests/
COPY tests/Bounce.IntegrationTests/Bounce.IntegrationTests.csproj tests/Bounce.IntegrationTests/
RUN dotnet restore

COPY . .
RUN dotnet publish src/Bounce/Bounce.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/runtime:10.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Bounce.dll"]
