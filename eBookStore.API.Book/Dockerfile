#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["eBookStore.API.Book/eBookStore.API.Book.csproj", "eBookStore.API.Book/"]
RUN dotnet restore "eBookStore.API.Book/eBookStore.API.Book.csproj"
COPY . .
WORKDIR "/src/eBookStore.API.Book"
RUN dotnet build "eBookStore.API.Book.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eBookStore.API.Book.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eBookStore.API.Book.dll", "pama1"]