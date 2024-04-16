#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV LANG C.UTF-8
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServerAuth/IdentityServerAspNetIdentity.csproj", "ServerAuth/"]
RUN dotnet restore "ServerAuth/IdentityServerAspNetIdentity.csproj"
COPY . .
WORKDIR "/src/ServerAuth"
RUN dotnet build "IdentityServerAspNetIdentity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServerAspNetIdentity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServerAspNetIdentity.dll"]