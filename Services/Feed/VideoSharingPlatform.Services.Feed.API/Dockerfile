FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Feed/VideoSharingPlatform.Services.Feed.API/VideoSharingPlatform.Services.Feed.API.csproj", "Services/Feed/VideoSharingPlatform.Services.Feed.API/"]
RUN dotnet restore "Services/Feed/VideoSharingPlatform.Services.Feed.API/VideoSharingPlatform.Services.Feed.API.csproj"
COPY . .
WORKDIR "/src/Services/Feed/VideoSharingPlatform.Services.Feed.API"
RUN dotnet build "VideoSharingPlatform.Services.Feed.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideoSharingPlatform.Services.Feed.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoSharingPlatform.Services.Feed.API.dll"]