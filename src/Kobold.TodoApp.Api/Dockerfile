#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Kobold.TodoApp.Api/Kobold.TodoApp.Api.csproj", "src/Kobold.TodoApp.Api/"]
RUN dotnet restore "src/Kobold.TodoApp.Api/Kobold.TodoApp.Api.csproj"
COPY . .
WORKDIR "/src/src/Kobold.TodoApp.Api"
RUN dotnet build "Kobold.TodoApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kobold.TodoApp.Api.csproj" -c Release -o /app/publish

FROM publish AS ef
RUN dotnet new tool-manifest
RUN dotnet tool install dotnet-ef
#RUN dotnet ef migrations add InitialMigration
RUN dotnet ef database update # FIX: Mesmo fazendo seed, dá erro `Table 'todos.Todos' doesn't exist`

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kobold.TodoApp.Api.dll"]