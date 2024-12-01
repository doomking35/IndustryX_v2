FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5215

ENV ASPNETCORE_URLS=http://+:5215

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["IndustryX.LogisticsService/IndustryX.LogisticsService.csproj", "IndustryX.LogisticsService/"]
RUN dotnet restore "IndustryX.LogisticsService/IndustryX.LogisticsService.csproj"
COPY . .
WORKDIR "/src/IndustryX.LogisticsService"
RUN dotnet build "IndustryX.LogisticsService.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "IndustryX.LogisticsService.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IndustryX.LogisticsService.dll"]
