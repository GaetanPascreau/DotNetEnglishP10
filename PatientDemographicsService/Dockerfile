#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /PatientDemographicsService
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PatientDemographicsService.csproj", "./"]
RUN dotnet restore "PatientDemographicsService.csproj"
COPY . .
RUN dotnet build "PatientDemographicsService.csproj" -c Release -o /PatientDemographicsService

FROM build AS publish
RUN dotnet publish "PatientDemographicsService.csproj" -c Release -o /PatientDemographicsService

FROM base AS final
WORKDIR /PatientDemographicsService
COPY --from=publish /PatientDemographicsService .
ENTRYPOINT ["dotnet", "PatientDemographicsService.dll"]