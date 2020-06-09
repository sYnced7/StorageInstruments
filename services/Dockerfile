FROM microsoft/dotnet:2.2.102-sdk-stretch AS build-env

WORKDIR /StorageInstruments

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2.1-aspnetcore-runtime-stretch-slim

WORKDIR /StorageInstruments

COPY --from=build-env /StorageInstruments/out .



# ENTRYPOINT ["dotnet", "TogglerApi.dll"]