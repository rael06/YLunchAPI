# Published with the .NET 6 SDK, runs on the chiseled ASP.NET runtime: no shell, non-root user 1654.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish apps/YLunchApi.Main/YLunchApi.Main.csproj -c Release -o /out -p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy-chiseled
WORKDIR /app
COPY --from=build /out .
# Host and Port come from the environment (config/deploy.yml).
EXPOSE 5258
ENTRYPOINT ["dotnet", "YLunchApi.Main.dll"]
