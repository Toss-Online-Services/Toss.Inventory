#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Web/Web.csproj", "src/Web/"]
COPY ["src/Application/Application.Product/Application.Product.csproj", "src/Application/Application.Product/"]
COPY ["src/Domain/Domain.Repositories/Domain.Repositories.csproj", "src/Domain/Domain.Repositories/"]
COPY ["src/Domain/Domain.Entities/Domain.Entities.csproj", "src/Domain/Domain.Entities/"]
COPY ["src/Domain/Domain.Common/Domain.Common.csproj", "src/Domain/Domain.Common/"]
COPY ["src/Domain/Domain.Enums/Domain.Enums.csproj", "src/Domain/Domain.Enums/"]
COPY ["src/Domain/Domain.SeedWork/Domain.SeedWork.csproj", "src/Domain/Domain.SeedWork/"]
COPY ["src/Domain/Domain.ValueObjects/Domain.ValueObjects.csproj", "src/Domain/Domain.ValueObjects/"]
COPY ["src/Domain/Domain.Exceptions/Domain.Exceptions.csproj", "src/Domain/Domain.Exceptions/"]
COPY ["src/Application/Application.Common/Application.Common.csproj", "src/Application/Application.Common/"]
COPY ["src/Infrastructure/Infrastructure.Repositories/Infrastructure.Repositories.csproj", "src/Infrastructure/Infrastructure.Repositories/"]
COPY ["src/Application/Application.TodoItems/Application.Todo.csproj", "src/Application/Application.TodoItems/"]
COPY ["src/Domain/Domain.Constants/Domain.Constants.csproj", "src/Domain/Domain.Constants/"]
COPY ["src/Infrastructure/Infrastructure.Data/Infrastructure.Data.csproj", "src/Infrastructure/Infrastructure.Data/"]
COPY ["src/Infrastructure/Infrastructure.Identity/Infrastructure.Identity.csproj", "src/Infrastructure/Infrastructure.Identity/"]
RUN dotnet restore "./src/Web/Web.csproj"
COPY . .
WORKDIR "/src/src/Web"
RUN dotnet build "./Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Toss.Inventory.Catalog.Web.dll"]