FROM microsoft/dotnet:sdk AS build-env
WORKDIR /WebApi

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /WebApi
COPY --from=build-env /WebApi/out .
ENTRYPOINT ["dotnet", "WebApi.dll"]