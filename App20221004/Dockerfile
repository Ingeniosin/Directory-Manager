FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["App20221004/App20221004.csproj", "App20221004/"]
RUN dotnet restore "App20221004/App20221004.csproj"
COPY . .
WORKDIR "/src/App20221004"
RUN dotnet build "App20221004.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App20221004.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App20221004.dll"]
