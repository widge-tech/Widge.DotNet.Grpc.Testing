FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./bin/Release/net6.0/publish /app
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "Widge.DotNet.Grpc.Testing.dll"]
