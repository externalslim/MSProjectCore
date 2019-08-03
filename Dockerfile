FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MS.API/MS.API.csproj", "MS.API/"]
COPY ["MS.Application/MS.Application.csproj", "MS.Application/"]
COPY ["MS.Core/MS.Core.csproj", "MS.Core/"]
COPY ["MS.Helper/MS.Helper.csproj", "MS.Helper/"]
COPY ["MS.Data/MS.Data.csproj", "MS.Data/"]
RUN dotnet restore "MS.API/MS.API.csproj"
COPY . .
WORKDIR "/src/MS.API"
RUN dotnet build "MS.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MS.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MS.API.dll"]