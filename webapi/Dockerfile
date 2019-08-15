


FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app


FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src

COPY ["webapi/webapi.csproj","myapi/"]
RUN dotnet restore "webapi/webapi.csproj"
COPY . .

WORKDIR "src/webapi/"
RUN dotnet build "webapi.csproj"

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webapi.dll"]