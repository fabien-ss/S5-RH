FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["S5-RH.csproj", "./"]
RUN dotnet restore "S5-RH.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "S5-RH.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S5-RH.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S5-RH.dll"]
