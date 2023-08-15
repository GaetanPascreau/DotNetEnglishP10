#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# MODIFICATIONS ON 20230815
# Use the appropriate base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MediscreenUI.csproj", "./"]
RUN dotnet restore "MediscreenUI.csproj"
COPY . .
RUN dotnet build "MediscreenUI.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "MediscreenUI.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediscreenUI.dll"]



#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["MediscreenUI/MediscreenUI.csproj", "MediscreenUI/"]
#RUN dotnet restore "MediscreenUI/MediscreenUI.csproj"
#COPY . .
#WORKDIR "/src/MediscreenUI"
#RUN dotnet build "MediscreenUI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MediscreenUI.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MediscreenUI.dll"]
#
#
#
#
#from mcr.microsoft.com/dotnet/sdk:7.0
#workdir /app
#env aspnetcore_urls http://+:80
#expose 80
#copy . .
#run dotnet restore
#entrypoint ["dotnet", "run"]