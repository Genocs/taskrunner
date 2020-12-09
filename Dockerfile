FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src/Genocs.TaskRunner.Service

COPY /src/Genocs.TaskRunner.Service/Genocs.TaskRunner.Service.csproj .
RUN dotnet restore Genocs.TaskRunner.Service.csproj

COPY /src/Genocs.TaskRunner.Service/. .
RUN dotnet build Genocs.TaskRunner.Service.csproj -c release -o /app

FROM build AS testrunner
WORKDIR /src/tests

COPY /src/Genocs.TaskRunner.Service.Tests/*.csproj .
RUN dotnet restore Genocs.TaskRunner.Service.Tests.csproj

COPY /src/Genocs.TaskRunner.Service.Tests/. .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM build AS publish
RUN dotnet publish Genocs.TaskRunner.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_ENVIRONMENT Docker
ENTRYPOINT ["dotnet", "Genocs.TaskRunner.Service.dll"]
