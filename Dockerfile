# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src 
COPY "src/Kobold.TodoApp.Api/Kobold.TodoApp.Api.csproj" .
RUN dotnet restore
COPY src/Kobold.TodoApp.Api/* .
RUN dotnet publish -c Release -o /publish 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80

RUN dotnet new tool-manifest
RUN dotnet tool install dotnet-ef
RUN dotnet ef database update

ENTRYPOINT ["dotnet", "Kobold.TodoApp.Api.dll"]
