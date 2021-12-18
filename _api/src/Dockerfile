FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . ./

RUN dotnet publish RtaAssignment.API -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .

#ENTRYPOINT ["dotnet", "RtaAssignment.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RtaAssignment.API.dll