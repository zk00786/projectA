#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BarberShop.Api/BarberShop.Api.csproj", "BarberShop.Api/"]
COPY ["BarberShop.Application/BarberShop.Application.csproj", "BarberShop.Application/"]
COPY ["BarberShop.Domain/BarberShop.Domain.csproj", "BarberShop.Domain/"]
COPY ["BarberShop.Infrastructure/BarberShop.Infrastructure.csproj", "BarberShop.Infrastructure/"]
RUN dotnet restore "BarberShop.Api/BarberShop.Api.csproj"
COPY . .
WORKDIR "/src/BarberShop.Api"
RUN dotnet build "BarberShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BarberShop.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BarberShop.Api.dll"]