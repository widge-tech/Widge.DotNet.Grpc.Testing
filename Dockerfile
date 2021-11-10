FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./app /app
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "Widge.DotNet.Grpc.Testing.dll"]
