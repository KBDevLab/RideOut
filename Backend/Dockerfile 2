# Use the official .NET 9 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the application code and build
COPY . .
RUN dotnet publish -c Release -o /out

# Use the official .NET 9 runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

# Expose the port your backend listens on
EXPOSE 5000

# Set the entry point
ENTRYPOINT ["dotnet", "RideOut.dll"]
