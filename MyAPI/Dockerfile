
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY MyAPI.csproj MyAPI/
RUN dotnet restore "MyAPI/MyAPI.csproj"


# Copy everything else and build
COPY . MyAPI/
RUN dotnet publish -c Release -o out MyAPI/MyAPI.csproj 


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MyAPI.dll"]