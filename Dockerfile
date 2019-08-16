FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
FROM node:7-alpine

COPY ./webapi/bin/Debug/netcoreapp2.2/publish .
ENTRYPOINT ["dotnet", "webapi.dll"]
