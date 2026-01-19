# Consultez https://aka.ms/customizecontainer pour savoir comment personnaliser votre conteneur de débogage et comment Visual Studio utilise ce Dockerfile pour générer vos images afin d’accélérer le débogage.

# Cet index est utilisé lors de l’exécution à partir de VS en mode rapide (par défaut pour la configuration de débogage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Cette phase est utilisée pour générer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["ShopTruck.Product.Api/ShopTruck.Product.Api.csproj", "ShopTruck.Product.Api/"]
COPY ["ShopTruck.Product.Application/ShopTruck.Product.Application.csproj", "ShopTruck.Product.Application/"]
COPY ["Infrastructure.Cache/ShopTruck.Infrastructure.Cache.csproj", "Infrastructure.Cache/"]
COPY ["ShopTruck.Product.Domain/ShopTruck.Product.Domain.csproj", "ShopTruck.Product.Domain/"]
COPY ["ShopTruck.Product.Infrastructure/ShopTruck.Product.Infrastructure.csproj", "ShopTruck.Product.Infrastructure/"]
RUN dotnet restore "./ShopTruck.Product.Api/ShopTruck.Product.Api.csproj"
COPY . .
WORKDIR "/src/ShopTruck.Product.Api"
RUN dotnet build "./ShopTruck.Product.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Cette étape permet de publier le projet de service à copier dans la phase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShopTruck.Product.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilisée en production ou lors de l’exécution à partir de VS en mode normal (par défaut quand la configuration de débogage n’est pas utilisée)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopTruck.Product.Api.dll"]