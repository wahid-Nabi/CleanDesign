#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CleanDesign.Presentation/CleanDesign.Presentation.csproj", "src/CleanDesign.Presentation/"]
COPY ["src/CleanDesign.Application/CleanDesign.Application.csproj", "src/CleanDesign.Application/"]
COPY ["src/CleanDesign.Domain/CleanDesign.Domain.csproj", "src/CleanDesign.Domain/"]
COPY ["src/CleanDesign.SharedKernel/CleanDesign.SharedKernel.csproj", "src/CleanDesign.SharedKernel/"]
COPY ["src/CleanDesign.Infrastructure/CleanDesign.Infrastructure.csproj", "src/CleanDesign.Infrastructure/"]
RUN dotnet restore "./src/CleanDesign.Presentation/CleanDesign.Presentation.csproj"
COPY . .
WORKDIR "/src/src/CleanDesign.Presentation"
RUN dotnet build "./CleanDesign.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanDesign.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanDesign.Presentation.dll"]