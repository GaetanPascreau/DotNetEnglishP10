#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["MediscreenWebUI/MediscreenWebUI.csproj", "MediscreenWebUI/"]
#RUN dotnet restore "MediscreenWebUI/MediscreenWebUI.csproj"
#COPY . .
#WORKDIR "/src/MediscreenWebUI"
#RUN dotnet build "MediscreenWebUI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MediscreenWebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MediscreenWebUI.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MediscreenWebUI.csproj", "./"]
RUN dotnet restore "MediscreenWebUI.csproj"
COPY . .
RUN dotnet build "MediscreenWebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediscreenWebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediscreenWebUI.dll"]