#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NotesApi/NotesApi.csproj", "src/NotesApi/"]
RUN dotnet restore "src/NotesApi/NotesApi.csproj"
COPY . .
WORKDIR "/src/src/NotesApi"
RUN dotnet build "NotesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApi.dll"]