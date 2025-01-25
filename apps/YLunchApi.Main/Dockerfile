FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YLunchApi.Main/YLunchApi.Main.csproj", "YLunchApi.Main/"]
RUN dotnet restore "YLunchApi.Main/YLunchApi.Main.csproj"
COPY . .
WORKDIR "/src/YLunchApi.Main"
RUN dotnet build "YLunchApi.Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YLunchApi.Main.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YLunchApi.Main.dll"]
