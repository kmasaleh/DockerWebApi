# Build Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app

FROM  mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . . 
RUN dotnet restore "./DockerWebApi/DockerWebApi.csproj" --disable-parallel
RUN dotnet publish  "./DockerWebApi/DockerWebApi.csproj" -c release -o /app --no-restore
FROM base AS final
COPY --from=build /app ./
EXPOSE 5001

#VOLUME ["/app/logs"]

ENTRYPOINT ["dotnet","DockerWebApi.dll"]
# Serve Stage 




#to open shell and inspect what happened inside the container
#ENTRYPOINT []
#docker run --name dockapi -it dockapi bash 

#docker run --name dockapi -it  -p 5001:5001 dockapi dotnet DockerWebApi.dll --urls="http://0.0.0.0:5001"