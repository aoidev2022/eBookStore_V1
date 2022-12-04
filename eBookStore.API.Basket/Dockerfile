#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["eBookStore.API.Basket/eBookStore.API.Basket.csproj", "eBookStore.API.Basket/"]
RUN dotnet restore "eBookStore.API.Basket/eBookStore.API.Basket.csproj"
COPY . .
WORKDIR "/src/eBookStore.API.Basket"
RUN dotnet build "eBookStore.API.Basket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eBookStore.API.Basket.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eBookStore.API.Basket.dll"]