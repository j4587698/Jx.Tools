#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jx.Tools/Jx.Tools.csproj", "Jx.Tools/"]
RUN dotnet restore "Jx.Tools/Jx.Tools.csproj"
COPY . .
WORKDIR "/src/Jx.Tools"
RUN dotnet build "Jx.Tools.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jx.Tools.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jx.Tools.dll"]