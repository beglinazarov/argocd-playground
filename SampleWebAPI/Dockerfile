# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
LABEL stage=builder
WORKDIR /source
# copy csproj and restore as distinct layers
COPY . .
# Dockerfile and deployment yaml is copied in jenkins
RUN dotnet restore 
RUN dotnet publish -c release -o /app --no-restore


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "SampleWebAPI.dll", "--environment=Development"]
EXPOSE 80
