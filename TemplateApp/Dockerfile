FROM mcr.microsoft.com/dotnet/aspnet:8.0.3-jammy-chiseled-arm64v8 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0.203-alpine3.19-amd64 AS build
WORKDIR /src
COPY TemplateApp.csproj .
RUN dotnet restore "TemplateApp.csproj"
COPY . .
RUN dotnet build "TemplateApp.csproj" -r linux-arm64 -c Release -o /app/build --self-contained

FROM build AS publish
RUN dotnet publish "TemplateApp.csproj" -r linux-arm64 -c Release -o /app/publish --self-contained

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemplateApp.dll"]
