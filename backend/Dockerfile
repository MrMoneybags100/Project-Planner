# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["projectplanner.Api/projectplanner.Api.csproj", "projectplanner.Api/"]
RUN dotnet restore "projectplanner.Api/projectplanner.Api.csproj"
COPY . .
WORKDIR "/src/projectplanner.Api"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "projectplanner.Api.dll"]
