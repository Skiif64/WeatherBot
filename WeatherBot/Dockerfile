#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 4000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WeatherBot/WeatherBot.csproj", "WeatherBot/"]
COPY ["WeatherBot.Integration.Telegram/WeatherBot.Integration.Telegram.csproj", "WeatherBot.Integration.Telegram/"]
COPY ["WeatherBot.Domain/WeatherBot.Domain.csproj", "WeatherBot.Domain/"]
COPY ["WeatherBot.Integration.OpenWeatherMap/WeatherBot.Integration.OpenWeatherMap.csproj", "WeatherBot.Integration.OpenWeatherMap/"]
RUN dotnet restore "WeatherBot/WeatherBot.csproj"
COPY . .
WORKDIR "/src/WeatherBot"
RUN dotnet build "WeatherBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherBot.dll"]