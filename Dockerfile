FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base

COPY ./webapi/bin/Debug/netcoreapp2.2/publish .
//ARG APPLICATION_NAME="Default"
//ENTRYPOINT ["dotnet", "${APPLICATION_NAME}.dll"]
ENTRYPOINT ["dotnet", "webapi.dll"]
